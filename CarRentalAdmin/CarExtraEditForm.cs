using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class CarExtraEditForm : Form
    {
        private int carId = 0;
        private int extraId = 0;

        public CarExtraEditForm(int carId, int extraId = 0)
        {
            InitializeComponent();
            this.carId = carId;
            this.extraId = extraId;
        }

        private void CarExtraEditForm_Load(object sender, EventArgs e)
        {
            if (extraId > 0)
            {
                //szerkesztés
                this.Text = AppResources.EditExtras;
                LoadExtraData();
            }
            else
            {
                // hozzáadás
                this.Text = AppResources.AddExtras;
                numPrice.Value = 10;
            }
        }

        private void LoadExtraData()
        {
            try
            {
                string query = "SELECT * FROM car_extras WHERE extra_id = " + extraId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // név beállítás
                    string extraName = row["extra_name"].ToString();
                    tbxName.Text = extraName;

                    // ár beállítása
                    numPrice.Value = Convert.ToDecimal(row["extra_price"]);
                }
                else
                {
                    AppResources.ShowMessage(
                        AppResources.NoDataFound,
                        AppResources.ErrorTitle,
                        true);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Hiba az adatok belöltésekor: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // bevitel validálása
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                AppResources.ShowMessage(
                    "Kérem írja be az extra megnevezését!",
                    AppResources.ValidationError,
                    true);
                return;
            }

            try
            {
                if (extraId > 0)
                {
                    // frissítése
                    string query =
                        "UPDATE car_extras SET " +
                        "extra_name = @name, " +
                        "extra_price = @price " +
                        "WHERE extra_id = @extraId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@name", tbxName.Text },
                        { "@price", numPrice.Value },
                        { "@extraId", extraId }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ExtraUpdateSuccess,
                            AppResources.SuccessTitle);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        AppResources.ShowMessage(
                            AppResources.OperationFailed,
                            AppResources.ErrorTitle,
                            true);
                    }
                }
                else
                {
                    // hozzáadás
                    string query =
                        "INSERT INTO car_extras " +
                        "(car_id, extra_name, extra_price) " +
                        "VALUES (@carId, @name, @price)";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@carId", carId },
                        { "@name", tbxName.Text },
                        { "@price", numPrice.Value }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ExtraAddSuccess,
                            AppResources.SuccessTitle);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        AppResources.ShowMessage(
                            AppResources.OperationFailed,
                            AppResources.ErrorTitle,
                            true);
                    }
                }
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Hiba az extra mentésekor: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }
    }
}
