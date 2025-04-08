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
    public partial class CommentEditForm : Form
    {
        private int commentId = 0;

        public CommentEditForm(int id = 0)
        {
            InitializeComponent();
            commentId = id;
        }

        private void CommentEditForm_Load(object sender, EventArgs e)
        {
            // adatok betöltése
            LoadUsers();
            LoadCars();

            // alapértelmezett
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            if (commentId > 0)
            {
                // szerkesztés
                this.Text = AppResources.EditComment;
                LoadCommentData();
            }
            else
            {
                //hozzáadás
                this.Text = AppResources.AddComment;
                // alapértelmezet (étékelés értéke)
                numRating.Value = 5;
            }
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT user_id, user_name, user_email FROM user WHERE user_active = 1";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                // Setup combobox
                cmbUser.DisplayMember = "Text";
                cmbUser.ValueMember = "Value";

                // Clear existing items
                cmbUser.Items.Clear();

                // Add users to combo
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["user_name"]} ({row["user_email"]})";
                    int id = Convert.ToInt32(row["user_id"]);

                    var item = new { Text = text, Value = id };

                    cmbUser.Items.Add(item);
                }

                // Select first item if available
                if (cmbUser.Items.Count > 0)
                {
                    cmbUser.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading users: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void LoadCars()
        {
            try
            {
                string query =
                    "SELECT car_id, car_brand, car_model, car_year, car_regnumber " +
                    "FROM car WHERE car_active = 1";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                // combobox beállízása
                cmbCar.DisplayMember = "Text";
                cmbCar.ValueMember = "Value";

                // "adatok tölrése"
                cmbCar.Items.Clear();

                // combobox adatok felvétele
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["car_brand"]} {row["car_model"]} {row["car_year"]} ({row["car_regnumber"]})";
                    int id = Convert.ToInt32(row["car_id"]);

                    var item = new { Text = text, Value = id };

                    cmbCar.Items.Add(item);
                }

                // első elem kiválasztása, ha elérhető
                if (cmbCar.Items.Count > 0)
                {
                    cmbCar.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading cars: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void LoadCommentData()
        {
            try
            {
                string query = "SELECT * FROM comment WHERE comment_id = " + commentId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // értékelés "adatai"
                    int userId = Convert.ToInt32(row["user_id"]);
                    int carId = Convert.ToInt32(row["car_id"]);

                    //autó és felhasználó választása
                    SelectComboboxItem(cmbUser, userId);
                    SelectComboboxItem(cmbCar, carId);

                    // értékelés választás
                    numRating.Value = Convert.ToDecimal(row["comment_star"]);

                    // kategória választás
                    cmbCategory.Text = AppResources.RatingCategoryen.Zip(AppResources.RatingCategoryhu, (en, hu) => new { en, hu })
                        .FirstOrDefault(pair => pair.en == row["rating_category"].ToString())?.hu ?? row["rating_category"].ToString();

                    //for (int i = 0; i < cmbCategory.Items.Count; i++)
                    //{
                    //    if (cmbCategory.Items[i].ToString() == category)
                    //    {
                    //        cmbCategory.SelectedIndex = i;
                    //        break;
                    //    }
                    //}

                    // flagged "akív" e a komment (látható a weboldalon)
                    chkFlagged.Checked = Convert.ToBoolean(row["comment_flagged"]);

                    // üzenet
                    txtMessage.Text = row["comment_message"].ToString();
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
                    "Error loading comment: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
                this.Close();
            }
        }

        private void SelectComboboxItem(ComboBox comboBox, int value)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                dynamic item = comboBox.Items[i];
                if (item.Value == value)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // bevitel validáció
            if (cmbUser.SelectedIndex < 0 || cmbCar.SelectedIndex < 0 || cmbCategory.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                AppResources.ShowMessage(
                    AppResources.ValidationError,
                    AppResources.ErrorTitle,
                    true);
                return;
            }

            // kiválasztott értékek "felvétele"
            dynamic user = cmbUser.SelectedItem;
            dynamic car = cmbCar.SelectedItem;

            int userId = user.Value;
            int carId = car.Value;
            string category = AppResources.RatingCategoryen[cmbCategory.SelectedIndex];

            try
            {
                if (commentId > 0)
                {
                    // komment frissítése
                    string query =
                        "UPDATE comment SET " +
                        "user_id = @userId, " +
                        "car_id = @carId, " +
                        "comment_message = @message, " +
                        "comment_star = @star, " +
                        "rating_category = @category, " +
                        "comment_flagged = @flagged " +
                        "WHERE comment_id = @commentId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@userId", userId },
                        { "@carId", carId },
                        { "@message", txtMessage.Text },
                        { "@star", (int)numRating.Value },
                        { "@category", category },
                        { "@flagged", chkFlagged.Checked ? 1 : 0 },
                        { "@commentId", commentId }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.CommentUpdateSuccess,
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
                    // komment hozzáadása
                    string query =
                        "INSERT INTO comment " +
                        "(user_id, car_id, comment_message, comment_star, rating_category, comment_date, comment_flagged) " +
                        "VALUES (@userId, @carId, @message, @star, @category, NOW(), @flagged)";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@userId", userId },
                        { "@carId", carId },
                        { "@message", txtMessage.Text },
                        { "@star", (int)numRating.Value },
                        { "@category", category },
                        { "@flagged", chkFlagged.Checked ? 1 : 0 }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.CommentAddSuccess,
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
                    "Error saving comment: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
