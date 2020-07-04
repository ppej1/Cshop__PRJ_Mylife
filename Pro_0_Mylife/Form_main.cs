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
    public partial class Form_main : Form
    {
        Form_login form_Login;
        static string loggin_User;
        MemoHandler memoHandler = new MemoHandler();

        public Form_main()
        {
            InitializeComponent();
            
        }


        private void Form_main_Load(object sender, EventArgs e)
        {
            form_Login = new Form_login();
            form_Login.loginEventHandler += new EventHandler(LoginSuccess);
            switch (form_Login.ShowDialog())
            {
                case DialogResult.OK:
                    form_Login.Close();
                    break;
                case DialogResult.Cancel:
                    Dispose();
                    break;
            }

           
        }
        private void LoginSuccess(String userName)
        {
            MessageBox.Show(userName);
            loggin_User = userName;
            Lb_loginUser.Text = loggin_User+" 님";
        }

        private void LOGO_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 0;

        }
        private void Btn_memo_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 1;
        }

        private void Btn_ck_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 2;
        }

        private void Btn_shp_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 3;
        }

        private void Btn_hk_btn(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 4;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lb_memo_Click(object sender, EventArgs e)
        {
            txt_memo.Focus();
        }

        private void memo_add_Click(object sender, EventArgs e)
        {
            string memo = txt_memo.Text;

            if (memoHandler.InsertMemo(loggin_User, memo))
            {
                MessageBox.Show("입력 성공");
                DataSet ds = new System.Data.DataSet();
                
                memoHandler.SelectMemo(ds,loggin_User);
                MemoView1.DataSource = ds.Tables[0];
            }
        }


    }
}
