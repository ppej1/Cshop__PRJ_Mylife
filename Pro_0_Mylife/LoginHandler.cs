using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    class LoginHandler
    {
        public bool LoginCheck(String id, String password)
        {
            DataSet ds = new DataSet();
            OracleDBManager db = new OracleDBManager();
            String query = @"SELECT US_EMAIL,US_PWD FROM root2.USER_T WHERE 1=1 AND  US_EMAIL = '#id' AND US_PWD = '#password'";
            
            query = query.Replace("#id",id);
            query = query.Replace("#password",password);
            db.ExecuteDsQuery(ds, query);

            //MessageBox.Show(ds.Tables[0].Rows[0][1].ToString());
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count> 0)
            {
                return true;
            }
            else
            {
                return false;
            }


            /*            if (id.Equals("admin") && password.Equals("admin"))
                        {
                            return true;
                        }*/
            return false;
        }
    }
}
