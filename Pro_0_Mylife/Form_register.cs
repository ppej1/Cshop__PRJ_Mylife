using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    public partial class Form_register : Form
    {
        RegisterDao registerDAo = new RegisterDao();

        public Form_register()
        {
            InitializeComponent();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            if (ControlCheck())
            {
                MessageBox.Show("정상입력");
                UserVO user = new UserVO(txt_email.Text, txt_pwd1.Text, txt_firstName.Text, txt_lastName.Text, cb_gender.SelectedIndex, txt_phone.Text);

                if (registerDAo.InsertEmployeeData(user))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("생성 실패");
                }
                
            }
        }

 




        // 회원가입 입력확인 
        private bool ControlCheck()
        {
            if (String.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show("이메일이 입력되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_email.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txt_pwd1.Text))
            {
                MessageBox.Show("비밀번호가 입력되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pwd1.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txt_firstName.Text))
            {
                MessageBox.Show("성이 입력되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_firstName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txt_lastName.Text))
            {
                MessageBox.Show("이름이 입력되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_lastName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txt_phone.Text))
            {
                MessageBox.Show("전화번호가 입력되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phone.Focus();
                return false;
            }else if (txt_pwd1.Text != txt_pwd2.Text)
            {
                MessageBox.Show("비밀번호가 맞지 않습니다..", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_pwd1.Focus();
                return false;
            }
            return true;
        }

        private void Btn_ck_email_Click(object sender, EventArgs e)
        {
            UserVO user = new UserVO();
            user.Email = txt_email.Text;
            if (registerDAo.CheckEmail(user))
            {
                MessageBox.Show("이 이메일은 이미 등록되어있는 이메일입니다.");
                txt_email.Text = "";
            }
            else
            {
                MessageBox.Show("이 이메일은 사용 가능한 이메일입니다.");
            }
        }
    }
}
