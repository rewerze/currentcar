namespace CarRentalAdmin
{
    partial class CarExtrasManageForm
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
            this.lblCarInfo = new System.Windows.Forms.Label();
            this.btnDeleteExtra = new System.Windows.Forms.Button();
            this.btnEditExtra = new System.Windows.Forms.Button();
            this.btnAddExtra = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.dgvExtras = new System.Windows.Forms.DataGridView();
            this.panelControls.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtras)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.lblCarInfo);
            this.panelControls.Controls.Add(this.btnDeleteExtra);
            this.panelControls.Controls.Add(this.btnEditExtra);
            this.panelControls.Controls.Add(this.btnAddExtra);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(450, 49);
            this.panelControls.TabIndex = 0;
            // 
            // lblCarInfo
            // 
            this.lblCarInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarInfo.Location = new System.Drawing.Point(262, 12);
            this.lblCarInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarInfo.Name = "lblCarInfo";
            this.lblCarInfo.Size = new System.Drawing.Size(176, 24);
            this.lblCarInfo.TabIndex = 3;
            this.lblCarInfo.Text = "[Car Info]";
            this.lblCarInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteExtra
            // 
            this.btnDeleteExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(100)))), ((int)(((byte)(70)))));
            this.btnDeleteExtra.FlatAppearance.BorderSize = 0;
            this.btnDeleteExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteExtra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteExtra.ForeColor = System.Drawing.Color.White;
            this.btnDeleteExtra.Location = new System.Drawing.Point(176, 2);
            this.btnDeleteExtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteExtra.Name = "btnDeleteExtra";
            this.btnDeleteExtra.Size = new System.Drawing.Size(68, 45);
            this.btnDeleteExtra.TabIndex = 2;
            this.btnDeleteExtra.Text = "Extra törlése";
            this.btnDeleteExtra.UseVisualStyleBackColor = false;
            this.btnDeleteExtra.Click += new System.EventHandler(this.btnDeleteExtra_Click);
            // 
            // btnEditExtra
            // 
            this.btnEditExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnEditExtra.FlatAppearance.BorderSize = 0;
            this.btnEditExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExtra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditExtra.ForeColor = System.Drawing.Color.White;
            this.btnEditExtra.Location = new System.Drawing.Point(94, 2);
            this.btnEditExtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditExtra.Name = "btnEditExtra";
            this.btnEditExtra.Size = new System.Drawing.Size(78, 45);
            this.btnEditExtra.TabIndex = 1;
            this.btnEditExtra.Text = "Extra szerkesztése";
            this.btnEditExtra.UseVisualStyleBackColor = false;
            this.btnEditExtra.Click += new System.EventHandler(this.btnEditExtra_Click);
            // 
            // btnAddExtra
            // 
            this.btnAddExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnAddExtra.FlatAppearance.BorderSize = 0;
            this.btnAddExtra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExtra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExtra.ForeColor = System.Drawing.Color.White;
            this.btnAddExtra.Location = new System.Drawing.Point(11, 2);
            this.btnAddExtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddExtra.Name = "btnAddExtra";
            this.btnAddExtra.Size = new System.Drawing.Size(79, 45);
            this.btnAddExtra.TabIndex = 0;
            this.btnAddExtra.Text = "Extra hozzáadása";
            this.btnAddExtra.UseVisualStyleBackColor = false;
            this.btnAddExtra.Click += new System.EventHandler(this.btnAddExtra_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.dgvExtras);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 49);
            this.panelData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelData.Size = new System.Drawing.Size(450, 276);
            this.panelData.TabIndex = 1;
            // 
            // dgvExtras
            // 
            this.dgvExtras.AllowUserToAddRows = false;
            this.dgvExtras.AllowUserToDeleteRows = false;
            this.dgvExtras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExtras.BackgroundColor = System.Drawing.Color.White;
            this.dgvExtras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExtras.Location = new System.Drawing.Point(11, 12);
            this.dgvExtras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvExtras.MultiSelect = false;
            this.dgvExtras.Name = "dgvExtras";
            this.dgvExtras.ReadOnly = true;
            this.dgvExtras.RowHeadersWidth = 51;
            this.dgvExtras.RowTemplate.Height = 24;
            this.dgvExtras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExtras.Size = new System.Drawing.Size(428, 252);
            this.dgvExtras.TabIndex = 0;
            this.dgvExtras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExtras_CellClick);
            // 
            // CarExtrasManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 325);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarExtrasManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autó extrák kezelése";
            this.Load += new System.EventHandler(this.CarExtrasManageForm_Load);
            this.panelControls.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtras)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnAddExtra;
        private System.Windows.Forms.Button btnEditExtra;
        private System.Windows.Forms.Button btnDeleteExtra;
        private System.Windows.Forms.Label lblCarInfo;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.DataGridView dgvExtras;
    }
}