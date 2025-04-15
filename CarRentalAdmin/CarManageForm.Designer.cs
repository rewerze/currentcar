namespace CarRentalAdmin
{
    partial class CarManageForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.carExtra = new System.Windows.Forms.Button();
            this.cmbCarCondition = new System.Windows.Forms.ComboBox();
            this.cmbCarType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.btnEditCar = new System.Windows.Forms.Button();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.chkShowUnverified = new System.Windows.Forms.CheckBox();
            this.lblShowUnverified = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.carExtra);
            this.panelControls.Controls.Add(this.cmbCarCondition);
            this.panelControls.Controls.Add(this.cmbCarType);
            this.panelControls.Controls.Add(this.btnSearch);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.btnDeleteCar);
            this.panelControls.Controls.Add(this.btnEditCar);
            this.panelControls.Controls.Add(this.btnAddCar);
            this.panelControls.Controls.Add(this.chkShowUnverified);
            this.panelControls.Controls.Add(this.lblShowUnverified);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(712, 49);
            this.panelControls.TabIndex = 0;
            // 
            // carExtra
            // 
            this.carExtra.BackColor = System.Drawing.Color.SteelBlue;
            this.carExtra.FlatAppearance.BorderSize = 0;
            this.carExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carExtra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carExtra.ForeColor = System.Drawing.Color.White;
            this.carExtra.Location = new System.Drawing.Point(169, 2);
            this.carExtra.Margin = new System.Windows.Forms.Padding(2);
            this.carExtra.Name = "carExtra";
            this.carExtra.Size = new System.Drawing.Size(75, 43);
            this.carExtra.TabIndex = 7;
            this.carExtra.Text = "Autó extra hozzáadása";
            this.carExtra.UseVisualStyleBackColor = false;
            this.carExtra.Click += new System.EventHandler(this.carExtra_Click);
            // 
            // cmbCarCondition
            // 
            this.cmbCarCondition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarCondition.FormattingEnabled = true;
            this.cmbCarCondition.Items.AddRange(new object[] {
            "Összes állapot",
            "új",
            "kiváló",
            "jó",
            "megfelelő",
            "gyenge"});
            this.cmbCarCondition.Location = new System.Drawing.Point(604, 2);
            this.cmbCarCondition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCarCondition.Name = "cmbCarCondition";
            this.cmbCarCondition.Size = new System.Drawing.Size(106, 23);
            this.cmbCarCondition.TabIndex = 6;
            this.cmbCarCondition.Text = "Összes állapot";
            this.cmbCarCondition.SelectedIndexChanged += new System.EventHandler(this.cmbCarCondition_SelectedIndexChanged);
            // 
            // cmbCarType
            // 
            this.cmbCarType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarType.FormattingEnabled = true;
            this.cmbCarType.Items.AddRange(new object[] {
            "Összes típus",
            "sedan",
            "SUV",
            "ferdehátú",
            "kabrió",
            "kupé",
            "kombi",
            "pickup",
            "minibusz"});
            this.cmbCarType.Location = new System.Drawing.Point(604, 26);
            this.cmbCarType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCarType.Name = "cmbCarType";
            this.cmbCarType.Size = new System.Drawing.Size(106, 23);
            this.cmbCarType.TabIndex = 5;
            this.cmbCarType.Text = "Összes típus";
            this.cmbCarType.SelectedIndexChanged += new System.EventHandler(this.cmbCarType_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(540, 3);
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
            this.txtSearch.Location = new System.Drawing.Point(327, 3);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnDeleteCar.FlatAppearance.BorderSize = 0;
            this.btnDeleteCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCar.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCar.Location = new System.Drawing.Point(248, 3);
            this.btnDeleteCar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(75, 43);
            this.btnDeleteCar.TabIndex = 2;
            this.btnDeleteCar.Text = "Autó törlése";
            this.btnDeleteCar.UseVisualStyleBackColor = false;
            this.btnDeleteCar.Click += new System.EventHandler(this.btnDeleteCar_Click);
            // 
            // btnEditCar
            // 
            this.btnEditCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditCar.FlatAppearance.BorderSize = 0;
            this.btnEditCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCar.ForeColor = System.Drawing.Color.White;
            this.btnEditCar.Location = new System.Drawing.Point(90, 2);
            this.btnEditCar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditCar.Name = "btnEditCar";
            this.btnEditCar.Size = new System.Drawing.Size(75, 43);
            this.btnEditCar.TabIndex = 1;
            this.btnEditCar.Text = "Autó szerkesztése";
            this.btnEditCar.UseVisualStyleBackColor = false;
            this.btnEditCar.Click += new System.EventHandler(this.btnEditCar_Click);
            // 
            // btnAddCar
            // 
            this.btnAddCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddCar.FlatAppearance.BorderSize = 0;
            this.btnAddCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCar.ForeColor = System.Drawing.Color.White;
            this.btnAddCar.Location = new System.Drawing.Point(11, 2);
            this.btnAddCar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(75, 43);
            this.btnAddCar.TabIndex = 0;
            this.btnAddCar.Text = "Autó hozzáadása";
            this.btnAddCar.UseVisualStyleBackColor = false;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // chkShowUnverified
            // 
            this.chkShowUnverified.AutoSize = true;
            this.chkShowUnverified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowUnverified.Location = new System.Drawing.Point(426, 32);
            this.chkShowUnverified.Name = "chkShowUnverified";
            this.chkShowUnverified.Size = new System.Drawing.Size(15, 14);
            this.chkShowUnverified.TabIndex = 8;
            this.chkShowUnverified.UseVisualStyleBackColor = true;
            this.chkShowUnverified.CheckedChanged += new System.EventHandler(this.chkShowUnverified_CheckedChanged);
            // 
            // lblShowUnverified
            // 
            this.lblShowUnverified.AutoSize = true;
            this.lblShowUnverified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowUnverified.Location = new System.Drawing.Point(328, 30);
            this.lblShowUnverified.Name = "lblShowUnverified";
            this.lblShowUnverified.Size = new System.Drawing.Size(92, 15);
            this.lblShowUnverified.TabIndex = 9;
            this.lblShowUnverified.Text = "Nem ellenőrzött";
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvCars);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(712, 471);
            this.panelData.TabIndex = 1;
            // 
            // dgvCars
            // 
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCars.BackgroundColor = System.Drawing.Color.White;
            this.dgvCars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCars.Location = new System.Drawing.Point(11, 12);
            this.dgvCars.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowHeadersWidth = 51;
            this.dgvCars.RowTemplate.Height = 24;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(690, 447);
            this.dgvCars.TabIndex = 0;
            this.dgvCars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellClick);
            // 
            // CarManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 520);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CarManageForm";
            this.Text = "Autó kezelés";
            this.Load += new System.EventHandler(this.CarManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.Button btnEditCar;
        private System.Windows.Forms.Button btnDeleteCar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCarType;
        private System.Windows.Forms.ComboBox cmbCarCondition;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Button carExtra;
        private System.Windows.Forms.CheckBox chkShowUnverified;
        private System.Windows.Forms.Label lblShowUnverified;
    }
}