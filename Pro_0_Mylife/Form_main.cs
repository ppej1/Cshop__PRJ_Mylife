using Pro_0_Mylife.DTO;
using Pro_0_Mylife.Handler;
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
        MemoDao memoDao = new MemoDao();
        TodoListDao todoListDao = new TodoListDao();
        DateTime now = DateTime.Now;
        static UserVO _logIn_User = new UserVO();

        // main form
        public Form_main()
        {
            InitializeComponent();
            Memo_flowpanel.AutoScroll = true;
            todolistFlowPanel.AutoScroll = true;
            UserInfo_panel.Hide();

        }


        private void Form_main_Load(object sender, EventArgs e)
        {
            form_Login = new Form_login();
            form_Login.LoginEventHandler += new EventHandler(LoginSuccess);
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
            _logIn_User.Email = userName;
            SettingUser();
        }

        private void SettingUser()
        {
            LoginDao logindao = new LoginDao();
            logindao.selectNowLogin(_logIn_User);           
            Lb_loginUser.Text = _logIn_User.FirstName +" " +_logIn_User.LastName + " 님";
            lb_UserName.Text = _logIn_User.FirstName + " " + _logIn_User.LastName;
            lb_UserEmail.Text = _logIn_User.Email;
        }

        private void LOGO_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 0;
            btn_setting(LOGO);


        }

        private void Btn_memo_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 1;
            btn_setting(btn_memo);
            LoadMemo();
        }

        private void Btn_ck_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 2;
            btn_setting(btn_ck);
            ResetTodolistForm();

            
        }

        private void Btn_shp_Click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 3;
            btn_setting(btn_shp);

        }

        private void Btn_hk_click(object sender, EventArgs e)
        {
            tab_form.SelectedIndex = 4;
            btn_setting(btn_hk);
        }

        private void btn_setting(Button btn_select)
        {
            btn_memo.BackColor = Color.FromArgb(37, 44, 65);
            btn_memo.ForeColor = Color.FromArgb(255, 255, 255);
            btn_ck.BackColor = Color.FromArgb(37, 44, 65);
            btn_ck.ForeColor = Color.FromArgb(255, 255, 255);
            btn_hk.BackColor = Color.FromArgb(37, 44, 65);
            btn_hk.ForeColor = Color.FromArgb(255, 255, 255);
            btn_shp.BackColor = Color.FromArgb(37, 44, 65);
            btn_shp.ForeColor = Color.FromArgb(255, 255, 255);
            btn_select.BackColor = Color.FromArgb(255, 255, 255);
            btn_select.ForeColor = Color.FromArgb(0, 0, 0);


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
            TodolistHandler todolistHandler = new TodolistHandler();
            MemoVO memo = new MemoVO(txt_memo.Text, _logIn_User.Email);
            if (todolistHandler.CheckTextEmpty(memo.MemoContents))
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

            memoDao.SelectMemo(ds, _logIn_User.Email);

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txtbox_contents = new Label();
                Label txtbox_date = new Label();
                Button btn_x = new Button();

                pnl.Size = new Size(200, 250);
                pnl.BackColor = Color.FromArgb(255, 255, 102);
                pnl.Name = String.Format("pnl_text_{0}", row[0].ToString());

                txtbox_contents.Size = new Size(140, 175);
                txtbox_contents.Location = new Point(15, 15);
                txtbox_contents.BackColor = Color.FromArgb(255, 255, 102);
                txtbox_contents.BorderStyle = BorderStyle.None;
                txtbox_contents.Text = String.Format("{0}", row[2].ToString());
                txtbox_contents.Name = String.Format("txt_content_{0}", row[0].ToString());
                
                txtbox_date.Size = new Size(145, 25);
                txtbox_date.Location = new Point(50, 214); 
                txtbox_date.BackColor = Color.FromArgb(255, 255, 102);
                txtbox_date.BorderStyle = BorderStyle.None;
                txtbox_date.Text = String.Format("{0}", row[3].ToString());
                txtbox_date.Name = String.Format("txt_date_{0}", row[0].ToString());

                btn_x.Size = new Size(28,28);
                btn_x.BackColor = System.Drawing.Color.FromArgb(255, 255, 102);
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
            LoadAllTodolist(Todo_Calendar.SelectionStart);
            return;
        }
        private void CKstartDateChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }
        private void CkEndDateChanged(object sender, EventArgs e)
        {
            ChangeDate();
        }
        
        private void CkStartHourChanged(object sender, EventArgs e)
        {
            ChangeHour();
        }
        
        private void CkEndHourChanged(object sender, EventArgs e)
        {
            ChangeHour();
        }
        
        private void CkStartMinuteChanged(object sender, EventArgs e)
        {
            ChangeMinute();
        }
        
        private void CkEndMinuteChanged(object sender, EventArgs e)
        {
            ChangeMinute();
        }

        private void ChangeDate()
        {
            if (DateTime.Compare(DateTime.Parse(Todo_startDate.Value.ToString("yyyy-MM-dd")), DateTime.Parse(Todo_EndDate.Value.ToString("yyyy-MM-dd"))) > 0)
            {
                Todo_EndDate.Value = Todo_startDate.Value;
                ChangeHour();
            }
        }
        private void ChangeHour()
        {
            if (DateTime.Compare(DateTime.Parse(Todo_startDate.Value.ToString("yyyy-MM-dd")), DateTime.Parse(Todo_EndDate.Value.ToString("yyyy-MM-dd"))) == 0)
            {
                if (Convert.ToInt32(Todo_EndHour.SelectedItem) < Convert.ToInt32(Todo_StartHour.SelectedItem))
                {
                    Todo_EndHour.SelectedIndex = Todo_StartHour.SelectedIndex;
                    ChangeMinute();
                }
            }
        }


        private void ChangeMinute()
        {
            if (DateTime.Compare(DateTime.Parse(Todo_startDate.Value.ToString("yyyy-MM-dd")), DateTime.Parse(Todo_EndDate.Value.ToString("yyyy-MM-dd"))) == 0)
            {
                if (Convert.ToInt32(Todo_EndHour.SelectedItem) == Convert.ToInt32(Todo_StartHour.SelectedItem))
                {
                    if (Convert.ToInt32(Todo_EndMinute.SelectedItem) < Convert.ToInt32(Todo_StartMinute.SelectedItem))
                    {
                        Todo_EndMinute.SelectedIndex = Todo_StartMinute.SelectedIndex;
                    }
                }
            }
        }

        private void btn_TodoRegister_Click(object sender, EventArgs e)
        {
            TodolistHandler todolistHandler = new TodolistHandler();
            DateTime startDate = DateTime.ParseExact(Todo_startDate.Value.ToString("MM-dd-yyyy") +" "+ Todo_StartHour.Text + ":" + Todo_StartMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime todoDeadLine = DateTime.ParseExact(Todo_EndDate.Value.ToString("MM-dd-yyyy") + " " + Todo_EndHour.Text + ":" + Todo_EndMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            TodolistVO todolist = new TodolistVO(Todo_contents.Text,startDate, todoDeadLine, _logIn_User.Email);
            
            if (todolistHandler.CheckTextEmpty(todolist.TodoContent))
            {   
                if(todolistHandler.chekDate(startDate,todoDeadLine))
                {
                    if (todoListDao.InsertTodoList(todolist))
                    {
                        ResetTodolistForm();
                    }
                }
                else
                {
                    MessageBox.Show("시작일이 마감일 보다 늦습니다. 다시입력해 주세요.");
                }

            }
        }

        private void ResetTodolistForm()
        {
            Todo_contents.Text = "";
            Todo_Calendar.SelectionStart = DateTime.Now;
            Todo_startDate.Value = DateTime.Now;
            Todo_StartHour.SelectedIndex = 0;
            Todo_StartMinute.SelectedIndex = 0;
            Todo_EndDate.Value = DateTime.Now;
            Todo_EndHour.SelectedIndex = 0;
            Todo_EndMinute.SelectedIndex = 0;
        }

        private void LoadAllTodolist(DateTime selectDate)
        {
            DataSet ds = new DataSet();
            todoListDao.SelectTodoList(ds, _logIn_User.Email, selectDate);
            LoadTodolist(ds);
        }

        private void LoadTodolist(DataSet ds)
        {
            todolistFlowPanel.Controls.Clear();
            TodolistHandler todolistHandler = new TodolistHandler();
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                CheckBox ch_todo = new CheckBox();
                Label txt_DDay = new Label();
                Label txt_contents = new Label();
                Label txt_Period = new Label();
                Label txt_state = new Label();

                pnl.Size = new Size(819, 60);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.Name = String.Format("pnl_text_{0}", row[0].ToString());

                ch_todo.AutoSize = false;
                ch_todo.Size = new Size(15, 30);
                ch_todo.Location = new Point(14, 15);
                ch_todo.Name = String.Format("{0}", row[0].ToString());
                if (row[5].ToString().Equals("1"))
                {
                    ch_todo.Checked = true;
                }
                ch_todo.CheckStateChanged += TodoCheckStateChanged;

                txt_DDay.AutoSize = false;
                txt_DDay.Size = new Size(60, 40);
                txt_DDay.Location = new Point(43, 9);
                txt_DDay.BackColor = Color.FromArgb(255, 255, 255);
                txt_DDay.BorderStyle = BorderStyle.None;
                txt_DDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_DDay.Name = String.Format("txt_DDayt_{0}", row[0].ToString());
                txt_DDay.Text = todolistHandler.selectDDay(DateTime.Parse(row[5].ToString()));



                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(515, 40);
                txt_contents.Location = new Point(107, 9);
                txt_contents.BackColor = Color.FromArgb(255, 255, 255);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_contents.Text = String.Format("{0}", row[2].ToString());
                txt_contents.Name = String.Format("{0}", row[0].ToString());
                txt_contents.Click += PopUpTodo;

                txt_Period.AutoSize = false;
                txt_Period.Size = new Size(80, 40);
                txt_Period.Location = new Point(628, 9);
                txt_Period.BackColor = Color.FromArgb(255, 255, 255);
                txt_Period.BorderStyle = BorderStyle.None;
                txt_Period.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Period.Text = String.Format("{0}", row[4].ToString());
                txt_Period.Name = String.Format("txt_Period_{0}", row[0].ToString());

                txt_state.AutoSize = false;
                txt_state.Size = new Size(90, 40);
                txt_state.Location = new Point(715, 9);
                txt_state.BackColor = Color.FromArgb(255, 255, 255);
                txt_state.BorderStyle = BorderStyle.None;
                txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_state.Name = String.Format("txt_state_{0}", row[0].ToString());
                txt_state.Text = todolistHandler.todoState(row[6].ToString(), DateTime.Parse(row[5].ToString()));


                pnl.Controls.Add(ch_todo);
                pnl.Controls.Add(txt_DDay);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_Period);
                pnl.Controls.Add(txt_state);

                todolistFlowPanel.Controls.Add(pnl);
            }

        }


        private void TodoCheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;            
            todoListDao.ChangeChecklistState(chk.Name, chk.Checked);           
            LoadAllTodolist(Todo_Calendar.SelectionStart);
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!txt_todoSearch.Text.Equals(""))
            {
                DataSet ds = new DataSet();
                todoListDao.SearchTodolist(ds, _logIn_User.Email, txt_todoSearch.Text);
                LoadTodolist(ds);
                txt_todoSearch.Text = "";
            }
            else
            {
                MessageBox.Show("검색 키워드가 없습니다.");
            }
        }

        private void PopUpTodo(object sender, EventArgs e)
        {
            Label selectTodo = (Label)sender;
            Form_TodoPopUp PopUp = new Form_TodoPopUp(_logIn_User.Email, selectTodo.Name);

            PopUp.Owner = this;
            switch (PopUp.ShowDialog())
            {
                case DialogResult.OK:
                    PopUp.Close();
                    LoadAllTodolist(Todo_Calendar.SelectionStart);
                    break;
                case DialogResult.Cancel:
                    PopUp.Close();
                    break;
            }

        }

        private void Lb_loginUser_Click(object sender, EventArgs e)
        {
            if (UserInfo_panel.Visible)
            {
                UserInfo_panel.Hide();
            }
            else
            {
                UserInfo_panel.Location = new Point(1040, 41);
                UserInfo_panel.Show();
            }
        }

        private void btn_signOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Restart();
        }

        private void btn_UserModify_Click(object sender, EventArgs e)
        {
            Form_confirmPassword confirmPassword = new Form_confirmPassword(_logIn_User.Email);

            confirmPassword.Owner = this;
            switch (confirmPassword.ShowDialog())
            {
                case DialogResult.OK:
                    confirmPassword.Close();
                    loadSettingUser();
                    break;
                case DialogResult.Cancel:
                    confirmPassword.Close();
                    break;
            }
        }
        private void loadSettingUser()
        {
            Form_SettingUser settingUser = new Form_SettingUser(_logIn_User.Email);

            settingUser.Owner = this;
            switch (settingUser.ShowDialog())
            {
                case DialogResult.OK:
                    settingUser.Close();
                    SettingUser();
                    break;
                case DialogResult.Yes:
                    settingUser.Close();
                    this.Dispose();
                    Application.Restart();
                    break;
                case DialogResult.Cancel:
                    settingUser.Close();
                    break;
            }
        }





        /* Function */



    }
}
