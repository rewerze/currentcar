using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class CarEditForm : Form
    {
        private int carId = 0;
        private List<string> carImagePaths = new List<string>();

        public CarEditForm(int id = 0)
        {
            InitializeComponent();
            carId = id;
        }
        private void CarEditForm_Load(object sender, EventArgs e)
        {
            // Biztosítási opciók betöltése
            LoadInsuranceOptions();
            LoadLocations();

            if (carId > 0)
            {
                // Szerkesztés mód - autó adatok betöltése
                LoadCarData();
                this.Text = AppResources.EditCar;
            }
            else
            {
                // Hozzáadás mód
                this.Text = AppResources.AddCar;
                // Alapértelmezett értékek beállítása
                numYear.Value = DateTime.Now.Year;
                cmbType.SelectedIndex = 0;
                cmbCondition.SelectedIndex = 0;
                cmbFuelType.SelectedIndex = 0;
                cmbTransmission.SelectedIndex = 0;
                cmbLocation.SelectedIndex = 0;
                btnRemoveImage.Visible = false;
                lstImages.Visible = false;
                picCarImage.Visible = false;
                lblImages.Visible = false;
                chkVerified.Checked = false;
                chkRented.Checked = false;
            }
        }
        private void LoadLocations()
        {
            try
            {
                string query = "SELECT location FROM location";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                cmbLocation.DisplayMember = "Text";
                cmbLocation.ValueMember = "Value";

                cmbLocation.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbLocation.Items.Add(row["location"]);
                }

                if (cmbLocation.Items.Count > 0)
                {
                    cmbLocation.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading locations: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadInsuranceOptions()
        {
            try
            {
                string query = "SELECT insurance_id, insurance_provider, insurance_fee FROM insurance";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                cmbInsurance.DisplayMember = "Text";
                cmbInsurance.ValueMember = "Value";

                cmbInsurance.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["insurance_provider"]} (${row["insurance_fee"]})";
                    cmbInsurance.Items.Add(new { Text = text, Value = row["insurance_id"] });
                }

                if (cmbInsurance.Items.Count > 0)
                {
                    cmbInsurance.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a biztosítás betölsésével" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarData()
        {
            try
            {
                string query = "SELECT c.*, l.location FROM car c " +
                               "LEFT JOIN location l ON c.location_id = l.location_id " +
                               "WHERE c.car_id = " + carId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtBrand.Text = row["car_brand"].ToString();
                    txtModel.Text = row["car_model"].ToString();
                    numYear.Value = Convert.ToDecimal(row["car_year"]);
                    cmbType.Text = AppResources.AllTypeEn.Zip(AppResources.AllType, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["car_type"].ToString())?.hu ?? row["car_type"].ToString();
                    cmbCondition.Text = AppResources.AllConditionEn.Zip(AppResources.AllCondition, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["car_condition"].ToString())?.hu ?? row["car_condition"].ToString();
                    numHourlyRate.Value = Convert.ToDecimal(row["price_per_hour"]);
                    numDailyRate.Value = Convert.ToDecimal(row["price_per_day"]);
                    numBasePrice.Value = Convert.ToDecimal(row["car_price"]);
                    txtRegNumber.Text = row["car_regnumber"].ToString();
                    numSeats.Value = Convert.ToDecimal(row["seats"]);
                    numDoors.Value = Convert.ToDecimal(row["number_of_doors"]);
                    numMileage.Value = Convert.ToDecimal(row["mileage"]);
                    cmbFuelType.Text = AppResources.Fuelen.Zip(AppResources.Fuelhu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["fuel_type"].ToString())?.hu ?? row["fuel_type"].ToString();
                    cmbTransmission.Text = AppResources.Transmissionen.Zip(AppResources.Transmissionhu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["transmission_type"].ToString())?.hu ?? row["transmission_type"].ToString();
                    txtDescription.Text = row["car_description"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["car_active"]);
                    chkVerified.Checked = Convert.ToBoolean(row["verified"]);
                    chkRented.Checked = Convert.ToBoolean(row["rented"]);

                    // Location beállítása
                    if (row["location"] != DBNull.Value)
                    {
                        string location = row["location"].ToString();
                        for (int i = 0; i < cmbLocation.Items.Count; i++)
                        {
                            if (cmbLocation.Items[i].ToString() == location)
                            {
                                cmbLocation.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    // megfelelő biztosítást kiválasztása
                    int insuranceId = Convert.ToInt32(row["insurance_id"]);
                    for (int i = 0; i < cmbInsurance.Items.Count; i++)
                    {
                        dynamic item = cmbInsurance.Items[i];
                        if (Convert.ToInt32(item.Value) == insuranceId)
                        {
                            cmbInsurance.SelectedIndex = i;
                            break;
                        }
                    }
                    if (chkRented.Checked) 
                    {
                        chkActive.Enabled = false;
                        chkVerified.Enabled = false;
                    }
                    // képbetöltés
                    LoadCarImages();
                }
                else
                {
                    MessageBox.Show("Nincs ilyen autó!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az autó betöltésekor " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadCarImages()
        {
            try
            {
                string query = "SELECT image_id, image_url FROM car_images WHERE car_id = " + carId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                lstImages.Items.Clear();
                carImagePaths.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string imagePath = row["image_url"].ToString();
                    lstImages.Items.Add(Path.GetFileName(imagePath));
                    carImagePaths.Add(imagePath);
                }

                if (lstImages.Items.Count > 0)
                {
                    lstImages.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a képek betöltésekor!" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CreateOrGetLocation(string location)
        {
            try
            {
                string checkQuery = "SELECT location_id FROM location WHERE location = @location";
                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@location", location }
                };

                DataTable dt = DatabaseOptimizer.ExecuteParameterizedQuery(checkQuery, checkParams);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["location_id"]);
                }

                string insertQuery = "INSERT INTO location (location) VALUES (@location)";
                Dictionary<string, object> insertParams = new Dictionary<string, object>
                {
                    { "@location", location }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(insertQuery, insertParams);

                if (rowsAffected > 0)
                {
                    string idQuery = "SELECT LAST_INSERT_ID()";
                    object result = DatabaseOptimizer.ExecuteScalar(idQuery);
                    return Convert.ToInt32(result);
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a helyadat létrehozásakor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Autó kép választás";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        lstImages.Items.Add(Path.GetFileName(fileName));
                        carImagePaths.Add(fileName);
                    }

                    if (lstImages.SelectedIndex < 0 && lstImages.Items.Count > 0)
                    {
                        lstImages.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex >= 0)
            {
                int selectedIndex = lstImages.SelectedIndex;
                carImagePaths.RemoveAt(selectedIndex);
                lstImages.Items.RemoveAt(selectedIndex);
                if (lstImages.Items.Count > 0)
                {
                    lstImages.SelectedIndex = selectedIndex < lstImages.Items.Count ?
                                              selectedIndex : lstImages.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show(AppResources.SelectionRequired, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstImages.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < carImagePaths.Count)
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageData = webClient.DownloadData("http://localhost:3000/api/uploads/" + lstImages.Text);
                        using (var ms = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(ms);

                            picCarImage.Image = image;
                        }
                    } 
                }
                catch
                {
                    picCarImage.Image = null;
                }
            }
            else
            {
                picCarImage.Image = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // bevitel validálása
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtModel.Text) ||
                string.IsNullOrEmpty(txtRegNumber.Text) || cmbType.SelectedIndex < 0 ||
                cmbCondition.SelectedIndex < 0 || cmbFuelType.SelectedIndex < 0 ||
                cmbTransmission.SelectedIndex < 0 || cmbInsurance.SelectedIndex < 0 ||
                cmbLocation.SelectedIndex < 0)
            {
                MessageBox.Show($"Kérem töltse ki az összes kötelező mezőt", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // hozzáadás vagy frissítés
            if (carId > 0)
            {
                UpdateCar();
            }
            else
            {
                AddCar();
            }
        }

        private void AddCar()
        {
            try
            {
                // kiválasztott biztosítás megszerzése
                dynamic selectedInsurance = cmbInsurance.SelectedItem;
                int insuranceId = Convert.ToInt32(selectedInsurance.Value);

                // helyadat
                int locationId = CreateOrGetLocation(cmbLocation.Text);
                if (locationId <= 0)
                {
                    MessageBox.Show("Sikertelen helyadat megadása", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //
                string query = "INSERT INTO car (car_brand, car_model, car_year, car_type, car_condition, " +
                               "price_per_hour, price_per_day, car_regnumber, seats, number_of_doors, " +
                               "mileage, fuel_type, transmission_type, car_description, insurance_id, car_active, car_price, location_id, " +
                               "verified, rented) " +
                               "VALUES (@brand, @model, @year, @type, @condition, @hourRate, @dayRate, @regNumber, " +
                               "@seats, @doors, @mileage, @fuelType, @transmission, @description, @insurance, @active, @basePrice, @locationId, " +
                               "@verified, @rented)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@brand", txtBrand.Text },
                    { "@model", txtModel.Text },
                    { "@year", (int)numYear.Value },
                    { "@type", AppResources.AllTypeEn[cmbType.SelectedIndex+1]},
                    { "@condition", AppResources.AllConditionEn[cmbCondition.SelectedIndex+1] },
                    { "@hourRate", (int)numHourlyRate.Value },
                    { "@dayRate", (int)numDailyRate.Value },
                    { "@regNumber", txtRegNumber.Text },
                    { "@seats", (int)numSeats.Value },
                    { "@doors", (int)numDoors.Value },
                    { "@mileage", (int)numMileage.Value },
                    { "@fuelType", AppResources.Fuelen[cmbFuelType.SelectedIndex] },
                    { "@transmission", AppResources.Transmissionen[cmbTransmission.SelectedIndex] },
                    { "@description", txtDescription.Text },
                    { "@insurance", insuranceId },
                    { "@active", chkActive.Checked ? 1 : 0 },
                    { "@basePrice", (int)numBasePrice.Value },
                    { "@locationId", locationId },
                    { "@verified", chkVerified.Checked ? 1 : 0 },
                    { "@rented", chkRented.Checked ? 1 : 0 }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    // id "visszakérése"
                    string idQuery = "SELECT LAST_INSERT_ID()";
                    object result = DatabaseOptimizer.ExecuteScalar(idQuery);
                    int newCarId = Convert.ToInt32(result);

                    // képmentés (képfelvitel "kivéve")
                    SaveCarImages(newCarId);

                    MessageBox.Show("Autó sikeresen hozzáadva", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hiba az autó felvételekor", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az autó felvételekor:" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCar()
        {
            try
            {
                // kiválasztott biztosítás megszerzése
                dynamic selectedInsurance = cmbInsurance.SelectedItem;
                int insuranceId = Convert.ToInt32(selectedInsurance.Value);

                // helyadat /hozzáadás
                int locationId = CreateOrGetLocation(cmbLocation.Text);
                if (locationId <= 0)
                {
                    MessageBox.Show("Sikertelen helyadat frissítés", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //query
                string query = "UPDATE car SET car_brand = @brand, car_model = @model, car_year = @year, " +
                               "car_type = @type, car_condition = @condition, price_per_hour = @hourRate, " +
                               "price_per_day = @dayRate, car_regnumber = @regNumber, seats = @seats, " +
                               "number_of_doors = @doors, mileage = @mileage, fuel_type = @fuelType, " +
                               "transmission_type = @transmission, car_description = @description, " +
                               "insurance_id = @insurance, car_active = @active, car_price = @basePrice, " +
                               "location_id = @locationId, verified = @verified, rented = @rented " +
                               "WHERE car_id = @id";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@brand", txtBrand.Text },
                    { "@model", txtModel.Text },
                    { "@year", (int)numYear.Value },
                    { "@type", AppResources.AllTypeEn[cmbType.SelectedIndex + 1]},
                    { "@condition", AppResources.AllConditionEn[cmbCondition.SelectedIndex + 1] },
                    { "@hourRate", (int)numHourlyRate.Value },
                    { "@dayRate", (int)numDailyRate.Value },
                    { "@regNumber", txtRegNumber.Text },
                    { "@seats", (int)numSeats.Value },
                    { "@doors", (int)numDoors.Value },
                    { "@mileage", (int)numMileage.Value },
                    { "@fuelType", AppResources.Fuelen[cmbFuelType.SelectedIndex] },
                    { "@transmission", AppResources.Transmissionen[cmbTransmission.SelectedIndex] },
                    { "@description", txtDescription.Text },
                    { "@insurance", insuranceId },
                    { "@active", chkActive.Checked ? 1 : 0 },
                    { "@basePrice", (int)numBasePrice.Value },
                    { "@locationId", locationId },
                    { "@verified", chkVerified.Checked ? 1 : 0 },
                    { "@rented", chkRented.Checked ? 1 : 0 },
                    { "@id", carId }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    SaveCarImages(carId);

                    MessageBox.Show("Autó adatai sikeresen frissítve", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hiba az autó frissítésekor!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba az autó frissítésekor:" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCarImages(int carId)
        {
            if (carImagePaths.Count == 0) return;

            try
            {
                // kép törlése
                if (this.carId > 0)
                {
                    string deleteQuery = "DELETE FROM car_images WHERE car_id = " + carId;
                    DatabaseOptimizer.ExecuteNonQuery(deleteQuery);
                }

                // új kép felvitele ("kivéve")
                foreach (string imagePath in carImagePaths)
                {
                    string query = "INSERT INTO car_images (car_id, image_url, uploaded_at) " +
                                   "VALUES (@carId, @url, NOW())";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@carId", carId },
                        { "@url", imagePath }
                    };

                    DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a kép mentésénél " + ex.Message, "Error",
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