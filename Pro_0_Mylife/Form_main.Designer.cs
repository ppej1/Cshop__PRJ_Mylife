namespace Pro_0_Mylife
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.tab_form = new System.Windows.Forms.TabControl();
            this.tab_home = new System.Windows.Forms.TabPage();
            this.tab_Memo = new System.Windows.Forms.TabPage();
            this.Memo_flowpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.memo_add = new System.Windows.Forms.Button();
            this.Lb_memo = new System.Windows.Forms.Label();
            this.tab_TodoList = new System.Windows.Forms.TabPage();
            this.todo_panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_Todo_Title = new System.Windows.Forms.Label();
            this.todolistFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Todo_panel1 = new System.Windows.Forms.Panel();
            this.Todo_EndMinute = new System.Windows.Forms.ComboBox();
            this.Todo_StartMinute = new System.Windows.Forms.ComboBox();
            this.Todo_Calendar = new System.Windows.Forms.MonthCalendar();
            this.btn_TodoRegister = new System.Windows.Forms.Button();
            this.Todo_StartHour = new System.Windows.Forms.ComboBox();
            this.lb_todo_contents = new System.Windows.Forms.Label();
            this.Todo_contents = new System.Windows.Forms.TextBox();
            this.lb_startDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Todo_EndHour = new System.Windows.Forms.ComboBox();
            this.Todo_EndDate = new System.Windows.Forms.DateTimePicker();
            this.Todo_startDate = new System.Windows.Forms.DateTimePicker();
            this.tab_shopping = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_memo = new System.Windows.Forms.Button();
            this.btn_ck = new System.Windows.Forms.Button();
            this.btn_shp = new System.Windows.Forms.Button();
            this.btn_hk = new System.Windows.Forms.Button();
            this.LOGO = new System.Windows.Forms.Label();
            this.Lb_loginUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tab_form.SuspendLayout();
            this.tab_Memo.SuspendLayout();
            this.tab_TodoList.SuspendLayout();
            this.todo_panel2.SuspendLayout();
            this.Todo_panel1.SuspendLayout();
            this.tab_shopping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_form
            // 
            resources.ApplyResources(this.tab_form, "tab_form");
            this.tab_form.Controls.Add(this.tab_home);
            this.tab_form.Controls.Add(this.tab_Memo);
            this.tab_form.Controls.Add(this.tab_TodoList);
            this.tab_form.Controls.Add(this.tab_shopping);
            this.tab_form.Controls.Add(this.tabPage5);
            this.tab_form.Name = "tab_form";
            this.tab_form.SelectedIndex = 0;
            this.tab_form.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tab_home
            // 
            this.tab_home.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tab_home, "tab_home");
            this.tab_home.Name = "tab_home";
            // 
            // tab_Memo
            // 
            this.tab_Memo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tab_Memo.Controls.Add(this.panel2);
            this.tab_Memo.Controls.Add(this.Memo_flowpanel);
            this.tab_Memo.Controls.Add(this.txt_memo);
            this.tab_Memo.Controls.Add(this.memo_add);
            this.tab_Memo.Controls.Add(this.Lb_memo);
            resources.ApplyResources(this.tab_Memo, "tab_Memo");
            this.tab_Memo.Name = "tab_Memo";
            // 
            // Memo_flowpanel
            // 
            resources.ApplyResources(this.Memo_flowpanel, "Memo_flowpanel");
            this.Memo_flowpanel.Name = "Memo_flowpanel";
            // 
            // txt_memo
            // 
            resources.ApplyResources(this.txt_memo, "txt_memo");
            this.txt_memo.Name = "txt_memo";
            // 
            // memo_add
            // 
            this.memo_add.BackColor = System.Drawing.Color.SkyBlue;
            this.memo_add.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.memo_add, "memo_add");
            this.memo_add.Name = "memo_add";
            this.memo_add.UseVisualStyleBackColor = false;
            this.memo_add.Click += new System.EventHandler(this.memo_add_Click);
            // 
            // Lb_memo
            // 
            resources.ApplyResources(this.Lb_memo, "Lb_memo");
            this.Lb_memo.Name = "Lb_memo";
            this.Lb_memo.Click += new System.EventHandler(this.Lb_memo_Click);
            // 
            // tab_TodoList
            // 
            this.tab_TodoList.BackColor = System.Drawing.Color.White;
            this.tab_TodoList.Controls.Add(this.todo_panel2);
            this.tab_TodoList.Controls.Add(this.Todo_panel1);
            resources.ApplyResources(this.tab_TodoList, "tab_TodoList");
            this.tab_TodoList.Name = "tab_TodoList";
            // 
            // todo_panel2
            // 
            this.todo_panel2.BackColor = System.Drawing.Color.Lavender;
            this.todo_panel2.Controls.Add(this.panel3);
            this.todo_panel2.Controls.Add(this.textBox1);
            this.todo_panel2.Controls.Add(this.button1);
            this.todo_panel2.Controls.Add(this.lb_Todo_Title);
            this.todo_panel2.Controls.Add(this.todolistFlowPanel);
            resources.ApplyResources(this.todo_panel2, "todo_panel2");
            this.todo_panel2.Name = "todo_panel2";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Lavender;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lb_Todo_Title
            // 
            this.lb_Todo_Title.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lb_Todo_Title, "lb_Todo_Title");
            this.lb_Todo_Title.Name = "lb_Todo_Title";
            // 
            // todolistFlowPanel
            // 
            this.todolistFlowPanel.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.todolistFlowPanel, "todolistFlowPanel");
            this.todolistFlowPanel.Name = "todolistFlowPanel";
            // 
            // Todo_panel1
            // 
            this.Todo_panel1.BackColor = System.Drawing.Color.Lavender;
            this.Todo_panel1.Controls.Add(this.Todo_EndMinute);
            this.Todo_panel1.Controls.Add(this.Todo_StartMinute);
            this.Todo_panel1.Controls.Add(this.Todo_Calendar);
            this.Todo_panel1.Controls.Add(this.btn_TodoRegister);
            this.Todo_panel1.Controls.Add(this.Todo_StartHour);
            this.Todo_panel1.Controls.Add(this.lb_todo_contents);
            this.Todo_panel1.Controls.Add(this.Todo_contents);
            this.Todo_panel1.Controls.Add(this.lb_startDate);
            this.Todo_panel1.Controls.Add(this.label3);
            this.Todo_panel1.Controls.Add(this.Todo_EndHour);
            this.Todo_panel1.Controls.Add(this.Todo_EndDate);
            this.Todo_panel1.Controls.Add(this.Todo_startDate);
            resources.ApplyResources(this.Todo_panel1, "Todo_panel1");
            this.Todo_panel1.Name = "Todo_panel1";
            // 
            // Todo_EndMinute
            // 
            this.Todo_EndMinute.FormattingEnabled = true;
            this.Todo_EndMinute.Items.AddRange(new object[] {
            resources.GetString("Todo_EndMinute.Items"),
            resources.GetString("Todo_EndMinute.Items1"),
            resources.GetString("Todo_EndMinute.Items2"),
            resources.GetString("Todo_EndMinute.Items3"),
            resources.GetString("Todo_EndMinute.Items4"),
            resources.GetString("Todo_EndMinute.Items5"),
            resources.GetString("Todo_EndMinute.Items6"),
            resources.GetString("Todo_EndMinute.Items7"),
            resources.GetString("Todo_EndMinute.Items8"),
            resources.GetString("Todo_EndMinute.Items9"),
            resources.GetString("Todo_EndMinute.Items10"),
            resources.GetString("Todo_EndMinute.Items11"),
            resources.GetString("Todo_EndMinute.Items12"),
            resources.GetString("Todo_EndMinute.Items13"),
            resources.GetString("Todo_EndMinute.Items14"),
            resources.GetString("Todo_EndMinute.Items15"),
            resources.GetString("Todo_EndMinute.Items16"),
            resources.GetString("Todo_EndMinute.Items17"),
            resources.GetString("Todo_EndMinute.Items18"),
            resources.GetString("Todo_EndMinute.Items19"),
            resources.GetString("Todo_EndMinute.Items20"),
            resources.GetString("Todo_EndMinute.Items21"),
            resources.GetString("Todo_EndMinute.Items22"),
            resources.GetString("Todo_EndMinute.Items23"),
            resources.GetString("Todo_EndMinute.Items24"),
            resources.GetString("Todo_EndMinute.Items25"),
            resources.GetString("Todo_EndMinute.Items26"),
            resources.GetString("Todo_EndMinute.Items27"),
            resources.GetString("Todo_EndMinute.Items28"),
            resources.GetString("Todo_EndMinute.Items29"),
            resources.GetString("Todo_EndMinute.Items30"),
            resources.GetString("Todo_EndMinute.Items31"),
            resources.GetString("Todo_EndMinute.Items32"),
            resources.GetString("Todo_EndMinute.Items33"),
            resources.GetString("Todo_EndMinute.Items34"),
            resources.GetString("Todo_EndMinute.Items35"),
            resources.GetString("Todo_EndMinute.Items36"),
            resources.GetString("Todo_EndMinute.Items37"),
            resources.GetString("Todo_EndMinute.Items38"),
            resources.GetString("Todo_EndMinute.Items39"),
            resources.GetString("Todo_EndMinute.Items40"),
            resources.GetString("Todo_EndMinute.Items41"),
            resources.GetString("Todo_EndMinute.Items42"),
            resources.GetString("Todo_EndMinute.Items43"),
            resources.GetString("Todo_EndMinute.Items44"),
            resources.GetString("Todo_EndMinute.Items45"),
            resources.GetString("Todo_EndMinute.Items46"),
            resources.GetString("Todo_EndMinute.Items47"),
            resources.GetString("Todo_EndMinute.Items48"),
            resources.GetString("Todo_EndMinute.Items49"),
            resources.GetString("Todo_EndMinute.Items50"),
            resources.GetString("Todo_EndMinute.Items51"),
            resources.GetString("Todo_EndMinute.Items52"),
            resources.GetString("Todo_EndMinute.Items53"),
            resources.GetString("Todo_EndMinute.Items54"),
            resources.GetString("Todo_EndMinute.Items55"),
            resources.GetString("Todo_EndMinute.Items56"),
            resources.GetString("Todo_EndMinute.Items57"),
            resources.GetString("Todo_EndMinute.Items58"),
            resources.GetString("Todo_EndMinute.Items59")});
            resources.ApplyResources(this.Todo_EndMinute, "Todo_EndMinute");
            this.Todo_EndMinute.Name = "Todo_EndMinute";
            // 
            // Todo_StartMinute
            // 
            this.Todo_StartMinute.FormattingEnabled = true;
            this.Todo_StartMinute.Items.AddRange(new object[] {
            resources.GetString("Todo_StartMinute.Items"),
            resources.GetString("Todo_StartMinute.Items1"),
            resources.GetString("Todo_StartMinute.Items2"),
            resources.GetString("Todo_StartMinute.Items3"),
            resources.GetString("Todo_StartMinute.Items4"),
            resources.GetString("Todo_StartMinute.Items5"),
            resources.GetString("Todo_StartMinute.Items6"),
            resources.GetString("Todo_StartMinute.Items7"),
            resources.GetString("Todo_StartMinute.Items8"),
            resources.GetString("Todo_StartMinute.Items9"),
            resources.GetString("Todo_StartMinute.Items10"),
            resources.GetString("Todo_StartMinute.Items11"),
            resources.GetString("Todo_StartMinute.Items12"),
            resources.GetString("Todo_StartMinute.Items13"),
            resources.GetString("Todo_StartMinute.Items14"),
            resources.GetString("Todo_StartMinute.Items15"),
            resources.GetString("Todo_StartMinute.Items16"),
            resources.GetString("Todo_StartMinute.Items17"),
            resources.GetString("Todo_StartMinute.Items18"),
            resources.GetString("Todo_StartMinute.Items19"),
            resources.GetString("Todo_StartMinute.Items20"),
            resources.GetString("Todo_StartMinute.Items21"),
            resources.GetString("Todo_StartMinute.Items22"),
            resources.GetString("Todo_StartMinute.Items23"),
            resources.GetString("Todo_StartMinute.Items24"),
            resources.GetString("Todo_StartMinute.Items25"),
            resources.GetString("Todo_StartMinute.Items26"),
            resources.GetString("Todo_StartMinute.Items27"),
            resources.GetString("Todo_StartMinute.Items28"),
            resources.GetString("Todo_StartMinute.Items29"),
            resources.GetString("Todo_StartMinute.Items30"),
            resources.GetString("Todo_StartMinute.Items31"),
            resources.GetString("Todo_StartMinute.Items32"),
            resources.GetString("Todo_StartMinute.Items33"),
            resources.GetString("Todo_StartMinute.Items34"),
            resources.GetString("Todo_StartMinute.Items35"),
            resources.GetString("Todo_StartMinute.Items36"),
            resources.GetString("Todo_StartMinute.Items37"),
            resources.GetString("Todo_StartMinute.Items38"),
            resources.GetString("Todo_StartMinute.Items39"),
            resources.GetString("Todo_StartMinute.Items40"),
            resources.GetString("Todo_StartMinute.Items41"),
            resources.GetString("Todo_StartMinute.Items42"),
            resources.GetString("Todo_StartMinute.Items43"),
            resources.GetString("Todo_StartMinute.Items44"),
            resources.GetString("Todo_StartMinute.Items45"),
            resources.GetString("Todo_StartMinute.Items46"),
            resources.GetString("Todo_StartMinute.Items47"),
            resources.GetString("Todo_StartMinute.Items48"),
            resources.GetString("Todo_StartMinute.Items49"),
            resources.GetString("Todo_StartMinute.Items50"),
            resources.GetString("Todo_StartMinute.Items51"),
            resources.GetString("Todo_StartMinute.Items52"),
            resources.GetString("Todo_StartMinute.Items53"),
            resources.GetString("Todo_StartMinute.Items54"),
            resources.GetString("Todo_StartMinute.Items55"),
            resources.GetString("Todo_StartMinute.Items56"),
            resources.GetString("Todo_StartMinute.Items57"),
            resources.GetString("Todo_StartMinute.Items58"),
            resources.GetString("Todo_StartMinute.Items59")});
            resources.ApplyResources(this.Todo_StartMinute, "Todo_StartMinute");
            this.Todo_StartMinute.Name = "Todo_StartMinute";
            // 
            // Todo_Calendar
            // 
            resources.ApplyResources(this.Todo_Calendar, "Todo_Calendar");
            this.Todo_Calendar.Name = "Todo_Calendar";
            this.Todo_Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Todo_Calendar_DateChanged);
            // 
            // btn_TodoRegister
            // 
            this.btn_TodoRegister.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_TodoRegister.FlatAppearance.BorderSize = 0;
            this.btn_TodoRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_TodoRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_TodoRegister, "btn_TodoRegister");
            this.btn_TodoRegister.Name = "btn_TodoRegister";
            this.btn_TodoRegister.UseVisualStyleBackColor = false;
            this.btn_TodoRegister.Click += new System.EventHandler(this.btn_TodoRegister_Click);
            // 
            // Todo_StartHour
            // 
            this.Todo_StartHour.FormattingEnabled = true;
            this.Todo_StartHour.Items.AddRange(new object[] {
            resources.GetString("Todo_StartHour.Items"),
            resources.GetString("Todo_StartHour.Items1"),
            resources.GetString("Todo_StartHour.Items2"),
            resources.GetString("Todo_StartHour.Items3"),
            resources.GetString("Todo_StartHour.Items4"),
            resources.GetString("Todo_StartHour.Items5"),
            resources.GetString("Todo_StartHour.Items6"),
            resources.GetString("Todo_StartHour.Items7"),
            resources.GetString("Todo_StartHour.Items8"),
            resources.GetString("Todo_StartHour.Items9"),
            resources.GetString("Todo_StartHour.Items10"),
            resources.GetString("Todo_StartHour.Items11"),
            resources.GetString("Todo_StartHour.Items12"),
            resources.GetString("Todo_StartHour.Items13"),
            resources.GetString("Todo_StartHour.Items14"),
            resources.GetString("Todo_StartHour.Items15"),
            resources.GetString("Todo_StartHour.Items16"),
            resources.GetString("Todo_StartHour.Items17"),
            resources.GetString("Todo_StartHour.Items18"),
            resources.GetString("Todo_StartHour.Items19"),
            resources.GetString("Todo_StartHour.Items20"),
            resources.GetString("Todo_StartHour.Items21"),
            resources.GetString("Todo_StartHour.Items22"),
            resources.GetString("Todo_StartHour.Items23")});
            resources.ApplyResources(this.Todo_StartHour, "Todo_StartHour");
            this.Todo_StartHour.Name = "Todo_StartHour";
            // 
            // lb_todo_contents
            // 
            resources.ApplyResources(this.lb_todo_contents, "lb_todo_contents");
            this.lb_todo_contents.Name = "lb_todo_contents";
            // 
            // Todo_contents
            // 
            resources.ApplyResources(this.Todo_contents, "Todo_contents");
            this.Todo_contents.Name = "Todo_contents";
            // 
            // lb_startDate
            // 
            resources.ApplyResources(this.lb_startDate, "lb_startDate");
            this.lb_startDate.Name = "lb_startDate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Todo_EndHour
            // 
            this.Todo_EndHour.FormattingEnabled = true;
            this.Todo_EndHour.Items.AddRange(new object[] {
            resources.GetString("Todo_EndHour.Items"),
            resources.GetString("Todo_EndHour.Items1"),
            resources.GetString("Todo_EndHour.Items2"),
            resources.GetString("Todo_EndHour.Items3"),
            resources.GetString("Todo_EndHour.Items4"),
            resources.GetString("Todo_EndHour.Items5"),
            resources.GetString("Todo_EndHour.Items6"),
            resources.GetString("Todo_EndHour.Items7"),
            resources.GetString("Todo_EndHour.Items8"),
            resources.GetString("Todo_EndHour.Items9"),
            resources.GetString("Todo_EndHour.Items10"),
            resources.GetString("Todo_EndHour.Items11"),
            resources.GetString("Todo_EndHour.Items12"),
            resources.GetString("Todo_EndHour.Items13"),
            resources.GetString("Todo_EndHour.Items14"),
            resources.GetString("Todo_EndHour.Items15"),
            resources.GetString("Todo_EndHour.Items16"),
            resources.GetString("Todo_EndHour.Items17"),
            resources.GetString("Todo_EndHour.Items18"),
            resources.GetString("Todo_EndHour.Items19"),
            resources.GetString("Todo_EndHour.Items20"),
            resources.GetString("Todo_EndHour.Items21"),
            resources.GetString("Todo_EndHour.Items22"),
            resources.GetString("Todo_EndHour.Items23")});
            resources.ApplyResources(this.Todo_EndHour, "Todo_EndHour");
            this.Todo_EndHour.Name = "Todo_EndHour";
            // 
            // Todo_EndDate
            // 
            resources.ApplyResources(this.Todo_EndDate, "Todo_EndDate");
            this.Todo_EndDate.Name = "Todo_EndDate";
            // 
            // Todo_startDate
            // 
            resources.ApplyResources(this.Todo_startDate, "Todo_startDate");
            this.Todo_startDate.Name = "Todo_startDate";
            // 
            // tab_shopping
            // 
            this.tab_shopping.Controls.Add(this.button5);
            this.tab_shopping.Controls.Add(this.button4);
            this.tab_shopping.Controls.Add(this.dataGridView3);
            this.tab_shopping.Controls.Add(this.button3);
            this.tab_shopping.Controls.Add(this.textBox6);
            this.tab_shopping.Controls.Add(this.textBox5);
            this.tab_shopping.Controls.Add(this.textBox4);
            this.tab_shopping.Controls.Add(this.textBox3);
            this.tab_shopping.Controls.Add(this.button2);
            this.tab_shopping.Controls.Add(this.comboBox3);
            this.tab_shopping.Controls.Add(this.label8);
            this.tab_shopping.Controls.Add(this.label7);
            this.tab_shopping.Controls.Add(this.label6);
            this.tab_shopping.Controls.Add(this.label5);
            this.tab_shopping.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.tab_shopping, "tab_shopping");
            this.tab_shopping.Name = "tab_shopping";
            this.tab_shopping.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView3, "dataGridView3");
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 27;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_memo
            // 
            this.btn_memo.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_memo.FlatAppearance.BorderSize = 0;
            this.btn_memo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_memo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_memo, "btn_memo");
            this.btn_memo.Name = "btn_memo";
            this.btn_memo.UseVisualStyleBackColor = false;
            this.btn_memo.Click += new System.EventHandler(this.Btn_memo_Click);
            // 
            // btn_ck
            // 
            this.btn_ck.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_ck.FlatAppearance.BorderSize = 0;
            this.btn_ck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_ck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_ck, "btn_ck");
            this.btn_ck.Name = "btn_ck";
            this.btn_ck.UseVisualStyleBackColor = false;
            this.btn_ck.Click += new System.EventHandler(this.Btn_ck_Click);
            // 
            // btn_shp
            // 
            this.btn_shp.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_shp.FlatAppearance.BorderSize = 0;
            this.btn_shp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_shp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_shp, "btn_shp");
            this.btn_shp.Name = "btn_shp";
            this.btn_shp.UseVisualStyleBackColor = false;
            this.btn_shp.Click += new System.EventHandler(this.Btn_shp_Click);
            // 
            // btn_hk
            // 
            this.btn_hk.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_hk.FlatAppearance.BorderSize = 0;
            this.btn_hk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_hk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_hk, "btn_hk");
            this.btn_hk.Name = "btn_hk";
            this.btn_hk.UseVisualStyleBackColor = false;
            this.btn_hk.Click += new System.EventHandler(this.Btn_hk_btn);
            // 
            // LOGO
            // 
            resources.ApplyResources(this.LOGO, "LOGO");
            this.LOGO.Name = "LOGO";
            this.LOGO.Click += new System.EventHandler(this.LOGO_Click);
            // 
            // Lb_loginUser
            // 
            resources.ApplyResources(this.Lb_loginUser, "Lb_loginUser");
            this.Lb_loginUser.Name = "Lb_loginUser";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // Form_main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.Lb_loginUser);
            this.Controls.Add(this.LOGO);
            this.Controls.Add(this.btn_hk);
            this.Controls.Add(this.btn_shp);
            this.Controls.Add(this.btn_ck);
            this.Controls.Add(this.btn_memo);
            this.Controls.Add(this.tab_form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_main";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.tab_form.ResumeLayout(false);
            this.tab_Memo.ResumeLayout(false);
            this.tab_Memo.PerformLayout();
            this.tab_TodoList.ResumeLayout(false);
            this.todo_panel2.ResumeLayout(false);
            this.todo_panel2.PerformLayout();
            this.Todo_panel1.ResumeLayout(false);
            this.Todo_panel1.PerformLayout();
            this.tab_shopping.ResumeLayout(false);
            this.tab_shopping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_form;
        private System.Windows.Forms.TabPage tab_home;
        private System.Windows.Forms.TabPage tab_Memo;
        private System.Windows.Forms.TabPage tab_TodoList;
        private System.Windows.Forms.TabPage tab_shopping;
        private System.Windows.Forms.Button btn_memo;
        private System.Windows.Forms.Button btn_ck;
        private System.Windows.Forms.Button btn_shp;
        private System.Windows.Forms.Button btn_hk;
        private System.Windows.Forms.Label Lb_memo;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Button memo_add;
        private System.Windows.Forms.Button btn_TodoRegister;
        private System.Windows.Forms.Label lb_todo_contents;
        private System.Windows.Forms.ComboBox Todo_StartHour;
        private System.Windows.Forms.MonthCalendar Todo_Calendar;
        private System.Windows.Forms.Label lb_startDate;
        private System.Windows.Forms.DateTimePicker Todo_startDate;
        private System.Windows.Forms.TextBox Todo_contents;
        private System.Windows.Forms.ComboBox Todo_EndHour;
        private System.Windows.Forms.DateTimePicker Todo_EndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LOGO;
        private System.Windows.Forms.Label Lb_loginUser;
        private System.Windows.Forms.FlowLayoutPanel Memo_flowpanel;
        private System.Windows.Forms.Panel todo_panel2;
        private System.Windows.Forms.Panel Todo_panel1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_Todo_Title;
        private System.Windows.Forms.FlowLayoutPanel todolistFlowPanel;
        private System.Windows.Forms.ComboBox Todo_EndMinute;
        private System.Windows.Forms.ComboBox Todo_StartMinute;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}