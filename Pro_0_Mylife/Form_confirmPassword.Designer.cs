namespace Pro_0_Mylife
{
    partial class Form_confirmPassword
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
            this.lb_confirm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_confirm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_signin_pwd = new System.Windows.Forms.TextBox();
            this.btn_confrim = new System.Windows.Forms.Button();
            this.panel_confirm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_confirm
            // 
            this.lb_confirm.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_confirm.Location = new System.Drawing.Point(32, 46);
            this.lb_confirm.Name = "lb_confirm";
            this.lb_confirm.Size = new System.Drawing.Size(261, 36);
            this.lb_confirm.TabIndex = 0;
            this.lb_confirm.Text = "Confirm Password";
            this.lb_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(34, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "To protect your personal information, please enter your password again.";
            // 
            // panel_confirm
            // 
            this.panel_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(65)))));
            this.panel_confirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_confirm.Controls.Add(this.btn_confrim);
            this.panel_confirm.Controls.Add(this.txt_signin_pwd);
            this.panel_confirm.Controls.Add(this.label4);
            this.panel_confirm.Location = new System.Drawing.Point(34, 131);
            this.panel_confirm.Margin = new System.Windows.Forms.Padding(0);
            this.panel_confirm.Name = "panel_confirm";
            this.panel_confirm.Size = new System.Drawing.Size(532, 105);
            this.panel_confirm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(31, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "We keeps your personal information secure and";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(31, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "will not edit or release it to the public without your consent.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sign-in Password";
            // 
            // txt_signin_pwd
            // 
            this.txt_signin_pwd.Location = new System.Drawing.Point(174, 34);
            this.txt_signin_pwd.Name = "txt_signin_pwd";
            this.txt_signin_pwd.PasswordChar = '*';
            this.txt_signin_pwd.Size = new System.Drawing.Size(232, 25);
            this.txt_signin_pwd.TabIndex = 1;
            // 
            // btn_confrim
            // 
            this.btn_confrim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(65)))));
            this.btn_confrim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confrim.Font = new System.Drawing.Font("HGPSoeiKakupoptai", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confrim.ForeColor = System.Drawing.Color.White;
            this.btn_confrim.Location = new System.Drawing.Point(421, 34);
            this.btn_confrim.Name = "btn_confrim";
            this.btn_confrim.Size = new System.Drawing.Size(91, 25);
            this.btn_confrim.TabIndex = 2;
            this.btn_confrim.Text = "submit";
            this.btn_confrim.UseVisualStyleBackColor = false;
            this.btn_confrim.Click += new System.EventHandler(this.btn_confrim_Click);
            // 
            // Form_confirmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 369);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_confirmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_confirmPassword";
            this.Load += new System.EventHandler(this.Form_confirmPassword_Load);
            this.panel_confirm.ResumeLayout(false);
            this.panel_confirm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_confirm;
        private System.Windows.Forms.Button btn_confrim;
        private System.Windows.Forms.TextBox txt_signin_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}