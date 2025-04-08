using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class NotificationManageForm : Form
    {
        private int selectedNotificationId = 0;

        public NotificationManageForm()
        {
            InitializeComponent();
        }

        private void NotificationManageForm_Load(object sender, EventArgs e)
        {
            LoadNotifications();

            //gomok disabled
            btnEditNotification.Enabled = false;
            btnDeleteNotification.Enabled = false;
            btnMarkAsRead.Enabled = false;
            btnMarkAsUnread.Enabled = false;

            //("eszköz információ" hover... "Test")
            SetButtonTooltips();
        }

        private void SetButtonTooltips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnMarkAsRead, AppResources.MarkAsRead);
            toolTip.SetToolTip(btnMarkAsUnread, AppResources.MarkAsUnread);
        }

        // dgv feltöltése
        private void LoadNotifications(string searchTerm = "", string status = "All")
        {
            try
            {
                string query =
                    "SELECT n.notification_id, u.user_name, n.message, n.status, n.created_at " +
                    "FROM notifications n " +
                    "JOIN user u ON n.user_id = u.user_id " +
                    "WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (u.user_name LIKE '%" + searchTerm + "%' OR n.message LIKE '%" + searchTerm + "%')";
                }

                if (status != "All" && status != "Összes")
                {
                    string dbStatus = status == AppResources.Read ? "read" : "unread";
                    query += " AND n.status = '" + dbStatus + "'";
                }

                query += " ORDER BY n.created_at DESC";

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvNotifications.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvNotifications.Columns.Count > 0)
                {
                    dgvNotifications.Columns["notification_id"].HeaderText = "ID";
                    dgvNotifications.Columns["user_name"].HeaderText = AppResources.Name;
                    dgvNotifications.Columns["message"].HeaderText = AppResources.Message;
                    dgvNotifications.Columns["status"].HeaderText = AppResources.Status;
                    dgvNotifications.Columns["created_at"].HeaderText = AppResources.CreatedAt;

                    //mező formátumok
                    dgvNotifications.Columns["created_at"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                    //mezőszín
                    dgvNotifications.CellFormatting += DgvNotifications_CellFormatting;
                }

                // alaphelyzet be állítása
                txtNotificationMessage.Text = "";
                selectedNotificationId = 0;
                btnEditNotification.Enabled = false;
                btnDeleteNotification.Enabled = false;
                btnMarkAsRead.Enabled = false;
                btnMarkAsUnread.Enabled = false;
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading notifications: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        private void DgvNotifications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNotifications.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "read")
                {
                    e.Value = AppResources.Read;
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (status == "unread")
                {
                    e.Value = AppResources.Unread;
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNotifications(txtSearch.Text, cmbStatus.Text);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNotifications(txtSearch.Text, cmbStatus.Text);
        }

        private void dgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNotifications.Rows.Count)
            {
                selectedNotificationId = Convert.ToInt32(dgvNotifications.Rows[e.RowIndex].Cells["notification_id"].Value);
                btnEditNotification.Enabled = true;
                btnDeleteNotification.Enabled = true;
                string status = dgvNotifications.Rows[e.RowIndex].Cells["status"].Value.ToString();
                btnMarkAsRead.Enabled = (status == "unread");
                btnMarkAsUnread.Enabled = (status == "read");
                txtNotificationMessage.Text = dgvNotifications.Rows[e.RowIndex].Cells["message"].Value.ToString();
            }
        }

        private void btnAddNotification_Click(object sender, EventArgs e)
        {
            NotificationEditForm addForm = new NotificationEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadNotifications(txtSearch.Text, cmbStatus.Text);
            }
        }

        private void btnEditNotification_Click(object sender, EventArgs e)
        {
            if (selectedNotificationId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectNotification,
                    AppResources.SelectionRequired);
                return;
            }

            NotificationEditForm editForm = new NotificationEditForm(selectedNotificationId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadNotifications(txtSearch.Text, cmbStatus.Text);
            }
        }

        private void btnDeleteNotification_Click(object sender, EventArgs e)
        {
            if (selectedNotificationId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectNotification,
                    AppResources.SelectionRequired);
                return;
            }

            //biztos törli?
            if (AppResources.ShowConfirmation(
                AppResources.ConfirmDeleteNotification,
                AppResources.DeleteNotification))
            {
                try
                {
                    string query = "DELETE FROM notifications WHERE notification_id = " + selectedNotificationId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.NotificationDeleteSuccess,
                            AppResources.SuccessTitle);

                        LoadNotifications(txtSearch.Text, cmbStatus.Text);
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
                        "Error deleting notification: " + ex.Message,
                        AppResources.ErrorTitle,
                        true);
                }
            }
        }

        private void btnMarkAsRead_Click(object sender, EventArgs e)
        {
            ChangeNotificationStatus("read");
        }

        private void btnMarkAsUnread_Click(object sender, EventArgs e)
        {
            ChangeNotificationStatus("unread");
        }

        private void ChangeNotificationStatus(string status)
        {
            if (selectedNotificationId <= 0)
            {
                AppResources.ShowMessage(
                    AppResources.SelectNotification,
                    AppResources.SelectionRequired);
                return;
            }

            try
            {
                string query = "UPDATE notifications SET status = '" + status + "' WHERE notification_id = " + selectedNotificationId;
                int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                if (rowsAffected > 0)
                {
                    LoadNotifications(txtSearch.Text, cmbStatus.Text);
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
                    "Error status: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }
    }
}