
namespace demoFront_End
{
    partial class HouseholdAddEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HouseholdAddEditForm));
            this.btEdit = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txbPostalcode = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.btAddEditHousehold = new System.Windows.Forms.Button();
            this.txbNoAddition = new System.Windows.Forms.TextBox();
            this.lblNoAddition = new System.Windows.Forms.Label();
            this.txbHouseNo = new System.Windows.Forms.TextBox();
            this.lblHouseNo = new System.Windows.Forms.Label();
            this.txbCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txbStreetname = new System.Windows.Forms.TextBox();
            this.lblHouseholdStreetname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btEdit
            // 
            this.btEdit.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btEdit.Location = new System.Drawing.Point(272, 174);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(113, 28);
            this.btEdit.TabIndex = 26;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(29, 145);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 25;
            // 
            // txbPostalcode
            // 
            this.txbPostalcode.BackColor = System.Drawing.Color.Gainsboro;
            this.txbPostalcode.Location = new System.Drawing.Point(143, 98);
            this.txbPostalcode.Name = "txbPostalcode";
            this.txbPostalcode.Size = new System.Drawing.Size(100, 20);
            this.txbPostalcode.TabIndex = 24;
            this.txbPostalcode.Text = "4242XD";
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.AutoSize = true;
            this.lblPostalcode.BackColor = System.Drawing.Color.Transparent;
            this.lblPostalcode.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblPostalcode.ForeColor = System.Drawing.Color.White;
            this.lblPostalcode.Location = new System.Drawing.Point(28, 95);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(122, 22);
            this.lblPostalcode.TabIndex = 23;
            this.lblPostalcode.Text = "Postalcode :";
            // 
            // btAddEditHousehold
            // 
            this.btAddEditHousehold.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btAddEditHousehold.Location = new System.Drawing.Point(272, 145);
            this.btAddEditHousehold.Name = "btAddEditHousehold";
            this.btAddEditHousehold.Size = new System.Drawing.Size(113, 28);
            this.btAddEditHousehold.TabIndex = 22;
            this.btAddEditHousehold.Text = "Add";
            this.btAddEditHousehold.UseVisualStyleBackColor = true;
            this.btAddEditHousehold.Click += new System.EventHandler(this.btAddEditHousehold_Click);
            // 
            // txbNoAddition
            // 
            this.txbNoAddition.BackColor = System.Drawing.Color.Gainsboro;
            this.txbNoAddition.Location = new System.Drawing.Point(351, 68);
            this.txbNoAddition.Name = "txbNoAddition";
            this.txbNoAddition.Size = new System.Drawing.Size(61, 20);
            this.txbNoAddition.TabIndex = 21;
            // 
            // lblNoAddition
            // 
            this.lblNoAddition.AutoSize = true;
            this.lblNoAddition.BackColor = System.Drawing.Color.Transparent;
            this.lblNoAddition.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblNoAddition.ForeColor = System.Drawing.Color.White;
            this.lblNoAddition.Location = new System.Drawing.Point(268, 65);
            this.lblNoAddition.Name = "lblNoAddition";
            this.lblNoAddition.Size = new System.Drawing.Size(90, 22);
            this.lblNoAddition.TabIndex = 20;
            this.lblNoAddition.Text = "No add :";
            // 
            // txbHouseNo
            // 
            this.txbHouseNo.BackColor = System.Drawing.Color.Gainsboro;
            this.txbHouseNo.Location = new System.Drawing.Point(351, 39);
            this.txbHouseNo.Name = "txbHouseNo";
            this.txbHouseNo.Size = new System.Drawing.Size(61, 20);
            this.txbHouseNo.TabIndex = 19;
            this.txbHouseNo.Text = "2020";
            // 
            // lblHouseNo
            // 
            this.lblHouseNo.AutoSize = true;
            this.lblHouseNo.BackColor = System.Drawing.Color.Transparent;
            this.lblHouseNo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblHouseNo.ForeColor = System.Drawing.Color.White;
            this.lblHouseNo.Location = new System.Drawing.Point(254, 36);
            this.lblHouseNo.Name = "lblHouseNo";
            this.lblHouseNo.Size = new System.Drawing.Size(107, 22);
            this.lblHouseNo.TabIndex = 18;
            this.lblHouseNo.Text = "House No :";
            // 
            // txbCity
            // 
            this.txbCity.BackColor = System.Drawing.Color.Gainsboro;
            this.txbCity.Location = new System.Drawing.Point(143, 68);
            this.txbCity.Name = "txbCity";
            this.txbCity.Size = new System.Drawing.Size(100, 20);
            this.txbCity.TabIndex = 17;
            this.txbCity.Text = "Asgard";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.BackColor = System.Drawing.Color.Transparent;
            this.lblCity.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblCity.ForeColor = System.Drawing.Color.White;
            this.lblCity.Location = new System.Drawing.Point(82, 65);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(56, 22);
            this.lblCity.TabIndex = 16;
            this.lblCity.Text = "City :";
            // 
            // txbStreetname
            // 
            this.txbStreetname.BackColor = System.Drawing.Color.Gainsboro;
            this.txbStreetname.Location = new System.Drawing.Point(143, 39);
            this.txbStreetname.Name = "txbStreetname";
            this.txbStreetname.Size = new System.Drawing.Size(100, 20);
            this.txbStreetname.TabIndex = 15;
            this.txbStreetname.Text = "dinkusstreet";
            // 
            // lblHouseholdStreetname
            // 
            this.lblHouseholdStreetname.AutoSize = true;
            this.lblHouseholdStreetname.BackColor = System.Drawing.Color.Transparent;
            this.lblHouseholdStreetname.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblHouseholdStreetname.ForeColor = System.Drawing.Color.White;
            this.lblHouseholdStreetname.Location = new System.Drawing.Point(26, 36);
            this.lblHouseholdStreetname.Name = "lblHouseholdStreetname";
            this.lblHouseholdStreetname.Size = new System.Drawing.Size(127, 22);
            this.lblHouseholdStreetname.TabIndex = 14;
            this.lblHouseholdStreetname.Text = "Streetname :";
            // 
            // HouseholdAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(443, 229);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txbPostalcode);
            this.Controls.Add(this.lblPostalcode);
            this.Controls.Add(this.btAddEditHousehold);
            this.Controls.Add(this.txbNoAddition);
            this.Controls.Add(this.lblNoAddition);
            this.Controls.Add(this.txbHouseNo);
            this.Controls.Add(this.lblHouseNo);
            this.Controls.Add(this.txbCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txbStreetname);
            this.Controls.Add(this.lblHouseholdStreetname);
            this.Name = "HouseholdAddEditForm";
            this.Text = "HouseholdAddEditForm";
            this.Load += new System.EventHandler(this.HouseholdAddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txbPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.Button btAddEditHousehold;
        private System.Windows.Forms.TextBox txbNoAddition;
        private System.Windows.Forms.Label lblNoAddition;
        private System.Windows.Forms.TextBox txbHouseNo;
        private System.Windows.Forms.Label lblHouseNo;
        private System.Windows.Forms.TextBox txbCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txbStreetname;
        private System.Windows.Forms.Label lblHouseholdStreetname;
    }
}