namespace attaysir
{
    partial class Form1
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
            this.firstNameTxtBx = new System.Windows.Forms.TextBox();
            this.lastNameTxtBx = new System.Windows.Forms.TextBox();
            this.emailTxtBx = new System.Windows.Forms.TextBox();
            this.passwordTxtBx = new System.Windows.Forms.TextBox();
            this.identityTxtBx = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameTxtBx
            // 
            this.firstNameTxtBx.Location = new System.Drawing.Point(299, 68);
            this.firstNameTxtBx.Name = "firstNameTxtBx";
            this.firstNameTxtBx.Size = new System.Drawing.Size(239, 22);
            this.firstNameTxtBx.TabIndex = 0;
            // 
            // lastNameTxtBx
            // 
            this.lastNameTxtBx.Location = new System.Drawing.Point(299, 96);
            this.lastNameTxtBx.Name = "lastNameTxtBx";
            this.lastNameTxtBx.Size = new System.Drawing.Size(239, 22);
            this.lastNameTxtBx.TabIndex = 1;
            // 
            // emailTxtBx
            // 
            this.emailTxtBx.Location = new System.Drawing.Point(299, 124);
            this.emailTxtBx.Name = "emailTxtBx";
            this.emailTxtBx.Size = new System.Drawing.Size(239, 22);
            this.emailTxtBx.TabIndex = 2;
            // 
            // passwordTxtBx
            // 
            this.passwordTxtBx.Location = new System.Drawing.Point(299, 152);
            this.passwordTxtBx.Name = "passwordTxtBx";
            this.passwordTxtBx.Size = new System.Drawing.Size(239, 22);
            this.passwordTxtBx.TabIndex = 3;
            // 
            // identityTxtBx
            // 
            this.identityTxtBx.Location = new System.Drawing.Point(299, 180);
            this.identityTxtBx.Name = "identityTxtBx";
            this.identityTxtBx.Size = new System.Drawing.Size(239, 22);
            this.identityTxtBx.TabIndex = 4;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(391, 241);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "button1";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.identityTxtBx);
            this.Controls.Add(this.passwordTxtBx);
            this.Controls.Add(this.emailTxtBx);
            this.Controls.Add(this.lastNameTxtBx);
            this.Controls.Add(this.firstNameTxtBx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameTxtBx;
        private System.Windows.Forms.TextBox lastNameTxtBx;
        private System.Windows.Forms.TextBox emailTxtBx;
        private System.Windows.Forms.TextBox passwordTxtBx;
        private System.Windows.Forms.TextBox identityTxtBx;
        private System.Windows.Forms.Button addBtn;
    }
}