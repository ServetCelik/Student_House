
namespace demoFront_End
{
    partial class TenantAddEditForm
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
            this.txbFirstName = new System.Windows.Forms.TextBox();
            this.txbLastName = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btAddTenant = new System.Windows.Forms.Button();
            this.btEditTenant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbFirstName
            // 
            this.txbFirstName.Location = new System.Drawing.Point(67, 36);
            this.txbFirstName.Name = "txbFirstName";
            this.txbFirstName.Size = new System.Drawing.Size(100, 20);
            this.txbFirstName.TabIndex = 0;
            this.txbFirstName.Text = "Dippus";
            // 
            // txbLastName
            // 
            this.txbLastName.Location = new System.Drawing.Point(67, 62);
            this.txbLastName.Name = "txbLastName";
            this.txbLastName.Size = new System.Drawing.Size(100, 20);
            this.txbLastName.TabIndex = 1;
            this.txbLastName.Text = "The builder";
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(68, 136);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(100, 20);
            this.txbUsername.TabIndex = 2;
            this.txbUsername.Text = "dipwip";
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(67, 169);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(100, 20);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.Text = "dipwipenters";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(3, 39);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(58, 13);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "First name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(3, 65);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(59, 13);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last name:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 139);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 172);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // btAddTenant
            // 
            this.btAddTenant.Location = new System.Drawing.Point(218, 139);
            this.btAddTenant.Name = "btAddTenant";
            this.btAddTenant.Size = new System.Drawing.Size(75, 23);
            this.btAddTenant.TabIndex = 8;
            this.btAddTenant.Text = "Add tenant";
            this.btAddTenant.UseVisualStyleBackColor = true;
            this.btAddTenant.Click += new System.EventHandler(this.btAddTenant_Click);
            // 
            // btEditTenant
            // 
            this.btEditTenant.Location = new System.Drawing.Point(218, 172);
            this.btEditTenant.Name = "btEditTenant";
            this.btEditTenant.Size = new System.Drawing.Size(75, 23);
            this.btEditTenant.TabIndex = 9;
            this.btEditTenant.Text = "Edit tenant";
            this.btEditTenant.UseVisualStyleBackColor = true;
            this.btEditTenant.Click += new System.EventHandler(this.btEditTenant_Click);
            // 
            // TenantAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 229);
            this.Controls.Add(this.btEditTenant);
            this.Controls.Add(this.btAddTenant);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.txbLastName);
            this.Controls.Add(this.txbFirstName);
            this.Name = "TenantAddEditForm";
            this.Text = "TenantAddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFirstName;
        private System.Windows.Forms.TextBox txbLastName;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btAddTenant;
        private System.Windows.Forms.Button btEditTenant;
    }
}