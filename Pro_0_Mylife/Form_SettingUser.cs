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
    public partial class Form_SettingUser : Form
    {
        UserVO _loginUser = new UserVO();
        RegisterDao register = new RegisterDao();

        public Form_SettingUser(string email)
        {
            InitializeComponent();
            _loginUser.Email = email;
            LoginDao logindao = new LoginDao();
            logindao.selectNowLogin(_loginUser);
            settingUser();
        }
        private void settingUser()
        {
            txt_email.Text = _loginUser.Email;
            txt_firstName.Text = _loginUser.FirstName;
            txt_lastName.Text = _loginUser.LastName;
            txt_phone.Text = _loginUser.Phone;
            cb_gender.SelectedIndex = _loginUser.Sex;
        }

        private void Btn_confirm_Click(object sender, EventArgs e)
        {
            if (ControlCheck())
            {
                _loginUser.Password = txt_pwd1.Text;
                _loginUser.FirstName = txt_firstName.Text;
                _loginUser.LastName = txt_lastName.Text;
                _loginUser.Phone = txt_phone.Text;
                _loginUser.Sex = cb_gender.SelectedIndex;

                if (register.confirmUser(_loginUser))
                {
                    MessageBox.Show("수정이 완료 되었습니다.");
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void Btn_withdraw_Click(object sender, EventArgs e)
        {

            if (ck_withdraw.Checked)
            {
                if (register.withdraw(_loginUser))
                {
                    MessageBox.Show("탈퇴되었습니다.");
                    DialogResult = DialogResult.Yes;
                }
            }
            else
            {
                MessageBox.Show("탈퇴를하시려면 체크박스에 동의해 주세요 ");
            }
        }


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
            else if (txt_pwd1.Text != txt_pwd2.Text)
            {
                MessageBox.Show("비밀번호가 맞지 않습니다..", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }

            return true;
        }
    }
}
