using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // input validáció
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError(AppResources.EnterEmailPassword);
                return;
            }

            //authentikáció
            int userId;
            string role;
            bool isAuthenticated = AuthService.AuthenticateUser(email, password, out userId, out role);

            if (isAuthenticated && role.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                ShowError(AppResources.LoginError);
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}