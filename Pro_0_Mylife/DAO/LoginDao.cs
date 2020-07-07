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
    class LoginDao
    {
        public bool LoginCheck(UserVO user)
        {
            DataSet ds = new DataSet();
            OracleDBManager db = new OracleDBManager();
            String query = @"SELECT US_EMAIL,US_PWD FROM root2.USER_T WHERE 1=1 AND  US_EMAIL = '#id' AND US_PWD = '#password'";
            
            query = query.Replace("#id",user.Email);
            query = query.Replace("#password",user.Password);
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
        }
    }
}
