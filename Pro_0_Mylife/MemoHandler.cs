using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    class MemoHandler
    {
        OracleDBManager db = new OracleDBManager();
        public bool InsertMemo(string loginUser,string memo)
        {
            MessageBox.Show(loginUser+" : " + memo);

            DataSet ds = new DataSet();
            string query = string.Empty;
            
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


            query = query.Replace("#US_EMAIL", loginUser);
            query = query.Replace("#ME_CONTENTS", memo);

            int result = db.ExecuteNonQuery(query);
            MessageBox.Show(query);
            MessageBox.Show("" + result);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public void SelectMemo(DataSet ds,string loginUser)
        {
            try
            {
                string query = @"SELECT ME_CONTENTS FROM root2.MEMO_T WHERE US_EMAIL='#US_EMAIL'";
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
    }
}
