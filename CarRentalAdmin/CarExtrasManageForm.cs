using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class CarExtrasManageForm : Form
    {
        private int selectedExtraId = 0;
        private int carId = 0;

        public CarExtrasManageForm(int carId)
        {
            InitializeComponent();
            this.carId = carId;
        }

        private void CarExtrasManageForm_Load(object sender, EventArgs e)
        {
            LoadCarInfo();

            LoadCarExtras();

            btnEditExtra.Enabled = false;
            btnDeleteExtra.Enabled = false;
        }

        private void LoadCarInfo()
        {
            try
            {
                string query =
                    "SELECT CONCAT(car_brand, ' ', car_model, ' (', car_year, ')') AS car_info " +
                    "FROM car WHERE car_id = " + carId;

                object result = DatabaseOptimizer.ExecuteScalar(query);

                if (result != null)
                {
                    lblCarInfo.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading car info: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void LoadCarExtras()
        {
            try
            {
                string query =
                    "SELECT extra_id, extra_name, extra_price " +
                    "FROM car_extras WHERE car_id = " + carId;

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvExtras.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvExtras.Columns.Count > 0)
                {
                    dgvExtras.Columns["extra_id"].HeaderText = "ID";
                    dgvExtras.Columns["extra_name"].HeaderText = AppResources.ExtraName;
                    dgvExtras.Columns["extra_price"].HeaderText = AppResources.ExtraPrice;

                    // formátum
                    dgvExtras.Columns["extra_price"].DefaultCellStyle.Format = "C2";
                }

                // kiválasztás alaphelyzet
                selectedExtraId = 0;
                btnEditExtra.Enabled = false;
                btnDeleteExtra.Enabled = false;
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading car extras: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void dgvExtras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvExtras.Rows.Count)
            {
                //extra id "megszerzése"
                selectedExtraId = Convert.ToInt32(dgvExtras.Rows[e.RowIndex].Cells["extra_id"].Value);

                // gomb enabled
                btnEditExtra.Enabled = true;
                btnDeleteExtra.Enabled = true;
            }
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {
            CarExtraEditForm addForm = new CarExtraEditForm(carId);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                //extra lista refresh
                LoadCarExtras();
            }
        }

        private void btnEditExtra_Click(object sender, EventArgs e)
        {
            if (selectedExtraId <= 0)
            {
                AppResources.ShowMessage(
                    "Please select an extra to edit.",
                    AppResources.SelectionRequired);
                return;
            }

            CarExtraEditForm editForm = new CarExtraEditForm(carId, selectedExtraId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // extra lista refresh
                LoadCarExtras();
            }
        }

        private void btnDeleteExtra_Click(object sender, EventArgs e)
        {
            if (selectedExtraId <= 0)
            {
                AppResources.ShowMessage(
                    "Please select an extra to delete.",
                    AppResources.SelectionRequired);
                return;
            }

            // biztos törli?
            if (AppResources.ShowConfirmation(
                AppResources.ConfirmDeleteExtra,
                AppResources.DeleteExtras))
            {
                try
                {
                    string query = "DELETE FROM car_extras WHERE extra_id = " + selectedExtraId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ExtraDeleteSuccess,
                            AppResources.SuccessTitle);

                        // extra lista refresh
                        LoadCarExtras();
                    }
                    else
                    {
                        AppResources.ShowMessage(
                            AppResources.OperationFailed,
                            AppResources.ErrorTitle,
                            true);
                    }
                }
                catch (Exception ex)
                {
                    AppResources.ShowMessage(
                        "Error deleting extra: " + ex.Message,
                        AppResources.ErrorTitle,
                        true);
                }
            }
        }
    }
}