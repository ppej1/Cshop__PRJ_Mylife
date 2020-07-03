namespace Pro_0_Mylife
{
    partial class Form_register
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
            this.Btn_ck_email = new System.Windows.Forms.Button();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lb_register = new System.Windows.Forms.Label();
            this.txt_pwd1 = new System.Windows.Forms.TextBox();
            this.txt_pwd2 = new System.Windows.Forms.TextBox();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.Btn_ck_pwd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.Btn_register = new System.Windows.Forms.Button();
            this.Btn_cancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_ck_email
            // 
            this.Btn_ck_email.Location = new System.Drawing.Point(260, 51);
            this.Btn_ck_email.Name = "Btn_ck_email";
            this.Btn_ck_email.Size = new System.Drawing.Size(78, 25);
            this.Btn_ck_email.TabIndex = 0;
            this.Btn_ck_email.Text = "확인";
            this.Btn_ck_email.UseVisualStyleBackColor = true;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(40, 74);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(298, 25);
            this.txt_email.TabIndex = 1;
            // 
            // lb_register
            // 
            this.lb_register.Font = new System.Drawing.Font("굴림", 20F);
            this.lb_register.Location = new System.Drawing.Point(22, 9);
            this.lb_register.Name = "lb_register";
            this.lb_register.Size = new System.Drawing.Size(152, 35);
            this.lb_register.TabIndex = 2;
            this.lb_register.Text = "회원가입";
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.Location = new System.Drawing.Point(40, 157);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.Size = new System.Drawing.Size(298, 25);
            this.txt_pwd1.TabIndex = 1;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.Location = new System.Drawing.Point(40, 204);
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.Size = new System.Drawing.Size(298, 25);
            this.txt_pwd2.TabIndex = 1;
            // 
            // txt_firstName
            // 
            this.txt_firstName.Location = new System.Drawing.Point(40, 287);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(83, 25);
            this.txt_firstName.TabIndex = 1;
            // 
            // txt_lastName
            // 
            this.txt_lastName.Location = new System.Drawing.Point(147, 287);
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.Size = new System.Drawing.Size(191, 25);
            this.txt_lastName.TabIndex = 1;
            // 
            // Btn_ck_pwd
            // 
            this.Btn_ck_pwd.Location = new System.Drawing.Point(260, 128);
            this.Btn_ck_pwd.Name = "Btn_ck_pwd";
            this.Btn_ck_pwd.Size = new System.Drawing.Size(78, 26);
            this.Btn_ck_pwd.TabIndex = 0;
            this.Btn_ck_pwd.Text = "확인";
            this.Btn_ck_pwd.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "확인";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "first_name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "last_name";
            // 
            // cb_gender
            // 
            this.cb_gender.AutoCompleteCustomSource.AddRange(new string[] {
            "남자",
            "여자"});
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Location = new System.Drawing.Point(40, 381);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(298, 23);
            this.cb_gender.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "gender";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(40, 454);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(298, 25);
            this.txt_phone.TabIndex = 5;
            // 
            // Btn_register
            // 
            this.Btn_register.Location = new System.Drawing.Point(40, 506);
            this.Btn_register.Name = "Btn_register";
            this.Btn_register.Size = new System.Drawing.Size(134, 47);
            this.Btn_register.TabIndex = 6;
            this.Btn_register.Text = "가입";
            this.Btn_register.UseVisualStyleBackColor = true;
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.Location = new System.Drawing.Point(204, 506);
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(134, 47);
            this.Btn_cancel.TabIndex = 6;
            this.Btn_cancel.Text = "취소";
            this.Btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "P.H.";
            // 
            // Form_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 583);
            this.Controls.Add(this.Btn_cancel);
            this.Controls.Add(this.Btn_register);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_gender);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_register);
            this.Controls.Add(this.txt_lastName);
            this.Controls.Add(this.txt_firstName);
            this.Controls.Add(this.txt_pwd2);
            this.Controls.Add(this.txt_pwd1);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.Btn_ck_pwd);
            this.Controls.Add(this.Btn_ck_email);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_ck_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lb_register;
        private System.Windows.Forms.TextBox txt_pwd1;
        private System.Windows.Forms.TextBox txt_pwd2;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.TextBox txt_lastName;
        private System.Windows.Forms.Button Btn_ck_pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Button Btn_register;
        private System.Windows.Forms.Button Btn_cancel;
        private System.Windows.Forms.Label label8;
    }
}