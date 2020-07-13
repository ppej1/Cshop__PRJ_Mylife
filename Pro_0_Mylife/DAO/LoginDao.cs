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
            try
            {
                DataSet ds = new DataSet();
                OracleDBManager db = new OracleDBManager();
                String query = @"SELECT US_EMAIL,US_PWD FROM root2.USER_T WHERE US_WITHDRAWAL is null AND  US_EMAIL = '#id' AND US_PWD = '#password'";

                query = query.Replace("#id", user.Email);
                query = query.Replace("#password", user.Password);
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
        public bool widthdrawCheck(UserVO user)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleDBManager db = new OracleDBManager();
                String query = @"SELECT US_EMAIL,US_PWD FROM root2.USER_T WHERE US_EMAIL = '#id' AND US_PWD = '#password'";

                query = query.Replace("#id", user.Email);
                query = query.Replace("#password", user.Password);
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
        public bool selectNowLogin(UserVO user)
        {
            try
            {
                
                DataSet ds = new DataSet();
                OracleDBManager db = new OracleDBManager();
                String query = @"SELECT US_EMAIL
                                        ,US_FIRSTNAME
                                        ,US_LASTNAME
                                        ,US_SEX
                                        ,US_REGISTERDATE
                                        ,US_LV
                                        ,US_IMAGE
                                        ,US_PHONE
                                     FROM USER_T WHERE 1=1 AND  US_EMAIL = '#id'";

                query = query.Replace("#id", user.Email);

                db.ExecuteDsQuery(ds, query);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    user.Email= ds.Tables[0].Rows[0][0].ToString();
                    user.FirstName = ds.Tables[0].Rows[0][1].ToString();
                    user.LastName = ds.Tables[0].Rows[0][2].ToString();
                    user.Sex = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
                    user.RegisterDate = DateTime.Parse(ds.Tables[0].Rows[0][4].ToString());
                    user.UserLv = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
                    user.Image = ds.Tables[0].Rows[0][6].ToString();
                    user.Phone = ds.Tables[0].Rows[0][7].ToString();

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
