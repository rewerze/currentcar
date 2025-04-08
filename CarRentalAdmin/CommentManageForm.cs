using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class CommentManageForm : Form
    {
        private int selectedCommentId = 0;

        public CommentManageForm()
        {
            InitializeComponent();
        }

        private void CommentManageForm_Load(object sender, EventArgs e)
        {
            // adatbetöltés
            LoadComments();

            // gombok disabled
            btnEditComment.Enabled = false;
            btnDeleteComment.Enabled = false;
            btnToggleFlag.Enabled = false;

            // info tip a Flag gomhoz (test? nm1)
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnToggleFlag, AppResources.FlagComment);
        }

        //betöltés
        private void LoadComments(string searchTerm = "", string rating = "All", string category = "All")
        {
            try
            {
                string query =
                    "SELECT c.comment_id, u.user_name, CONCAT(car.car_brand, ' ', car.car_model) AS car_name, " +
                    "c.comment_star, c.rating_category, c.comment_date, c.comment_flagged, c.comment_message " +
                    "FROM comment c " +
                    "JOIN user u ON c.user_id = u.user_id " +
                    "JOIN car ON c.car_id = car.car_id " +
                    "WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (u.user_name LIKE '%" + searchTerm + "%' OR " +
                             "car.car_brand LIKE '%" + searchTerm + "%' OR " +
                             "car.car_model LIKE '%" + searchTerm + "%' OR " +
                             "c.comment_message LIKE '%" + searchTerm + "%')";
                }

                if (rating != "All" && rating != "Összes")
                {
                    query += " AND c.comment_star = " + rating;
                }

                if (category != "All" && category != "Összes")
                {
                    query += " AND c.rating_category = '" + category + "'";
                }

                query += " ORDER BY c.comment_date DESC";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvComments.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvComments.Columns.Count > 0)
                {
                    dgvComments.Columns["comment_id"].HeaderText = "ID";
                    dgvComments.Columns["user_name"].HeaderText = AppResources.Name;
                    dgvComments.Columns["car_name"].HeaderText = AppResources.Car;
                    dgvComments.Columns["comment_star"].HeaderText = AppResources.CommentStar;
                    dgvComments.Columns["rating_category"].HeaderText = AppResources.RatingCategory;
                    dgvComments.Columns["comment_date"].HeaderText = AppResources.CommentDate;
                    dgvComments.Columns["comment_flagged"].HeaderText = AppResources.Flagged;
                    dgvComments.Columns["comment_message"].HeaderText = AppResources.CommentMessage;

                    // formátum
                    dgvComments.Columns["comment_date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                    // üzenet elrejtése
                    dgvComments.Columns["comment_message"].Visible = false;
                }

                // kiválasztás alaphelyzet
                txtCommentMessage.Text = "";
                selectedCommentId = 0;
                btnEditComment.Enabled = false;
                btnDeleteComment.Enabled = false;
                btnToggleFlag.Enabled = false;
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading comments: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void DgvComments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvComments.Columns[e.ColumnIndex].Name == "comment_flagged" && e.Value != null)
            {
                bool flagged = Convert.ToBoolean(e.Value);
                e.Value = flagged ? 0 : 1;
                e.FormattingApplied = true;

                if (flagged)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
        }

        private void cmbRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
        }

        private void dgvComments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvComments.Rows.Count)
            {
                // kiválaszott id "lekérés"
                selectedCommentId = Convert.ToInt32(dgvComments.Rows[e.RowIndex].Cells["comment_id"].Value);

                // gombok enabled
                btnEditComment.Enabled = true;
                btnDeleteComment.Enabled = true;
                btnToggleFlag.Enabled = true;

                // üzenet részlet kiírás
                txtCommentMessage.Text = dgvComments.Rows[e.RowIndex].Cells["comment_message"].Value.ToString();
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            CommentEditForm addForm = new CommentEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // kommentek refresh
                LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
            }
        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if (selectedCommentId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectComment,
                    AppResources.SelectionRequired);
                return;
            }

            CommentEditForm editForm = new CommentEditForm(selectedCommentId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // kommentek refresh
                LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
            }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (selectedCommentId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectComment,
                    AppResources.SelectionRequired);
                return;
            }

            // törlés rákérdez
            if (AppResources.ShowConfirmation(
                AppResources.ConfirmDeleteComment,
                AppResources.DeleteComment))
            {
                try
                {
                    string query = "DELETE FROM comment WHERE comment_id = " + selectedCommentId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.CommentDeleteSuccess,
                            AppResources.SuccessTitle);

                        //komment refresh
                        LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
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
                        "Error deleting comment: " + ex.Message,
                        AppResources.ErrorTitle,
                        true);
                }
            }
        }

        private void btnToggleFlag_Click(object sender, EventArgs e)
        {
            if (selectedCommentId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectComment,
                    AppResources.SelectionRequired);
                return;
            }

            try
            {
                int selectedRowIndex = dgvComments.SelectedRows[0].Index;
                bool currentFlag = Convert.ToBoolean(dgvComments.Rows[selectedRowIndex].Cells["comment_flagged"].Value);

                // flag "állapot lekérés" 
                string query = "UPDATE comment SET comment_flagged = " + (!currentFlag ? 1 : 0) +
                              " WHERE comment_id = " + selectedCommentId;

                int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    // kommentek refresh
                    LoadComments(txtSearch.Text, cmbRating.Text, AppResources.RatingCategoryen[cmbCategory.SelectedIndex]);
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
                    "Error toggling flag: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }
    }
}