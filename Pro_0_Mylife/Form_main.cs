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

        // main form
        public Form_main()
        {
            InitializeComponent();
            Memo_flowpanel.AutoScroll = true;
            

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
            LoadMemo();
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

        /*  main form  End*/


        /* function */

        /* memo UI */
        private void Lb_memo_Click(object sender, EventArgs e)
        {
            txt_memo.Focus();
        }

        private void memo_add_Click(object sender, EventArgs e)
        {
            string memo = txt_memo.Text;
            if (memo.Equals(""))
            {
                MessageBox.Show("Please Input the Memo");
            }
            else
            {
                if (memoHandler.InsertMemo(loggin_User, memo))
                {
                    txt_memo.Text = "";
                    LoadMemo();
                }
            }
        }

        private void LoadMemo()
        {
            Memo_flowpanel.Controls.Clear();

            DataSet ds = new System.Data.DataSet();

            memoHandler.SelectMemo(ds, loggin_User);

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txtbox_contents = new Label();
                Label txtbox_date = new Label();
                Button btn_x = new Button();

                pnl.Size = new Size(200, 250);
                pnl.BackColor = Color.FromArgb(230, 230, 250);
                pnl.Name = String.Format("pnl_text_{0}", flowLayoutPanel1.Controls.Count);

                txtbox_contents.Size = new Size(140, 175);
                txtbox_contents.Location = new Point(15, 15);
                txtbox_contents.BackColor = Color.FromArgb(230, 230, 250);
                txtbox_contents.BorderStyle = BorderStyle.None;
                txtbox_contents.Text = String.Format("{0}", row[1].ToString());
                txtbox_contents.Name = String.Format("txt_content_{0}", row[0].ToString());
                
                txtbox_date.Size = new Size(140, 25);
                txtbox_date.Location = new Point(55, 214); 
                txtbox_date.BackColor = Color.FromArgb(230, 230, 250);
                txtbox_date.BorderStyle = BorderStyle.None;
                txtbox_date.Text = String.Format("{0}", row[2].ToString());
                txtbox_date.Name = String.Format("txt_date_{0}", row[0].ToString());

                btn_x.Size = new Size(28,28);
                btn_x.BackColor = System.Drawing.Color.FromArgb(230, 230, 250);
                btn_x.Font = new System.Drawing.Font("Ravie", 10F);
                btn_x.FlatStyle = FlatStyle.Flat;
                btn_x.FlatAppearance.BorderSize = 0;
                btn_x.Location = new Point(170, 4);
                btn_x.Text = String.Format("X");
                btn_x.Name = String.Format("{0}", row[0].ToString());
                btn_x.Click += delete_memo_click;
                

                pnl.Controls.Add(txtbox_contents);
                pnl.Controls.Add(txtbox_date);
                pnl.Controls.Add(btn_x);
                Memo_flowpanel.Controls.Add(pnl);
            }
        }
        private void delete_memo_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (memoHandler.DeleteMemo(btn.Name))
            {
                LoadMemo();
            }
        }



        /* test */
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }




        







        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
