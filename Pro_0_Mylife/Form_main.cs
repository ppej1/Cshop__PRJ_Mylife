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
using System.Windows.Forms.VisualStyles;

namespace Pro_0_Mylife
{
    public partial class Form_main : Form
    {
        Form_login form_Login;
        static string loggin_User;
        MemoDao memoDao = new MemoDao();
        TodoListDao todoListDao = new TodoListDao();
        DateTime now = DateTime.Now;


        // main form
        public Form_main()
        {
            InitializeComponent();
            Memo_flowpanel.AutoScroll = true;
            todolistFlowPanel.AutoScroll = true;


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
            lb_Todo_Title.Text = now.ToString("MMM dd,yyyy");
            resetTodolistForm();

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
            MemoVO memo = new MemoVO(txt_memo.Text, loggin_User);
            if (CheckTextEmpty(memo.MemoContents))
            {
                if (memoDao.InsertMemo(memo))
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

            memoDao.SelectMemo(ds, loggin_User);

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txtbox_contents = new Label();
                Label txtbox_date = new Label();
                Button btn_x = new Button();

                pnl.Size = new Size(200, 250);
                pnl.BackColor = Color.FromArgb(230, 230, 250);
                pnl.Name = String.Format("pnl_text_{0}", row[1].ToString());

                txtbox_contents.Size = new Size(140, 175);
                txtbox_contents.Location = new Point(15, 15);
                txtbox_contents.BackColor = Color.FromArgb(230, 230, 250);
                txtbox_contents.BorderStyle = BorderStyle.None;
                txtbox_contents.Text = String.Format("{0}", row[1].ToString());
                txtbox_contents.Name = String.Format("txt_content_{0}", row[0].ToString());
                
                txtbox_date.Size = new Size(145, 25);
                txtbox_date.Location = new Point(50, 214); 
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
            if (memoDao.DeleteMemo(btn.Name))
            {
                LoadMemo();
            }
        }
        /* memo UI END */



        /*TodoList UI */

        private void Todo_Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Todo_startDate.Value = Todo_Calendar.SelectionStart;
            Todo_EndDate.Value = Todo_Calendar.SelectionEnd;
            lb_Todo_Title.Text = Todo_Calendar.SelectionStart.ToString("MMM dd,yyyy");
            loadTodolist(Todo_Calendar.SelectionStart);
        }

        private void btn_TodoRegister_Click(object sender, EventArgs e)
        {

            DateTime startDate = DateTime.ParseExact(Todo_startDate.Value.ToString("MM-dd-yyyy") +" "+ Todo_StartHour.Text + ":" + Todo_StartMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime todoDeadLine = DateTime.ParseExact(Todo_EndDate.Value.ToString("MM-dd-yyyy") + " " + Todo_EndHour.Text + ":" + Todo_EndMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            string todoContent = Todo_contents.Text;
            TodolistVO todolist = new TodolistVO(Todo_contents.Text,startDate, todoDeadLine, loggin_User);
            
            if (CheckTextEmpty(todolist.TodoContent))
            {
                if (todoListDao.InsertTodoList(todolist))
                {
                    resetTodolistForm();
                }
            }
        }

        private void resetTodolistForm()
        {
            Todo_contents.Text = "";
            Todo_Calendar.SelectionStart = DateTime.Now;
            Todo_Calendar.SelectionEnd = DateTime.Now;
            Todo_startDate.Value = DateTime.Now;
            Todo_StartHour.SelectedIndex = 0;
            Todo_StartMinute.SelectedIndex = 0;
            Todo_EndDate.Value = DateTime.Now;
            Todo_EndHour.SelectedIndex = 0;
            Todo_EndMinute.SelectedIndex = 0;
        }

        private void loadTodolist(DateTime selectDate)
        {
            todolistFlowPanel.Controls.Clear();
            DataSet ds = new DataSet();
            todoListDao.SelectTodoList(ds, loggin_User, selectDate);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                CheckBox ch_todo = new CheckBox();
                Label txt_DDay = new Label();
                Label txt_contents = new Label();
                Label txt_Period = new Label();
                Label txt_state = new Label();

                pnl.Size = new Size(779, 60);
                pnl.BackColor = Color.FromArgb(230, 230, 250);
                pnl.Name = String.Format("pnl_text_{0}", row[0].ToString());

                ch_todo.AutoSize = false;
                ch_todo.Size = new Size(15 , 30);
                ch_todo.Location = new Point(14, 15);
                ch_todo.Name = String.Format("{0}", row[0].ToString());
                if (row[5].ToString().Equals("1"))
                {
                    ch_todo.Checked = true;
                }
                ch_todo.CheckStateChanged += todoCheckStateChanged;

                txt_DDay.AutoSize = false;
                txt_DDay.Size = new Size(60, 40);
                txt_DDay.Location = new Point(43, 9);
                txt_DDay.BackColor = Color.FromArgb(230, 230, 250);
                txt_DDay.BorderStyle = BorderStyle.None;
                txt_DDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_DDay.Name = String.Format("txt_DDayt_{0}", row[0].ToString());

                DateTime endDate = DateTime.Parse(row[4].ToString());
                TimeSpan dday = DateTime.Parse(endDate.ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                if(dday.Days > 0)
                {
                    txt_DDay.Text = String.Format("D - {0}", dday.Days);
                }
                else if(dday.Days == 0)
                {
                    txt_DDay.Text = String.Format("D - Day");

                }
                else
                {
                    txt_DDay.Text = String.Format("D + {0}", System.Math.Abs(dday.Days));
                }


                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(495, 40);
                txt_contents.Location = new Point(107, 9);
                txt_contents.BackColor = Color.FromArgb(230, 230, 250);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_contents.Text = String.Format("{0}", row[1].ToString());
                txt_contents.Name = String.Format("{0}", row[0].ToString());
                txt_contents.Click += popUpTodo;

                txt_Period.AutoSize = false;
                txt_Period.Size = new Size(80, 40);
                txt_Period.Location = new Point(608, 9);
                txt_Period.BackColor = Color.FromArgb(230, 230, 250);
                txt_Period.BorderStyle = BorderStyle.None;                
                txt_Period.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Period.Text = String.Format("{0}", row[3].ToString());
                txt_Period.Name = String.Format("txt_Period_{0}", row[0].ToString());

                txt_state.AutoSize = false;
                txt_state.Size = new Size(80, 40);
                txt_state.Location = new Point(695, 9);
                txt_state.BackColor = Color.FromArgb(230, 230, 250);
                txt_state.BorderStyle = BorderStyle.None;
                txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_state.Name = String.Format("txt_state_{0}", row[0].ToString());
                if (row[5].ToString().Equals("0"))
                {
                    if(dday.Days > 3)
                    {
                        txt_state.Text = String.Format("미완료");
                    }
                    else if(dday.Days >=0 && dday.Days <= 3)
                    {
                        txt_state.Text = String.Format("임박");
                    }
                    else
                    {
                        txt_state.Text = String.Format("기한지남");
                    }
                }
                else
                {
                    txt_state.Text = String.Format("완료");
                }


                pnl.Controls.Add(ch_todo);
                pnl.Controls.Add(txt_DDay);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_Period);
                pnl.Controls.Add(txt_state);

                todolistFlowPanel.Controls.Add(pnl);
            }
            
            
        }

        private void todoCheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;            
            todoListDao.ChangeChecklistState(chk.Name, chk.Checked);           
            loadTodolist(Todo_Calendar.SelectionStart);
            
        }
        private void popUpTodo(object sender, EventArgs e)
        {
            Label selectTodo = (Label)sender;
            TodoPopUp PopUp = new TodoPopUp(selectTodo.Name);

            PopUp.Owner = this;
            PopUp.ShowDialog();
        }






        /* Function */
        private bool CheckTextEmpty(string txt)
        {
            if (txt.Equals(""))
            {
                MessageBox.Show("Please Input the Text");
                return false;
            }
            return true;
        }


    }
}
