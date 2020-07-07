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
    class MemoDao
    {
        OracleDBManager db = new OracleDBManager();
        public bool InsertMemo(MemoVO memo)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;
            try
            {
                query = @"
                INSERT INTO root2.MEMO_T(
                    US_EMAIL
                    ,ME_CONTENTS
                    ,ME_REG_DATE
                    )
                Values(
                    '#US_EMAIL'
                    ,'#ME_CONTENTS'
                    ,sysDate
                 )";

                query = query.Replace("#US_EMAIL", memo.Email);
                query = query.Replace("#ME_CONTENTS", memo.MemoContents);

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


        public void SelectMemo(DataSet ds,string loginUser)
        {
            try
            {
                string query = @"SELECT * FROM root2.MEMO_T WHERE US_EMAIL='#US_EMAIL' ORDER BY ME_REG_DATE DESC";
                query = query.Replace("#US_EMAIL", loginUser);
                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }


        public bool DeleteMemo(string memo_no)
        {
            try
            {
                string query = @"DELETE MEMO_T WHERE ME_NO = '#ME_NO'";
                query = query.Replace("#ME_NO", memo_no);

                int result = db.ExecuteNonQuery(query);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
