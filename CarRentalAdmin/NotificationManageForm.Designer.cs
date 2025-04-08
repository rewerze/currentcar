namespace CarRentalAdmin
{
    partial class NotificationManageForm
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnMarkAsUnread = new System.Windows.Forms.Button();
            this.btnMarkAsRead = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteNotification = new System.Windows.Forms.Button();
            this.btnEditNotification = new System.Windows.Forms.Button();
            this.btnAddNotification = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.txtNotificationMessage = new System.Windows.Forms.TextBox();
            this.lblNotificationDetails = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.btnMarkAsUnread);
            this.panelControls.Controls.Add(this.btnMarkAsRead);
            this.panelControls.Controls.Add(this.lblStatus);
            this.panelControls.Controls.Add(this.cmbStatus);
            this.panelControls.Controls.Add(this.btnSearch);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnDeleteNotification);
            this.panelControls.Controls.Add(this.btnEditNotification);
            this.panelControls.Controls.Add(this.btnAddNotification);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(712, 49);
            this.panelControls.TabIndex = 0;
            // 
            // btnMarkAsUnread
            // 
            this.btnMarkAsUnread.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMarkAsUnread.FlatAppearance.BorderSize = 0;
            this.btnMarkAsUnread.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsUnread.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkAsUnread.ForeColor = System.Drawing.Color.White;
            this.btnMarkAsUnread.Location = new System.Drawing.Point(296, 12);
            this.btnMarkAsUnread.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarkAsUnread.Name = "btnMarkAsUnread";
            this.btnMarkAsUnread.Size = new System.Drawing.Size(34, 24);
            this.btnMarkAsUnread.TabIndex = 8;
            this.btnMarkAsUnread.Text = "✗";
            this.btnMarkAsUnread.UseVisualStyleBackColor = false;
            this.btnMarkAsUnread.Click += new System.EventHandler(this.btnMarkAsUnread_Click);
            // 
            // btnMarkAsRead
            // 
            this.btnMarkAsRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMarkAsRead.FlatAppearance.BorderSize = 0;
            this.btnMarkAsRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsRead.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkAsRead.ForeColor = System.Drawing.Color.White;
            this.btnMarkAsRead.Location = new System.Drawing.Point(259, 12);
            this.btnMarkAsRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarkAsRead.Name = "btnMarkAsRead";
            this.btnMarkAsRead.Size = new System.Drawing.Size(34, 24);
            this.btnMarkAsRead.TabIndex = 7;
            this.btnMarkAsRead.Text = "✓";
            this.btnMarkAsRead.UseVisualStyleBackColor = false;
            this.btnMarkAsRead.Click += new System.EventHandler(this.btnMarkAsRead_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(548, 15);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Állapot";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Összes",
            "Olvasott",
            "Olvasatlan"});
            this.cmbStatus.Location = new System.Drawing.Point(597, 11);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(91, 23);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.Text = "Összes";
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(480, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Keresés";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(338, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(136, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnDeleteNotification
            // 
            this.btnDeleteNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnDeleteNotification.FlatAppearance.BorderSize = 0;
            this.btnDeleteNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteNotification.ForeColor = System.Drawing.Color.White;
            this.btnDeleteNotification.Location = new System.Drawing.Point(169, 2);
            this.btnDeleteNotification.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteNotification.Name = "btnDeleteNotification";
            this.btnDeleteNotification.Size = new System.Drawing.Size(75, 43);
            this.btnDeleteNotification.TabIndex = 2;
            this.btnDeleteNotification.Text = "Értesítés törlése";
            this.btnDeleteNotification.UseVisualStyleBackColor = false;
            this.btnDeleteNotification.Click += new System.EventHandler(this.btnDeleteNotification_Click);
            // 
            // btnEditNotification
            // 
            this.btnEditNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditNotification.FlatAppearance.BorderSize = 0;
            this.btnEditNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditNotification.ForeColor = System.Drawing.Color.White;
            this.btnEditNotification.Location = new System.Drawing.Point(90, 2);
            this.btnEditNotification.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditNotification.Name = "btnEditNotification";
            this.btnEditNotification.Size = new System.Drawing.Size(75, 43);
            this.btnEditNotification.TabIndex = 1;
            this.btnEditNotification.Text = "Értesítés szerkesztése";
            this.btnEditNotification.UseVisualStyleBackColor = false;
            this.btnEditNotification.Click += new System.EventHandler(this.btnEditNotification_Click);
            // 
            // btnAddNotification
            // 
            this.btnAddNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddNotification.FlatAppearance.BorderSize = 0;
            this.btnAddNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotification.ForeColor = System.Drawing.Color.White;
            this.btnAddNotification.Location = new System.Drawing.Point(11, 2);
            this.btnAddNotification.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddNotification.Name = "btnAddNotification";
            this.btnAddNotification.Size = new System.Drawing.Size(75, 43);
            this.btnAddNotification.TabIndex = 0;
            this.btnAddNotification.Text = "Értesítés hozzáadása";
            this.btnAddNotification.UseVisualStyleBackColor = false;
            this.btnAddNotification.Click += new System.EventHandler(this.btnAddNotification_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvNotifications);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(712, 309);
            this.panelData.TabIndex = 1;
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.AllowUserToAddRows = false;
            this.dgvNotifications.AllowUserToDeleteRows = false;
            this.dgvNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotifications.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotifications.Location = new System.Drawing.Point(11, 12);
            this.dgvNotifications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvNotifications.MultiSelect = false;
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.ReadOnly = true;
            this.dgvNotifications.RowHeadersWidth = 51;
            this.dgvNotifications.RowTemplate.Height = 24;
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(690, 285);
            this.dgvNotifications.TabIndex = 0;
            this.dgvNotifications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotifications_CellClick);
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.txtNotificationMessage);
            this.panelDetails.Controls.Add(this.lblNotificationDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetails.Location = new System.Drawing.Point(0, 358);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelDetails.Size = new System.Drawing.Size(712, 162);
            this.panelDetails.TabIndex = 2;
            // 
            // txtNotificationMessage
            // 
            this.txtNotificationMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotificationMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotificationMessage.Location = new System.Drawing.Point(11, 37);
            this.txtNotificationMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNotificationMessage.Multiline = true;
            this.txtNotificationMessage.Name = "txtNotificationMessage";
            this.txtNotificationMessage.ReadOnly = true;
            this.txtNotificationMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotificationMessage.Size = new System.Drawing.Size(691, 114);
            this.txtNotificationMessage.TabIndex = 1;
            // 
            // lblNotificationDetails
            // 
            this.lblNotificationDetails.AutoSize = true;
            this.lblNotificationDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationDetails.Location = new System.Drawing.Point(11, 12);
            this.lblNotificationDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotificationDetails.Name = "lblNotificationDetails";
            this.lblNotificationDetails.Size = new System.Drawing.Size(124, 19);
            this.lblNotificationDetails.TabIndex = 0;
            this.lblNotificationDetails.Text = "Értesítés részletei";
            // 
            // NotificationManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NotificationManageForm";
            this.Text = "Értesítés kezelés";
            this.Load += new System.EventHandler(this.NotificationManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddNotification;
        private System.Windows.Forms.Button btnEditNotification;
        private System.Windows.Forms.Button btnDeleteNotification;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnMarkAsRead;
        private System.Windows.Forms.Button btnMarkAsUnread;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblNotificationDetails;
        private System.Windows.Forms.TextBox txtNotificationMessage;
    }
}