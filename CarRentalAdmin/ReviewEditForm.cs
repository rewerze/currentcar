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
    public partial class ReviewEditForm : Form
    {
        private int reviewId = 0;

        public ReviewEditForm(int id = 0)
        {
            InitializeComponent();
            reviewId = id;
        }

        private void ReviewEditForm_Load(object sender, EventArgs e)
        {
            LoadUsers();

            if (reviewId > 0)
            {
                // szerkesztés mód
                this.Text = AppResources.EditReview;
                LoadReviewData();
            }
            else
            {
                //hozzáadás mód
                this.Text = AppResources.AddReview;
                numRating.Value = 5;
            }
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT user_id, user_name, user_email FROM user WHERE user_active = 1";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                //combobox alap value
                cmbReviewer.DisplayMember = "Text";
                cmbReviewer.ValueMember = "Value";

                cmbReviewee.DisplayMember = "Text";
                cmbReviewee.ValueMember = "Value";

                cmbReviewer.Items.Clear();
                cmbReviewee.Items.Clear();

                // Felhasználó hozzáadása cmb
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["user_name"]} ({row["user_email"]})";
                    int id = Convert.ToInt32(row["user_id"]);

                    var item = new { Text = text, Value = id };

                    cmbReviewer.Items.Add(item);
                    cmbReviewee.Items.Add(item);
                }

                // első kiválasztása "már ha van"
                if (cmbReviewer.Items.Count > 0)
                {
                    cmbReviewer.SelectedIndex = 0;
                    cmbReviewee.SelectedIndex = 0;
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

        private void LoadReviewData()
        {
            try
            {
                string query = "SELECT * FROM user_reviews WHERE review_id = " + reviewId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    int reviewerId = Convert.ToInt32(row["reviewer_user_id"]);
                    int revieweeId = Convert.ToInt32(row["reviewee_user_id"]);
                    SelectComboboxItem(cmbReviewer, reviewerId);
                    SelectComboboxItem(cmbReviewee, revieweeId);

                    numRating.Value = Convert.ToDecimal(row["review_rating"]);

                    txtReviewMessage.Text = row["review_message"].ToString();
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
                    "Error loading review: " + ex.Message,
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
            //bevitel validálás
            if (cmbReviewer.SelectedIndex < 0 || cmbReviewee.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtReviewMessage.Text))
            {
                AppResources.ShowMessage(
                    AppResources.ValidationError,
                    AppResources.ErrorTitle,
                    true);
                return;
            }

            // érték felvétel
            dynamic reviewer = cmbReviewer.SelectedItem;
            dynamic reviewee = cmbReviewee.SelectedItem;
            int reviewerId = reviewer.Value;
            int revieweeId = reviewee.Value;

            //önmagadat nem tudod értékelni!
            if (reviewerId == revieweeId)
            {
                AppResources.ShowMessage(
                    "Saját magát nem tudja értékelni a felhasználó!",
                    AppResources.ValidationError,
                    true);
                return;
            }

            try
            {
                if (reviewId > 0)
                {
                    //értékelés frissítése
                    string query =
                        "UPDATE user_reviews SET " +
                        "reviewer_user_id = @reviewerId, " +
                        "reviewee_user_id = @revieweeId, " +
                        "review_message = @message, " +
                        "review_rating = @rating, " +
                        "review_date = NOW() " +
                        "WHERE review_id = @reviewId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@reviewerId", reviewerId },
                        { "@revieweeId", revieweeId },
                        { "@message", txtReviewMessage.Text },
                        { "@rating", (int)numRating.Value },
                        { "@reviewId", reviewId }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ReviewUpdateSuccess,
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
                    // értékelés hozzáadása
                    string query =
                        "INSERT INTO user_reviews " +
                        "(reviewer_user_id, reviewee_user_id, review_message, review_rating, review_date) " +
                        "VALUES (@reviewerId, @revieweeId, @message, @rating, NOW())";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@reviewerId", reviewerId },
                        { "@revieweeId", revieweeId },
                        { "@message", txtReviewMessage.Text },
                        { "@rating", (int)numRating.Value }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ReviewAddSuccess,
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
                    "Error saving review: " + ex.Message,
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
