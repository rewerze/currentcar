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
    public partial class NotificationEditForm : Form
    {
        private int notificationId = 0;

        public NotificationEditForm(int id = 0)
        {
            InitializeComponent();
            notificationId = id;
        }

        private void NotificationEditForm_Load(object sender, EventArgs e)
        {
            // felhasználók betöltése
            LoadUsers();

            cmbStatus.SelectedIndex = 1;

            if (notificationId > 0)
            {
                // szerkesztés mód
                this.Text = AppResources.EditNotification;
                LoadNotificationData();
            }
            else
            {
                // hozzáadás mód
                this.Text = AppResources.AddNotification;
            }
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT user_id, user_name, user_email FROM user WHERE user_active = 1";
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                // combobox értékek
                cmbUser.DisplayMember = "Text";
                cmbUser.ValueMember = "Value";
                cmbUser.Items.Clear();

                // felhasználók hozzáadása
                foreach (DataRow row in dt.Rows)
                {
                    string text = $"{row["user_name"]} ({row["user_email"]})";
                    int id = Convert.ToInt32(row["user_id"]);

                    var item = new { Text = text, Value = id };

                    cmbUser.Items.Add(item);
                }
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

        private void LoadNotificationData()
        {
            try
            {
                string query = "SELECT * FROM notifications WHERE notification_id = " + notificationId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                //értesítés adatának betöltése
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int userId = Convert.ToInt32(row["user_id"]);

                    SelectComboboxItem(cmbUser, userId);
                    string status = row["status"].ToString();
                    cmbStatus.SelectedIndex = (status == "read") ? 0 : 1;
                    txtMessage.Text = row["message"].ToString();
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
                    "Error loading notification: " + ex.Message,
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
            //input validáció
            if (cmbUser.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                AppResources.ShowMessage(
                    AppResources.ValidationError,
                    AppResources.ErrorTitle,
                    true);
                return;
            }

            dynamic user = cmbUser.SelectedItem;
            int userId = user.Value;
            string status = AppResources.Notificationen[cmbStatus.SelectedIndex];

            try
            {
                if (notificationId > 0)
                {
                    //kiválasztott értesítés frissítése
                    string query =
                        "UPDATE notifications SET " +
                        "user_id = @userId, " +
                        "message = @message, " +
                        "status = @status " +
                        "WHERE notification_id = @notificationId";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@userId", userId },
                        { "@message", txtMessage.Text },
                        { "@status", status },
                        { "@notificationId", notificationId }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.NotificationUpdateSuccess,
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
                    // értesítés hozzáadása
                    string query =
                        "INSERT INTO notifications " +
                        "(user_id, message, status, created_at) " +
                        "VALUES (@userId, @message, @status, NOW())";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@userId", userId },
                        { "@message", txtMessage.Text },
                        { "@status", status }
                    };

                    int result = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                    if (result > 0)
                    {
                        AppResources.ShowMessage(
                            AppResources.NotificationAddSuccess,
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
                    "Error saving notification: " + ex.Message,
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
