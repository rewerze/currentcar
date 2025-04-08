namespace CarRentalAdmin
{
    partial class OrderEditForm
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.cmbCar = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblPickupLocation = new System.Windows.Forms.Label();
            this.txtPickupLocation = new System.Windows.Forms.TextBox();
            this.lblDropoffLocation = new System.Windows.Forms.Label();
            this.txtDropoffLocation = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblExtended = new System.Windows.Forms.Label();
            this.chkExtended = new System.Windows.Forms.CheckBox();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.numPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.numTaxAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblInvoiceAddress = new System.Windows.Forms.Label();
            this.txtInvoiceAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomer.Location = new System.Drawing.Point(15, 16);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(41, 15);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Ügyfél";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(121, 13);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(237, 23);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCar.Location = new System.Drawing.Point(15, 49);
            this.lblCar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(33, 15);
            this.lblCar.TabIndex = 2;
            this.lblCar.Text = "Autó";
            // 
            // cmbCar
            // 
            this.cmbCar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new System.Drawing.Point(121, 46);
            this.cmbCar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new System.Drawing.Size(238, 23);
            this.cmbCar.TabIndex = 3;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(15, 81);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(77, 15);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Kezdő dátum";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(121, 78);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(151, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(15, 114);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(89, 15);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "Befejező dátum";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(121, 111);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(151, 23);
            this.dtpEndDate.TabIndex = 7;
            // 
            // lblPickupLocation
            // 
            this.lblPickupLocation.AutoSize = true;
            this.lblPickupLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPickupLocation.Location = new System.Drawing.Point(15, 146);
            this.lblPickupLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPickupLocation.Name = "lblPickupLocation";
            this.lblPickupLocation.Size = new System.Drawing.Size(78, 15);
            this.lblPickupLocation.TabIndex = 8;
            this.lblPickupLocation.Text = "Felvétel helye";
            // 
            // txtPickupLocation
            // 
            this.txtPickupLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPickupLocation.Location = new System.Drawing.Point(121, 143);
            this.txtPickupLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPickupLocation.Name = "txtPickupLocation";
            this.txtPickupLocation.Size = new System.Drawing.Size(407, 23);
            this.txtPickupLocation.TabIndex = 9;
            // 
            // lblDropoffLocation
            // 
            this.lblDropoffLocation.AutoSize = true;
            this.lblDropoffLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDropoffLocation.Location = new System.Drawing.Point(15, 179);
            this.lblDropoffLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDropoffLocation.Name = "lblDropoffLocation";
            this.lblDropoffLocation.Size = new System.Drawing.Size(74, 15);
            this.lblDropoffLocation.TabIndex = 10;
            this.lblDropoffLocation.Text = "Leadás helye";
            // 
            // txtDropoffLocation
            // 
            this.txtDropoffLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDropoffLocation.Location = new System.Drawing.Point(121, 176);
            this.txtDropoffLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDropoffLocation.Name = "txtDropoffLocation";
            this.txtDropoffLocation.Size = new System.Drawing.Size(407, 23);
            this.txtDropoffLocation.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(296, 249);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Állapot";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "függőben",
            "megerősítve",
            "teljesítve",
            "lemondva",
            "meghosszabbítva"});
            this.cmbStatus.Location = new System.Drawing.Point(398, 246);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbStatus.TabIndex = 13;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentStatus.Location = new System.Drawing.Point(296, 282);
            this.lblPaymentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(84, 15);
            this.lblPaymentStatus.TabIndex = 14;
            this.lblPaymentStatus.Text = "Fizetési állapot";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "függőben",
            "fizetve",
            "sikertelen",
            "visszatérítve",
            "részben fizetve"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(398, 279);
            this.cmbPaymentStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbPaymentStatus.TabIndex = 15;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscount.Location = new System.Drawing.Point(312, 211);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(94, 15);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.Text = "Kedvezménykód";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiscount.Location = new System.Drawing.Point(414, 208);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(114, 23);
            this.txtDiscount.TabIndex = 17;
            // 
            // lblExtended
            // 
            this.lblExtended.AutoSize = true;
            this.lblExtended.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExtended.Location = new System.Drawing.Point(381, 110);
            this.lblExtended.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExtended.Name = "lblExtended";
            this.lblExtended.Size = new System.Drawing.Size(114, 15);
            this.lblExtended.TabIndex = 18;
            this.lblExtended.Text = "Hosszabbított bérlés";
            // 
            // chkExtended
            // 
            this.chkExtended.AutoSize = true;
            this.chkExtended.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkExtended.Location = new System.Drawing.Point(499, 111);
            this.chkExtended.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkExtended.Name = "chkExtended";
            this.chkExtended.Size = new System.Drawing.Size(15, 14);
            this.chkExtended.TabIndex = 19;
            this.chkExtended.UseVisualStyleBackColor = true;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentAmount.Location = new System.Drawing.Point(15, 246);
            this.lblPaymentAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(86, 15);
            this.lblPaymentAmount.TabIndex = 20;
            this.lblPaymentAmount.Text = "Fizetés összege";
            // 
            // numPaymentAmount
            // 
            this.numPaymentAmount.DecimalPlaces = 2;
            this.numPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPaymentAmount.Location = new System.Drawing.Point(121, 246);
            this.numPaymentAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numPaymentAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPaymentAmount.Name = "numPaymentAmount";
            this.numPaymentAmount.Size = new System.Drawing.Size(112, 23);
            this.numPaymentAmount.TabIndex = 21;
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxAmount.Location = new System.Drawing.Point(15, 279);
            this.lblTaxAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(73, 15);
            this.lblTaxAmount.TabIndex = 22;
            this.lblTaxAmount.Text = "Adó összege";
            // 
            // numTaxAmount
            // 
            this.numTaxAmount.DecimalPlaces = 2;
            this.numTaxAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTaxAmount.Location = new System.Drawing.Point(121, 279);
            this.numTaxAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numTaxAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTaxAmount.Name = "numTaxAmount";
            this.numTaxAmount.Size = new System.Drawing.Size(112, 23);
            this.numTaxAmount.TabIndex = 23;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(15, 211);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(73, 15);
            this.lblPaymentMethod.TabIndex = 24;
            this.lblPaymentMethod.Text = "Fizetési mód";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "bankkártya",
            "PayPal",
            "banki átutalás",
            "készpénz",
            "Bitcoin"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(121, 208);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(151, 23);
            this.cmbPaymentMethod.TabIndex = 25;
            // 
            // lblInvoiceAddress
            // 
            this.lblInvoiceAddress.AutoSize = true;
            this.lblInvoiceAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceAddress.Location = new System.Drawing.Point(17, 314);
            this.lblInvoiceAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceAddress.Name = "lblInvoiceAddress";
            this.lblInvoiceAddress.Size = new System.Drawing.Size(86, 15);
            this.lblInvoiceAddress.TabIndex = 26;
            this.lblInvoiceAddress.Text = "Számlázási cím";
            // 
            // txtInvoiceAddress
            // 
            this.txtInvoiceAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInvoiceAddress.Location = new System.Drawing.Point(114, 314);
            this.txtInvoiceAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInvoiceAddress.Multiline = true;
            this.txtInvoiceAddress.Name = "txtInvoiceAddress";
            this.txtInvoiceAddress.Size = new System.Drawing.Size(414, 50);
            this.txtInvoiceAddress.TabIndex = 27;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(187, 368);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(283, 368);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 402);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInvoiceAddress);
            this.Controls.Add(this.lblInvoiceAddress);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.numTaxAmount);
            this.Controls.Add(this.lblTaxAmount);
            this.Controls.Add(this.numPaymentAmount);
            this.Controls.Add(this.lblPaymentAmount);
            this.Controls.Add(this.chkExtended);
            this.Controls.Add(this.lblExtended);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.cmbPaymentStatus);
            this.Controls.Add(this.lblPaymentStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDropoffLocation);
            this.Controls.Add(this.lblDropoffLocation);
            this.Controls.Add(this.txtPickupLocation);
            this.Controls.Add(this.lblPickupLocation);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cmbCar);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendelés részletei";
            this.Load += new System.EventHandler(this.OrderEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.ComboBox cmbCar;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblPickupLocation;
        private System.Windows.Forms.TextBox txtPickupLocation;
        private System.Windows.Forms.Label lblDropoffLocation;
        private System.Windows.Forms.TextBox txtDropoffLocation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblExtended;
        private System.Windows.Forms.CheckBox chkExtended;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.NumericUpDown numPaymentAmount;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.NumericUpDown numTaxAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblInvoiceAddress;
        private System.Windows.Forms.TextBox txtInvoiceAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}