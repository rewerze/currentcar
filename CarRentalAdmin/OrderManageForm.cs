using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class OrderManageForm : Form
    {
        private int selectedOrderId = 0;

        public OrderManageForm()
        {
            InitializeComponent();
        }

        private void OrderManageForm_Load(object sender, EventArgs e)
        {
            chkUseDate.Checked = false;
            dtpDate.Enabled = chkUseDate.Checked;

            LoadOrders();
            btnEditOrder.Enabled = false;
            btnCancelOrder.Enabled = false;

            // Hide order details
            HideOrderDetails();
        }

        // Load orders
        private void LoadOrders(string searchTerm = "", string status = "All", DateTime? date = null)
        {
            try
            {
                string query =
                    "SELECT o.orders_id, u.user_name, c.car_brand, c.car_model, c.car_regnumber, " +
                    "o.start_date, o.end_date, o.rental_status, o.payment_status, " +
                    "loc.pickup_location, i.payment_amount " +
                    "FROM orders o " +
                    "JOIN user u ON o.user_id = u.user_id " +
                    "JOIN car c ON o.car_id = c.car_id " +
                    "JOIN location loc ON o.location_id = loc.location_id " +
                    "LEFT JOIN invoice i ON o.orders_id = i.orders_id " +
                    "WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (u.user_name LIKE '%" + searchTerm + "%' OR c.car_regnumber LIKE '%" + searchTerm +
                            "%' OR c.car_brand LIKE '%" + searchTerm + "%')";
                }

                if (status != "All" && status != "Összes")
                {
                    query += " AND o.rental_status = '" + status + "'";
                }

                if (date.HasValue)
                {
                    string dateStr = date.Value.ToString("yyyy-MM-dd");
                    query += " AND (DATE(o.start_date) = '" + dateStr + "' OR DATE(o.end_date) = '" + dateStr + "')";
                }

                query += " ORDER BY o.start_date DESC";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvOrders.DataSource = dt;

                // Customize column headers
                if (dgvOrders.Columns.Count > 0)
                {
                    dgvOrders.Columns["orders_id"].HeaderText = "Rendelés ID";
                    dgvOrders.Columns["user_name"].HeaderText = AppResources.Customer;
                    dgvOrders.Columns["car_brand"].HeaderText = AppResources.Brand;
                    dgvOrders.Columns["car_model"].HeaderText = AppResources.Model;
                    dgvOrders.Columns["car_regnumber"].HeaderText = AppResources.RegNumber;
                    dgvOrders.Columns["start_date"].HeaderText = AppResources.StartDate;
                    dgvOrders.Columns["end_date"].HeaderText = AppResources.EndDate;
                    dgvOrders.Columns["rental_status"].HeaderText = AppResources.Status;
                    dgvOrders.Columns["payment_status"].HeaderText = AppResources.PaymentStatus;
                    dgvOrders.Columns["pickup_location"].HeaderText = AppResources.PickupLocation;
                    dgvOrders.Columns["payment_amount"].HeaderText = AppResources.PaymentAmount;

                    // Format columns
                    dgvOrders.Columns["start_date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                    dgvOrders.Columns["end_date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                    dgvOrders.Columns["payment_amount"].DefaultCellStyle.Format = "C2";
                }

                // Hide details
                HideOrderDetails();

                // Reset selection
                selectedOrderId = 0;
                btnEditOrder.Enabled = false;
                btnCancelOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a betöltés közben:" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkUseDate.Checked)
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], dtpDate.Value);
            }
            else
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], null);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkUseDate.Checked)
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], dtpDate.Value);
            }
            else
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], null);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (chkUseDate.Checked)
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], dtpDate.Value);
            }
        }

        private void chkUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = chkUseDate.Checked;
            RefreshOrdersList();
        }

        private void RefreshOrdersList()
        {
            if (chkUseDate.Checked)
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], dtpDate.Value);
            }
            else
            {
                LoadOrders(txtSearch.Text, AppResources.OrderStatusen[cmbStatus.SelectedIndex], null);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedOrderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["orders_id"].Value);
                btnEditOrder.Enabled = true;

                // Only allow cancellation for pending or confirmed orders
                string status = dgvOrders.Rows[e.RowIndex].Cells["rental_status"].Value.ToString();
                btnCancelOrder.Enabled = (status == "pending" || status == "confirmed");

                // Load order details
                LoadOrderDetails(selectedOrderId);
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                // Query to get detailed information about the order
                string query =
                    "SELECT o.orders_id, o.start_date, o.end_date, o.rental_status, o.payment_status, " +
                    "o.discount_code, o.extended_rental, " +
                    "u.user_name, u.user_email, u.u_phone_number, " +
                    "c.car_brand, c.car_model, c.car_year, c.car_regnumber, c.price_per_hour, c.price_per_day, " +
                    "loc.pickup_location, loc.dropoff_location, " +
                    "i.payment_id, i.payment_amount, i.tax_amount, i.payment_method, i.payment_date, i.invoice_address " +
                    "FROM orders o " +
                    "JOIN user u ON o.user_id = u.user_id " +
                    "JOIN car c ON o.car_id = c.car_id " +
                    "JOIN location loc ON o.location_id = loc.location_id " +
                    "LEFT JOIN invoice i ON o.orders_id = i.orders_id " +
                    "WHERE o.orders_id = " + orderId;

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Update label values and show them
                    UpdateOrderDetailsDisplay(row);
                }
                else
                {
                    HideOrderDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(AppResources.ErrorLoadingUserData + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                HideOrderDetails();
            }
        }

        private void UpdateOrderDetailsDisplay(DataRow row)
        {
            //panel visible
            panelOrderDetails.Visible = true;

            // Order information
            lblOrderIdValue.Text = row["orders_id"].ToString();
            lblOrderIdLabel.Visible = true;
            lblOrderIdValue.Visible = true;

            lblStatusValue.Text = row["rental_status"].ToString();
            lblStatusLabel.Visible = true;
            lblStatusValue.Visible = true;

            lblStartDateValue.Text = Convert.ToDateTime(row["start_date"]).ToString("yyyy-MM-dd HH:mm");
            lblStartDateLabel.Visible = true;
            lblStartDateValue.Visible = true;

            lblEndDateValue.Text = Convert.ToDateTime(row["end_date"]).ToString("yyyy-MM-dd HH:mm");
            lblEndDateLabel.Visible = true;
            lblEndDateValue.Visible = true;

            // Customer information
            lblUserValue.Text = row["user_name"].ToString();
            lblUserLabel.Visible = true;
            lblUserValue.Visible = true;

            lblEmailValue.Text = row["user_email"].ToString();
            lblEmailLabel.Visible = true;
            lblEmailValue.Visible = true;

            lblPhoneValue.Text = row["u_phone_number"].ToString();
            lblPhoneLabel.Visible = true;
            lblPhoneValue.Visible = true;

            lblDiscountCodeValue.Text = row["discount_code"].ToString();
            lblDiscountCodeLabel.Visible = true;
            lblDiscountCodeValue.Visible = true;

            // Car information
            lblCarValue.Text = row["car_brand"].ToString() + " " + row["car_model"].ToString() + " (" + row["car_year"].ToString() + ")";
            lblCarLabel.Visible = true;
            lblCarValue.Visible = true;

            lblRegNumberValue.Text = row["car_regnumber"].ToString();
            lblRegNumberLabel.Visible = true;
            lblRegNumberValue.Visible = true;

            // Location information
            lblPickupLocationValue.Text = row["pickup_location"].ToString();
            lblPickupLocationLabel.Visible = true;
            lblPickupLocationValue.Visible = true;

            lblDropoffLocationValue.Text = row["dropoff_location"].ToString();
            lblDropoffLocationLabel.Visible = true;
            lblDropoffLocationValue.Visible = true;

            // Payment information
            lblPaymentStatusValue.Text = row["payment_status"].ToString();
            lblPaymentStatusLabel.Visible = true;
            lblPaymentStatusValue.Visible = true;

            // Payment details (only if payment exists)
            if (row["payment_id"] != DBNull.Value)
            {
                lblPaymentMethodValue.Text = row["payment_method"].ToString();
                lblPaymentMethodLabel.Visible = true;
                lblPaymentMethodValue.Visible = true;

                lblPaymentAmountValue.Text = Convert.ToDecimal(row["payment_amount"]).ToString("C2");
                lblPaymentAmountLabel.Visible = true;
                lblPaymentAmountValue.Visible = true;

                lblTaxAmountValue.Text = Convert.ToDecimal(row["tax_amount"]).ToString("C2");
                lblTaxAmountLabel.Visible = true;
                lblTaxAmountValue.Visible = true;

                if (row["payment_date"] != DBNull.Value)
                {
                    lblPaymentDateValue.Text = Convert.ToDateTime(row["payment_date"]).ToString("yyyy-MM-dd HH:mm");
                    lblPaymentDateLabel.Visible = true;
                    lblPaymentDateValue.Visible = true;
                }
                else
                {
                    lblPaymentDateLabel.Visible = false;
                    lblPaymentDateValue.Visible = false;
                }
            }
            else
            {
                lblPaymentMethodLabel.Visible = false;
                lblPaymentMethodValue.Visible = false;
                lblPaymentAmountLabel.Visible = false;
                lblPaymentAmountValue.Visible = false;
                lblTaxAmountLabel.Visible = false;
                lblTaxAmountValue.Visible = false;
                lblPaymentDateLabel.Visible = false;
                lblPaymentDateValue.Visible = false;
            }
        }

        private void HideOrderDetails()
        {
            // Hide  panel
            panelOrderDetails.Visible = false;

            // Hide labels
            lblOrderIdLabel.Visible = false;
            lblOrderIdValue.Visible = false;
            lblStatusLabel.Visible = false;
            lblStatusValue.Visible = false;
            lblStartDateLabel.Visible = false;
            lblStartDateValue.Visible = false;
            lblEndDateLabel.Visible = false;
            lblEndDateValue.Visible = false;

            lblUserLabel.Visible = false;
            lblUserValue.Visible = false;
            lblEmailLabel.Visible = false;
            lblEmailValue.Visible = false;
            lblPhoneLabel.Visible = false;
            lblPhoneValue.Visible = false;
            lblDiscountCodeLabel.Visible = false;
            lblDiscountCodeValue.Visible = false;

            lblCarLabel.Visible = false;
            lblCarValue.Visible = false;
            lblRegNumberLabel.Visible = false;
            lblRegNumberValue.Visible = false;

            lblPickupLocationLabel.Visible = false;
            lblPickupLocationValue.Visible = false;
            lblDropoffLocationLabel.Visible = false;
            lblDropoffLocationValue.Visible = false;

            lblPaymentStatusLabel.Visible = false;
            lblPaymentStatusValue.Visible = false;
            lblPaymentMethodLabel.Visible = false;
            lblPaymentMethodValue.Visible = false;
            lblPaymentAmountLabel.Visible = false;
            lblPaymentAmountValue.Visible = false;
            lblTaxAmountLabel.Visible = false;
            lblTaxAmountValue.Visible = false;
            lblPaymentDateLabel.Visible = false;
            lblPaymentDateValue.Visible = false;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderEditForm addForm = new OrderEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshOrdersList();
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (selectedOrderId <= 0)
            {
                MessageBox.Show(AppResources.SelectOrder, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrderEditForm editForm = new OrderEditForm(selectedOrderId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshOrdersList();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (selectedOrderId <= 0)
            {
                MessageBox.Show(AppResources.SelectOrderCancel, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(AppResources.ConfirmCancelOrder,
                AppResources.ConfirmCancel, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE orders SET rental_status = 'cancelled' WHERE orders_id = " + selectedOrderId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(AppResources.OrderCancelSuccess, AppResources.SuccessTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshOrdersList();
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a törlés során: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}