namespace CarRentalAdmin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnComments = new System.Windows.Forms.Button();
            this.btnReviews = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnCars = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelOrdersStats = new System.Windows.Forms.Panel();
            this.lblOrdersCount = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.panelCarsStats = new System.Windows.Forms.Panel();
            this.lblCarsCount = new System.Windows.Forms.Label();
            this.lblCarsTitle = new System.Windows.Forms.Label();
            this.panelUsersStats = new System.Windows.Forms.Panel();
            this.lblUsersCount = new System.Windows.Forms.Label();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.panelOrdersStats.SuspendLayout();
            this.panelCarsStats.SuspendLayout();
            this.panelUsersStats.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelSideMenu.Controls.Add(this.btnLogout);
            this.panelSideMenu.Controls.Add(this.btnNotifications);
            this.panelSideMenu.Controls.Add(this.btnComments);
            this.panelSideMenu.Controls.Add(this.btnReviews);
            this.panelSideMenu.Controls.Add(this.btnOrders);
            this.panelSideMenu.Controls.Add(this.btnCars);
            this.panelSideMenu.Controls.Add(this.btnUsers);
            this.panelSideMenu.Controls.Add(this.btnDashboard);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(188, 569);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 528);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(188, 41);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Kijelentkezés";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNotifications
            // 
            this.btnNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotifications.ForeColor = System.Drawing.Color.White;
            this.btnNotifications.Location = new System.Drawing.Point(0, 327);
            this.btnNotifications.Margin = new System.Windows.Forms.Padding(2);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnNotifications.Size = new System.Drawing.Size(188, 41);
            this.btnNotifications.TabIndex = 7;
            this.btnNotifications.Text = "Értesítések";
            this.btnNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotifications.UseVisualStyleBackColor = false;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnComments
            // 
            this.btnComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComments.FlatAppearance.BorderSize = 0;
            this.btnComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComments.ForeColor = System.Drawing.Color.White;
            this.btnComments.Location = new System.Drawing.Point(0, 286);
            this.btnComments.Margin = new System.Windows.Forms.Padding(2);
            this.btnComments.Name = "btnComments";
            this.btnComments.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnComments.Size = new System.Drawing.Size(188, 41);
            this.btnComments.TabIndex = 6;
            this.btnComments.Text = "Hozzászólások";
            this.btnComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComments.UseVisualStyleBackColor = false;
            this.btnComments.Click += new System.EventHandler(this.btnComments_Click);
            // 
            // btnReviews
            // 
            this.btnReviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReviews.FlatAppearance.BorderSize = 0;
            this.btnReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReviews.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReviews.ForeColor = System.Drawing.Color.White;
            this.btnReviews.Location = new System.Drawing.Point(0, 245);
            this.btnReviews.Margin = new System.Windows.Forms.Padding(2);
            this.btnReviews.Name = "btnReviews";
            this.btnReviews.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnReviews.Size = new System.Drawing.Size(188, 41);
            this.btnReviews.TabIndex = 5;
            this.btnReviews.Text = "Értékelések";
            this.btnReviews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReviews.UseVisualStyleBackColor = false;
            this.btnReviews.Click += new System.EventHandler(this.btnReviews_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.Location = new System.Drawing.Point(0, 204);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOrders.Size = new System.Drawing.Size(188, 41);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "Rendelések";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnCars
            // 
            this.btnCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCars.FlatAppearance.BorderSize = 0;
            this.btnCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCars.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCars.ForeColor = System.Drawing.Color.White;
            this.btnCars.Location = new System.Drawing.Point(0, 163);
            this.btnCars.Margin = new System.Windows.Forms.Padding(2);
            this.btnCars.Name = "btnCars";
            this.btnCars.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCars.Size = new System.Drawing.Size(188, 41);
            this.btnCars.TabIndex = 3;
            this.btnCars.Text = "Autók";
            this.btnCars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCars.UseVisualStyleBackColor = false;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(0, 122);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(188, 41);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Felhasználók";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 81);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(188, 41);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Irányítópult";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelLogo.Controls.Add(this.lblAdminName);
            this.panelLogo.Controls.Add(this.lblAppName);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(188, 81);
            this.panelLogo.TabIndex = 0;
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.Color.LightGray;
            this.lblAdminName.Location = new System.Drawing.Point(9, 49);
            this.lblAdminName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(71, 13);
            this.lblAdminName.TabIndex = 1;
            this.lblAdminName.Text = "Admin Panel";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(9, 24);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(96, 21);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "CurRentCar";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.panelDashboard);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(188, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(712, 569);
            this.panelContent.TabIndex = 1;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.panelOrdersStats);
            this.panelDashboard.Controls.Add(this.panelCarsStats);
            this.panelDashboard.Controls.Add(this.panelUsersStats);
            this.panelDashboard.Controls.Add(this.lblWelcome);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(0, 49);
            this.panelDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelDashboard.Size = new System.Drawing.Size(712, 520);
            this.panelDashboard.TabIndex = 1;
            // 
            // panelOrdersStats
            // 
            this.panelOrdersStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.panelOrdersStats.Controls.Add(this.lblOrdersCount);
            this.panelOrdersStats.Controls.Add(this.lblOrdersTitle);
            this.panelOrdersStats.Location = new System.Drawing.Point(480, 81);
            this.panelOrdersStats.Margin = new System.Windows.Forms.Padding(2);
            this.panelOrdersStats.Name = "panelOrdersStats";
            this.panelOrdersStats.Size = new System.Drawing.Size(188, 122);
            this.panelOrdersStats.TabIndex = 3;
            // 
            // lblOrdersCount
            // 
            this.lblOrdersCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersCount.ForeColor = System.Drawing.Color.White;
            this.lblOrdersCount.Location = new System.Drawing.Point(0, 41);
            this.lblOrdersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdersCount.Name = "lblOrdersCount";
            this.lblOrdersCount.Size = new System.Drawing.Size(188, 41);
            this.lblOrdersCount.TabIndex = 1;
            this.lblOrdersCount.Text = "0";
            this.lblOrdersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.White;
            this.lblOrdersTitle.Location = new System.Drawing.Point(0, 12);
            this.lblOrdersTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(188, 24);
            this.lblOrdersTitle.TabIndex = 0;
            this.lblOrdersTitle.Text = "Aktív rendelések";
            this.lblOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCarsStats
            // 
            this.panelCarsStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(151)))), ((int)(((byte)(78)))));
            this.panelCarsStats.Controls.Add(this.lblCarsCount);
            this.panelCarsStats.Controls.Add(this.lblCarsTitle);
            this.panelCarsStats.Location = new System.Drawing.Point(262, 81);
            this.panelCarsStats.Margin = new System.Windows.Forms.Padding(2);
            this.panelCarsStats.Name = "panelCarsStats";
            this.panelCarsStats.Size = new System.Drawing.Size(188, 122);
            this.panelCarsStats.TabIndex = 2;
            // 
            // lblCarsCount
            // 
            this.lblCarsCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarsCount.ForeColor = System.Drawing.Color.White;
            this.lblCarsCount.Location = new System.Drawing.Point(0, 41);
            this.lblCarsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsCount.Name = "lblCarsCount";
            this.lblCarsCount.Size = new System.Drawing.Size(188, 41);
            this.lblCarsCount.TabIndex = 1;
            this.lblCarsCount.Text = "0";
            this.lblCarsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarsTitle
            // 
            this.lblCarsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarsTitle.ForeColor = System.Drawing.Color.White;
            this.lblCarsTitle.Location = new System.Drawing.Point(0, 12);
            this.lblCarsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarsTitle.Name = "lblCarsTitle";
            this.lblCarsTitle.Size = new System.Drawing.Size(188, 24);
            this.lblCarsTitle.TabIndex = 0;
            this.lblCarsTitle.Text = "Elérhető autók";
            this.lblCarsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelUsersStats
            // 
            this.panelUsersStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.panelUsersStats.Controls.Add(this.lblUsersCount);
            this.panelUsersStats.Controls.Add(this.lblUsersTitle);
            this.panelUsersStats.Location = new System.Drawing.Point(45, 81);
            this.panelUsersStats.Margin = new System.Windows.Forms.Padding(2);
            this.panelUsersStats.Name = "panelUsersStats";
            this.panelUsersStats.Size = new System.Drawing.Size(188, 122);
            this.panelUsersStats.TabIndex = 1;
            // 
            // lblUsersCount
            // 
            this.lblUsersCount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersCount.ForeColor = System.Drawing.Color.White;
            this.lblUsersCount.Location = new System.Drawing.Point(0, 41);
            this.lblUsersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsersCount.Name = "lblUsersCount";
            this.lblUsersCount.Size = new System.Drawing.Size(188, 41);
            this.lblUsersCount.TabIndex = 1;
            this.lblUsersCount.Text = "0";
            this.lblUsersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersTitle.ForeColor = System.Drawing.Color.White;
            this.lblUsersTitle.Location = new System.Drawing.Point(0, 12);
            this.lblUsersTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(188, 24);
            this.lblUsersTitle.TabIndex = 0;
            this.lblUsersTitle.Text = "Regisztrált felhasználók";
            this.lblUsersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(15, 16);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(336, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Üdvözöljük az Autókölcsönző Admin Panel-ben";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(712, 49);
            this.panelHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(15, 12);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(90, 21);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Irányítópult";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 569);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSideMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(754, 495);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autókölcsönző Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelDashboard.PerformLayout();
            this.panelOrdersStats.ResumeLayout(false);
            this.panelCarsStats.ResumeLayout(false);
            this.panelUsersStats.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnReviews;
        private System.Windows.Forms.Button btnComments;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelUsersStats;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.Label lblUsersCount;
        private System.Windows.Forms.Panel panelCarsStats;
        private System.Windows.Forms.Label lblCarsCount;
        private System.Windows.Forms.Label lblCarsTitle;
        private System.Windows.Forms.Panel panelOrdersStats;
        private System.Windows.Forms.Label lblOrdersCount;
        private System.Windows.Forms.Label lblOrdersTitle;

        // References to child forms
        private UserManageForm userManageForm;
        private CarManageForm carManageForm;
        private OrderManageForm orderManageForm;
        private ReviewManageForm reviewManageForm;
        private CommentManageForm commentManageForm;
        private NotificationManageForm notificationManageForm;
    }
}