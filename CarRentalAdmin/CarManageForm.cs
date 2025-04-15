using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class CarManageForm : Form
    {
        private int selectedCarId = 0;

        public CarManageForm()
        {
            InitializeComponent();
        }
        private void CarManageForm_Load(object sender, EventArgs e)
        {
            // alap értékek
            cmbCarType.SelectedIndex = 0;
            cmbCarCondition.SelectedIndex = 0;
            chkShowUnverified.Checked = false;

            LoadCars();

            // gombok disabled
            btnEditCar.Enabled = false;
            btnDeleteCar.Enabled = false;
            carExtra.Enabled = false;
        }

        // autók betöltése adatbázisból
        private void LoadCars(string searchTerm = "", string carType = "All Types", string condition = "All Conditions", bool showOnlyUnverified = false)
        {
            try
            {
                string query = "SELECT c.car_id, c.car_brand, c.car_model, c.car_year, c.car_type, " +
                              "c.car_condition, CAST(c.car_price AS DECIMAL(10,2)) as car_price, " +
                              "c.price_per_day, c.price_per_hour, c.car_regnumber, " +
                              "c.seats, c.mileage, c.car_active, loc.location, c.verified, c.rented " +
                              "FROM car c " +
                              "JOIN location loc ON c.location_id = loc.location_id " +
                              "WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (c.car_brand LIKE '%" + searchTerm + "%' OR c.car_model LIKE '%" + searchTerm +
                             "%' OR c.car_regnumber LIKE '%" + searchTerm + "%')";
                }

                if (carType != "All Types")
                {
                    query += " AND c.car_type = '" + carType + "'";
                }

                if (condition != "All Conditions")
                {
                    query += " AND c.car_condition = '" + condition + "'";
                }

                if (showOnlyUnverified)
                {
                    query += " AND c.verified = 0";
                }

                query += " ORDER BY c.car_id";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvCars.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvCars.Columns.Count > 0)
                {
                    dgvCars.Columns["car_id"].HeaderText = "ID";
                    dgvCars.Columns["car_brand"].HeaderText = AppResources.Brand;
                    dgvCars.Columns["car_model"].HeaderText = AppResources.Model;
                    dgvCars.Columns["car_year"].HeaderText = AppResources.Year;
                    dgvCars.Columns["car_type"].HeaderText = AppResources.Type;
                    dgvCars.Columns["car_condition"].HeaderText = AppResources.Condition;
                    dgvCars.Columns["car_price"].HeaderText = AppResources.BasePrice;
                    dgvCars.Columns["price_per_day"].HeaderText = AppResources.DailyRate;
                    dgvCars.Columns["price_per_hour"].HeaderText = AppResources.HourlyRate;
                    dgvCars.Columns["car_regnumber"].HeaderText = AppResources.RegNumber;
                    dgvCars.Columns["seats"].HeaderText = AppResources.Seats;
                    dgvCars.Columns["mileage"].HeaderText = AppResources.Mileage[0];
                    dgvCars.Columns["car_active"].HeaderText = AppResources.Active;
                    dgvCars.Columns["location"].HeaderText = AppResources.Location;
                    dgvCars.Columns["verified"].HeaderText = "Ellenőrzött";
                    dgvCars.Columns["rented"].HeaderText = "Kiadott";

                    // formátum
                    dgvCars.Columns["car_price"].DefaultCellStyle.Format = "C2";
                    dgvCars.Columns["price_per_day"].DefaultCellStyle.Format = "C2";
                    dgvCars.Columns["price_per_hour"].DefaultCellStyle.Format = "C2";
                    OptimizeDataGridViewColumns();
                }

                // nincs "validálva"
                ColorUnverifiedRows();

                // kiválasztás alaphelyzet
                selectedCarId = 0;
                btnEditCar.Enabled = false;
                btnDeleteCar.Enabled = false;
                carExtra.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ColorUnverifiedRows()
        {
            foreach (DataGridViewRow row in dgvCars.Rows)
            {
                if (row.Cells["verified"] != null && row.Cells["verified"].Value != DBNull.Value)
                {
                    bool isVerified = Convert.ToBoolean(row.Cells["verified"].Value);
                    if (!isVerified)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                if (row.Cells["rented"] != null && row.Cells["rented"].Value != DBNull.Value)
                {
                    bool isRented = Convert.ToBoolean(row.Cells["rented"].Value);
                    if (isRented)
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        row.DefaultCellStyle.Font = new Font(dgvCars.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void OptimizeDataGridViewColumns()
        {
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCars.Columns["car_regnumber"].Visible = false;
            dgvCars.Columns["seats"].Visible = false;
            dgvCars.Columns["mileage"].Visible = false;
            dgvCars.Columns["car_type"].Visible = false;
            dgvCars.Columns["car_condition"].Visible = false;
            dgvCars.Columns["verified"].Width = 70;
            dgvCars.Columns["rented"].Width = 70;

            dgvCars.ScrollBars = ScrollBars.Both;
        }
        private void chkShowUnverified_CheckedChanged(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex], chkShowUnverified.Checked);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex], chkShowUnverified.Checked);
        }

        private void cmbCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex], chkShowUnverified.Checked);
        }

        private void cmbCarCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(cmbCarCondition.SelectedIndex);
            //Console.WriteLine(AppResources.AllConditionEn[cmbCarCondition.SelectedIndex]);
            LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex], chkShowUnverified.Checked);
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCarId = Convert.ToInt32(dgvCars.Rows[e.RowIndex].Cells["car_id"].Value);
                btnEditCar.Enabled = true;
                btnDeleteCar.Enabled = true;
                carExtra.Enabled = true;
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            CarEditForm addForm = new CarEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex]);
            }
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            if (selectedCarId <= 0)
            {
                MessageBox.Show(AppResources.SelectCar, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CarEditForm editForm = new CarEditForm(selectedCarId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Frissítsük az autók listáját
                LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex]);
            }
        }
        private void carExtra_Click(object sender, EventArgs e)
        {
            if (selectedCarId <= 0)
            {
                MessageBox.Show(AppResources.SelectCar, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //car extra manage form megnyitás
            CarExtrasManageForm carExtrasForm = new CarExtrasManageForm(selectedCarId);
            if (carExtrasForm.ShowDialog() == DialogResult.OK)
            {
                LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex]);
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (selectedCarId <= 0)
            {
                MessageBox.Show(AppResources.SelectCar, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Törlés megerősítése
            DialogResult result = MessageBox.Show(AppResources.ConfirmDeleteCar,
                AppResources.DeleteCar, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE car SET car_active = 0 WHERE car_id = " + selectedCarId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(AppResources.CarDeleteSuccess, AppResources.SuccessTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Frissítsük az autók listáját
                        LoadCars(txtSearch.Text, AppResources.AllTypeEn[cmbCarType.SelectedIndex], AppResources.AllConditionEn[cmbCarCondition.SelectedIndex]);
                    }
                    else
                    {
                        MessageBox.Show(AppResources.OperationFailed, AppResources.ErrorTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AppResources.ShowMessage("Hiba az autó törlésekor: " + ex.Message,
                        AppResources.ErrorTitle, true));
                }
            }
        }
    }
}