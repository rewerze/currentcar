namespace CarRentalAdmin
{
    partial class CarEditForm
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.lblHourlyRate = new System.Windows.Forms.Label();
            this.numHourlyRate = new System.Windows.Forms.NumericUpDown();
            this.lblDailyRate = new System.Windows.Forms.Label();
            this.numDailyRate = new System.Windows.Forms.NumericUpDown();
            this.lblRegNumber = new System.Windows.Forms.Label();
            this.txtRegNumber = new System.Windows.Forms.TextBox();
            this.lblSeats = new System.Windows.Forms.Label();
            this.numSeats = new System.Windows.Forms.NumericUpDown();
            this.lblDoors = new System.Windows.Forms.Label();
            this.numDoors = new System.Windows.Forms.NumericUpDown();
            this.lblMileage = new System.Windows.Forms.Label();
            this.numMileage = new System.Windows.Forms.NumericUpDown();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.lblTransmission = new System.Windows.Forms.Label();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblInsurance = new System.Windows.Forms.Label();
            this.cmbInsurance = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblImages = new System.Windows.Forms.Label();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.picCarImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblPickupLocation = new System.Windows.Forms.Label();
            this.lblVerified = new System.Windows.Forms.Label();
            this.chkVerified = new System.Windows.Forms.CheckBox();
            this.lblRented = new System.Windows.Forms.Label();
            this.chkRented = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBrand.Location = new System.Drawing.Point(15, 16);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(40, 15);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Márka";
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBrand.Location = new System.Drawing.Point(112, 16);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(2);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(151, 23);
            this.txtBrand.TabIndex = 1;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModel.Location = new System.Drawing.Point(15, 45);
            this.lblModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(44, 15);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Modell";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtModel.Location = new System.Drawing.Point(112, 45);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(151, 23);
            this.txtModel.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYear.Location = new System.Drawing.Point(15, 73);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 15);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Évjárat";
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numYear.Location = new System.Drawing.Point(112, 73);
            this.numYear.Margin = new System.Windows.Forms.Padding(2);
            this.numYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1960,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(90, 23);
            this.numYear.TabIndex = 5;
            this.numYear.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblType.Location = new System.Drawing.Point(15, 102);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(62, 15);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Autó típus";
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "sedan",
            "SUV",
            "ferdehátú",
            "kabrió",
            "kupé",
            "kombi",
            "pickup",
            "minibusz"});
            this.cmbType.Location = new System.Drawing.Point(112, 102);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(151, 23);
            this.cmbType.TabIndex = 7;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCondition.Location = new System.Drawing.Point(15, 130);
            this.lblCondition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(45, 15);
            this.lblCondition.TabIndex = 8;
            this.lblCondition.Text = "Állapot";
            // 
            // cmbCondition
            // 
            this.cmbCondition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Items.AddRange(new object[] {
            "új",
            "kiváló",
            "jó",
            "megfelelő",
            "gyenge"});
            this.cmbCondition.Location = new System.Drawing.Point(112, 130);
            this.cmbCondition.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(151, 23);
            this.cmbCondition.TabIndex = 9;
            // 
            // lblHourlyRate
            // 
            this.lblHourlyRate.AutoSize = true;
            this.lblHourlyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHourlyRate.Location = new System.Drawing.Point(15, 188);
            this.lblHourlyRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHourlyRate.Name = "lblHourlyRate";
            this.lblHourlyRate.Size = new System.Drawing.Size(39, 15);
            this.lblHourlyRate.TabIndex = 10;
            this.lblHourlyRate.Text = "Óradíj";
            // 
            // numHourlyRate
            // 
            this.numHourlyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numHourlyRate.Location = new System.Drawing.Point(112, 186);
            this.numHourlyRate.Margin = new System.Windows.Forms.Padding(2);
            this.numHourlyRate.Maximum = new decimal(new int[] {
            1600000,
            0,
            0,
            0});
            this.numHourlyRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHourlyRate.Name = "numHourlyRate";
            this.numHourlyRate.Size = new System.Drawing.Size(90, 23);
            this.numHourlyRate.TabIndex = 11;
            this.numHourlyRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblDailyRate
            // 
            this.lblDailyRate.AutoSize = true;
            this.lblDailyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDailyRate.Location = new System.Drawing.Point(15, 215);
            this.lblDailyRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDailyRate.Name = "lblDailyRate";
            this.lblDailyRate.Size = new System.Drawing.Size(45, 15);
            this.lblDailyRate.TabIndex = 12;
            this.lblDailyRate.Text = "Napidíj";
            // 
            // numDailyRate
            // 
            this.numDailyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDailyRate.Location = new System.Drawing.Point(112, 213);
            this.numDailyRate.Margin = new System.Windows.Forms.Padding(2);
            this.numDailyRate.Maximum = new decimal(new int[] {
            1300000,
            0,
            0,
            0});
            this.numDailyRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDailyRate.Name = "numDailyRate";
            this.numDailyRate.Size = new System.Drawing.Size(90, 23);
            this.numDailyRate.TabIndex = 13;
            this.numDailyRate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblRegNumber
            // 
            this.lblRegNumber.AutoSize = true;
            this.lblRegNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegNumber.Location = new System.Drawing.Point(15, 242);
            this.lblRegNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegNumber.Name = "lblRegNumber";
            this.lblRegNumber.Size = new System.Drawing.Size(61, 15);
            this.lblRegNumber.TabIndex = 14;
            this.lblRegNumber.Text = "Rendszám";
            // 
            // txtRegNumber
            // 
            this.txtRegNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegNumber.Location = new System.Drawing.Point(112, 242);
            this.txtRegNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtRegNumber.Name = "txtRegNumber";
            this.txtRegNumber.Size = new System.Drawing.Size(151, 23);
            this.txtRegNumber.TabIndex = 15;
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeats.Location = new System.Drawing.Point(15, 271);
            this.lblSeats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(41, 15);
            this.lblSeats.TabIndex = 16;
            this.lblSeats.Text = "Ülések";
            // 
            // numSeats
            // 
            this.numSeats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSeats.Location = new System.Drawing.Point(112, 271);
            this.numSeats.Margin = new System.Windows.Forms.Padding(2);
            this.numSeats.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSeats.Name = "numSeats";
            this.numSeats.Size = new System.Drawing.Size(60, 23);
            this.numSeats.TabIndex = 17;
            this.numSeats.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblDoors
            // 
            this.lblDoors.AutoSize = true;
            this.lblDoors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoors.Location = new System.Drawing.Point(15, 302);
            this.lblDoors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoors.Name = "lblDoors";
            this.lblDoors.Size = new System.Drawing.Size(35, 15);
            this.lblDoors.TabIndex = 18;
            this.lblDoors.Text = "Ajtók";
            // 
            // numDoors
            // 
            this.numDoors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDoors.Location = new System.Drawing.Point(112, 299);
            this.numDoors.Margin = new System.Windows.Forms.Padding(2);
            this.numDoors.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDoors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDoors.Name = "numDoors";
            this.numDoors.Size = new System.Drawing.Size(60, 23);
            this.numDoors.TabIndex = 19;
            this.numDoors.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMileage.Location = new System.Drawing.Point(15, 334);
            this.lblMileage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(101, 15);
            this.lblMileage.TabIndex = 20;
            this.lblMileage.Text = "Kilóméteróra állás";
            // 
            // numMileage
            // 
            this.numMileage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMileage.Location = new System.Drawing.Point(136, 332);
            this.numMileage.Margin = new System.Windows.Forms.Padding(2);
            this.numMileage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMileage.Name = "numMileage";
            this.numMileage.Size = new System.Drawing.Size(90, 23);
            this.numMileage.TabIndex = 21;
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFuelType.Location = new System.Drawing.Point(285, 16);
            this.lblFuelType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(104, 15);
            this.lblFuelType.TabIndex = 22;
            this.lblFuelType.Text = "Üzemanyag típusa";
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFuelType.FormattingEnabled = true;
            this.cmbFuelType.Items.AddRange(new object[] {
            "benzin",
            "dízel",
            "elektromos",
            "hibrid",
            "gáz"});
            this.cmbFuelType.Location = new System.Drawing.Point(393, 13);
            this.cmbFuelType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(151, 23);
            this.cmbFuelType.TabIndex = 23;
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransmission.Location = new System.Drawing.Point(285, 45);
            this.lblTransmission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(81, 15);
            this.lblTransmission.TabIndex = 24;
            this.lblTransmission.Text = "Sebességváltó";
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTransmission.FormattingEnabled = true;
            this.cmbTransmission.Items.AddRange(new object[] {
            "automata",
            "manuális",
            "félautomata",
            "CVT"});
            this.cmbTransmission.Location = new System.Drawing.Point(370, 42);
            this.cmbTransmission.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(151, 23);
            this.cmbTransmission.TabIndex = 25;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(285, 73);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(37, 15);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "Leírás";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(360, 73);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(226, 82);
            this.txtDescription.TabIndex = 27;
            // 
            // lblInsurance
            // 
            this.lblInsurance.AutoSize = true;
            this.lblInsurance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInsurance.Location = new System.Drawing.Point(285, 162);
            this.lblInsurance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInsurance.Name = "lblInsurance";
            this.lblInsurance.Size = new System.Drawing.Size(56, 15);
            this.lblInsurance.TabIndex = 28;
            this.lblInsurance.Text = "Biztosítás";
            // 
            // cmbInsurance
            // 
            this.cmbInsurance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbInsurance.FormattingEnabled = true;
            this.cmbInsurance.Location = new System.Drawing.Point(360, 162);
            this.cmbInsurance.Margin = new System.Windows.Forms.Padding(2);
            this.cmbInsurance.Name = "cmbInsurance";
            this.cmbInsurance.Size = new System.Drawing.Size(226, 23);
            this.cmbInsurance.TabIndex = 29;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActive.Location = new System.Drawing.Point(367, 194);
            this.lblActive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(34, 15);
            this.lblActive.TabIndex = 30;
            this.lblActive.Text = "Aktív";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActive.Location = new System.Drawing.Point(468, 194);
            this.chkActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 31;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImages.Location = new System.Drawing.Point(547, 394);
            this.lblImages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(39, 15);
            this.lblImages.TabIndex = 32;
            this.lblImages.Text = "Képek";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddImage.Location = new System.Drawing.Point(370, 420);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(113, 24);
            this.btnAddImage.TabIndex = 33;
            this.btnAddImage.Text = "Kép hozzáadása";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Visible = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lstImages
            // 
            this.lstImages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstImages.FormattingEnabled = true;
            this.lstImages.ItemHeight = 15;
            this.lstImages.Location = new System.Drawing.Point(370, 448);
            this.lstImages.Margin = new System.Windows.Forms.Padding(2);
            this.lstImages.Name = "lstImages";
            this.lstImages.Size = new System.Drawing.Size(226, 79);
            this.lstImages.TabIndex = 34;
            this.lstImages.SelectedIndexChanged += new System.EventHandler(this.lstImages_SelectedIndexChanged);
            // 
            // picCarImage
            // 
            this.picCarImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCarImage.Location = new System.Drawing.Point(85, 405);
            this.picCarImage.Margin = new System.Windows.Forms.Padding(2);
            this.picCarImage.Name = "picCarImage";
            this.picCarImage.Size = new System.Drawing.Size(281, 122);
            this.picCarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarImage.TabIndex = 35;
            this.picCarImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(225, 544);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 36;
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
            this.btnCancel.Location = new System.Drawing.Point(320, 544);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveImage.Location = new System.Drawing.Point(487, 420);
            this.btnRemoveImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(109, 24);
            this.btnRemoveImage.TabIndex = 38;
            this.btnRemoveImage.Text = "Kép törlése";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBasePrice.Location = new System.Drawing.Point(15, 162);
            this.lblBasePrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(47, 15);
            this.lblBasePrice.TabIndex = 38;
            this.lblBasePrice.Text = "Alap díj";
            // 
            // numBasePrice
            // 
            this.numBasePrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numBasePrice.Location = new System.Drawing.Point(112, 158);
            this.numBasePrice.Margin = new System.Windows.Forms.Padding(2);
            this.numBasePrice.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numBasePrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(90, 23);
            this.numBasePrice.TabIndex = 39;
            this.numBasePrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmbLocation
            // 
            this.cmbLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(136, 372);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(392, 23);
            this.cmbLocation.TabIndex = 40;
            // 
            // lblPickupLocation
            // 
            this.lblPickupLocation.AutoSize = true;
            this.lblPickupLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPickupLocation.Location = new System.Drawing.Point(15, 375);
            this.lblPickupLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPickupLocation.Name = "lblPickupLocation";
            this.lblPickupLocation.Size = new System.Drawing.Size(116, 15);
            this.lblPickupLocation.TabIndex = 41;
            this.lblPickupLocation.Text = "Felvétel/leadás helye";
            // 
            // lblVerified
            // 
            this.lblVerified.AutoSize = true;
            this.lblVerified.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVerified.Location = new System.Drawing.Point(367, 299);
            this.lblVerified.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVerified.Name = "lblVerified";
            this.lblVerified.Size = new System.Drawing.Size(63, 15);
            this.lblVerified.TabIndex = 42;
            this.lblVerified.Text = "Ellenőrzött";
            // 
            // chkVerified
            // 
            this.chkVerified.AutoSize = true;
            this.chkVerified.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkVerified.Location = new System.Drawing.Point(468, 302);
            this.chkVerified.Margin = new System.Windows.Forms.Padding(2);
            this.chkVerified.Name = "chkVerified";
            this.chkVerified.Size = new System.Drawing.Size(15, 14);
            this.chkVerified.TabIndex = 43;
            this.chkVerified.UseVisualStyleBackColor = true;
            // 
            // lblRented
            // 
            this.lblRented.AutoSize = true;
            this.lblRented.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRented.Location = new System.Drawing.Point(367, 242);
            this.lblRented.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRented.Name = "lblRented";
            this.lblRented.Size = new System.Drawing.Size(45, 15);
            this.lblRented.TabIndex = 44;
            this.lblRented.Text = "Kiadott";
            // 
            // chkRented
            // 
            this.chkRented.AutoSize = true;
            this.chkRented.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRented.Location = new System.Drawing.Point(468, 242);
            this.chkRented.Margin = new System.Windows.Forms.Padding(2);
            this.chkRented.Name = "chkRented";
            this.chkRented.Size = new System.Drawing.Size(15, 14);
            this.chkRented.TabIndex = 45;
            this.chkRented.UseVisualStyleBackColor = true;
            // 
            // CarEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 583);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblPickupLocation);
            this.Controls.Add(this.btnRemoveImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picCarImage);
            this.Controls.Add(this.lstImages);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.lblImages);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.cmbInsurance);
            this.Controls.Add(this.lblInsurance);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbTransmission);
            this.Controls.Add(this.lblTransmission);
            this.Controls.Add(this.cmbFuelType);
            this.Controls.Add(this.lblFuelType);
            this.Controls.Add(this.numMileage);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.numDoors);
            this.Controls.Add(this.lblDoors);
            this.Controls.Add(this.numSeats);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.txtRegNumber);
            this.Controls.Add(this.lblRegNumber);
            this.Controls.Add(this.numDailyRate);
            this.Controls.Add(this.lblDailyRate);
            this.Controls.Add(this.numHourlyRate);
            this.Controls.Add(this.lblHourlyRate);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.numBasePrice);
            this.Controls.Add(this.lblBasePrice);
            this.Controls.Add(this.chkRented);
            this.Controls.Add(this.lblRented);
            this.Controls.Add(this.chkVerified);
            this.Controls.Add(this.lblVerified);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Car Details";
            this.Load += new System.EventHandler(this.CarEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Label lblHourlyRate;
        private System.Windows.Forms.NumericUpDown numHourlyRate;
        private System.Windows.Forms.Label lblDailyRate;
        private System.Windows.Forms.NumericUpDown numDailyRate;
        private System.Windows.Forms.Label lblRegNumber;
        private System.Windows.Forms.TextBox txtRegNumber;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.NumericUpDown numSeats;
        private System.Windows.Forms.Label lblDoors;
        private System.Windows.Forms.NumericUpDown numDoors;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.NumericUpDown numMileage;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.Label lblTransmission;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblInsurance;
        private System.Windows.Forms.ComboBox cmbInsurance;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.PictureBox picCarImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblPickupLocation;
        private System.Windows.Forms.Label lblVerified;
        private System.Windows.Forms.CheckBox chkVerified;
        private System.Windows.Forms.Label lblRented;
        private System.Windows.Forms.CheckBox chkRented;
    }
}