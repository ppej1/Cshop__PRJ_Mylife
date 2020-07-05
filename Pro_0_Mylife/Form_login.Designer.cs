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
            this.lb_register = new System.Windows.Forms.Label();
            this.lb_find = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ID_lb
            // 
            this.ID_lb.Font = new System.Drawing.Font("Ravie", 10F);
            this.ID_lb.Location = new System.Drawing.Point(12, 68);
            this.ID_lb.Name = "ID_lb";
            this.ID_lb.Size = new System.Drawing.Size(102, 33);
            this.ID_lb.TabIndex = 0;
            this.ID_lb.Text = "E-mail";
            this.ID_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pwd_lb
            // 
            this.pwd_lb.Font = new System.Drawing.Font("Ravie", 10F);
            this.pwd_lb.Location = new System.Drawing.Point(8, 186);
            this.pwd_lb.Name = "pwd_lb";
            this.pwd_lb.Size = new System.Drawing.Size(129, 35);
            this.pwd_lb.TabIndex = 1;
            this.pwd_lb.Text = "Password";
            this.pwd_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(281, 342);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(100, 63);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.Login_click);
            // 
            // id_bx
            // 
            this.id_bx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_bx.Location = new System.Drawing.Point(12, 104);
            this.id_bx.Name = "id_bx";
            this.id_bx.Size = new System.Drawing.Size(369, 50);
            this.id_bx.TabIndex = 0;
            // 
            // pwd_bx
            // 
            this.pwd_bx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwd_bx.Location = new System.Drawing.Point(12, 224);
            this.pwd_bx.Name = "pwd_bx";
            this.pwd_bx.PasswordChar = '*';
            this.pwd_bx.Size = new System.Drawing.Size(369, 50);
            this.pwd_bx.TabIndex = 1;
            // 
            // lb_register
            // 
            this.lb_register.AutoSize = true;
            this.lb_register.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_register.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lb_register.Location = new System.Drawing.Point(7, 372);
            this.lb_register.Name = "lb_register";
            this.lb_register.Size = new System.Drawing.Size(261, 27);
            this.lb_register.TabIndex = 3;
            this.lb_register.Text = "Need to Register ?";
            this.lb_register.Click += new System.EventHandler(this.lb_register_Click);
            // 
            // lb_find
            // 
            this.lb_find.AutoSize = true;
            this.lb_find.Font = new System.Drawing.Font("Ravie", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_find.Location = new System.Drawing.Point(9, 353);
            this.lb_find.Name = "lb_find";
            this.lb_find.Size = new System.Drawing.Size(181, 19);
            this.lb_find.TabIndex = 3;
            this.lb_find.Text = "Forgot Password?";
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(393, 417);
            this.Controls.Add(this.lb_find);
            this.Controls.Add(this.lb_register);
            this.Controls.Add(this.pwd_bx);
            this.Controls.Add(this.id_bx);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pwd_lb);
            this.Controls.Add(this.ID_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_login";
            this.Text = "Sign In";
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
        private System.Windows.Forms.Label lb_register;
        private System.Windows.Forms.Label lb_find;
    }
}

