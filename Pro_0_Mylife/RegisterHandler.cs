using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{
    class RegisterHandler
    {
        public bool InsertEmployeeData(string email, string pwd, string firstName, string lastName, string phoneNumber,int gender)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;
            OracleDBManager db = new OracleDBManager();

            string AvatarImage = "image.jpg";


            query = @"
            INSERT INTO root2.USER_T(
                US_EMAIL
                ,US_PWD
                ,US_FIRSTNAME
                ,US_LASTNAME
                ,US_SEX
                ,US_REGISTERDATE
                ,US_IMAGE
                ,US_PHONE)
            Values(
                '#US_EMAIL'
                ,'#US_PWD'
                ,'#US_FIRSTNAME'
                ,'#US_LASTNAME'
                ,'#US_SEX'
                ,sysdate
                ,'#US_IMAGE'
                ,'#US_PHONE'
             )";


            query = query.Replace("#US_EMAIL", email);
            query = query.Replace("#US_PWD", pwd);
            query = query.Replace("#US_FIRSTNAME", firstName);
            query = query.Replace("#US_LASTNAME", lastName);
            query = query.Replace("#US_SEX", "" + gender);
            query = query.Replace("#US_IMAGE", AvatarImage);
            query = query.Replace("#US_PHONE", phoneNumber);


            int result = db.ExecuteNonQuery(query);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

    }
}
