using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K4os.Compression.LZ4.Internal;
using static Mysqlx.Expect.Open.Types;

namespace CarRentalAdmin
{
    public partial class OrderEditForm : Form
    {
        private int orderId = 0;
        private List<dynamic> availableCars = new List<dynamic>();

        public OrderEditForm(int id = 0)
        {
            InitializeComponent();
            orderId = id;
        }
        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadAvailableCars();

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(3);

            if (orderId > 0)
            {
                LoadOrderData();
                this.Text = "Edit Order";
            }
            else
            {
                this.Text = "Add New Order";
                //alapértelmezett értékek
                cmbStatus.SelectedIndex = 0;
                cmbPaymentStatus.SelectedIndex = 0;
                cmbPaymentMethod.SelectedIndex = 0;
            }
        }

        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT user_id, user_name, user_email FROM user WHERE user_active = 1";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                cmbCustomer.DisplayMember = "Text";
                cmbCustomer.ValueMember = "Value";

                cmbCustomer.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["user_name"]} ({row["user_email"]})";
                    cmbCustomer.Items.Add(new { Text = text, Value = row["user_id"] });
                }

                if (cmbCustomer.Items.Count > 0)
                {
                    cmbCustomer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableCars()
        {
            try
            {
                // aktív autók
                string query = "SELECT car_id, car_brand, car_model, car_year, car_regnumber, " +
                               "price_per_hour, price_per_day FROM car WHERE car_active = 1";

                if (orderId <= 0)
                {
                    // csak a "most" elérhető autók, (dátum alapján)
                    query += " AND car_id NOT IN (SELECT car_id FROM orders WHERE " +
                             "rental_status IN ('pending', 'confirmed', 'extended') AND " +
                             "((start_date <= NOW() AND end_date >= NOW()) OR " +
                             "(start_date BETWEEN NOW() AND DATE_ADD(NOW(), INTERVAL 3 DAY))))";
                }

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                cmbCar.DisplayMember = "Text";
                cmbCar.ValueMember = "Value";
                availableCars.Clear();
                cmbCar.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["car_brand"]} {row["car_model"]} {row["car_year"]} ({row["car_regnumber"]})";
                    decimal hourlyRate = Convert.ToDecimal(row["price_per_hour"]);
                    decimal dailyRate = Convert.ToDecimal(row["price_per_day"]);

                    var carInfo = new
                    {
                        Text = text,
                        Value = row["car_id"],
                        HourlyRate = hourlyRate,
                        DailyRate = dailyRate
                    };

                    availableCars.Add(carInfo);
                    cmbCar.Items.Add(carInfo);
                }

                if (cmbCar.Items.Count > 0)
                {
                    cmbCar.SelectedIndex = 0;

                    //Egy alapértelmezett fizetési összeg az első autó alapján
                    dynamic selectedCar = cmbCar.SelectedItem;
                    TimeSpan duration = dtpEndDate.Value - dtpStartDate.Value;
                    decimal amount = CalculateAmount(selectedCar, duration);
                    numPaymentAmount.Value = amount;
                    numTaxAmount.Value = amount * 0.15m; // 15% áfa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available cars: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateAmount(dynamic car, TimeSpan duration)
        {
            int days = (int)Math.Ceiling(duration.TotalDays);
            int hours = (int)duration.TotalHours % 24;

            decimal dailyCost = car.DailyRate * days;
            decimal hourlyCost = 0;

            if (hours > 0)
            {
                // Ha az "órák" száma meghaladja a "24"-et akkor napi árat fog számolni
                hourlyCost = Math.Min(car.HourlyRate * hours, car.DailyRate);
            }

            return dailyCost + hourlyCost;
        }

        private void LoadOrderData()
        {
            try
            {
                string query = "SELECT o.*, i.payment_id, i.payment_amount, i.tax_amount, " +
                               "i.payment_method, i.invoice_address, l.pickup_location, l.dropoff_location " +
                               "FROM orders o " +
                               "LEFT JOIN invoice i ON o.orders_id = i.orders_id " +
                               "LEFT JOIN location l ON o.location_id = l.location_id " +
                               "WHERE o.orders_id = " + orderId;

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    int userId = Convert.ToInt32(row["user_id"]);
                    for (int i = 0; i < cmbCustomer.Items.Count; i++)
                    {
                        dynamic item = cmbCustomer.Items[i];
                        if (Convert.ToInt32(item.Value) == userId)
                        {
                            cmbCustomer.SelectedIndex = i;
                            break;
                        }
                    }

                    int carId = Convert.ToInt32(row["car_id"]);
                    for (int i = 0; i < cmbCar.Items.Count; i++)
                    {
                        dynamic item = cmbCar.Items[i];
                        if (Convert.ToInt32(item.Value) == carId)
                        {
                            cmbCar.SelectedIndex = i;
                            break;
                        }
                    }

                    dtpStartDate.Value = Convert.ToDateTime(row["start_date"]);
                    dtpEndDate.Value = Convert.ToDateTime(row["end_date"]);

                    txtPickupLocation.Text = row["pickup_location"].ToString();
                    txtDropoffLocation.Text = row["dropoff_location"].ToString();

                    //cmb db en to hu linq

                    //A Zip metódussal párosítja az angol és magyar elemeket
                    //Minden párosítást egy új objektumként hoz létre, amely tartalmazza az angol(en) és magyar(hu) értéket
                    //A FirstOrDefault segítségével megkeresi az első olyan párosítást, ahol az angol érték megegyezik az adatbázisból olvasott értékkel
                    //A null - conditional operátorral(?.) és a null - coalescing operátorral(??) kezeli azt az esetet, ha nem találna megfelelő értéket

                    //cmbStatus.Text = row["rental_status"].ToString();
                    cmbStatus.Text = AppResources.OrderStatusen.Zip(AppResources.OrderStatushu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["rental_status"].ToString())?.hu ?? row["rental_status"].ToString();

                    //cmbPaymentStatus.Text = row["payment_status"].ToString();
                    cmbPaymentStatus.Text = AppResources.PaymentStatusen.Zip(AppResources.PaymentStatushu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["payment_status"].ToString())?.hu ?? row["payment_status"].ToString();
                    

                    txtDiscount.Text = row["discount_code"].ToString();
                    chkExtended.Checked = Convert.ToBoolean(row["extended_rental"]);

                    if (row["payment_id"] != DBNull.Value)
                    {
                        numPaymentAmount.Value = Convert.ToDecimal(row["payment_amount"]);
                        numTaxAmount.Value = Convert.ToDecimal(row["tax_amount"]);
                        //cmbPaymentMethod.Text = row["payment_method"].ToString();
                        cmbPaymentMethod.Text = AppResources.PaymentMethoden.Zip(AppResources.PaymentMethodhu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["payment_method"].ToString())?.hu ?? row["payment_method"].ToString();
                        txtInvoiceAddress.Text = row["invoice_address"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //beviteli adat validálás
            if (cmbCustomer.SelectedIndex < 0 || cmbCar.SelectedIndex < 0 ||
                string.IsNullOrEmpty(txtPickupLocation.Text) || string.IsNullOrEmpty(txtDropoffLocation.Text) ||
                cmbStatus.SelectedIndex < 0 || cmbPaymentStatus.SelectedIndex < 0 ||
                cmbPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show(AppResources.ReqFields, AppResources.ValidationError,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show(AppResources.DateEroor, AppResources.ValidationError,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (orderId > 0)
            {
                UpdateOrder();
            }
            else
            {
                AddOrder();
            }
        }

        private void AddOrder()
        {
            try
            {
                dynamic selectedCustomer = cmbCustomer.SelectedItem;
                dynamic selectedCar = cmbCar.SelectedItem;

                int userId = Convert.ToInt32(selectedCustomer.Value);
                int carId = Convert.ToInt32(selectedCar.Value);

                // helyadat meghatározása
                int locationId = CreateOrGetLocation(txtPickupLocation.Text, txtDropoffLocation.Text);

                if (locationId <= 0)
                {
                    MessageBox.Show(AppResources.LocationError, AppResources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Rendelés hozzáadása
                string orderQuery = "INSERT INTO orders (user_id, car_id, start_date, end_date, rental_status, " +
                                   "location_id, payment_status, discount_code, extended_rental) " +
                                   "VALUES (@userId, @carId, @startDate, @endDate, @status, @locationId, " +
                                   "@paymentStatus, @discount, @extended)";

                Dictionary<string, object> orderParams = new Dictionary<string, object>
                {
                    { "@userId", userId },
                    { "@carId", carId },
                    { "@startDate", dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "@endDate", dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "@status", AppResources.OrderStatusen[cmbStatus.SelectedIndex+1] },
                    { "@locationId", locationId },
                    { "@paymentStatus", AppResources.PaymentStatusen[cmbPaymentStatus.SelectedIndex] },
                    { "@discount", txtDiscount.Text },
                    { "@extended", chkExtended.Checked ? 1 : 0 }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(orderQuery, orderParams);

                if (rowsAffected > 0)
                {
                    string idQuery = "SELECT LAST_INSERT_ID()";
                    object result = DatabaseOptimizer.ExecuteScalar(idQuery);
                    int newOrderId = Convert.ToInt32(result);

                    // számlázási adatok létrehozása
                    if (numPaymentAmount.Value > 0)
                    {
                        CreateInvoice(newOrderId);
                    }

                    MessageBox.Show("Rendelés sikeresen hozzáadva", AppResources.SuccessTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hiba a rendelés felvételekor!", AppResources.ErrorTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba rendelés feltöltésekor: " + ex.Message, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrder()
        {
            try
            {
                dynamic selectedCustomer = cmbCustomer.SelectedItem;
                dynamic selectedCar = cmbCar.SelectedItem;

                int userId = Convert.ToInt32(selectedCustomer.Value);
                int carId = Convert.ToInt32(selectedCar.Value);
                int locationId = CreateOrGetLocation(txtPickupLocation.Text, txtDropoffLocation.Text);

                if (locationId <= 0)
                {
                    MessageBox.Show("Failed to update location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // rendelés frissítése
                string orderQuery = "UPDATE orders SET user_id = @userId, car_id = @carId, " +
                                   "start_date = @startDate, end_date = @endDate, rental_status = @status, " +
                                   "location_id = @locationId, payment_status = @paymentStatus, " +
                                   "discount_code = @discount, extended_rental = @extended " +
                                   "WHERE orders_id = @orderId";

                Dictionary<string, object> orderParams = new Dictionary<string, object>
                {
                    { "@userId", userId },
                    { "@carId", carId },
                    { "@startDate", dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "@endDate", dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "@status", AppResources.OrderStatusen[cmbStatus.SelectedIndex+1] },
                    { "@locationId", locationId },
                    { "@paymentStatus", AppResources.PaymentStatusen[cmbPaymentStatus.SelectedIndex] },
                    { "@discount", txtDiscount.Text },
                    { "@extended", chkExtended.Checked ? 1 : 0 },
                    { "@orderId", orderId }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(orderQuery, orderParams);

                if (rowsAffected > 0)
                {
                    //létezik e a számla?
                    string invoiceQuery = "SELECT payment_id FROM invoice WHERE orders_id = " + orderId;
                    object invoiceResult = DatabaseOptimizer.ExecuteScalar(invoiceQuery);

                    if (invoiceResult != null && invoiceResult != DBNull.Value)
                    {
                        // létező frissítése
                        UpdateInvoice(orderId);
                    }
                    else if (numPaymentAmount.Value > 0)
                    {
                        // új felvétele
                        CreateInvoice(orderId);
                    }

                    MessageBox.Show("Order updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update order.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CreateOrGetLocation(string pickupLocation, string dropoffLocation)
        {
            try
            {
                //létezik e már?
                string checkQuery = "SELECT location_id FROM location WHERE " +
                                   "pickup_location = @pickup AND dropoff_location = @dropoff";

                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@pickup", pickupLocation },
                    { "@dropoff", dropoffLocation }
                };

                DataTable dt = DatabaseOptimizer.ExecuteParameterizedQuery(checkQuery, checkParams);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["location_id"]);
                }

                //új létrehozása
                string insertQuery = "INSERT INTO location (pickup_location, dropoff_location, longitude, latitude) " +
                                    "VALUES (@pickup, @dropoff, 0, 0)"; // alapértelmezett hosszúság és szélleségki adat 0,0

                Dictionary<string, object> insertParams = new Dictionary<string, object>
                {
                    { "@pickup", pickupLocation },
                    { "@dropoff", dropoffLocation }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(insertQuery, insertParams);

                if (rowsAffected > 0)
                {
                    //helyadat id lekérés
                    string idQuery = "SELECT LAST_INSERT_ID()";
                    object result = DatabaseOptimizer.ExecuteScalar(idQuery);
                    return Convert.ToInt32(result);
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a helyadat létrehozásakor:" + ex.Message, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void CreateInvoice(int orderId)
        {
            try
            {
                // számlázási cím a kiválasztott autó szerint!
                dynamic selectedCar = cmbCar.SelectedItem;
                int carId = Convert.ToInt32(selectedCar.Value);
                string insuranceQuery = "SELECT insurance_id FROM car WHERE car_id = " + carId;
                object insuranceResult = DatabaseOptimizer.ExecuteScalar(insuranceQuery);
                int insuranceId = Convert.ToInt32(insuranceResult);

                // számlázás létrehozása
                string invoiceQuery = "INSERT INTO invoice (orders_id, insurance_id, payment_amount, tax_amount, " +
                                     "payment_method, payment_status, payment_date, invoice_address) " +
                                     "VALUES (@orderId, @insuranceId, @amount, @tax, @method, @status, NOW(), @address)";

                Dictionary<string, object> invoiceParams = new Dictionary<string, object>
                {
                    { "@orderId", orderId },
                    { "@insuranceId", insuranceId },
                    { "@amount", numPaymentAmount.Value },
                    { "@tax", numTaxAmount.Value },
                    { "@method", AppResources.PaymentMethoden[cmbPaymentMethod.SelectedIndex] },
                    { "@status", AppResources.PaymentStatusen[cmbPaymentStatus.SelectedIndex] },
                    { "@address", txtInvoiceAddress.Text }
                };

                DatabaseOptimizer.ExecuteParameterizedNonQuery(invoiceQuery, invoiceParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating invoice: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateInvoice(int orderId)
        {
            try
            {
                // számlázási cím a kiválasztott autó szerint!
                dynamic selectedCar = cmbCar.SelectedItem;
                int carId = Convert.ToInt32(selectedCar.Value);

                string insuranceQuery = "SELECT insurance_id FROM car WHERE car_id = " + carId;
                object insuranceResult = DatabaseOptimizer.ExecuteScalar(insuranceQuery);
                int insuranceId = Convert.ToInt32(insuranceResult);

                //számlázás frissítésa
                string invoiceQuery = "UPDATE invoice SET insurance_id = @insuranceId, payment_amount = @amount, " +
                                     "tax_amount = @tax, payment_method = @method, payment_status = @status, " +
                                     "invoice_address = @address WHERE orders_id = @orderId";

                Dictionary<string, object> invoiceParams = new Dictionary<string, object>
                {
                    { "@insuranceId", insuranceId },
                    { "@amount", numPaymentAmount.Value },
                    { "@tax", numTaxAmount.Value },
                    { "@method", AppResources.PaymentMethoden[cmbPaymentMethod.SelectedIndex] },
                    { "@status", AppResources.PaymentStatusen[cmbPaymentStatus.SelectedIndex] },
                    { "@address", txtInvoiceAddress.Text },
                    { "@orderId", orderId }
                };

                DatabaseOptimizer.ExecuteParameterizedNonQuery(invoiceQuery, invoiceParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating invoice: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
