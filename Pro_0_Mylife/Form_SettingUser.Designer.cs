namespace Pro_0_Mylife
{
    partial class Form_SettingUser
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
            this.Btn_withdraw = new System.Windows.Forms.Button();
            this.lb_register = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_confirm = new System.Windows.Forms.Panel();
            this.Btn_confirm = new System.Windows.Forms.Button();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_pwd2 = new System.Windows.Forms.TextBox();
            this.txt_pwd1 = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.pnl_withdraw = new System.Windows.Forms.Panel();
            this.ck_withdraw = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_confirm.SuspendLayout();
            this.pnl_withdraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_withdraw
            // 
            this.Btn_withdraw.BackColor = System.Drawing.Color.White;
            this.Btn_withdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_withdraw.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_withdraw.ForeColor = System.Drawing.Color.Black;
            this.Btn_withdraw.Location = new System.Drawing.Point(582, 14);
            this.Btn_withdraw.Name = "Btn_withdraw";
            this.Btn_withdraw.Size = new System.Drawing.Size(134, 47);
            this.Btn_withdraw.TabIndex = 27;
            this.Btn_withdraw.Text = "탈퇴";
            this.Btn_withdraw.UseVisualStyleBackColor = false;
            this.Btn_withdraw.Click += new System.EventHandler(this.Btn_withdraw_Click);
            // 
            // lb_register
            // 
            this.lb_register.Font = new System.Drawing.Font("Ravie", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_register.Location = new System.Drawing.Point(12, 9);
            this.lb_register.Name = "lb_register";
            this.lb_register.Size = new System.Drawing.Size(356, 51);
            this.lb_register.TabIndex = 13;
            this.lb_register.Text = "Setting User";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Cyan;
            this.pictureBox1.Location = new System.Drawing.Point(14, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_confirm
            // 
            this.pnl_confirm.BackColor = System.Drawing.Color.White;
            this.pnl_confirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_confirm.Controls.Add(this.Btn_confirm);
            this.pnl_confirm.Controls.Add(this.txt_phone);
            this.pnl_confirm.Controls.Add(this.label8);
            this.pnl_confirm.Controls.Add(this.label7);
            this.pnl_confirm.Controls.Add(this.cb_gender);
            this.pnl_confirm.Controls.Add(this.label6);
            this.pnl_confirm.Controls.Add(this.label5);
            this.pnl_confirm.Controls.Add(this.label4);
            this.pnl_confirm.Controls.Add(this.label3);
            this.pnl_confirm.Controls.Add(this.label2);
            this.pnl_confirm.Controls.Add(this.txt_lastName);
            this.pnl_confirm.Controls.Add(this.txt_firstName);
            this.pnl_confirm.Controls.Add(this.txt_pwd2);
            this.pnl_confirm.Controls.Add(this.txt_pwd1);
            this.pnl_confirm.Controls.Add(this.txt_email);
            this.pnl_confirm.Controls.Add(this.pictureBox1);
            this.pnl_confirm.Location = new System.Drawing.Point(20, 62);
            this.pnl_confirm.Name = "pnl_confirm";
            this.pnl_confirm.Size = new System.Drawing.Size(756, 385);
            this.pnl_confirm.TabIndex = 29;
            // 
            // Btn_confirm
            // 
            this.Btn_confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(65)))));
            this.Btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_confirm.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_confirm.ForeColor = System.Drawing.Color.White;
            this.Btn_confirm.Location = new System.Drawing.Point(585, 327);
            this.Btn_confirm.Name = "Btn_confirm";
            this.Btn_confirm.Size = new System.Drawing.Size(134, 47);
            this.Btn_confirm.TabIndex = 43;
            this.Btn_confirm.Text = "수정";
            this.Btn_confirm.UseVisualStyleBackColor = false;
            this.Btn_confirm.Click += new System.EventHandler(this.Btn_confirm_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(398, 245);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(234, 25);
            this.txt_phone.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "P.H.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(635, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "gender";
            // 
            // cb_gender
            // 
            this.cb_gender.AutoCompleteCustomSource.AddRange(new string[] {
            "MAN",
            "WOMAN"});
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Items.AddRange(new object[] {
            "MAN",
            "WOMAN"});
            this.cb_gender.Location = new System.Drawing.Point(638, 247);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(83, 23);
            this.cb_gender.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "last_name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "first_name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "confirm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "email";
            // 
            // txt_lastName
            // 
            this.txt_lastName.Location = new System.Drawing.Point(530, 181);
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.Size = new System.Drawing.Size(191, 25);
            this.txt_lastName.TabIndex = 40;
            // 
            // txt_firstName
            // 
            this.txt_firstName.Location = new System.Drawing.Point(398, 181);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(126, 25);
            this.txt_firstName.TabIndex = 39;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.Location = new System.Drawing.Point(565, 111);
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '*';
            this.txt_pwd2.Size = new System.Drawing.Size(154, 25);
            this.txt_pwd2.TabIndex = 36;
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.Location = new System.Drawing.Point(398, 111);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.PasswordChar = '*';
            this.txt_pwd1.Size = new System.Drawing.Size(161, 25);
            this.txt_pwd1.TabIndex = 30;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.White;
            this.txt_email.Location = new System.Drawing.Point(398, 37);
            this.txt_email.Name = "txt_email";
            this.txt_email.ReadOnly = true;
            this.txt_email.Size = new System.Drawing.Size(321, 25);
            this.txt_email.TabIndex = 29;
            // 
            // pnl_withdraw
            // 
            this.pnl_withdraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(44)))), ((int)(((byte)(65)))));
            this.pnl_withdraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_withdraw.Controls.Add(this.ck_withdraw);
            this.pnl_withdraw.Controls.Add(this.Btn_withdraw);
            this.pnl_withdraw.Location = new System.Drawing.Point(20, 465);
            this.pnl_withdraw.Name = "pnl_withdraw";
            this.pnl_withdraw.Size = new System.Drawing.Size(756, 78);
            this.pnl_withdraw.TabIndex = 30;
            // 
            // ck_withdraw
            // 
            this.ck_withdraw.AutoSize = true;
            this.ck_withdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ck_withdraw.ForeColor = System.Drawing.Color.White;
            this.ck_withdraw.Location = new System.Drawing.Point(25, 30);
            this.ck_withdraw.Name = "ck_withdraw";
            this.ck_withdraw.Size = new System.Drawing.Size(158, 19);
            this.ck_withdraw.TabIndex = 28;
            this.ck_withdraw.Text = "탈퇴를 원하십니까?";
            this.ck_withdraw.UseVisualStyleBackColor = true;
            // 
            // Form_SettingUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(805, 559);
            this.Controls.Add(this.pnl_withdraw);
            this.Controls.Add(this.pnl_confirm);
            this.Controls.Add(this.lb_register);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_SettingUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_SettingUser";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_confirm.ResumeLayout(false);
            this.pnl_confirm.PerformLayout();
            this.pnl_withdraw.ResumeLayout(false);
            this.pnl_withdraw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_withdraw;
        private System.Windows.Forms.Label lb_register;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_confirm;
        private System.Windows.Forms.Button Btn_confirm;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lastName;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.TextBox txt_pwd2;
        private System.Windows.Forms.TextBox txt_pwd1;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Panel pnl_withdraw;
        private System.Windows.Forms.CheckBox ck_withdraw;
    }
}