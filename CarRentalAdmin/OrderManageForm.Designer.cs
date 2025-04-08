namespace CarRentalAdmin
{
    partial class OrderManageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.panelOrderDetails = new System.Windows.Forms.Panel();
            this.lblOrderIdLabel = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStartDateLabel = new System.Windows.Forms.Label();
            this.lblStartDateValue = new System.Windows.Forms.Label();
            this.lblEndDateLabel = new System.Windows.Forms.Label();
            this.lblEndDateValue = new System.Windows.Forms.Label();
            this.lblUserLabel = new System.Windows.Forms.Label();
            this.lblUserValue = new System.Windows.Forms.Label();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.lblEmailValue = new System.Windows.Forms.Label();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.lblPhoneValue = new System.Windows.Forms.Label();
            this.lblDiscountCodeLabel = new System.Windows.Forms.Label();
            this.lblDiscountCodeValue = new System.Windows.Forms.Label();
            this.lblCarLabel = new System.Windows.Forms.Label();
            this.lblCarValue = new System.Windows.Forms.Label();
            this.lblRegNumberLabel = new System.Windows.Forms.Label();
            this.lblRegNumberValue = new System.Windows.Forms.Label();
            this.lblPickupLocationLabel = new System.Windows.Forms.Label();
            this.lblPickupLocationValue = new System.Windows.Forms.Label();
            this.lblDropoffLocationLabel = new System.Windows.Forms.Label();
            this.lblDropoffLocationValue = new System.Windows.Forms.Label();
            this.lblPaymentStatusLabel = new System.Windows.Forms.Label();
            this.lblPaymentStatusValue = new System.Windows.Forms.Label();
            this.lblPaymentMethodLabel = new System.Windows.Forms.Label();
            this.lblPaymentMethodValue = new System.Windows.Forms.Label();
            this.lblPaymentAmountLabel = new System.Windows.Forms.Label();
            this.lblPaymentAmountValue = new System.Windows.Forms.Label();
            this.lblTaxAmountLabel = new System.Windows.Forms.Label();
            this.lblTaxAmountValue = new System.Windows.Forms.Label();
            this.lblPaymentDateLabel = new System.Windows.Forms.Label();
            this.lblPaymentDateValue = new System.Windows.Forms.Label();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Controls.Add(this.chkUseDate);
            this.panelControls.Controls.Add(this.dtpDate);
            this.panelControls.Controls.Add(this.cmbStatus);
            this.panelControls.Controls.Add(this.btnSearch);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnCancelOrder);
            this.panelControls.Controls.Add(this.btnEditOrder);
            this.panelControls.Controls.Add(this.btnAddOrder);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(712, 49);
            this.panelControls.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rendelés állapota";
            // 
            // chkUseDate
            // 
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Location = new System.Drawing.Point(591, 29);
            this.chkUseDate.Name = "chkUseDate";
            this.chkUseDate.Size = new System.Drawing.Size(126, 17);
            this.chkUseDate.TabIndex = 7;
            this.chkUseDate.Text = "Dátum alapú keresés";
            this.chkUseDate.UseVisualStyleBackColor = true;
            this.chkUseDate.CheckedChanged += new System.EventHandler(this.chkUseDate_CheckedChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(591, 4);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 23);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Összes",
            "függőben",
            "megerősítve",
            "teljesítve",
            "lemondva",
            "meghosszabbítva"});
            this.cmbStatus.Location = new System.Drawing.Point(472, 23);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(114, 23);
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
            this.btnSearch.Location = new System.Drawing.Point(408, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
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
            this.txtSearch.Location = new System.Drawing.Point(250, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnCancelOrder.FlatAppearance.BorderSize = 0;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(170, 4);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(75, 43);
            this.btnCancelOrder.TabIndex = 2;
            this.btnCancelOrder.Text = "Rendelés törlése";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditOrder.FlatAppearance.BorderSize = 0;
            this.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrder.ForeColor = System.Drawing.Color.White;
            this.btnEditOrder.Location = new System.Drawing.Point(91, 4);
            this.btnEditOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(75, 43);
            this.btnEditOrder.TabIndex = 1;
            this.btnEditOrder.Text = "Rendelés szerkesztése";
            this.btnEditOrder.UseVisualStyleBackColor = false;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddOrder.FlatAppearance.BorderSize = 0;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddOrder.Location = new System.Drawing.Point(11, 4);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(75, 43);
            this.btnAddOrder.TabIndex = 0;
            this.btnAddOrder.Text = "Rendelés hozzáadása";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvOrders);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(712, 261);
            this.panelData.TabIndex = 1;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(11, 12);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(690, 237);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.Controls.Add(this.panelOrderDetails);
            this.panelDetails.Controls.Add(this.lblDetailsTitle);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetails.Location = new System.Drawing.Point(0, 310);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelDetails.Size = new System.Drawing.Size(712, 210);
            this.panelDetails.TabIndex = 2;
            // 
            // panelOrderDetails
            // 
            this.panelOrderDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelOrderDetails.Controls.Add(this.lblOrderIdLabel);
            this.panelOrderDetails.Controls.Add(this.lblOrderIdValue);
            this.panelOrderDetails.Controls.Add(this.lblStatusLabel);
            this.panelOrderDetails.Controls.Add(this.lblStatusValue);
            this.panelOrderDetails.Controls.Add(this.lblStartDateLabel);
            this.panelOrderDetails.Controls.Add(this.lblStartDateValue);
            this.panelOrderDetails.Controls.Add(this.lblEndDateLabel);
            this.panelOrderDetails.Controls.Add(this.lblEndDateValue);
            this.panelOrderDetails.Controls.Add(this.lblUserLabel);
            this.panelOrderDetails.Controls.Add(this.lblUserValue);
            this.panelOrderDetails.Controls.Add(this.lblEmailLabel);
            this.panelOrderDetails.Controls.Add(this.lblEmailValue);
            this.panelOrderDetails.Controls.Add(this.lblPhoneLabel);
            this.panelOrderDetails.Controls.Add(this.lblPhoneValue);
            this.panelOrderDetails.Controls.Add(this.lblDiscountCodeLabel);
            this.panelOrderDetails.Controls.Add(this.lblDiscountCodeValue);
            this.panelOrderDetails.Controls.Add(this.lblCarLabel);
            this.panelOrderDetails.Controls.Add(this.lblCarValue);
            this.panelOrderDetails.Controls.Add(this.lblRegNumberLabel);
            this.panelOrderDetails.Controls.Add(this.lblRegNumberValue);
            this.panelOrderDetails.Controls.Add(this.lblPickupLocationLabel);
            this.panelOrderDetails.Controls.Add(this.lblPickupLocationValue);
            this.panelOrderDetails.Controls.Add(this.lblDropoffLocationLabel);
            this.panelOrderDetails.Controls.Add(this.lblDropoffLocationValue);
            this.panelOrderDetails.Controls.Add(this.lblPaymentStatusLabel);
            this.panelOrderDetails.Controls.Add(this.lblPaymentStatusValue);
            this.panelOrderDetails.Controls.Add(this.lblPaymentMethodLabel);
            this.panelOrderDetails.Controls.Add(this.lblPaymentMethodValue);
            this.panelOrderDetails.Controls.Add(this.lblPaymentAmountLabel);
            this.panelOrderDetails.Controls.Add(this.lblPaymentAmountValue);
            this.panelOrderDetails.Controls.Add(this.lblTaxAmountLabel);
            this.panelOrderDetails.Controls.Add(this.lblTaxAmountValue);
            this.panelOrderDetails.Controls.Add(this.lblPaymentDateLabel);
            this.panelOrderDetails.Controls.Add(this.lblPaymentDateValue);
            this.panelOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderDetails.Location = new System.Drawing.Point(11, 12);
            this.panelOrderDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelOrderDetails.Name = "panelOrderDetails";
            this.panelOrderDetails.Padding = new System.Windows.Forms.Padding(8);
            this.panelOrderDetails.Size = new System.Drawing.Size(690, 186);
            this.panelOrderDetails.TabIndex = 1;
            this.panelOrderDetails.Visible = false;
            // 
            // lblOrderIdLabel
            // 
            this.lblOrderIdLabel.AutoSize = true;
            this.lblOrderIdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrderIdLabel.Location = new System.Drawing.Point(10, 7);
            this.lblOrderIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderIdLabel.Name = "lblOrderIdLabel";
            this.lblOrderIdLabel.Size = new System.Drawing.Size(74, 15);
            this.lblOrderIdLabel.TabIndex = 0;
            this.lblOrderIdLabel.Text = "Rendelés ID";
            this.lblOrderIdLabel.Visible = false;
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderIdValue.Location = new System.Drawing.Point(122, 7);
            this.lblOrderIdValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(0, 15);
            this.lblOrderIdValue.TabIndex = 1;
            this.lblOrderIdValue.Visible = false;
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.Location = new System.Drawing.Point(371, 7);
            this.lblStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(48, 15);
            this.lblStatusLabel.TabIndex = 2;
            this.lblStatusLabel.Text = "Státusz";
            this.lblStatusLabel.Visible = false;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusValue.Location = new System.Drawing.Point(483, 7);
            this.lblStatusValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(0, 15);
            this.lblStatusValue.TabIndex = 3;
            this.lblStatusValue.Visible = false;
            // 
            // lblStartDateLabel
            // 
            this.lblStartDateLabel.AutoSize = true;
            this.lblStartDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStartDateLabel.Location = new System.Drawing.Point(10, 27);
            this.lblStartDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDateLabel.Name = "lblStartDateLabel";
            this.lblStartDateLabel.Size = new System.Drawing.Size(81, 15);
            this.lblStartDateLabel.TabIndex = 4;
            this.lblStartDateLabel.Text = "Kezdő dátum";
            this.lblStartDateLabel.Visible = false;
            // 
            // lblStartDateValue
            // 
            this.lblStartDateValue.AutoSize = true;
            this.lblStartDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDateValue.Location = new System.Drawing.Point(122, 27);
            this.lblStartDateValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDateValue.Name = "lblStartDateValue";
            this.lblStartDateValue.Size = new System.Drawing.Size(0, 15);
            this.lblStartDateValue.TabIndex = 5;
            this.lblStartDateValue.Visible = false;
            // 
            // lblEndDateLabel
            // 
            this.lblEndDateLabel.AutoSize = true;
            this.lblEndDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEndDateLabel.Location = new System.Drawing.Point(371, 27);
            this.lblEndDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndDateLabel.Name = "lblEndDateLabel";
            this.lblEndDateLabel.Size = new System.Drawing.Size(79, 15);
            this.lblEndDateLabel.TabIndex = 6;
            this.lblEndDateLabel.Text = "Végső dátum";
            this.lblEndDateLabel.Visible = false;
            // 
            // lblEndDateValue
            // 
            this.lblEndDateValue.AutoSize = true;
            this.lblEndDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDateValue.Location = new System.Drawing.Point(483, 27);
            this.lblEndDateValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndDateValue.Name = "lblEndDateValue";
            this.lblEndDateValue.Size = new System.Drawing.Size(0, 15);
            this.lblEndDateValue.TabIndex = 7;
            this.lblEndDateValue.Visible = false;
            // 
            // lblUserLabel
            // 
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserLabel.Location = new System.Drawing.Point(10, 48);
            this.lblUserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new System.Drawing.Size(70, 15);
            this.lblUserLabel.TabIndex = 8;
            this.lblUserLabel.Text = "Felhasználó";
            this.lblUserLabel.Visible = false;
            // 
            // lblUserValue
            // 
            this.lblUserValue.AutoSize = true;
            this.lblUserValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserValue.Location = new System.Drawing.Point(122, 48);
            this.lblUserValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserValue.Name = "lblUserValue";
            this.lblUserValue.Size = new System.Drawing.Size(0, 15);
            this.lblUserValue.TabIndex = 9;
            this.lblUserValue.Visible = false;
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.AutoSize = true;
            this.lblEmailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.Location = new System.Drawing.Point(371, 48);
            this.lblEmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(36, 15);
            this.lblEmailLabel.TabIndex = 10;
            this.lblEmailLabel.Text = "Email";
            this.lblEmailLabel.Visible = false;
            // 
            // lblEmailValue
            // 
            this.lblEmailValue.AutoSize = true;
            this.lblEmailValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailValue.Location = new System.Drawing.Point(483, 48);
            this.lblEmailValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailValue.Name = "lblEmailValue";
            this.lblEmailValue.Size = new System.Drawing.Size(0, 15);
            this.lblEmailValue.TabIndex = 11;
            this.lblEmailValue.Visible = false;
            // 
            // lblPhoneLabel
            // 
            this.lblPhoneLabel.AutoSize = true;
            this.lblPhoneLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhoneLabel.Location = new System.Drawing.Point(10, 68);
            this.lblPhoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhoneLabel.Name = "lblPhoneLabel";
            this.lblPhoneLabel.Size = new System.Drawing.Size(49, 15);
            this.lblPhoneLabel.TabIndex = 12;
            this.lblPhoneLabel.Text = "Telefon";
            this.lblPhoneLabel.Visible = false;
            // 
            // lblPhoneValue
            // 
            this.lblPhoneValue.AutoSize = true;
            this.lblPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhoneValue.Location = new System.Drawing.Point(122, 68);
            this.lblPhoneValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhoneValue.Name = "lblPhoneValue";
            this.lblPhoneValue.Size = new System.Drawing.Size(0, 15);
            this.lblPhoneValue.TabIndex = 13;
            this.lblPhoneValue.Visible = false;
            // 
            // lblDiscountCodeLabel
            // 
            this.lblDiscountCodeLabel.AutoSize = true;
            this.lblDiscountCodeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountCodeLabel.Location = new System.Drawing.Point(371, 68);
            this.lblDiscountCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscountCodeLabel.Name = "lblDiscountCodeLabel";
            this.lblDiscountCodeLabel.Size = new System.Drawing.Size(67, 15);
            this.lblDiscountCodeLabel.TabIndex = 14;
            this.lblDiscountCodeLabel.Text = "Kupon kód";
            this.lblDiscountCodeLabel.Visible = false;
            // 
            // lblDiscountCodeValue
            // 
            this.lblDiscountCodeValue.AutoSize = true;
            this.lblDiscountCodeValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountCodeValue.Location = new System.Drawing.Point(483, 68);
            this.lblDiscountCodeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscountCodeValue.Name = "lblDiscountCodeValue";
            this.lblDiscountCodeValue.Size = new System.Drawing.Size(0, 15);
            this.lblDiscountCodeValue.TabIndex = 15;
            this.lblDiscountCodeValue.Visible = false;
            // 
            // lblCarLabel
            // 
            this.lblCarLabel.AutoSize = true;
            this.lblCarLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCarLabel.Location = new System.Drawing.Point(10, 88);
            this.lblCarLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarLabel.Name = "lblCarLabel";
            this.lblCarLabel.Size = new System.Drawing.Size(34, 15);
            this.lblCarLabel.TabIndex = 16;
            this.lblCarLabel.Text = "Autó";
            this.lblCarLabel.Visible = false;
            // 
            // lblCarValue
            // 
            this.lblCarValue.AutoSize = true;
            this.lblCarValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCarValue.Location = new System.Drawing.Point(122, 88);
            this.lblCarValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarValue.Name = "lblCarValue";
            this.lblCarValue.Size = new System.Drawing.Size(0, 15);
            this.lblCarValue.TabIndex = 17;
            this.lblCarValue.Visible = false;
            // 
            // lblRegNumberLabel
            // 
            this.lblRegNumberLabel.AutoSize = true;
            this.lblRegNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegNumberLabel.Location = new System.Drawing.Point(371, 88);
            this.lblRegNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegNumberLabel.Name = "lblRegNumberLabel";
            this.lblRegNumberLabel.Size = new System.Drawing.Size(64, 15);
            this.lblRegNumberLabel.TabIndex = 18;
            this.lblRegNumberLabel.Text = "Rendszám";
            this.lblRegNumberLabel.Visible = false;
            // 
            // lblRegNumberValue
            // 
            this.lblRegNumberValue.AutoSize = true;
            this.lblRegNumberValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegNumberValue.Location = new System.Drawing.Point(483, 88);
            this.lblRegNumberValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegNumberValue.Name = "lblRegNumberValue";
            this.lblRegNumberValue.Size = new System.Drawing.Size(0, 15);
            this.lblRegNumberValue.TabIndex = 19;
            this.lblRegNumberValue.Visible = false;
            // 
            // lblPickupLocationLabel
            // 
            this.lblPickupLocationLabel.AutoSize = true;
            this.lblPickupLocationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPickupLocationLabel.Location = new System.Drawing.Point(10, 109);
            this.lblPickupLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPickupLocationLabel.Name = "lblPickupLocationLabel";
            this.lblPickupLocationLabel.Size = new System.Drawing.Size(81, 15);
            this.lblPickupLocationLabel.TabIndex = 20;
            this.lblPickupLocationLabel.Text = "Felvételi hely";
            this.lblPickupLocationLabel.Visible = false;
            // 
            // lblPickupLocationValue
            // 
            this.lblPickupLocationValue.AutoSize = true;
            this.lblPickupLocationValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPickupLocationValue.Location = new System.Drawing.Point(122, 109);
            this.lblPickupLocationValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPickupLocationValue.Name = "lblPickupLocationValue";
            this.lblPickupLocationValue.Size = new System.Drawing.Size(0, 15);
            this.lblPickupLocationValue.TabIndex = 21;
            this.lblPickupLocationValue.Visible = false;
            // 
            // lblDropoffLocationLabel
            // 
            this.lblDropoffLocationLabel.AutoSize = true;
            this.lblDropoffLocationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDropoffLocationLabel.Location = new System.Drawing.Point(371, 109);
            this.lblDropoffLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDropoffLocationLabel.Name = "lblDropoffLocationLabel";
            this.lblDropoffLocationLabel.Size = new System.Drawing.Size(73, 15);
            this.lblDropoffLocationLabel.TabIndex = 22;
            this.lblDropoffLocationLabel.Text = "Leadási hely";
            this.lblDropoffLocationLabel.Visible = false;
            // 
            // lblDropoffLocationValue
            // 
            this.lblDropoffLocationValue.AutoSize = true;
            this.lblDropoffLocationValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDropoffLocationValue.Location = new System.Drawing.Point(483, 109);
            this.lblDropoffLocationValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDropoffLocationValue.Name = "lblDropoffLocationValue";
            this.lblDropoffLocationValue.Size = new System.Drawing.Size(0, 15);
            this.lblDropoffLocationValue.TabIndex = 23;
            this.lblDropoffLocationValue.Visible = false;
            // 
            // lblPaymentStatusLabel
            // 
            this.lblPaymentStatusLabel.AutoSize = true;
            this.lblPaymentStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentStatusLabel.Location = new System.Drawing.Point(10, 129);
            this.lblPaymentStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentStatusLabel.Name = "lblPaymentStatusLabel";
            this.lblPaymentStatusLabel.Size = new System.Drawing.Size(91, 15);
            this.lblPaymentStatusLabel.TabIndex = 24;
            this.lblPaymentStatusLabel.Text = "Fizetési státusz";
            this.lblPaymentStatusLabel.Visible = false;
            // 
            // lblPaymentStatusValue
            // 
            this.lblPaymentStatusValue.AutoSize = true;
            this.lblPaymentStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentStatusValue.Location = new System.Drawing.Point(122, 129);
            this.lblPaymentStatusValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentStatusValue.Name = "lblPaymentStatusValue";
            this.lblPaymentStatusValue.Size = new System.Drawing.Size(0, 15);
            this.lblPaymentStatusValue.TabIndex = 25;
            this.lblPaymentStatusValue.Visible = false;
            // 
            // lblPaymentMethodLabel
            // 
            this.lblPaymentMethodLabel.AutoSize = true;
            this.lblPaymentMethodLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethodLabel.Location = new System.Drawing.Point(371, 129);
            this.lblPaymentMethodLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentMethodLabel.Name = "lblPaymentMethodLabel";
            this.lblPaymentMethodLabel.Size = new System.Drawing.Size(77, 15);
            this.lblPaymentMethodLabel.TabIndex = 26;
            this.lblPaymentMethodLabel.Text = "Fizetési mód";
            this.lblPaymentMethodLabel.Visible = false;
            // 
            // lblPaymentMethodValue
            // 
            this.lblPaymentMethodValue.AutoSize = true;
            this.lblPaymentMethodValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethodValue.Location = new System.Drawing.Point(483, 129);
            this.lblPaymentMethodValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentMethodValue.Name = "lblPaymentMethodValue";
            this.lblPaymentMethodValue.Size = new System.Drawing.Size(0, 15);
            this.lblPaymentMethodValue.TabIndex = 27;
            this.lblPaymentMethodValue.Visible = false;
            // 
            // lblPaymentAmountLabel
            // 
            this.lblPaymentAmountLabel.AutoSize = true;
            this.lblPaymentAmountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentAmountLabel.Location = new System.Drawing.Point(10, 149);
            this.lblPaymentAmountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentAmountLabel.Name = "lblPaymentAmountLabel";
            this.lblPaymentAmountLabel.Size = new System.Drawing.Size(102, 15);
            this.lblPaymentAmountLabel.TabIndex = 28;
            this.lblPaymentAmountLabel.Text = "Fizetendő összeg";
            this.lblPaymentAmountLabel.Visible = false;
            // 
            // lblPaymentAmountValue
            // 
            this.lblPaymentAmountValue.AutoSize = true;
            this.lblPaymentAmountValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentAmountValue.Location = new System.Drawing.Point(122, 149);
            this.lblPaymentAmountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentAmountValue.Name = "lblPaymentAmountValue";
            this.lblPaymentAmountValue.Size = new System.Drawing.Size(0, 15);
            this.lblPaymentAmountValue.TabIndex = 29;
            this.lblPaymentAmountValue.Visible = false;
            // 
            // lblTaxAmountLabel
            // 
            this.lblTaxAmountLabel.AutoSize = true;
            this.lblTaxAmountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaxAmountLabel.Location = new System.Drawing.Point(371, 149);
            this.lblTaxAmountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaxAmountLabel.Name = "lblTaxAmountLabel";
            this.lblTaxAmountLabel.Size = new System.Drawing.Size(69, 15);
            this.lblTaxAmountLabel.TabIndex = 30;
            this.lblTaxAmountLabel.Text = "Adó összeg";
            this.lblTaxAmountLabel.Visible = false;
            // 
            // lblTaxAmountValue
            // 
            this.lblTaxAmountValue.AutoSize = true;
            this.lblTaxAmountValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxAmountValue.Location = new System.Drawing.Point(483, 149);
            this.lblTaxAmountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaxAmountValue.Name = "lblTaxAmountValue";
            this.lblTaxAmountValue.Size = new System.Drawing.Size(0, 15);
            this.lblTaxAmountValue.TabIndex = 31;
            this.lblTaxAmountValue.Visible = false;
            // 
            // lblPaymentDateLabel
            // 
            this.lblPaymentDateLabel.AutoSize = true;
            this.lblPaymentDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentDateLabel.Location = new System.Drawing.Point(10, 170);
            this.lblPaymentDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentDateLabel.Name = "lblPaymentDateLabel";
            this.lblPaymentDateLabel.Size = new System.Drawing.Size(91, 15);
            this.lblPaymentDateLabel.TabIndex = 32;
            this.lblPaymentDateLabel.Text = "Fizetés dátuma";
            this.lblPaymentDateLabel.Visible = false;
            // 
            // lblPaymentDateValue
            // 
            this.lblPaymentDateValue.AutoSize = true;
            this.lblPaymentDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentDateValue.Location = new System.Drawing.Point(122, 170);
            this.lblPaymentDateValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentDateValue.Name = "lblPaymentDateValue";
            this.lblPaymentDateValue.Size = new System.Drawing.Size(0, 15);
            this.lblPaymentDateValue.TabIndex = 33;
            this.lblPaymentDateValue.Visible = false;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsTitle.Location = new System.Drawing.Point(11, 12);
            this.lblDetailsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(129, 19);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Rendelés részletei";
            // 
            // OrderManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrderManageForm";
            this.Text = "Rendelés kezelés";
            this.Load += new System.EventHandler(this.OrderManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelOrderDetails.ResumeLayout(false);
            this.panelOrderDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelOrderDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.CheckBox chkUseDate;
        private System.Windows.Forms.Label label1;

        // Order details labels
        private System.Windows.Forms.Label lblOrderIdLabel;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatusValue;

        private System.Windows.Forms.Label lblStartDateLabel;
        private System.Windows.Forms.Label lblStartDateValue;
        private System.Windows.Forms.Label lblEndDateLabel;
        private System.Windows.Forms.Label lblEndDateValue;

        private System.Windows.Forms.Label lblUserLabel;
        private System.Windows.Forms.Label lblUserValue;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.Label lblEmailValue;

        private System.Windows.Forms.Label lblPhoneLabel;
        private System.Windows.Forms.Label lblPhoneValue;
        private System.Windows.Forms.Label lblDiscountCodeLabel;
        private System.Windows.Forms.Label lblDiscountCodeValue;

        private System.Windows.Forms.Label lblCarLabel;
        private System.Windows.Forms.Label lblCarValue;
        private System.Windows.Forms.Label lblRegNumberLabel;
        private System.Windows.Forms.Label lblRegNumberValue;

        private System.Windows.Forms.Label lblPickupLocationLabel;
        private System.Windows.Forms.Label lblPickupLocationValue;
        private System.Windows.Forms.Label lblDropoffLocationLabel;
        private System.Windows.Forms.Label lblDropoffLocationValue;

        private System.Windows.Forms.Label lblPaymentStatusLabel;
        private System.Windows.Forms.Label lblPaymentStatusValue;
        private System.Windows.Forms.Label lblPaymentMethodLabel;
        private System.Windows.Forms.Label lblPaymentMethodValue;

        private System.Windows.Forms.Label lblPaymentAmountLabel;
        private System.Windows.Forms.Label lblPaymentAmountValue;
        private System.Windows.Forms.Label lblTaxAmountLabel;
        private System.Windows.Forms.Label lblTaxAmountValue;

        private System.Windows.Forms.Label lblPaymentDateLabel;
        private System.Windows.Forms.Label lblPaymentDateValue;

    }
}