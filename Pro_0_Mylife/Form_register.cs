﻿using System;
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
            RegisterHandler registerHandler = new RegisterHandler();
            if (ControlCheck())
            {
                MessageBox.Show("정상입력");

                string email = txt_email.Text;
                string pwd = txt_pwd1.Text;
                string firstName = txt_firstName.Text;
                string lastName = txt_lastName.Text;
                string phoneNumber = txt_phone.Text;
                int gender = cb_gender.SelectedIndex;

                if (registerHandler.InsertEmployeeData(email,pwd,firstName,lastName,phoneNumber,gender))
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
    }
}