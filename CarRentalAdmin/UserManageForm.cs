using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalAdmin
{
    public partial class UserManageForm : Form
    {
        private int selectedUserId = 0;

        public UserManageForm()
        {
            InitializeComponent();
        }

        private void UserManageForm_Load(object sender, EventArgs e)
        {
            LoadUsers();

            btnEditUser.Enabled = false;
            btnDeleteUser.Enabled = false;
        }

        // adat betöltés
        private void LoadUsers(string searchTerm = "", string role = "All")
        {
            try
            {
                string query = "SELECT user_id, user_name, user_email, u_phone_number, born_at, user_role, user_active, user_iban " +
                              "FROM user WHERE 1=1";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND (user_name LIKE '%" + searchTerm + "%' OR user_email LIKE '%" + searchTerm + "%')";
                }

                if (role != "All" && role != "Összes")
                {
                    query += " AND user_role = '" + role.ToLower() + "'";
                }

                DataTable dt = DatabaseOptimizer.ExecuteQuery(query);
                dgvUsers.DataSource = dt;

                // dgv fejléc nevek (en/hu "inprogress")
                if (dgvUsers.Columns.Count > 0)
                {
                    dgvUsers.Columns["user_id"].HeaderText = "ID";
                    dgvUsers.Columns["user_name"].HeaderText = AppResources.Name;
                    dgvUsers.Columns["user_email"].HeaderText = AppResources.Email;
                    dgvUsers.Columns["u_phone_number"].HeaderText = AppResources.Phone;
                    dgvUsers.Columns["born_at"].HeaderText = AppResources.DateOfBirth;
                    dgvUsers.Columns["user_role"].HeaderText = AppResources.Role;
                    dgvUsers.Columns["user_active"].HeaderText = AppResources.Active;
                    dgvUsers.Columns["born_at"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvUsers.Columns["user_iban"].HeaderText = AppResources.IBAN;
                }

                //alaphelyzet
                selectedUserId = 0;
                btnEditUser.Enabled = false;
                btnDeleteUser.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a felhasználók betöltésekor: " + ex.Message, AppResources.ErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text, cmbUserRole.Text);
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text, cmbUserRole.Text);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUsers.Rows.Count)
            {
                //valid e a user id?
                if (dgvUsers.Rows[e.RowIndex].Cells["user_id"].Value != null)
                {
                    try
                    {
                        selectedUserId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["user_id"].Value);
                        btnEditUser.Enabled = true;
                        btnDeleteUser.Enabled = true;

                       // Console.WriteLine("ID: " + selectedUserId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hiba felhasználó kiválasztásakor: " + ex.Message, AppResources.SelectionRequired,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedUserId = 0;
                        btnEditUser.Enabled = false;
                        btnDeleteUser.Enabled = false;
                    }
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserEditForm addForm = new UserEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(txtSearch.Text, cmbUserRole.Text);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId <= 0)
            {
                MessageBox.Show(AppResources.SelectUser, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // User edit form meghívás, a kiválasztott felhasználó ID-vel
            UserEditForm editForm = new UserEditForm(selectedUserId);
            DialogResult result = editForm.ShowDialog();

            // Ha OK-ra kattintott (felhasználó mentette a változásokat), frissítsük a listát
            if (result == DialogResult.OK)
            {
                LoadUsers(txtSearch.Text, cmbUserRole.Text);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId <= 0)
            {
                MessageBox.Show(AppResources.SelectUser, AppResources.SelectionRequired,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Törlés megerősítése
            DialogResult result = MessageBox.Show(AppResources.ConfirmDeleteUser,
                AppResources.DeleteUser, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE user SET user_active = 0, updated_at = NOW() WHERE user_id = " + selectedUserId;
                    int rowsAffected = DatabaseOptimizer.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(AppResources.UserDeleteSuccess, AppResources.SuccessTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Frissítjük a felhasználói listát
                        LoadUsers(txtSearch.Text, cmbUserRole.Text);
                    }
                    else
                    {
                        MessageBox.Show(AppResources.OperationFailed, AppResources.ErrorTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AppResources.ShowMessage("Hiba a felhasználó törlésekor: " + ex.Message,
                        AppResources.ErrorTitle, true));
                }
            }
        }
    }
}