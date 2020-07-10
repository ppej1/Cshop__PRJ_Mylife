namespace Pro_0_Mylife
{
    partial class Form_TodoPopUp
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
            this.btn_modify = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.lb_state = new System.Windows.Forms.Label();
            this.lb_DDAY = new System.Windows.Forms.Label();
            this.Todo_EndMinute = new System.Windows.Forms.ComboBox();
            this.Todo_StartMinute = new System.Windows.Forms.ComboBox();
            this.Todo_StartHour = new System.Windows.Forms.ComboBox();
            this.lb_todo_contents = new System.Windows.Forms.Label();
            this.Todo_contents = new System.Windows.Forms.TextBox();
            this.lb_startDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Todo_EndHour = new System.Windows.Forms.ComboBox();
            this.Todo_EndDate = new System.Windows.Forms.DateTimePicker();
            this.Todo_startDate = new System.Windows.Forms.DateTimePicker();
            this.ck_modify = new System.Windows.Forms.CheckBox();
            this.ck_delete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_modify
            // 
            this.btn_modify.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_modify.FlatAppearance.BorderSize = 0;
            this.btn_modify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_modify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modify.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modify.Location = new System.Drawing.Point(252, 504);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(187, 38);
            this.btn_modify.TabIndex = 0;
            this.btn_modify.Text = "수정";
            this.btn_modify.UseVisualStyleBackColor = false;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(252, 548);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(187, 38);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Text = "삭제";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // lb_state
            // 
            this.lb_state.Location = new System.Drawing.Point(350, 35);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(89, 50);
            this.lb_state.TabIndex = 1;
            this.lb_state.Text = "완료";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_DDAY
            // 
            this.lb_DDAY.Location = new System.Drawing.Point(25, 5);
            this.lb_DDAY.Name = "lb_DDAY";
            this.lb_DDAY.Size = new System.Drawing.Size(103, 55);
            this.lb_DDAY.TabIndex = 1;
            this.lb_DDAY.Text = "D-DAY";
            this.lb_DDAY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Todo_EndMinute
            // 
            this.Todo_EndMinute.FormattingEnabled = true;
            this.Todo_EndMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.Todo_EndMinute.Location = new System.Drawing.Point(350, 418);
            this.Todo_EndMinute.Name = "Todo_EndMinute";
            this.Todo_EndMinute.Size = new System.Drawing.Size(89, 23);
            this.Todo_EndMinute.TabIndex = 16;
            this.Todo_EndMinute.SelectedIndexChanged += new System.EventHandler(this.CkEndMinuteChanged);
            // 
            // Todo_StartMinute
            // 
            this.Todo_StartMinute.FormattingEnabled = true;
            this.Todo_StartMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.Todo_StartMinute.Location = new System.Drawing.Point(350, 347);
            this.Todo_StartMinute.Name = "Todo_StartMinute";
            this.Todo_StartMinute.Size = new System.Drawing.Size(89, 23);
            this.Todo_StartMinute.TabIndex = 12;
            this.Todo_StartMinute.SelectedIndexChanged += new System.EventHandler(this.CkStartMinuteChanged);
            // 
            // Todo_StartHour
            // 
            this.Todo_StartHour.FormattingEnabled = true;
            this.Todo_StartHour.Items.AddRange(new object[] {
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.Todo_StartHour.Location = new System.Drawing.Point(252, 347);
            this.Todo_StartHour.Name = "Todo_StartHour";
            this.Todo_StartHour.Size = new System.Drawing.Size(89, 23);
            this.Todo_StartHour.TabIndex = 11;
            this.Todo_StartHour.SelectedIndexChanged += new System.EventHandler(this.CkStartHourChanged);
            // 
            // lb_todo_contents
            // 
            this.lb_todo_contents.AutoSize = true;
            this.lb_todo_contents.Font = new System.Drawing.Font("Ravie", 9F);
            this.lb_todo_contents.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_todo_contents.Location = new System.Drawing.Point(24, 64);
            this.lb_todo_contents.Name = "lb_todo_contents";
            this.lb_todo_contents.Size = new System.Drawing.Size(100, 21);
            this.lb_todo_contents.TabIndex = 8;
            this.lb_todo_contents.Text = "Contents";
            // 
            // Todo_contents
            // 
            this.Todo_contents.Location = new System.Drawing.Point(28, 88);
            this.Todo_contents.Multiline = true;
            this.Todo_contents.Name = "Todo_contents";
            this.Todo_contents.Size = new System.Drawing.Size(411, 219);
            this.Todo_contents.TabIndex = 9;
            // 
            // lb_startDate
            // 
            this.lb_startDate.AutoSize = true;
            this.lb_startDate.Font = new System.Drawing.Font("Ravie", 9F);
            this.lb_startDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb_startDate.Location = new System.Drawing.Point(24, 323);
            this.lb_startDate.Name = "lb_startDate";
            this.lb_startDate.Size = new System.Drawing.Size(126, 21);
            this.lb_startDate.TabIndex = 13;
            this.lb_startDate.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ravie", 9F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(27, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "End Date";
            // 
            // Todo_EndHour
            // 
            this.Todo_EndHour.FormattingEnabled = true;
            this.Todo_EndHour.Items.AddRange(new object[] {
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.Todo_EndHour.Location = new System.Drawing.Point(252, 418);
            this.Todo_EndHour.Name = "Todo_EndHour";
            this.Todo_EndHour.Size = new System.Drawing.Size(89, 23);
            this.Todo_EndHour.TabIndex = 15;
            this.Todo_EndHour.SelectedIndexChanged += new System.EventHandler(this.CkEndHourChanged);
            // 
            // Todo_EndDate
            // 
            this.Todo_EndDate.Location = new System.Drawing.Point(28, 418);
            this.Todo_EndDate.Name = "Todo_EndDate";
            this.Todo_EndDate.Size = new System.Drawing.Size(218, 25);
            this.Todo_EndDate.TabIndex = 14;
            this.Todo_EndDate.ValueChanged += new System.EventHandler(this.CkEndDateChanged);
            // 
            // Todo_startDate
            // 
            this.Todo_startDate.Location = new System.Drawing.Point(28, 347);
            this.Todo_startDate.Name = "Todo_startDate";
            this.Todo_startDate.Size = new System.Drawing.Size(218, 25);
            this.Todo_startDate.TabIndex = 10;
            this.Todo_startDate.ValueChanged += new System.EventHandler(this.CKstartDateChanged);
            // 
            // ck_modify
            // 
            this.ck_modify.AutoSize = true;
            this.ck_modify.Location = new System.Drawing.Point(28, 515);
            this.ck_modify.Name = "ck_modify";
            this.ck_modify.Size = new System.Drawing.Size(204, 19);
            this.ck_modify.TabIndex = 18;
            this.ck_modify.Text = "수정하는것에 동의합니다.";
            this.ck_modify.UseVisualStyleBackColor = true;
            // 
            // ck_delete
            // 
            this.ck_delete.AutoSize = true;
            this.ck_delete.Location = new System.Drawing.Point(28, 559);
            this.ck_delete.Name = "ck_delete";
            this.ck_delete.Size = new System.Drawing.Size(204, 19);
            this.ck_delete.TabIndex = 18;
            this.ck_delete.Text = "삭제하는것에 동의합니다.";
            this.ck_delete.UseVisualStyleBackColor = true;
            // 
            // Form_TodoPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(468, 601);
            this.Controls.Add(this.ck_delete);
            this.Controls.Add(this.ck_modify);
            this.Controls.Add(this.Todo_EndMinute);
            this.Controls.Add(this.Todo_StartMinute);
            this.Controls.Add(this.Todo_StartHour);
            this.Controls.Add(this.lb_todo_contents);
            this.Controls.Add(this.Todo_contents);
            this.Controls.Add(this.lb_startDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Todo_EndHour);
            this.Controls.Add(this.Todo_EndDate);
            this.Controls.Add(this.Todo_startDate);
            this.Controls.Add(this.lb_DDAY);
            this.Controls.Add(this.lb_state);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_modify);
            this.Name = "Form_TodoPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TodoPopUp";
            this.Load += new System.EventHandler(this.TodoPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label lb_DDAY;
        private System.Windows.Forms.ComboBox Todo_EndMinute;
        private System.Windows.Forms.ComboBox Todo_StartMinute;
        private System.Windows.Forms.ComboBox Todo_StartHour;
        private System.Windows.Forms.Label lb_todo_contents;
        private System.Windows.Forms.TextBox Todo_contents;
        private System.Windows.Forms.Label lb_startDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Todo_EndHour;
        private System.Windows.Forms.DateTimePicker Todo_EndDate;
        private System.Windows.Forms.DateTimePicker Todo_startDate;
        private System.Windows.Forms.CheckBox ck_modify;
        private System.Windows.Forms.CheckBox ck_delete;
    }
}