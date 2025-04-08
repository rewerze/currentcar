using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class ReviewManageForm : Form
    {
        private int selectedReviewId = 0;

        public ReviewManageForm()
        {
            InitializeComponent();
        }

        private void ReviewManageForm_Load(object sender, EventArgs e)
        {
            LoadReviews();
            btnEditReview.Enabled = false;
            btnDeleteReview.Enabled = false;
        }

        // értékelések betöltése
        private void LoadReviews(string searchTerm = "", string rating = "All")
        {
            try
            {
                string query =
                    "SELECT r.review_id, u1.user_name AS reviewer_name, u2.user_name AS reviewee_name, " +
                    "r.review_rating, r.review_date, r.review_message " +
                    "FROM user_reviews r " +
                    "JOIN user u1 ON r.reviewer_user_id = u1.user_id " +
                    "JOIN user u2 ON r.reviewee_user_id = u2.user_id " +
                    "WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (u1.user_name LIKE '%" + searchTerm + "%' OR u2.user_name LIKE '%" + searchTerm +
                             "%' OR r.review_message LIKE '%" + searchTerm + "%')";
                }

                if (rating != "All" && rating != "Összes")
                {
                    query += " AND r.review_rating = " + rating;
                }

                query += " ORDER BY r.review_date DESC";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvReviews.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvReviews.Columns.Count > 0)
                {
                    dgvReviews.Columns["review_id"].HeaderText = "ID";
                    dgvReviews.Columns["reviewer_name"].HeaderText = AppResources.Reviewer;
                    dgvReviews.Columns["reviewee_name"].HeaderText = AppResources.Reviewee;
                    dgvReviews.Columns["review_rating"].HeaderText = AppResources.Rating;
                    dgvReviews.Columns["review_date"].HeaderText = AppResources.ReviewDate;
                    dgvReviews.Columns["review_message"].HeaderText = AppResources.ReviewMessage;

                    //mező formátum
                    dgvReviews.Columns["review_date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                    //rejtett mező
                    dgvReviews.Columns["review_message"].Visible = false;
                }

                // alaphelyzet set
                txtReviewMessage.Text = "";
                selectedReviewId = 0;
                btnEditReview.Enabled = false;
                btnDeleteReview.Enabled = false;
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Hiba értesítések betöltésekor: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReviews(txtSearch.Text, cmbRating.Text);
        }

        private void cmbRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReviews(txtSearch.Text, cmbRating.Text);
        }

        private void dgvReviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvReviews.Rows.Count)
            {
                selectedReviewId = Convert.ToInt32(dgvReviews.Rows[e.RowIndex].Cells["review_id"].Value);

                btnEditReview.Enabled = true;
                btnDeleteReview.Enabled = true;

                txtReviewMessage.Text = dgvReviews.Rows[e.RowIndex].Cells["review_message"].Value.ToString();
            }
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            ReviewEditForm addForm = new ReviewEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadReviews(txtSearch.Text, cmbRating.Text);
            }
        }

        private void btnEditReview_Click(object sender, EventArgs e)
        {
            if (selectedReviewId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectReview,
                    AppResources.SelectionRequired);
                return;
            }

            ReviewEditForm editForm = new ReviewEditForm(selectedReviewId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadReviews(txtSearch.Text, cmbRating.Text);
            }
        }

        private void btnDeleteReview_Click(object sender, EventArgs e)
        {
            if (selectedReviewId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectReview,
                    AppResources.SelectionRequired);
                return;
            }

            //biztos törli?
            if (AppResources.ShowConfirmation(
                AppResources.ConfirmDeleteReview,
                AppResources.DeleteReview))
            {
                try
                {
                    string query = "DELETE FROM user_reviews WHERE review_id = " + selectedReviewId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.ReviewDeleteSuccess,
                            AppResources.SuccessTitle);

                        LoadReviews(txtSearch.Text, cmbRating.Text);
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
                        "Hiba a törlés során " + ex.Message,
                        AppResources.ErrorTitle,
                        true);
                }
            }
        }
    }
}