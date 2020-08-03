using Pro_0_Mylife.DAO;
using Pro_0_Mylife.DTO;
using Pro_0_Mylife.Handler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

        //로그인 후 성공여부 확인 
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
            lb_loginUser.Text = _logIn_User.FirstName +" " +_logIn_User.LastName + " 님";
            lb_UserName.Text = _logIn_User.FirstName + " " + _logIn_User.LastName;
            lb_UserEmail.Text = _logIn_User.Email;
        }

        // 유저 클릭시 유저 팝업창 열기 
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
        // 로그아웃 기능 
        private void btn_signOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Restart();
        }
        // 유저 정보 수정창 열기
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
        // 로그인 유저 수정후 성공여부 확인 
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
        //로고 클릭시 기능
        private void LOGO_Click(object sender, EventArgs e)
        {
            TabPageHideAndShow(tab_home, tab_shopping, tab_Memo, tab_TodoList, tab_HouseKeep);
            tab_form.SelectedIndex = 0;
            btn_setting(LOGO);

        }
        // 메모 버튼 클릭시 
        private void Btn_memo_Click(object sender, EventArgs e)
        {
            TabPageHideAndShow(tab_Memo, tab_home, tab_shopping, tab_TodoList, tab_HouseKeep);
            tab_form.SelectedIndex = 1;
            btn_setting(btn_memo);
            LoadMemo();
        }
        // 체크리스트 클릭시 
        private void Btn_ck_Click(object sender, EventArgs e)
        {
            TabPageHideAndShow(tab_TodoList, tab_home, tab_Memo, tab_shopping, tab_HouseKeep);
            tab_form.SelectedIndex = 2;
            btn_setting(btn_ck);
            ResetTodolistForm();
        }
        // 쇼핑리스트 클릭시 
        private void Btn_shp_Click(object sender, EventArgs e)
        {
            TabPageHideAndShow(tab_shopping, tab_home, tab_Memo, tab_TodoList, tab_HouseKeep);
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
        // 가계부 클릭시 기능 
        private void Btn_hk_click(object sender, EventArgs e)
        {
            TabPageHideAndShow(tab_HouseKeep, tab_home, tab_Memo, tab_TodoList, tab_shopping);
            SettingHouseKeepAccount();
            SettingHouseKeepType();
            ResetHouseKeep();
            SetHouseKeepDate();

            tab_form.SelectedIndex = 4;
            btn_setting(btn_hk);
        }
        // 선택한 텝 제외하고 숨기기 기능 
        private void TabPageHideAndShow(TabPage show, TabPage hide1, TabPage hide2, TabPage hide3, TabPage hide4)
        {
            show.Show();
            hide1.Hide();
            hide2.Hide();
            hide3.Hide();
            hide4.Hide();
        }
        // 버튼 색상 변경을 위한 기능 
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
        // 메모 추가 
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

                PanelDesign(pnl, 200, 250, 255, 255, 102,String.Format("pnl_text_{0}", row["ME_NO"].ToString()));
                LabelDesign(txtbox_contents, 140, 175, 15, 15, 255, 255, 102, String.Format("txt_content_{0}", row["ME_NO"].ToString()), String.Format("{0}", row["ME_CONTENTS"].ToString()));
                LabelDesign(txtbox_date, 145, 25, 50, 214, 255, 255, 102, String.Format("txt_date_{0}", row["ME_NO"].ToString()), String.Format("{0}", row["ME_REG_DATE"].ToString()));

                ButtonDesign(btn_x, 28, 28, 170, 4, 255, 255, 102, String.Format("{0}", row["ME_NO"].ToString()), String.Format("X"));
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
        // 날짜 수정시 화면 변경 
        private void Todo_Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Todo_startDate.Value = Todo_Calendar.SelectionStart;
            Todo_EndDate.Value = Todo_Calendar.SelectionEnd;
            lb_Todo_Title.Text = Todo_Calendar.SelectionStart.ToString("MMM dd,yyyy");
            LoadAllTodolist(Todo_Calendar.SelectionStart);
            return;
        }
        // 날짜 수정 호출 
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
        // 날짜 수정 기능 
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

        // Todo리스트 등록 
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
        //Todo리스트 초기화 
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
        // Todo리스트 항목 불러오기 호출 
        private void LoadAllTodolist(DateTime selectDate)
        {
            DataSet ds = new DataSet();
            todoListDao.SelectTodoList(ds, _logIn_User.Email, selectDate);
            LoadTodolist(ds);
        }
        // Todo리스트 항목 불러오기 기능 
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

                PanelDesign(pnl, todolistFlowPanel.Width - 40, 60, 255, 255, 255, String.Format("pnl_text_{0}", row["TOD_NO"].ToString()));

                ch_todo.AutoSize = false;
                ch_todo.Size = new Size(15, 30);
                ch_todo.Location = new Point(14, 15);
                ch_todo.Name = String.Format("{0}", row["TOD_NO"].ToString());
                if (row["TOD_STATE"].ToString().Equals("1"))
                {
                    ch_todo.Checked = true;
                }
                ch_todo.CheckStateChanged += TodoCheckStateChanged;


                LabelDesign(txt_DDay,60,40,43,9,255,255,255, todolistHandler.selectDDay(DateTime.Parse(row["TOD_DEADLINE_DATE"].ToString())), todolistHandler.selectDDay(DateTime.Parse(row["TOD_DEADLINE_DATE"].ToString())));

                LabelDesign(txt_contents, (pnl.Width - (txt_DDay.Location.X+txt_DDay.Width+172)), 40, 107, 9, 255, 255, 255, String.Format("{0}", row["TOD_NO"].ToString()), String.Format("{0}", row["TOD_CONTENTS"].ToString()));
                txt_contents.Click += PopUpTodo;
                
                LabelDesign(txt_Period,80,40,txt_contents.Location.X+txt_contents.Width+1,9,255,255, 255, String.Format("txt_Period_{0}", row["TOD_NO"].ToString()), String.Format("{0}", row["TOD_END_DATE"].ToString()));
                txt_Period.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                LabelDesign(txt_state,90,40, txt_Period.Location.X + txt_Period.Width + 1, 9, 255, 255,255, String.Format("txt_state_{0}", row["TOD_NO"].ToString()), todolistHandler.todoState(row["TOD_STATE"].ToString(), DateTime.Parse(row[5].ToString())));
                txt_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                pnl.Controls.Add(ch_todo);
                pnl.Controls.Add(txt_DDay);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_Period);
                pnl.Controls.Add(txt_state);

                todolistFlowPanel.Controls.Add(pnl);
            }
        }
        // 체크on/off 기능 
        private void TodoCheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;            
            todoListDao.ChangeChecklistState(chk.Name, chk.Checked);           
            LoadAllTodolist(Todo_Calendar.SelectionStart);
        }
        // Todo리스트 내부 검색 
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
        // Todo리스트 수정 팝업 열기 
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
        // 쇼핑 정보 등록 
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
        // 쇼핑 등록시 체크 항목 
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
        // 쇼핑리스트 입력창 초기화 
        private void resetShoppingRegister()
        {
            cb_shp_type.SelectedIndex = 0;
            txt_shp_price.Text = "";
            txt_shp_productName.Text = "";
            txt_shp_URL.Text = "";
        }
        // 쇼핑 입력창 쇼핑 종류 combo박스 내용 넣기
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
        // 쇼핑 리스트 불러오기 
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
                int width = 0;
                if (shp_tab_result.SelectedIndex == 0)
                {
                    width = flp_wishShp.Width - pnl_shp_side1.Width - 2;
                }
                else
                {
                    width = flp_purchasedList.Width - pnl_shp_side2.Width - 2;
                }
                PanelDesign(pnl, width, 100, 255, 255, 255, String.Format("pnl_text_{0}", row["SHOP_NO"].ToString()));

                ch_wishShp.AutoSize = false;
                ch_wishShp.Size = new Size(14, 14);
                ch_wishShp.Location = new Point(12, 38);
                ch_wishShp.Name = String.Format("{0}", row["SHOP_NO"].ToString());
                ch_wishShp.CheckedChanged += ch_wishShp_Change;

                DataSet tds = new DataSet();
                shoppingWishDAO.SelectOneProdType(tds, Convert.ToInt32(row["PROD_TYPE"].ToString()));
                DataTable ttb = tds.Tables[0];
                LabelDesign(txt_Type,180,20,50,5,255,255, 255, String.Format("txt_DDayt_{0}", row["SHOP_NO"].ToString()), String.Format("{0}", ttb.Rows[0]["PROD_T_NAME"].ToString()));

                LabelDesign(txt_contents,(pnl.Width-(txt_Type.Location.X+100)),40, (txt_Type.Location.X), 30,255,255, 255, String.Format("{0}", row["SHOP_NO"].ToString()), String.Format("{0}", row["SHOP_NAME"].ToString()));

                LabelDesign(txt_registerDate,70,20,50,75,255,255, 255, String.Format("txt_Period_{0}", row["SHOP_NO"].ToString()), String.Format("{0}", DateTime.Parse(row["SHOP_REGISTER"].ToString()).ToString("yyyy-MM-dd")));
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                LabelDesign(txt_price,100,20,(pnl.Width-245),75,255,255, 255, String.Format("txt_state_{0}", row["SHOP_NO"].ToString()), String.Format("{0}", shoppingHandler.ExchangeSet(cb_shp_exchangeType.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["PRICE"].ToString())));
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                ButtonDesign(btn_URL, 130, 25, (pnl.Width - 140), 70, 37, 44, 65, String.Format("{0}", row["SHOP_URL"].ToString()), String.Format("판매사이트로 가기"));
                btn_URL.Font = new System.Drawing.Font("Ravie", 9F);
                btn_URL.ForeColor = Color.FromArgb(255, 255, 255);
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
                    LabelDesign(txt_buyDate, 80, 20, 120, 75, 255, 255, 255, String.Format("txt_state_{0}", row["SHOP_NO"].ToString()), String.Format("({0})", DateTime.Parse(row["BUY_DATE"].ToString()).ToString("yyyy-MM-dd")));

                    LabelDesign(txt_state,90,40, (pnl.Width - 100), 30,255,255,255, String.Format("txt_state_{0}", row["SHOP_NO"].ToString()), String.Format("구매완료"));
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
        // 쇼핑리스트 소개 정보 (통계/ 그래프)
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

                PanelDesign(pnl, flp_hk_income.Width-25, 24, 255, 255, 255, String.Format("pnl_text_{0}", row["KE_NO"].ToString()));

                LabelDesign(txt_registerDate,99,20,0,2,255,255,255, String.Format("txt_registerDate_{0}", row["KE_NO"].ToString()), String.Format("{0}", DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")));
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                LabelDesign(txt_contents,(pnl.Width -(txt_registerDate.Location.X+txt_registerDate.Width+227)),20,100,2,255,255,255, String.Format("{0}", row["KE_NO"].ToString()), String.Format("{0}", row["KE_CONTENTS"].ToString()));
                
                LabelDesign(txt_price,79,20,(txt_contents.Location.X+txt_contents.Width+2),2,255,255,255, String.Format("txt_price_{0}", row["KE_NO"].ToString()), String.Format("{0}", shoppingHandler.ExchangeSet(cb_hk_spendEx.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString())));
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                LabelDesign(txt_payType,148,20,(txt_price.Location.X+txt_price.Width+2),2,255,255,255, String.Format("txt_payType_{0}", row["KE_NO"].ToString()), hkHandler.selectPaymentName(row["PAY_TYPE_NO"].ToString(), _logIn_User));
                txt_payType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                pnl.Controls.Add(txt_registerDate);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(txt_payType);
                flp_hk_income.Controls.Add(pnl);
            }
        }

        // 지출 항목 불러오기 
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

                PanelDesign(pnl, flp_hk_spend.Width - 25, 24,255,255,255, String.Format("pnl_text_{0}", row["KE_NO"].ToString()));

                LabelDesign(txt_registerDate,99,20,0,2,255,255,255, String.Format("txt_registerDate_{0}", row["KE_NO"].ToString()), String.Format("{0}", DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")));
                txt_registerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


                LabelDesign(txt_hkType,149,20,100,2,255,255,255, String.Format("txt_payType_{0}", row["KE_NO"].ToString()), hkHandler.SelectHKTypeName(row["KE_TYPE"].ToString()));
                txt_hkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                LabelDesign(txt_contents,(pnl.Width-(txt_hkType.Location.X+txt_hkType.Width+227)),20,250,2,255,255,255, String.Format("{0}", row["KE_NO"].ToString()), String.Format("{0}", row["KE_CONTENTS"].ToString()));

                LabelDesign(txt_price,79,20,(txt_contents.Location.X+txt_contents.Width+2),2,255,255,255, String.Format("txt_price_{0}", row["KE_NO"].ToString()), String.Format("{0}", shoppingHandler.ExchangeSet(cb_hk_spendEx.SelectedIndex, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString())));
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                LabelDesign(txt_payType,148,20, (txt_price.Location.X + txt_price.Width + 2), 2,255,255,255, String.Format("txt_payType_{0}", row["KE_NO"].ToString()), hkHandler.selectPaymentName(row["PAY_TYPE_NO"].ToString(), _logIn_User));
                txt_payType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                pnl.Controls.Add(txt_registerDate);
                pnl.Controls.Add(txt_hkType);
                pnl.Controls.Add(txt_contents);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(txt_payType);
                flp_hk_spend.Controls.Add(pnl);

            }
        }
        // 월별 계좌의 수입지출 보기 
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

                PanelDesign(pnl,428,24,255,255,255, String.Format("pnl_text_{0}", row["PAY_TYPE_NO"].ToString()));

                LabelDesign(txt_UserAccounts,149,20,0,2,255,255,255, String.Format("txt_registerDate_{0}", row["PAY_TYPE_NO"].ToString()), String.Format("{0}", row["PAY_NAME"].ToString()));
                txt_UserAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                float forward = hkHandler.CarryForewardByAccount(year, month, row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                LabelDesign(txt_Carryforward,69,20,150,2,255,255,255, String.Format("txt_payType_{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, forward.ToString("N0")));
                txt_Carryforward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                float income = hkHandler.SelectMontlyIncomeByAccount(year, month,row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                LabelDesign(txt_Income,69,20,220,2,255,255,255, String.Format("{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, income.ToString("N0")));
                allIncome += income;


                float spend = hkHandler.SelectMontlySpendByAccount(year, month, row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                allSpend += spend;
                LabelDesign(txt_Spend,69,20,290,2,255,255,255, String.Format("txt_price_{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, spend.ToString("N0")));
                txt_Spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                total = forward + income - spend;
                LabelDesign(txt_Total,68,20,360,2,255,255,255, String.Format("txt_payType_{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, total.ToString("N0")));
                txt_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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

        //Monthly analysis  ( 분석 ) 
        // 항목 분류예 따른 지출량 분석 
        private void AnalysisHkByGenre(String year, String month)
        {
            chart_hk_pie.Series["Series1"].Points.Clear();
            flp_hk_analysis.Controls.Clear();
            List<String> list = hkHandler.SettingHouseKeepType();
            float total= 0;

            foreach (String item in list)
            {
                float result = hkHandler.CalcTotalByType(year, month, _logIn_User, list.IndexOf(item) + 2, cb_hk_spendEx.SelectedIndex);
                total += result;
            }
            foreach (String item in list)
            {
                float result = hkHandler.CalcTotalByType(year, month, _logIn_User, list.IndexOf(item) + 2, cb_hk_spendEx.SelectedIndex);
                float rate = 0;
                rate = result / total * 100;
                if (rate.Equals(float.NaN))
                {
                  rate = 0;
                }
                Panel pnl = new Panel();
                Label txt_hkType = new Label();
                Label txt_price = new Label();
                Label txt_rate = new Label();

                PanelDesign(pnl,628,20,255,255,255, String.Format("pnl_text_{0}", list.IndexOf(item)));
                pnl.BorderStyle = BorderStyle.None;

                LabelDesign(txt_hkType,200,16,7,2,255,255,255, String.Format("{0}", list.IndexOf(item) + 2), item);

                LabelDesign(txt_price, 200, 16, 214, 2, 255, 255, 255, String.Format("{0}", list.IndexOf(item) + 2), String.Format("{0}", shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, result.ToString("N0"))));
                txt_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    
                LabelDesign(txt_rate,200,16,421,2,255,255,255, String.Format("txt_price_{0}", list.IndexOf(item) + 2), String.Format("{0}%", rate.ToString("N2")));
                txt_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                pnl.Controls.Add(txt_hkType);
                pnl.Controls.Add(txt_price);
                pnl.Controls.Add(txt_rate);
                flp_hk_analysis.Controls.Add(pnl);

                if (result != 0)
                {
                    chart_hk_pie.Series["Series1"].Points.AddXY(item, result);
                }
            }
            chart_hk_pie.Series["Series1"].IsValueShownAsLabel = false;
            chart_hk_pie.Series["Series1"].IsVisibleInLegend = false;
        }

        // 월별 날짜에 따른 지출량 분석 
        private void AnalysisHkByDate(String year, String month)
        {
            chart_AnalysisByDate.Series.Clear();

            Dictionary<String, float> dic = hkHandler.AnalysisHkByDate(year, month, _logIn_User, cb_hk_spendEx.SelectedIndex,0);
            Dictionary<String, float> dicIn = hkHandler.AnalysisHkByDate(year, month, _logIn_User, cb_hk_spendEx.SelectedIndex, 1);

            Series Series1 = new Series();
            Series Series2 = new Series();
            chart_AnalysisByDate.Series.Add(Series1);
            chart_AnalysisByDate.Series.Add(Series2);
            foreach (KeyValuePair<string, float> each in dic)
            {
                string key = each.Key;
                float value = each.Value;
                chart_AnalysisByDate.Series["Series1"].Points.AddXY(key, value);
                chart_AnalysisByDate.Series["Series1"].IsValueShownAsLabel = true;
                chart_AnalysisByDate.Series["Series1"].IsVisibleInLegend = false;

            }
            foreach (KeyValuePair<string, float> each in dicIn)
            {
                string key = each.Key;
                float value = each.Value;
                chart_AnalysisByDate.Series["Series2"].Points.AddXY(key, value);
                chart_AnalysisByDate.Series["Series2"].IsValueShownAsLabel = true;
                chart_AnalysisByDate.Series["Series2"].IsVisibleInLegend = false;
            }
        }

        //year Analysis ( 년간 분석 )

        private void AnalysisHkYearAccountList(String year)
        {
            pnl_hk_anal_title.Controls.Clear();
            flp_hk_year_anal1.Controls.Clear();
            pnl_hk_y_ana1.Width = flp_hk_year.Width - 23;
            chart_hk_year_anal1.Width = pnl_hk_year_anal1.Width / 2 - 3;
            chart_hk_year_anal2.Width = pnl_hk_year_anal1.Width / 2;
            chart_hk_year_anal2.Location = new Point(chart_hk_year_anal1.Location.X + chart_hk_year_anal1.Width + 1, 4);
            flp_hk_year_anal1.Width = pnl_hk_year_anal1.Width - 21;
            InsertCulumn(pnl_hk_anal_title);

            AnalysisHkYearAccountListIncome(year);
            AnalysisHkYearAccountListSpend(year);
            AnalysisHkYearAccountListTotal(year);

        }
        private void AnalysisHkYearByType(String year)
        {
            pnl_hk_anal_title2.Controls.Clear();
            pnl_hk_y_ana2.Width = flp_hk_year.Width - 23;
            InsertCulumn(pnl_hk_anal_title2);
            flp_hk_year_anal2.Width = pnl_hk_y_ana2.Width - 21;

            AnalysisHkYearByTypeDetail(year);
            AnalysisHkYearByTypeTotal(year);
        }
        private void  AnalysisHkYearAccountListIncome(String year)
        {
            DataSet ds = hkDao.LoadPayment(_logIn_User);
            DataTable dt = ds.Tables[0];
            List<String> list_X = new List<String>();
            List<float[]> list_Y = new List<float[]>();
            List<String> list_L = new List<String>();
            float allIncome = 0,  totalIncome = 0 ;
            Panel pnl1 = new Panel();
            Label[] txt_Incomes = new Label[12];
            Label txt_UserTitle = new Label();
            Label txt_TotalIncome = new Label();
            PanelDesign(pnl1, flp_hk_year_anal1.Width-33, 24, 255, 255, 255, String.Format("pnl_text"));
            int size = pnl1.Width / 15;
            int x = (pnl1.Width / 15) * 3;
            pnl1.Margin = new Padding(0, 0, 0, 0);
            LabelDesign(txt_UserTitle, size * 2, 20, 0, 1, 255, 255, 255, String.Format("txt_registerDate"), String.Format("입금"));
            txt_UserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           
            for (int i = 0; i < 12; i++)
            {
                List<float> temp = new List<float>();
                Label txt_Income = new Label();

                foreach (DataRow row in dt.Rows)
                {
                    int month = i + 1;
                    float income = hkHandler.SelectMontlyIncomeByAccount(year, month.ToString(), row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex);
                    allIncome += income;
                    temp.Add(income);
                    if(i == 0){ list_L.Add(row["PAY_NAME"].ToString()); }
                    
                }
                LabelDesign(txt_Income, size, 20, x, 1, 255, 255, 255, String.Format("income"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, allIncome.ToString("N0")));
                txt_Income.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                x = txt_Income.Location.X + txt_Income.Width;
                txt_Incomes[i] = txt_Income;
                pnl1.Controls.Add(txt_Incomes[i]);
                totalIncome += allIncome;
                allIncome = 0;
                list_X.Add(String.Format("{0}/{1}",year ,i+1));
                float[] array = temp.ToArray();
                list_Y.Add(array);
            }
            x = txt_UserTitle.Location.X + txt_UserTitle.Width;
            LabelDesign(txt_TotalIncome, size, 20, x, 1, 255, 255, 255, String.Format("txt_TotalIncome"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, totalIncome.ToString("N0")));
            txt_TotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txt_TotalIncome.BorderStyle = BorderStyle.FixedSingle;
            
            pnl1.Controls.Add(txt_TotalIncome);
            pnl1.Controls.Add(txt_UserTitle);

            flp_hk_year_anal1.Controls.Add(pnl1);
            Chart_HK_Year(chart_hk_year_anal1,list_L, list_X,list_Y);
        }
        private void AnalysisHkYearAccountListSpend(String year)
        {
            DataSet ds = hkDao.LoadPayment(_logIn_User);
            DataTable dt = ds.Tables[0];

            float allSpend = 0, total = 0;
            int flp_height = 0;
            foreach (DataRow row in dt.Rows)
            {
                Panel pnl = new Panel();
                Label txt_Total = new Label();
                Label[] txt_Spends = new Label[12];
                Label txt_UserAccounts = new Label();
                flp_height += 25;
                PanelDesign(pnl, flp_hk_year_anal1.Width - 33, 24, 255, 255, 255, String.Format("pnl_txt_{0}", row["PAY_TYPE_NO"].ToString()));
                pnl.Margin = new Padding(0, 0, 0, 0);
                int size = pnl.Width / 15;
                int x = (pnl.Width / 15) * 3;

                LabelDesign(txt_UserAccounts, size * 2, 20, 0, 1, 255, 255, 255, String.Format("txt_registerDate_{0}", row["PAY_TYPE_NO"].ToString()), String.Format("{0}", row["PAY_NAME"].ToString()));
                txt_UserAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                for (int i = 0; i <= 11; i++)
                {
                    Label txt_Spend = new Label();
                    int month = i + 1;
                    float spend = hkHandler.SelectMontlySpendByAccount(year, month.ToString(), row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex); ;
                    LabelDesign(txt_Spend, size, 20, x, 1, 255, 255, 255, String.Format("txt_price_{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, spend.ToString("N0")));
                    txt_Spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    allSpend += spend;
                    txt_Spends[i] = txt_Spend;
                    x = txt_Spend.Location.X + txt_Spend.Width;

                }
                x = (pnl.Width / 15) * 2;

                LabelDesign(txt_Total, size, 20, x, 1, 255, 255, 255, String.Format("txt_payType_{0}", row["PAY_TYPE_NO"].ToString()), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, total.ToString("N0")));
                txt_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Total.BorderStyle = BorderStyle.FixedSingle;

                total = allSpend;
                allSpend = 0;

                pnl.Controls.Add(txt_UserAccounts);

                for (int i = 0; i <= 11; i++)
                {
                    pnl.Controls.Add(txt_Spends[i]);
                }
                pnl.Controls.Add(txt_Total);
                flp_hk_year_anal1.Controls.Add(pnl);
            }
            flp_hk_year_anal1.Height = flp_height + 50;
            pnl_hk_year_anal1.Height = flp_hk_year_anal1.Height + 50;
            pnl_hk_y_ana1.Height = pnl_hk_year_anal1.Height + 330;
        }

        private void AnalysisHkYearAccountListTotal(String year)
        {
            DataSet ds = hkDao.LoadPayment(_logIn_User);
            DataTable dt = ds.Tables[0];
            float allSpend = 0, totalSpend = 0;
            List<String> list_X = new List<String>();
            List<float[]> list_Y = new List<float[]>();
            List<String> list_L = new List<String>();

            Panel pnl2 = new Panel();
            Label[] txt_spends2 = new Label[12];
            Label txt_TotalSpendTitle2 = new Label();
            Label txt_TotalSpend = new Label();

            PanelDesign(pnl2, flp_hk_year_anal1.Width - 33, 24, 240, 240, 240, String.Format("pnl_text"));
            pnl2.Margin = new Padding(0, 0, 0, 0);

            LabelDesign(txt_TotalSpendTitle2, (pnl2.Width / 15) * 2, 20, 0, 1, 240, 240, 240, String.Format("txt_registerDate"), String.Format("합계"));
            txt_TotalSpendTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            int size = pnl2.Width / 15;
            int x = (pnl2.Width / 15) * 3;
            for (int i = 0; i < 12; i++)
            {
                List<float> temp = new List<float>();
                Label txt_spend = new Label();
                foreach (DataRow row in dt.Rows)
                {
                    int month = i + 1;
                    float spend = hkHandler.SelectMontlySpendByAccount(year, month.ToString(), row["PAY_TYPE_NO"].ToString(), _logIn_User, cb_hk_spendEx.SelectedIndex); ;
                    allSpend += spend;
                    temp.Add(spend);
                    if (i == 0) { list_L.Add(row["PAY_NAME"].ToString()); }
                }
                LabelDesign(txt_spend, size, 20, x, 1, 240, 240, 240, String.Format("spend"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, allSpend.ToString("N0")));
                txt_spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                x = txt_spend.Location.X + txt_spend.Width;

                txt_spends2[i] = txt_spend;
                pnl2.Controls.Add(txt_spends2[i]);
                totalSpend += allSpend;
                allSpend = 0;
                list_X.Add(String.Format("{0}/{1}", year, i + 1));
                float[] array = temp.ToArray();
                list_Y.Add(array);
            }
            x = txt_TotalSpendTitle2.Location.X + txt_TotalSpendTitle2.Width;

            LabelDesign(txt_TotalSpend, size, 20, x, 1, 240, 240, 240, String.Format("txt_TotalIncome"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, totalSpend.ToString("N0")));
            txt_TotalSpend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txt_TotalSpend.BorderStyle = BorderStyle.FixedSingle;
            pnl2.Controls.Add(txt_TotalSpendTitle2);
            pnl2.Controls.Add(txt_TotalSpend);

            flp_hk_year_anal1.Controls.Add(pnl2);
            Chart_HK_Year(chart_hk_year_anal2, list_L, list_X, list_Y);

        }


        private void AnalysisHkYearByTypeDetail(String year)
        {
            flp_hk_year_anal2.Controls.Clear();

            List<String> list = hkHandler.SettingHouseKeepType();

            float allSpend = 0;
            int flp_height = 0;

            foreach (String item in list)
            {
                Panel pnl = new Panel();
                Label txt_Total = new Label();
                Label[] txt_Spends = new Label[12];
                Label txt_UserType = new Label();
                flp_height += 25;
                PanelDesign(pnl, flp_hk_year_anal2.Width - 33, 24, 255, 255, 255, String.Format("pnl_text_{0}", list.IndexOf(item)));
                pnl.Margin = new Padding(0, 0, 0, 0);

                int size = pnl.Width / 15;
                int x = (pnl.Width / 15) * 3;
                LabelDesign(txt_UserType, size*2, 20, 0, 0, 255, 255, 255, String.Format("txt_registerDate_{0}", String.Format("pnl_text_{0}", list.IndexOf(item))), item);
                txt_UserType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                for (int i = 0; i <= 11; i++)
                {
                    Label txt_Spend = new Label();
                    int month = i + 1;
                    float spend = hkHandler.CalcTotalByType(year, month.ToString(), _logIn_User, list.IndexOf(item) + 2, cb_hk_spendEx.SelectedIndex);
                    LabelDesign(txt_Spend, size, 20, x, 1, 255, 255, 255, String.Format("{0}", list.IndexOf(item) + 2), String.Format("{0}", shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, spend.ToString("N0"))));
                    txt_Spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    allSpend += spend;
                    txt_Spends[i] = txt_Spend;
                    x = txt_Spend.Location.X + txt_Spend.Width;
                }
                x = (pnl.Width / 15) * 2;
                LabelDesign(txt_Total, size, 20, x, 1, 255, 255, 255, String.Format("{0}", list.IndexOf(item) + 2), String.Format("{0}", shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, allSpend.ToString("N0"))));
                txt_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                txt_Total.BorderStyle = BorderStyle.FixedSingle;

                pnl.Controls.Add(txt_UserType);

                for (int i = 0; i <= 11; i++)
                {
                    pnl.Controls.Add(txt_Spends[i]);
                }
                pnl.Controls.Add(txt_Total);
                flp_hk_year_anal2.Controls.Add(pnl);
            }

            flp_hk_year_anal2.Height = flp_height+3;
            pnl_hk_year_anal2.Height = flp_hk_year_anal2.Height + 80;
            pnl_hk_y_ana2.Height = pnl_hk_year_anal2.Height + 470;     
        }

        private void AnalysisHkYearByTypeTotal(String year)
        {
            List<String> list = hkHandler.SettingHouseKeepType();
            List<String> list_X = new List<String>();
            List<float[]> list_Y = new List<float[]>();
            List<String> list_L = new List<String>();
            float allSpend = 0, totalSpend = 0;

            Panel pnl2 = new Panel();
            Label[] txt_spends2 = new Label[12];
            Label txt_TotalSpendTitle2 = new Label();
            Label txt_TotalSpend = new Label();

            PanelDesign(pnl2, flp_hk_year_anal2.Width - 33, 24, 240, 240, 240, String.Format("pnl_text"));
            pnl2.Margin = new Padding(0, 0, 0, 0);
            int size = pnl2.Width / 15;
            int x = (pnl2.Width / 15) * 3;
            LabelDesign(txt_TotalSpendTitle2, size, 20, 0, 1, 240, 240, 240, String.Format("txt_registerDate"), String.Format("합계"));
            txt_TotalSpendTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            for (int i = 0; i < 12; i++)
            {
                List<float> temp = new List<float>();
                Label txt_spend = new Label();
                foreach (String item in list)
                {
                    int month = i + 1;
                    float spend = hkHandler.CalcTotalByType(year, month.ToString(), _logIn_User, list.IndexOf(item) + 2, cb_hk_spendEx.SelectedIndex);
                    allSpend += spend;
                    temp.Add(spend);
                    if (i == 0) { list_L.Add(item); }
                }
                LabelDesign(txt_spend, size, 20, x, 1, 240, 240, 240, String.Format("spend"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, allSpend.ToString("N0")));
                txt_spend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                txt_spends2[i] = txt_spend;
                pnl2.Controls.Add(txt_spends2[i]);
                totalSpend += allSpend;
                allSpend = 0;
                list_X.Add(String.Format("{0}/{1}", year, i + 1));
                float[] array = temp.ToArray();
                list_Y.Add(array);
                x = txt_spend.Location.X + txt_spend.Width;

            }
            x = (pnl2.Width / 15) * 2;
            LabelDesign(txt_TotalSpend, size, 20, x, 1, 240, 240, 240, String.Format("txt_TotalIncome"), shoppingHandler.AddExchangeType(cb_hk_spendEx.SelectedIndex, totalSpend.ToString("N0")));
            txt_TotalSpend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txt_TotalSpend.BorderStyle = BorderStyle.FixedSingle;
            pnl2.Controls.Add(txt_TotalSpendTitle2);
            pnl2.Controls.Add(txt_TotalSpend);

            flp_hk_year_anal2.Controls.Add(pnl2);
            Chart_HK_Year(chart_hk_year_anal3, list_L, list_X, list_Y);

        }

        //chart
        private void Chart_HK_Year(Chart chart ,List<String> legend,List<String> list_X, List<float[]> list_Y)
        {
            {
                string[] legends = legend.ToArray();

                chart.Series.Clear();  

                foreach (var item in legends)
                {
                    chart.Series.Add(item);

                    chart.Series[item].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    chart.Series[item].LegendText = item; 
                }

                string[] xValues = list_X.ToArray();    
                float[][] yValues = list_Y.ToArray();   

                for (int i = 0; i< xValues.Length; i++)
                {
                    for(int j = 0; j < yValues[i].Length; j++)
                    {
                     
                        System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                        dp.SetValueXY(xValues[i], yValues[i][j]);
                        chart.Series[legends[j]].Points.Add(dp);  
                    }
                }
            }
        }


        //design

        private void ButtonDesign(Button btn, int size_x, int size_y, int location_x, int location_y, int r, int g, int b, String n, String s)
        {
            btn.Size = new Size(size_x, size_y);
            btn.Location = new Point(location_x, location_y);
            btn.BackColor = System.Drawing.Color.FromArgb(r, g, b);
            btn.Font = new System.Drawing.Font("Ravie", 10F);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Text = s;
            btn.Name = n;
        }
        private void PanelDesign(Panel pnl, int size_x, int size_y, int r, int g, int b, String n)
        {
            pnl.Size = new Size(size_x, size_y);
            pnl.BackColor = Color.FromArgb(r, g, b);
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Name = n;
        }
        private void LabelDesign(Label temp, int size_x , int size_y,int location_x,int location_y, int r, int g, int b,String n,String s)
        {
            temp.AutoSize = false;
            temp.Size = new Size(size_x, size_y);
            temp.Location = new Point(location_x, location_y);
            temp.BackColor = Color.FromArgb(r, g, b);
            temp.BorderStyle = BorderStyle.None;
            temp.Name = n;
            temp.Text = s;
            temp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        }
        private void InsertCulumn(Panel pnl)
        {
            String[] Culumn = { "항목","합계","Jan.","Feb.","Mar.","Apr.","May.","Jun.","Jul.","Aug.","Sep.","Oct.","Nov.","Dec." };
            int width = pnl.Width / 15;
            int size_x = width*2-1;
            int size_y = 20;
            int location_x = 0;
            int location_y = 1;
            for(int i=0; i<Culumn.Length; i++)
            {
                Label lb = new Label();
                LabelDesign(lb, size_x, size_y, location_x, location_y, 255, 255, 25, "title", Culumn[i]);
                pnl.Controls.Add(lb);
                size_x = width;
                location_x = lb.Location.X + lb.Width+1;
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
            txt_hk_A_selectYear.Text = now.ToString("yyyy");
        }

        private void cb_hk_selectMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHouseKeepIncome(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            LoadHouseKeepSpend(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            LoadHouseKeepAccountList(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            AnalysisHkByDate(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            AnalysisHkByGenre(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
        }

        private void Title_timer_Tick(object sender, EventArgs e)
        {
            lb_title_Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void cb_hk_spendEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_hk_incomeEx.SelectedIndex = cb_hk_spendEx.SelectedIndex;
            cb_hk_exchangeEx.SelectedIndex = cb_hk_spendEx.SelectedIndex;
        }

        private void cb_hk_incomeEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_hk_spendEx.SelectedIndex = cb_hk_incomeEx.SelectedIndex;
            cb_hk_exchangeEx.SelectedIndex = cb_hk_incomeEx.SelectedIndex;
        }

        private void cb_hk_exchangeEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_hk_incomeEx.SelectedIndex = cb_hk_exchangeEx.SelectedIndex;
            cb_hk_spendEx.SelectedIndex = cb_hk_exchangeEx.SelectedIndex;
        }

        private void txt_hk_selectYear_TextChanged(object sender, EventArgs e)
        {
            if(txt_hk_selectYear.TextLength <=0|| txt_hk_selectYear.TextLength > 4 || Convert.ToInt32(txt_hk_selectYear.Text.ToString())<= 0 ) { txt_hk_selectYear.Text = now.ToString("yyyy"); }
            if(!(cb_hk_selectMonth.SelectedItem is null))
            {
                txt_hk_A_selectYear.Text = txt_hk_selectYear.Text;
            }
        }

        private void txt_hk_A_selectYear_TextChanged(object sender, EventArgs e)
        {
            if (txt_hk_A_selectYear.TextLength <= 0 || txt_hk_A_selectYear.TextLength > 4 || Convert.ToInt32(txt_hk_A_selectYear.Text.ToString()) <= 0) { txt_hk_A_selectYear.Text = now.ToString("yyyy"); }

            AnalysisHkYearAccountList(txt_hk_A_selectYear.Text);
            AnalysisHkYearByType(txt_hk_A_selectYear.Text);
        }

        private void todo_panel2_Resize(object sender, EventArgs e)
        {
            LoadAllTodolist(Todo_Calendar.SelectionStart);
        }

        private void hk_month_table_Resize(object sender, EventArgs e)
        {
            LoadHouseKeepIncome(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
            LoadHouseKeepSpend(txt_hk_selectYear.Text, cb_hk_selectMonth.SelectedItem.ToString());
        }

        private void hk_year_Resize(object sender, EventArgs e)
        {
            AnalysisHkYearAccountList(txt_hk_A_selectYear.Text);
            AnalysisHkYearByType(txt_hk_A_selectYear.Text);
        }


        private void tab_shopping_Resize(object sender, EventArgs e)
        {
            loadshopList(shp_tab_result.SelectedIndex);
        }



        /* Function */



    }
}
