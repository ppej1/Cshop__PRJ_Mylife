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

    }
}
