using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    class TodoListDao
    {
        OracleDBManager db = new OracleDBManager();
        public bool InsertTodoList(TodolistVO todolist)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO root2.TODO_T(
                TOD_CONTENTS
                ,TOD_START_DATE
                ,TOD_DEADLINE_DATE
                ,US_EMAIL
                ,TOD_REGDATE
            )
            VALUES(
                '#TOD_CONTENTS'
                ,TO_DATE('#TOD_START_DATE','YYYY-MM-DD HH24:MI:SS')
                ,TO_DATE('#TOD_DEADLINE_DATE','YYYY-MM-DD HH24:MI:SS')
                ,'#US_EMAIL'
                ,sysdate
             )";

                query = query.Replace("#TOD_CONTENTS", todolist.TodoContent);
                query = query.Replace("#TOD_START_DATE", "" + todolist.TodoStartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                query = query.Replace("#TOD_DEADLINE_DATE", ""+ todolist.TodoDeadLine.ToString("yyyy-MM-dd HH:mm:ss"));
                query = query.Replace("#US_EMAIL", todolist.Email);

                MessageBox.Show(query);

                int result = db.ExecuteNonQuery(query);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public void SelectTodoList(DataSet ds, string loginUser)
        {
            try
            {
                string query = @"SELECT * FROM root2.TODO_T WHERE US_EMAIL='#US_EMAIL' ORDER BY TOD_REGDATE DESC";
                query = query.Replace("#US_EMAIL", loginUser);

                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
