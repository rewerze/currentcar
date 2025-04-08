using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace CarRentalAdmin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Form activeForm = null;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!AuthService.IsAdmin())
            {
                AppResources.ShowMessage(
                    "Adminisztrátorként kell hogy bejelentkezve legyél!",
                    "Authentication HIBA",
                    true);
                this.Close();
                return;
            }
            SetupHungarianUI();

            LoadDashboardData();
        }

        private void SetupHungarianUI()
        {
            this.Text = AppResources.ApplicationTitle;
            lblPageTitle.Text = AppResources.Dashboard;
            lblWelcome.Text = AppResources.WelcomeMessage;
            lblUsersTitle.Text = AppResources.RegisteredUsers;
            lblCarsTitle.Text = AppResources.AvailableCars;
            lblOrdersTitle.Text = AppResources.ActiveOrders;

            btnDashboard.Text = AppResources.Dashboard;
            btnUsers.Text = AppResources.Users;
            btnCars.Text = AppResources.Cars;
            btnOrders.Text = AppResources.Orders;
            btnReviews.Text = AppResources.Reviews;
            btnComments.Text = AppResources.Comments;
            btnNotifications.Text = AppResources.Notifications;
            btnLogout.Text = AppResources.Logout;
        }

        // Statisztika betöltése
        private void LoadDashboardData()
        {
            try
            {
                string userCountQuery = "SELECT COUNT(*) FROM user WHERE user_active = 1";
                object userCount = DatabaseOptimizer.ExecuteScalar(userCountQuery);
                lblUsersCount.Text = userCount?.ToString() ?? "0";

                string carCountQuery = "SELECT COUNT(*) FROM car WHERE car_active = 1";
                object carCount = DatabaseOptimizer.ExecuteScalar(carCountQuery);
                lblCarsCount.Text = carCount?.ToString() ?? "0";

                string orderCountQuery = "SELECT COUNT(*) FROM orders WHERE rental_status IN ('pending', 'confirmed')";
                object orderCount = DatabaseOptimizer.ExecuteScalar(orderCountQuery);
                lblOrdersCount.Text = orderCount?.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                AppResources.ShowMessage(
                    "Error loading dashboard: " + ex.Message,
                    AppResources.ErrorTitle,
                    true);
            }
        }

        // alformok betöltése
        private void OpenChildForm(Form childForm, string title)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Remove(panelDashboard);
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;

            lblPageTitle.Text = title;
            childForm.BringToFront();
            childForm.Show();
        }

        // Gombok
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
                activeForm = null;
            }

            lblPageTitle.Text = AppResources.Dashboard;
            panelContent.Controls.Add(panelDashboard);
            panelDashboard.BringToFront();

            LoadDashboardData();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (userManageForm == null || userManageForm.IsDisposed)
            {
                userManageForm = new UserManageForm();
            }

            OpenChildForm(userManageForm, AppResources.UserManagement);
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            if (carManageForm == null || carManageForm.IsDisposed)
            {
                carManageForm = new CarManageForm();
            }

            OpenChildForm(carManageForm, AppResources.CarManagement);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (orderManageForm == null || orderManageForm.IsDisposed)
            {
                orderManageForm = new OrderManageForm();
            }

            OpenChildForm(orderManageForm, AppResources.OrderManagement);
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            if (reviewManageForm == null || reviewManageForm.IsDisposed)
            {
                reviewManageForm = new ReviewManageForm();
            }

            OpenChildForm(reviewManageForm, AppResources.ReviewManagement);
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            if (commentManageForm == null || commentManageForm.IsDisposed)
            {
                commentManageForm = new CommentManageForm();
            }

            OpenChildForm(commentManageForm, AppResources.CommentManagement);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            if (notificationManageForm == null || notificationManageForm.IsDisposed)
            {
                notificationManageForm = new NotificationManageForm();
            }

            OpenChildForm(notificationManageForm, AppResources.NotificationManagement);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // kijelentkezés
            bool result = AppResources.ShowConfirmation(
                AppResources.LogoutConfirm,
                AppResources.Logout);

            if (result)
            {
                // vissza a loginra
                AuthService.Logout();
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AuthService.Logout();
            Application.Exit();
        }
    }
}