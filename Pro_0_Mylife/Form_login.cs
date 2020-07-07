using System;
using Pro_0_Mylife.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Pro_0_Mylife
{
    public delegate void EventHandler(String userName);
    public partial class Form_login : Form
    {
        public event EventHandler loginEventHandler;
        public Form_login()
        {
            InitializeComponent();
        }

        private void Login_click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();
            UserVO user = new UserVO();
            user.Email = id_bx.Text;
            user.Password = pwd_bx.Text;
            if (ControlCheck())
            {
                if (loginDao.LoginCheck(user))
                {
                    String userName = id_bx.Text;
                    loginEventHandler(userName);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    id_bx.Clear();
                    pwd_bx.Clear();
                }
            }
        }
        private bool ControlCheck()
        {
            if(String.IsNullOrEmpty(id_bx.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                id_bx.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(pwd_bx.Text))
            {
                MessageBox.Show("비밀번호를 입력해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pwd_bx.Focus();
                return false;
            }
            return true;
        }


        private void loginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void lb_register_Click(object sender, EventArgs e)
        {
            Form_register registerForm = new Form_register();
            registerForm.Show();
        }

    }
}
