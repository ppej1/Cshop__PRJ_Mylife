using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    public partial class Form_confirmPassword : Form
    {
        string _login_email;
        public Form_confirmPassword(string email)
        {
            _login_email = email;
            InitializeComponent();
        }
        private void Form_confirmPassword_Load(object sender, EventArgs e)
        {

        }

        private void btn_confrim_Click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();
            UserVO user = new UserVO();
            user.Email = _login_email;
            user.Password = txt_signin_pwd.Text;
            if (ControlCheck())
            {
                if (loginDao.LoginCheck(user))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_signin_pwd.Clear();
                }
            }
        }


        private bool ControlCheck()
        {
           if (String.IsNullOrEmpty(txt_signin_pwd.Text))
            {
                MessageBox.Show("비밀번호를 입력해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_signin_pwd.Focus();
                return false;
            }
            return true;
        }

    }
}
