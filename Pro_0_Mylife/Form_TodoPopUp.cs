using Pro_0_Mylife.DTO;
using Pro_0_Mylife.Handler;
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
    public partial class Form_TodoPopUp : Form
    {
        TodoListDao todoListDao = new TodoListDao();
        TodolistHandler todolistHandler = new TodolistHandler();
        string todoNo;
        string loginUser;
        public Form_TodoPopUp(string loginUser,string todoNo)
        {
            InitializeComponent();
            this.todoNo = todoNo;
            this.loginUser = loginUser;
        }

        private void TodoPopUp_Load(object sender, EventArgs e)
        {
            TodoDataLoad();
        }

        private void TodoDataLoad()
        {
            DataSet ds = new DataSet();
            todoListDao.selectTodolistByNo(ds, loginUser, todoNo);

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                lb_DDAY.Name = String.Format("txt_DDayt_{0}", row[0].ToString());
                lb_DDAY.Text = todolistHandler.selectDDay(DateTime.Parse(row[5].ToString()));
                Todo_contents.Text = String.Format("{0}", row[2].ToString());
                Todo_contents.Name = String.Format("{0}", row[0].ToString());
                lb_state.Name = String.Format("txt_state_{0}", row[0].ToString());
                lb_state.Text = todolistHandler.todoState(row[6].ToString(), DateTime.Parse(row[5].ToString()));
                Todo_startDate.Value = DateTime.Parse(row[3].ToString());
                Todo_StartHour.SelectedIndex = HourIndex(DateTime.Parse(row[3].ToString()));
                Todo_StartMinute.SelectedIndex = int.Parse(DateTime.Parse(row[3].ToString()).ToString("mm"));
                Todo_EndDate.Value = DateTime.Parse(row[5].ToString());
                Todo_EndHour.SelectedIndex = HourIndex(DateTime.Parse(row[5].ToString()));
                Todo_EndMinute.SelectedIndex = int.Parse(DateTime.Parse(row[5].ToString()).ToString("mm"));
            }
        }

        private int HourIndex(DateTime date)
        {
            int result = int.Parse(date.ToString("HH"));
            if(result < 8)
            {
                return result + 16;
            }
            else
            {
                return result-8;
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (ck_modify.Checked)
            {
                DateTime startDate = DateTime.ParseExact(Todo_startDate.Value.ToString("MM-dd-yyyy") + " " + Todo_StartHour.Text + ":" + Todo_StartMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime todoDeadLine = DateTime.ParseExact(Todo_EndDate.Value.ToString("MM-dd-yyyy") + " " + Todo_EndHour.Text + ":" + Todo_EndMinute.Text + ":00", "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                TodolistVO todolist = new TodolistVO(Todo_contents.Text, startDate, todoDeadLine, loginUser);
                todolist.TodoNo = Convert.ToInt32(Todo_contents.Name);

                if (todoListDao.UpdateTodolist(todolist))
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("동의에 체크해 주세요 ");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ck_delete.Checked)
            {
                if (todoListDao.DeleteTodoList(Todo_contents.Name))
                {
                   DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("동의에 체크해 주세요 ");
            }
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
    }
}
