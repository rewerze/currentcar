using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarRentalAdmin
{
    public partial class UserEditForm : Form
    {
        private int userId = 0;
        private string profilePicturePath = string.Empty;

        public UserEditForm(int id = 0)
        {
            InitializeComponent();
            userId = id;

            //Console.WriteLine("UserEditForm létrehozva : " + userId);
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("UserEditForm_Load uid: " + userId);

            if (userId > 0)
            {
                // Szerkesztés mód
                LoadUserData();
                this.Text = AppResources.EditUser;
                lblPassword.Text = AppResources.PasswordKeepCurrent;
                btnBrowse.Visible = true;
                lblProfilePicture.Visible = false;
                picProfilePicture.Visible = true;
            }
            else
            {
                // Hozzáadás mód
                this.Text = AppResources.AddUser;
                dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
                dtpLicenseExpiry.Value = DateTime.Now.AddYears(5);
                btnBrowse.Visible = false;
                lblProfilePicture.Visible = false;
                picProfilePicture.Visible = true;
            }
        }

        private void LoadUserData()
        {
            try
            {
                string query = "SELECT * FROM user WHERE user_id = " + userId;
                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["user_name"].ToString();
                    txtEmail.Text = row["user_email"].ToString();
                    txtPhone.Text = row["u_phone_number"].ToString();
                    txtAreaCode.Text = row["user_areacode"].ToString();
                    DateTime born = Convert.ToDateTime(row["born_at"]);
                    dtpDateOfBirth.Text = born.Date.ToString("yyyy-MM-dd");
                    cmbRole.Text = row["user_role"].ToString();
                    txtLicenseNumber.Text = row["driver_license_number"].ToString();
                    if (string.IsNullOrEmpty($"{row["driver_license_expiry"]}"))
                    {
                        dtpLicenseExpiry.Text = DateTime.Now.ToString();
                    }
                    else
                    {
                        DateTime expire = Convert.ToDateTime(row["driver_license_expiry"]);
                        dtpLicenseExpiry.Text = expire.Date.ToString("yyyy-MM-dd");
                    }
                    txtIBAN.Text = row["user_iban"].ToString();
                    profilePicturePath = row["profile_picture"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["user_active"]);

                    //Console.WriteLine("User data loaded successfully for ID: " + userId);

                    if (!string.IsNullOrEmpty(profilePicturePath))
                    {
                        try
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                byte[] imageData = webClient.DownloadData("http://localhost:3000/api/uploads/profile-pictures/" + profilePicturePath);
                                using (var ms = new MemoryStream(imageData))
                                {
                                    Image image = Image.FromStream(ms);

                                    picProfilePicture.Image = image;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Hiba a kép betöltésekor: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(AppResources.UserNotFound, AppResources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(AppResources.ShowMessage(AppResources.ErrorLoadingUserData + ": " + ex.Message,
                    AppResources.ErrorTitle, true));
                //Console.WriteLine("Hiba felhasználó adatbetöltés: " + ex.Message);
                this.Close();
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            profilePicturePath = null;
            MessageBox.Show("A profilkép törlési értéke mentésre került.","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            //    openFileDialog.Title = "Select Profile Picture";

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        profilePicturePath = openFileDialog.FileName;
            //        try
            //        {
            //            using (var img = Image.FromFile(profilePicturePath))
            //            {
            //                picProfilePicture.Image = new Bitmap(img);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error loading image: " + ex.Message, "Error",
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Bemenet validálása
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) /*||
                string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtAreaCode.Text) ||
                string.IsNullOrEmpty(txtLicenseNumber.Text)*/)
            {
                MessageBox.Show(AppResources.ValidationError,
                    AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Felhasználó hozzáadása vagy frissítése
            if (userId > 0)
            {
                UpdateUser();
            }
            else
            {
                AddUser();
            }
        }

        private void AddUser()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Új felhasználó megadásakor jelszó megadása kötelező!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hash jelszó
                string hashedPassword = AuthService.HashPassword(txtPassword.Text);
                // pfp felvétel
                string profilePic = string.IsNullOrEmpty(profilePicturePath) ? null : profilePicturePath;
                //formátum
                string bornDate = dtpDateOfBirth.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string licenseExpiryDate = dtpLicenseExpiry.Value.ToString("yyyy-MM-dd");

                string query = "INSERT INTO user (user_email, user_name, password, born_at, created_at, updated_at, " +
                               "user_active, u_phone_number, user_areacode, user_role, driver_license_number, " +
                               "driver_license_expiry, profile_picture, user_iban) " +
                               "VALUES (@email, @name, @password, @born, NOW(), NOW(), @active, @phone, @areacode, " +
                               "@role, @license, @expiry, @picture, @iban)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@email", txtEmail.Text },
                    { "@name", txtName.Text },
                    { "@password", hashedPassword },
                    { "@born", bornDate },
                    { "@active", chkActive.Checked ? 1 : 0 },
                    { "@phone", txtPhone.Text },
                    { "@areacode", txtAreaCode.Text },
                    { "@role", cmbRole.Text },
                    { "@license", txtLicenseNumber.Text },
                    { "@expiry", licenseExpiryDate },
                    { "@picture", profilePic },
                    { "@iban", txtIBAN.Text }
                };

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Felhasználó sikeresen hozzáadva", AppResources.SuccessTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hiba a felhasználó hozzáadásakor!", AppResources.ErrorTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba felhasználó hozzáadásakor: " + ex.Message, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("HIBA AddUser: " + ex.Message);
            }
        }

        private void UpdateUser()
        {
            try
            {
                //Console.WriteLine("id frissítés, id: " + userId);

                // pfp utvonal
                string profilePic = string.IsNullOrEmpty(profilePicturePath) ? null : profilePicturePath;

                // dátum formátum beállítása
                string bornDate = dtpDateOfBirth.Value.ToString("yyyy-MM-dd");
                string licenseExpiryDate = dtpLicenseExpiry.Value.ToString("yyyy-MM-dd");

                string query = "UPDATE user SET user_email = @email, user_name = @name, ";

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@email", txtEmail.Text);
                parameters.Add("@name", txtName.Text);

                //Csak akkor frissítse a jelszót, ha meg van adva
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    string hashedPassword = AuthService.HashPassword(txtPassword.Text);
                    query += "password = @password, ";
                    parameters.Add("@password", hashedPassword);
                }

                query += "born_at = @born, updated_at = NOW(), user_active = @active, " +
                     "u_phone_number = @phone, user_areacode = @areacode, user_role = @role, " +
                     "driver_license_number = @license, driver_license_expiry = @expiry, " +
                     "profile_picture = @picture, user_iban = @iban WHERE user_id = @id";

                // további értékek
                parameters.Add("@born", bornDate);
                parameters.Add("@active", chkActive.Checked ? 1 : 0);
                parameters.Add("@phone", txtPhone.Text);
                parameters.Add("@areacode", txtAreaCode.Text);
                parameters.Add("@role", cmbRole.Text);
                parameters.Add("@license", txtLicenseNumber.Text);
                parameters.Add("@expiry", licenseExpiryDate);
                parameters.Add("@picture", profilePic);
                parameters.Add("@id", userId);
                parameters.Add("@iban", txtIBAN.Text);

                int rowsAffected = DatabaseOptimizer.ExecuteParameterizedNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Felhasználó adatai sikeresen frissítve", AppResources.SuccessTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nem sikerült frissíteni a felhasználót, vagy nem történt módosítás.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hiba, felhasználó frissítésekor: " + ex.Message, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Error" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}