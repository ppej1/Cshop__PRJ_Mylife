using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pro_0_Mylife.DTO;

namespace Pro_0_Mylife
{
    class RegisterDao
    {
        public bool InsertEmployeeData(UserVO user)
        {
            try
            {
                DataSet ds = new DataSet();
                string query = string.Empty;
                OracleDBManager db = new OracleDBManager();

                query = @"
            INSERT INTO root2.USER_T(
                US_EMAIL
                ,US_PWD
                ,US_FIRSTNAME
                ,US_LASTNAME
                ,US_SEX
                ,US_REGISTERDATE
                ,US_PHONE
            )
            Values(
                '#US_EMAIL'
                ,'#US_PWD'
                ,'#US_FIRSTNAME'
                ,'#US_LASTNAME'
                ,'#US_SEX'
                ,sysdate
                ,'#US_PHONE'
             )";


                query = query.Replace("#US_EMAIL", user.Email);
                query = query.Replace("#US_PWD", user.Password);
                query = query.Replace("#US_FIRSTNAME", user.FirstName);
                query = query.Replace("#US_LASTNAME", user.LastName);
                query = query.Replace("#US_SEX", "" + user.Sex);
                query = query.Replace("#US_PHONE", user.Phone);


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

        public bool CheckEmail(UserVO user)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleDBManager db = new OracleDBManager();
                String query = @"SELECT US_EMAIL,US_PWD FROM root2.USER_T WHERE US_EMAIL = '#id'";

                query = query.Replace("#id", user.Email);
                db.ExecuteDsQuery(ds, query);

                //MessageBox.Show(ds.Tables[0].Rows[0][1].ToString());
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
