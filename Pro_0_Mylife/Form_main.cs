using Pro_0_Mylife.DAO;
using Pro_0_Mylife.DTO;
using Pro_0_Mylife.Handler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        DateTime now = DateTime.Now;
        static UserVO _logIn_User = new UserVO();
        static ArrayList shpCheck = new ArrayList();
        LoginDao logindao = new LoginDao();
        MemoDao memoDao = new MemoDao();
        HouseKeepDao hkDao = new HouseKeepDao();
        TodoListDao todoListDao = new TodoListDao();
        ShoppingWishDAO shoppingWishDAO = new ShoppingWishDAO();

        TodolistHandler todolistHandler = new TodolistHandler();
        HouseKeepHandler hkHandler = new HouseKeepHandler();
        ShoppingHandler shoppingHandler = new ShoppingHandler();
        // Program Main start //////////////////////////////////////////////////////////////////////////////////
        public Form_main()
        {
            InitializeComponent();
            Memo_flowpanel.AutoScroll = true;
            todolistFlowPanel.AutoScroll = true;
            UserInfo_panel.Hide();
            cb_shp_exchangeType.SelectedIndex = 1;
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
        // login Function////////////////////////////////////////////////////////////////////////////////////////////////
        private void LoginSuccess(String userName)
        {
            _logIn_User.Email = userName;
            SettingUser();
        }
        // 초기 로그인 유저 세팅 
        private void SettingUser()
        {
            logindao.selectNowLogin(_logIn_User);           
            Lb_loginUser.Text = _logIn_User.FirstName +" " +_logIn_User.LastName + " 님";
            lb_UserName.Text = _logIn_User.FirstName + " " + _logIn_User.LastName;
            lb_UserEmail.Text = _logIn_User.Email;
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


        // nav function //////////////////////////////////////////////////////////////////////////
        private void LOGO_Click(object sender, EventArgs e)
        {
            tab_Memo.Hide();
            tab_TodoList.Hide();
            tab_HouseKeep.Hide();
            tab_shopping.Hide();
            tab_home.Show();

            tab_form.SelectedIndex = 0;
            btn_setting(LOGO);


        }

        private void Btn_memo_Click(object sender, EventArgs e)
        {
            tab_home.Hide();
            tab_TodoList.Hide();
            tab_HouseKeep.Hide();
            tab_shopping.Hide();
            tab_Memo.Show();

            tab_form.SelectedIndex = 1;
            btn_setting(btn_memo);
            LoadMemo();
        }

        private void Btn_ck_Click(object sender, EventArgs e)
        {
            tab_home.Hide();
            tab_Memo.Hide();
            tab_HouseKeep.Hide();
            tab_shopping.Hide();
            tab_TodoList.Show();

            tab_form.SelectedIndex = 2;
            btn_setting(btn_ck);
            ResetTodolistForm();
        
        }

        private void Btn_shp_Click(object sender, EventArgs e)
        {
            tab_home.Hide();
            tab_Memo.Hide();
            tab_TodoList.Hide();
            tab_HouseKeep.Hide();
            tab_shopping.Show();

            tab_form.SelectedIndex = 3;
            loadShoppingProdType();
            resetShoppingRegister();

            
            if(shp_tab_result.SelectedIndex == 0) 
            {
                loadshopList(shp_tab_result.SelectedIndex);
            }
            shp_tab_result.SelectedIndex = 0;

            btn_setting(btn_shp);
        }

        private void Btn_hk_click(object sender, EventArgs e)
        {
            tab_home.Hide();
            tab_Memo.Hide();
            tab_TodoList.Hide();
            tab_shopping.Hide();
            tab_HouseKeep.Show();

            SettingHouseKeepAccount();
            SettingHouseKeepType();
            ResetHouseKeep();
            SetHouseKeepDate();


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


        // memo function /////////////////////////////////////////////////////////////////////////////////
        // memo label click 
        private void Lb_memo_Click(object sender, EventArgs e)
        {
            txt_memo.Focus();
        }

        private void memo_add_Click(object sender, EventArgs e)
        {
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
        // memolist Load
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
                pnl.Name = String.Format("pnl_text_{0}", row["ME_NO"].ToString());

                txtbox_contents.Size = new Size(140, 175);
                txtbox_contents.Location = new Point(15, 15);
                txtbox_contents.BackColor = Color.FromArgb(255, 255, 102);
                txtbox_contents.BorderStyle = BorderStyle.None;
                txtbox_contents.Text = String.Format("{0}", row["ME_CONTENTS"].ToString());
                txtbox_contents.Name = String.Format("txt_content_{0}", row["ME_NO"].ToString());


                txtbox_date.Size = new Size(145, 25);
                txtbox_date.Location = new Point(50, 214); 
                txtbox_date.BackColor = Color.FromArgb(255, 255, 102);
                txtbox_date.BorderStyle = BorderStyle.None;
                txtbox_date.Text = String.Format("{0}", row["ME_REG_DATE"].ToString());
                txtbox_date.Name = String.Format("txt_date_{0}", row["ME_NO"].ToString());

                btn_x.Size = new Size(28,28);
                btn_x.BackColor = System.Drawing.Color.FromArgb(255, 255, 102);
                btn_x.Font = new System.Drawing.Font("Ravie", 10F);
                btn_x.FlatStyle = FlatStyle.Flat;
                btn_x.FlatAppearance.BorderSize = 0;
                btn_x.Location = new Point(170, 4);
                btn_x.Text = String.Format("X");
                btn_x.Name = String.Format("{0}", row["ME_NO"].ToString());
                btn_x.Click += delete_memo_click;
                
                pnl.Controls.Add(txtbox_contents);
                pnl.Controls.Add(txtbox_date);
                pnl.Controls.Add(btn_x);
                Memo_flowpanel.Controls.Add(pnl);
            }
        }
        // delete memo
        private void delete_memo_click(object sender, EventArgs e)
        {
            MemoDao memoDao = new MemoDao();
            Button btn = (Button)sender;
            if (memoDao.DeleteMemo(btn.Name))
            {
                LoadMemo();
            }
        }


        // Todolist Function //////////////////////////////////////////////////////////////////////////////////
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
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                CheckBox ch_todo = new CheckBox();
                Label txt_DDay = new Label();
                Label txt_contents = new Label();
                Label txt_Period = new Label();
                Label txt_state = new Label();

                pnl.Size = new Size(804, 60);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Name = String.Format("pnl_text_{0}", row["TOD_NO"].ToString());

                ch_todo.AutoSize = false;
                ch_todo.Size = new Size(15, 30);
                ch_todo.Location = new Point(14, 15);
                ch_todo.Name = String.Format("{0}", row["TOD_NO"].ToString());
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
                txt_DDay.Name = String.Format("txt_DDayt_{0}", row["TOD_NO"].ToString());
                txt_DDay.Text = todolistHandler.selectDDay(DateTime.Parse(row["TOD_DEADLINE_DATE"].ToString()));

                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(515, 40);
                txt_contents.Location = new Point(107, 9);
                txt_contents.BackColor = Color.FromArgb(255, 255, 255);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_contents.Text = String.Format("{0}", row["TOD_CONTENTS"].ToString());
                txt_contents.Name = String.Format("{0}", row["TOD_NO"].ToString());
                txt_contents.Click += PopUpTodo;

                txt_Period.AutoSize = false;
                txt_Period.Size = new Size(80, 40);
                txt_Period.Location = new Point(628, 9);
                txt_Period.BackColor = Color.FromArgb(255, 255, 255);
                txt_Period.BorderStyle = BorderStyle.None;
                txt_Period.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Period.Text = String.Format("{0}", row["TOD_END_DATE"].ToString());
                txt_Period.Name = String.Format("txt_Period_{0}", row["TOD_NO"].ToString());

                txt_state.AutoSize = false;
                txt_state.Size = new Size(90, 40);
                txt_state.Location = new Point(715, 9);
                txt_state.BackColor = Color.FromArgb(255, 255, 255);
                txt_state.BorderStyle = BorderStyle.None;
                txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_state.Name = String.Format("txt_state_{0}", row["TOD_NO"].ToString());
                txt_state.Text = todolistHandler.todoState(row["TOD_STATE"].ToString(), DateTime.Parse(row[5].ToString()));

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


        //shoppingList Function ////////////////////////////////////////////////////////////////////////////////////
        private void btn_shpRegister_Click(object sender, EventArgs e)
        {
            if (CheckShoppingInsert())
            {
                ShoppingVO shpData = new ShoppingVO(_logIn_User.Email, cb_shp_type.SelectedIndex, txt_shp_productName.Text, cb_shp_exchangeType.SelectedIndex, Convert.ToInt32(txt_shp_price.Text), txt_shp_URL.Text);
                if (shoppingWishDAO.InsertShoppingList(shpData))
                {
                    resetShoppingRegister();
                    loadshopList(shp_tab_result.SelectedIndex);
                }
            }
        }

        private bool CheckShoppingInsert()
        {
            int i = 0;
            if (txt_shp_productName.Text.Equals(""))
            {
                MessageBox.Show("상품의 내용이 입력 되지 않았습니다.");
                return false;
            }
            else if (txt_shp_price.Text.Equals(""))
            {
                MessageBox.Show("상품의 가격이 입력 되지 않았습니다.");
                return false;
            }
            else if (!int.TryParse(txt_shp_price.Text, out i))
            {
                MessageBox.Show("상품가격은 숫자만 입력 됩니다.");
                return false;

            }
            else if (txt_shp_URL.Text.Equals(""))
            {
                MessageBox.Show("상품의 주소이 입력 되지 않았습니다.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void resetShoppingRegister()
        {
            cb_shp_type.SelectedIndex = 0;
            txt_shp_price.Text = "";
            txt_shp_productName.Text = "";
            txt_shp_URL.Text = "";
        }

        private void loadShoppingProdType()
        {
            cb_shp_type.Items.Clear();
            DataSet ds = new DataSet();
            shoppingWishDAO.SelectProdType(ds); 
            DataTable dt = ds.Tables[0];
            List<String> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["PROD_T_NAME"].ToString());
            }
            string[] data = list.ToArray();
            cb_shp_type.Items.AddRange(data);
        }

        private void loadshopList(int state)
        {
            shpCheck.Clear();
            flp_wishShp.Controls.Clear();
            flp_purchasedList.Controls.Clear();
            DataSet ds = new DataSet();
            shoppingWishDAO.loadshopList(ds,_logIn_User.Email, state);
            DataTable dt = ds.Tables[0];

            foreach(DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                CheckBox ch_wishShp = new CheckBox();
                Label txt_Type = new Label();
                Label txt_contents = new Label();
                Label txt_registerDate = new Label();
                Label txt_price = new Label();
                Button btn_URL = new Button();
                Label txt_buyDate = new Label();
                Label txt_state = new Label();

                pnl.Size = new Size(754, 100);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Name = String.Format("pnl_text_{0}", row["SHOP_NO"].ToString());

                ch_wishShp.AutoSize = false;
                ch_wishShp.Size = new Size(14, 14);
                ch_wishShp.Location = new Point(12, 38);
                ch_wishShp.Name = String.Format("{0}", row["SHOP_NO"].ToString());
                ch_wishShp.CheckedChanged += ch_wishShp_Change;

                txt_Type.AutoSize = false;
                txt_Type.Size = new Size(180,20);
                txt_Type.Location = new Point(50, 5);
                txt_Type.BackColor = Color.FromArgb(255, 255, 255);
                txt_Type.BorderStyle = BorderStyle.None;
                txt_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_Type.Name = String.Format("txt_DDayt_{0}", row["SHOP_NO"].ToString());
                DataSet tds = new DataSet();
                shoppingWishDAO.SelectOneProdType(tds, Convert.ToInt32(row["PROD_TYPE"].ToString()));
                DataTable ttb = tds.Tables[0];
                txt_Type.Text = String.Format("{0}", ttb.Rows[0]["PROD_T_NAME"].ToString());

                txt_contents.Text = String.Format("{0}", row["SHOP_NAME"].ToString());
                txt_contents.Name = String.Format("{0}", row["SHOP_NO"].ToString());
                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(590, 40);
                txt_contents.Location = new Point(50, 30);
                txt_contents.BackColor = Color.FromArgb(255, 255, 255);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                txt_registerDate.Text = String.Format("{0}", DateTime.Parse(row["SHOP_REGISTER"].ToString()).ToString("yyyy-MM-dd"));
                txt_registerDate.Name = String.Format("txt_Period_{0}", row["SHOP_NO"].ToString());
                txt_registerDate.AutoSize = false;
                txt_registerDate.Size = new Size(70, 20);
                txt_registerDate.Location = new Point(50, 75);
                txt_registerDate.BackColor = Color.FromArgb(255, 255, 255);
                txt_registerDate.BorderStyle = BorderStyle.None;
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                txt_price.Name = String.Format("txt_state_{0}", row["SHOP_NO"].ToString());
                txt_price.Text = String.Format("{0}", shoppingHandler.ExchangeSet(cb_shp_exchangeType.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["PRICE"].ToString()));
                txt_price.AutoSize = false;
                txt_price.Size = new Size(100, 20);
                txt_price.Location = new Point(500, 75);
                txt_price.BackColor = Color.FromArgb(255, 255, 255);
                txt_price.BorderStyle = BorderStyle.None;
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                btn_URL.Name = String.Format("{0}", row["SHOP_URL"].ToString());
                btn_URL.Text = String.Format("판매사이트로 가기");
                btn_URL.AutoSize = false;
                btn_URL.Size = new Size(130, 25);
                btn_URL.Location = new Point(610, 70);
                btn_URL.BackColor = Color.FromArgb(150, 255, 180);
                btn_URL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btn_URL.FlatStyle = FlatStyle.Flat;
                btn_URL.Click += btn_URL_Click;

                pnl.Controls.Add(ch_wishShp);
                pnl.Controls.Add(txt_Type);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_registerDate);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(btn_URL);

                if (shp_tab_result.SelectedIndex == 1)
                {
                    txt_buyDate.Name = String.Format("txt_state_{0}", row["SHOP_NO"].ToString());
                    txt_buyDate.Text = String.Format("({0})", DateTime.Parse(row["BUY_DATE"].ToString()).ToString("yyyy-MM-dd"));
                    txt_buyDate.AutoSize = false;
                    txt_buyDate.Size = new Size(80, 20);
                    txt_buyDate.Location = new Point(120, 75);
                    txt_buyDate.BackColor = Color.FromArgb(255, 255, 255);
                    txt_buyDate.BorderStyle = BorderStyle.None;
                    txt_buyDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    txt_state.Name = String.Format("txt_state_{0}", row["SHOP_NO"].ToString());
                    txt_state.Text = String.Format("구매완료");
                    txt_state.AutoSize = false;
                    txt_state.Size = new Size(90, 40);
                    txt_state.Location = new Point(650, 30);
                    txt_state.BackColor = Color.FromArgb(255, 255, 255);
                    txt_state.BorderStyle = BorderStyle.None;
                    txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    pnl.Controls.Add(txt_buyDate);
                    pnl.Controls.Add(txt_state);
                    flp_purchasedList.Controls.Add(pnl);
                }
                else
                {
                    flp_wishShp.Controls.Add(pnl);
                }
            }


            ShoppingInfo();
            
        }

        private void ShoppingInfo()
        {           
            List<float> wishList = shoppingHandler.CalshoppingList(cb_shp_exchangeType.SelectedIndex,_logIn_User.Email,0);
            List<float> purchasedList = shoppingHandler.CalshoppingList(cb_shp_exchangeType.SelectedIndex,_logIn_User.Email, 1);
            float totalNo = wishList[0] + purchasedList[0];
            float totalMoney = wishList[1] + purchasedList[1];

            lb_shp_wishNo.Text = wishList[0].ToString("N0");
            lb_shp_purchasedNo.Text = purchasedList[0].ToString("N0");
            lb_shp_TotalNo.Text = totalNo.ToString("N0");

            lb_shp_wishMoney.Text = shoppingHandler.AddExchangeType(cb_shp_exchangeType.SelectedIndex,wishList[1].ToString("N0"));
            lb_shp_purchasedMoney.Text = shoppingHandler.AddExchangeType(cb_shp_exchangeType.SelectedIndex,purchasedList[1].ToString("N0"));
            lb_shp_TotalMoney.Text = shoppingHandler.AddExchangeType(cb_shp_exchangeType.SelectedIndex,totalMoney.ToString("N0"));

            shp_chart.Series["Series"].Points.Clear();
            shp_chart.Series["Series"].Points.Add(wishList[1]);
            shp_chart.Series["Series"].Points.Add(purchasedList[1]);
            shp_chart.Series["Series"].Points[0].LegendText = "wishList";
            shp_chart.Series["Series"].Points[1].LegendText = "purchasedList";
            shp_chart.Series["Series"].IsValueShownAsLabel = true;
            shp_chart.Series["Series"].IsVisibleInLegend = true;
        }

        private void shp_tab_result_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadshopList(shp_tab_result.SelectedIndex);
        }

        private void cb_shp_exchangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadshopList(shp_tab_result.SelectedIndex);
        }

        private void btn_URL_Click(object sender, EventArgs e)
        {
            Button btn_URL = (Button)sender;
            System.Diagnostics.Process.Start(btn_URL.Name);
        }

        private void ch_wishShp_Change(object sender, EventArgs e)
        {
            CheckBox ch_wish = (CheckBox)sender;
            if (ch_wish.Checked)
            {
                shpCheck.Add(ch_wish.Name);
            }
            else
            {
                shpCheck.Remove(ch_wish.Name);
            }

        }
        private void btn_shpAdd_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (string chNo in shpCheck)
            {
                if (shoppingWishDAO.purchaseShpList(chNo))
                {
                    result = true;
                }
            }
            if (result)
            {
                loadshopList(shp_tab_result.SelectedIndex);
            }

        }

        //HOUSEKEEP Function ///////////////////////////////////////////////////////////////////////////////////////
        // regist new Account
        private void btn_hk_AccountRegister_Click(object sender, EventArgs e)
        {
            if(!(txt_hk_AccountName.Text.Equals("")))
            {
                HouseKeep_PaymentVO hkVO = new HouseKeep_PaymentVO(cb_hk_AccountType.SelectedIndex, txt_hk_AccountName.Text, _logIn_User.Email);
                if (hkDao.InsertAccount(hkVO))
                {
                    MessageBox.Show("success");
                    LoadHouseKeepAccountList(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                    txt_hk_AccountName.Text = "";
                    cb_hk_AccountType.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("내용이 비어있습니다.");
            }
        }
        // spend Function
        private void btn_hk_spend_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!(txt_hk_spendComment.Text.Equals("")))
            {
                if (!(txt_hk_spendPrice.Text.Equals("")))
                {
                    if (int.TryParse(txt_hk_spendPrice.Text, out i))
                    {
                        int houseKeepNo = cb_hk_spendType.SelectedIndex + 2;
                        int payNo = hkHandler.selectPaymentNo(cb_hk_spendAccont.SelectedItem.ToString(), _logIn_User);
                        HouseKeepVO houseVO = new HouseKeepVO(_logIn_User.Email, houseKeepNo, txt_hk_spendComment.Text, payNo, cb_hk_spendEx.SelectedIndex, Convert.ToSingle(txt_hk_spendPrice.Text), tdp_hk_selectDate.Value);
                        if (hkDao.spend(houseVO))
                        {
                            MessageBox.Show("Spend success");
                            LoadHouseKeepSpend(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                            LoadHouseKeepAccountList(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                            txt_hk_spendComment.Text = "";
                            txt_hk_spendPrice.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("숫자가 아닙니다.");
                        txt_hk_spendPrice.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("내용이 비어있습니다.");
                }
            }
            else
            {
                MessageBox.Show("내용이 비어있습니다.");
            }
        }


        //income Function
        private void btn_hk_income_Click(object sender, EventArgs e)
        {
            int i = 0;
            if(!(txt_hk_incomeComment.Text.Equals("")))
            {
                if(!(txt_hk_incomePrice.Text.Equals("")))
                {
                    if(int.TryParse(txt_hk_incomePrice.Text, out i))
                    {
                        int payNo = hkHandler.selectPaymentNo(cb_hk_incomeAccount.SelectedItem.ToString(), _logIn_User);
                        HouseKeepVO houseVO = new HouseKeepVO(_logIn_User.Email, txt_hk_incomeComment.Text, payNo, cb_hk_incomeEx.SelectedIndex, Convert.ToSingle(txt_hk_incomePrice.Text), tdp_hk_selectDate.Value);
                        if (hkDao.Income(houseVO))
                        {
                            MessageBox.Show("Income success");
                            LoadHouseKeepIncome(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                            LoadHouseKeepAccountList(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                            txt_hk_incomeComment.Text = "";
                            txt_hk_incomePrice.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("숫자가 아닙니다.");
                        txt_hk_incomePrice.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("내용이 비어있습니다.");
                }
            }
            else
            {
                MessageBox.Show("내용이 비어있습니다.");
            }
        }

        // Exchange Function
        private void EXCHANGE_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(txt_hk_exchangePrice.Text, out i))
            {
                int payNo1 = hkHandler.selectPaymentNo(cb_hk_exChange1.SelectedItem.ToString(), _logIn_User);
                int payNo2 = hkHandler.selectPaymentNo(cb_hk_exChange2.SelectedItem.ToString(), _logIn_User);

                HouseKeepVO houseVO1 = new HouseKeepVO(_logIn_User.Email, "Exchange(send)", payNo1, cb_hk_incomeEx.SelectedIndex, Convert.ToSingle(txt_hk_exchangePrice.Text), tdp_hk_selectDate.Value);
                HouseKeepVO houseVO2 = new HouseKeepVO(_logIn_User.Email, "Exchange(receive)", payNo2, cb_hk_incomeEx.SelectedIndex, Convert.ToSingle(txt_hk_exchangePrice.Text), tdp_hk_selectDate.Value);
                if (hkDao.ExchangeMoney(houseVO1, houseVO2))
                {
                    MessageBox.Show("Exchange success");
                    LoadHouseKeepIncome(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
                    cb_hk_exChange1.SelectedIndex = 0;
                    cb_hk_exChange2.SelectedIndex = 0;
                    txt_hk_exchangePrice.Text = "";
                }
            }
            else
            {
                MessageBox.Show("숫자가 아닙니다.");
                txt_hk_exchangePrice.Text = "";
            }

        }

        //HouseKeeper SelectFunction
        private void LoadHouseKeepIncome(String year, String month)
        {
            flp_hk_income.Controls.Clear();
            DataSet ds = new DataSet();
            hkDao.SelectInCome(ds,year,month, _logIn_User);
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txt_registerDate = new Label();
                Label txt_contents = new Label();
                Label txt_price = new Label();
                Label txt_payType = new Label();

                pnl.Size = new Size(678, 24);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Name = String.Format("pnl_text_{0}", row["KE_NO"].ToString());

                txt_registerDate.Text = String.Format("{0}", DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd"));
                txt_registerDate.Name = String.Format("txt_registerDate_{0}", row["KE_NO"].ToString());
                txt_registerDate.AutoSize = false;
                txt_registerDate.Size = new Size(99, 20);
                txt_registerDate.Location = new Point(0, 2);
                txt_registerDate.BackColor = Color.FromArgb(255, 255, 255);
                txt_registerDate.BorderStyle = BorderStyle.None;
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                txt_contents.Text = String.Format("{0}", row["KE_CONTENTS"].ToString());
                txt_contents.Name = String.Format("{0}", row["KE_NO"].ToString());
                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(359, 20);
                txt_contents.Location = new Point(100, 2);
                txt_contents.BackColor = Color.FromArgb(255, 255, 255);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                txt_price.Name = String.Format("txt_price_{0}", row["KE_NO"].ToString());
                txt_price.Text = String.Format("{0}", shoppingHandler.ExchangeSet(cb_hk_spendEx.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
                txt_price.AutoSize = false;
                txt_price.Size = new Size(79, 20);
                txt_price.Location = new Point(460, 2);
                txt_price.BackColor = Color.FromArgb(255, 255, 255);
                txt_price.BorderStyle = BorderStyle.None;
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                txt_payType.Name = String.Format("txt_payType_{0}", row["KE_NO"].ToString());
                txt_payType.Text = hkHandler.selectPaymentName(row["PAY_TYPE_NO"].ToString(), _logIn_User);
                txt_payType.AutoSize = false;
                txt_payType.Size = new Size(148, 20);
                txt_payType.Location = new Point(540, 2);
                txt_payType.BackColor = Color.FromArgb(255, 255, 255);
                txt_payType.BorderStyle = BorderStyle.None;
                txt_payType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                pnl.Controls.Add(txt_registerDate);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(txt_payType);
                flp_hk_income.Controls.Add(pnl);
            }
        }


        private void LoadHouseKeepSpend(String year, String month)
        {
            flp_hk_spend.Controls.Clear();
            DataSet ds = new DataSet();
            hkDao.SelectSpend(ds, year, month, _logIn_User);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txt_registerDate = new Label();
                Label txt_hkType = new Label();
                Label txt_contents = new Label();
                Label txt_price = new Label();
                Label txt_payType = new Label();

                pnl.Size = new Size(678, 24);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Name = String.Format("pnl_text_{0}", row["KE_NO"].ToString());

                txt_registerDate.Text = String.Format("{0}", DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd"));
                txt_registerDate.Name = String.Format("txt_registerDate_{0}", row["KE_NO"].ToString());
                txt_registerDate.AutoSize = false;
                txt_registerDate.Size = new Size(99, 20);
                txt_registerDate.Location = new Point(0, 2);
                txt_registerDate.BackColor = Color.FromArgb(255, 255, 255);
                txt_registerDate.BorderStyle = BorderStyle.None;
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                txt_hkType.Name = String.Format("txt_payType_{0}", row["KE_NO"].ToString());
                txt_hkType.Text = hkHandler.SelectHKTypeName(row["KE_TYPE"].ToString());
                txt_hkType.AutoSize = false;
                txt_hkType.Size = new Size(149, 20);
                txt_hkType.Location = new Point(100, 2);
                txt_hkType.BackColor = Color.FromArgb(255, 255, 255);
                txt_hkType.BorderStyle = BorderStyle.None;
                txt_hkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                txt_contents.Text = String.Format("{0}", row["KE_CONTENTS"].ToString());
                txt_contents.Name = String.Format("{0}", row["KE_NO"].ToString());
                txt_contents.AutoSize = false;
                txt_contents.Size = new Size(209, 20);
                txt_contents.Location = new Point(250, 2);
                txt_contents.BackColor = Color.FromArgb(255, 255, 255);
                txt_contents.BorderStyle = BorderStyle.None;
                txt_contents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                txt_price.Name = String.Format("txt_price_{0}", row["KE_NO"].ToString());
                txt_price.Text = String.Format("{0}", shoppingHandler.ExchangeSet(cb_hk_spendEx.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
                txt_price.AutoSize = false;
                txt_price.Size = new Size(79, 20);
                txt_price.Location = new Point(460, 2);
                txt_price.BackColor = Color.FromArgb(255, 255, 255);
                txt_price.BorderStyle = BorderStyle.None;
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                txt_payType.AutoSize = false;
                txt_payType.Size = new Size(148, 20);
                txt_payType.Location = new Point(540, 2);
                txt_payType.BackColor = Color.FromArgb(255, 255, 255);
                txt_payType.BorderStyle = BorderStyle.None;
                txt_payType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_payType.Name = String.Format("txt_payType_{0}", row["KE_NO"].ToString());
                txt_payType.Text = hkHandler.selectPaymentName(row["PAY_TYPE_NO"].ToString(), _logIn_User);

                pnl.Controls.Add(txt_registerDate);
                pnl.Controls.Add(txt_hkType);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(txt_payType);
                flp_hk_spend.Controls.Add(pnl);

            }
        }


        private void LoadHouseKeepAccountList(String year, String month)
        {
            flp_hk_AccontInfo.Controls.Clear();

            DataSet ds = hkDao.LoadPayment( _logIn_User);
            DataTable dt = ds.Tables[0];
            
            float allIncome =0, allSpend = 0, total=0, cashTotal = 0, AccountTotal =0 ;
            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txt_UserAccounts = new Label();
                Label txt_Carryforward = new Label();
                Label txt_Income = new Label();
                Label txt_Spend = new Label();
                Label txt_Total = new Label();

                pnl.Size = new Size(428, 24);
                pnl.BackColor = Color.FromArgb(255, 255, 255);
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Name = String.Format("pnl_text_{0}", row["PAY_TYPE_NO"].ToString());

                txt_UserAccounts.AutoSize = false;
                txt_UserAccounts.Size = new Size(149, 20);
                txt_UserAccounts.Location = new Point(0, 2);
                txt_UserAccounts.BackColor = Color.FromArgb(255, 255, 255);
                txt_UserAccounts.BorderStyle = BorderStyle.None;
                txt_UserAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_UserAccounts.Name = String.Format("txt_registerDate_{0}", row["PAY_TYPE_NO"].ToString());
                txt_UserAccounts.Text = String.Format("{0}", row["PAY_NAME"].ToString());

                txt_Carryforward.AutoSize = false;
                txt_Carryforward.Size = new Size(69, 20);
                txt_Carryforward.Location = new Point(150, 2);
                txt_Carryforward.BackColor = Color.FromArgb(255, 255, 255);
                txt_Carryforward.BorderStyle = BorderStyle.None;
                txt_Carryforward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Carryforward.Name = String.Format("txt_payType_{0}", row["PAY_TYPE_NO"].ToString());
                float forward = hkHandler.CarryForewardByAccount(year, month, row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                txt_Carryforward.Text = shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, forward.ToString("N0"));

                txt_Income.AutoSize = false;
                txt_Income.Size = new Size(69, 20);
                txt_Income.Location = new Point(220, 2);
                txt_Income.BackColor = Color.FromArgb(255, 255, 255);
                txt_Income.BorderStyle = BorderStyle.None;
                txt_Income.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                txt_Income.Name = String.Format("{0}", row["PAY_TYPE_NO"].ToString());
                float income = hkHandler.SelectMontlyIncomeByAccount(year, month,row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                txt_Income.Text = shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, income.ToString("N0"));
                allIncome += income;

                txt_Spend.AutoSize = false;
                txt_Spend.Size = new Size(69, 20);
                txt_Spend.Location = new Point(290, 2);
                txt_Spend.BackColor = Color.FromArgb(255, 255, 255);
                txt_Spend.BorderStyle = BorderStyle.None;
                txt_Spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                txt_Spend.Name = String.Format("txt_price_{0}", row["PAY_TYPE_NO"].ToString());
                float spend = hkHandler.SelectMontlySpendByAccount(year, month, row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                txt_Spend.Text = shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, spend.ToString("N0"));
                allSpend += spend;

                txt_Total.AutoSize = false;
                txt_Total.Size = new Size(68, 20);
                txt_Total.Location = new Point(360, 2);
                txt_Total.BackColor = Color.FromArgb(255, 255, 255);
                txt_Total.BorderStyle = BorderStyle.None;
                txt_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Total.Name = String.Format("txt_payType_{0}", row["PAY_TYPE_NO"].ToString());
                total = forward + income - spend;
                txt_Total.Text = shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, total.ToString("N0"));
                if (row["PAY_TYPE"].ToString().Equals("1"))
                {
                    cashTotal += total;
                }
                else
                {
                    AccountTotal += total;
                }
                
                pnl.Controls.Add(txt_UserAccounts);
                pnl.Controls.Add(txt_Carryforward);
                pnl.Controls.Add(txt_Income);
                pnl.Controls.Add(txt_Spend);
                pnl.Controls.Add(txt_Total);
                flp_hk_AccontInfo.Controls.Add(pnl);

            }
            lb_hk_infoNo2.Text = cashTotal.ToString("N0");
            lb_hk_infoNo3.Text = AccountTotal.ToString("N0");
            lb_hk_infoNo1.Text = (cashTotal + AccountTotal).ToString("N0");

            chart_inOut.Series.Clear();
            chart_inOut.Series.Add("Series1");
            chart_inOut.Series.Add("Series2");
            chart_inOut.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chart_inOut.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chart_inOut.Series["Series1"].Points.Clear();
            chart_inOut.Series["Series1"].Points.Add(allIncome);
            chart_inOut.Series["Series2"].Points.Add(allSpend);
            chart_inOut.Series["Series1"].LegendText = "수입: "+ allIncome.ToString();
            chart_inOut.Series["Series2"].LegendText = "지출: " +allSpend.ToString();
            
        }


        private void AnalysisHkByGenre(String year, String month)
        {

        }
        private void AnalysisHkByDate(String year, String month)
        {
            chart_AnalysisByDate.Series["Series1"].Points.Clear();

            Dictionary<String, float> dic = hkHandler.AnalysisHkByDate(year, month, _logIn_User, cb_hk_spendEx.SelectedIndex);

            foreach (KeyValuePair<string, float> each in dic)
            {
                string key = each.Key;
                float value = each.Value;
                chart_AnalysisByDate.Series["Series1"].Points.AddXY(key, value);
                //chart_AnalysisByDate.Series[key].LegendText = key+ " : " + value.ToString();
                chart_AnalysisByDate.Series["Series1"].IsValueShownAsLabel = true;
                chart_AnalysisByDate.Series["Series1"].IsVisibleInLegend = false;
            }

        }

        //setting for show

        //reset housekeeper  textBox
        private void ResetHouseKeep()
        {
            cb_hk_AccountType.SelectedIndex = 0;
            cb_hk_spendAccont.SelectedIndex = 0;
            cb_hk_incomeAccount.SelectedIndex = 0;
            cb_hk_exChange1.SelectedIndex = 0;
            cb_hk_exChange2.SelectedIndex = 0;

            cb_hk_incomeEx.SelectedIndex = 2;
            cb_hk_exchangeEx.SelectedIndex = 2;
            cb_hk_spendEx.SelectedIndex = 2;

            cb_hk_spendType.SelectedIndex = 0;

            txt_hk_incomeComment.Text = "";
            txt_hk_incomePrice.Text = "";
            txt_hk_AccountName.Text = "";
            txt_hk_exchangePrice.Text = "";
            txt_hk_spendComment.Text = "";
            txt_hk_spendPrice.Text = "";
        }

        private void SettingHouseKeepAccount()
        {
            cb_hk_spendAccont.Items.Clear();
            cb_hk_incomeAccount.Items.Clear();
            cb_hk_exChange1.Items.Clear();
            cb_hk_exChange2.Items.Clear();
            
            List<String> list = hkHandler.SettingHouseKeepAccount(_logIn_User);
            string[] data = list.ToArray();
            cb_hk_spendAccont.Items.AddRange(data);
            cb_hk_incomeAccount.Items.AddRange(data);
            cb_hk_exChange1.Items.AddRange(data);
            cb_hk_exChange2.Items.AddRange(data);
        }

        private void SettingHouseKeepType()
        {
            cb_hk_spendType.Items.Clear();

            List<String> list = hkHandler.SettingHouseKeepType();
            string[] data = list.ToArray();
            cb_hk_spendType.Items.AddRange(data);
        }
        
        private void SetHouseKeepDate()
        {
            tdp_hk_selectDate.Value = now;
            txt_hk_selectYear.Text = now.ToString("yyyy");
            cb_hk_selectMonth.SelectedIndex = Convert.ToInt32(now.ToString("MM")) - 1;
        }

        private void cb_hk_selectMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHouseKeepIncome(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            LoadHouseKeepSpend(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            LoadHouseKeepAccountList(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            AnalysisHkByDate(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
        }




        /* Function */



    }
}
