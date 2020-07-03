namespace Pro_0_Mylife
{
    partial class Form_login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ID_lb = new System.Windows.Forms.Label();
            this.pwd_lb = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.id_bx = new System.Windows.Forms.TextBox();
            this.pwd_bx = new System.Windows.Forms.TextBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_pass_find = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_lb
            // 
            this.ID_lb.Location = new System.Drawing.Point(44, 40);
            this.ID_lb.Name = "ID_lb";
            this.ID_lb.Size = new System.Drawing.Size(86, 45);
            this.ID_lb.TabIndex = 0;
            this.ID_lb.Text = "ID";
            this.ID_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pwd_lb
            // 
            this.pwd_lb.Location = new System.Drawing.Point(44, 93);
            this.pwd_lb.Name = "pwd_lb";
            this.pwd_lb.Size = new System.Drawing.Size(86, 45);
            this.pwd_lb.TabIndex = 1;
            this.pwd_lb.Text = "Password";
            this.pwd_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_login.Location = new System.Drawing.Point(368, 40);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(77, 90);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.Login_click);
            // 
            // id_bx
            // 
            this.id_bx.Location = new System.Drawing.Point(155, 52);
            this.id_bx.Name = "id_bx";
            this.id_bx.Size = new System.Drawing.Size(176, 25);
            this.id_bx.TabIndex = 3;
            // 
            // pwd_bx
            // 
            this.pwd_bx.Location = new System.Drawing.Point(155, 104);
            this.pwd_bx.Name = "pwd_bx";
            this.pwd_bx.Size = new System.Drawing.Size(176, 25);
            this.pwd_bx.TabIndex = 4;
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(368, 136);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(77, 25);
            this.btn_register.TabIndex = 5;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_pass_find
            // 
            this.btn_pass_find.Location = new System.Drawing.Point(368, 167);
            this.btn_pass_find.Name = "btn_pass_find";
            this.btn_pass_find.Size = new System.Drawing.Size(77, 25);
            this.btn_pass_find.TabIndex = 6;
            this.btn_pass_find.Text = "find password";
            this.btn_pass_find.UseVisualStyleBackColor = true;
            this.btn_pass_find.Click += new System.EventHandler(this.btn_pass_find_Click);
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(483, 226);
            this.Controls.Add(this.btn_pass_find);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.pwd_bx);
            this.Controls.Add(this.id_bx);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pwd_lb);
            this.Controls.Add(this.ID_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ID_lb;
        private System.Windows.Forms.Label pwd_lb;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox id_bx;
        private System.Windows.Forms.TextBox pwd_bx;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_pass_find;
    }
}

