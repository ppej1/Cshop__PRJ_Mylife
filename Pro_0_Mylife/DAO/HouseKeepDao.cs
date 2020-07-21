using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife.DAO
{
    class HouseKeepDao
    {
        OracleDBManager db = new OracleDBManager();

        public bool InsertAccount(HouseKeep_PaymentVO payment)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO PAY_T(
                PAY_NAME
                ,US_EMAIL
                ,PAY_TYPE
            )
            VALUES(
                '#PAY_NAME'
                ,'#US_EMAIL'
                ,'#PAY_TYPE'
             )";

                query = query.Replace("#PAY_NAME", payment.PayName);
                query = query.Replace("#US_EMAIL",  payment.Email);
                query = query.Replace("#PAY_TYPE", "" + payment.payType);
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


        public DataSet LoadPayment(UserVO user)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"SELECT * FROM PAY_T WHERE US_EMAIL = '#US_EMAIL' ORDER BY PAY_TYPE_NO ASC ";

                query = query.Replace("#US_EMAIL", user.Email);
                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return ds;

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ds;
            }
        }

        public DataSet LoadHouseKeepType()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"SELECT * FROM K_TYPE_T ORDER BY KE_TYPE ASC ";

                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return ds;

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ds;
            }
        }

        public void selectPaymentNo(DataSet ds, String pamentName, UserVO user)
        {
            try
            {
                string query = @"SELECT PAY_TYPE_NO FROM PAY_T WHERE PAY_NAME  = '#PAY_NAME' AND US_EMAIL = '#US_EMAIL' ";

                query = query.Replace("#PAY_NAME", pamentName);
                query = query.Replace("#US_EMAIL", user.Email);
                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Income(HouseKeepVO hkVO)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO HOUSE_T(
                US_EMAIL
                ,IETYPE
                ,KE_TYPE
                ,KE_CONTENTS
                ,PAY_TYPE_NO
                ,EXCHANGE_TYPE
                ,KE_PRICE
                ,KE_PAY_DATE
            )
            VALUES(
                '#US_EMAIL'
                ,'#IETYPE'
                ,'#KE_TYPE'
                ,'#KE_CONTENTS'
                ,'#PAY_TYPE_NO'
                ,'#EXCHANGE_TYPE'
                ,'#KE_PRICE'
                ,TO_DATE('#KE_PAY_DATE','YYYY-MM-DD')
             )";

                query = query.Replace("#US_EMAIL", hkVO.Email);
                query = query.Replace("#IETYPE", "1");
                query = query.Replace("#KE_TYPE", "1");
                query = query.Replace("#KE_CONTENTS",hkVO.Contents);
                query = query.Replace("#PAY_TYPE_NO",""+hkVO.PayNo);
                query = query.Replace("#EXCHANGE_TYPE",""+ hkVO.ExchangeType);
                query = query.Replace("#KE_PRICE",""+hkVO.Price);
                query = query.Replace("#KE_PAY_DATE", "" + hkVO.RegisterDate.ToString("yyyy-MM-dd"));


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

        public bool ExchangeMoney(HouseKeepVO hkVO1, HouseKeepVO hkVO2)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO HOUSE_T(
                US_EMAIL
                ,IETYPE
                ,KE_TYPE
                ,KE_CONTENTS
                ,PAY_TYPE_NO
                ,EXCHANGE_TYPE
                ,KE_PRICE
                ,KE_PAY_DATE
            )
            VALUES(
                '#US_EMAIL'
                ,'#IETYPE'
                ,'#KE_TYPE'
                ,'#KE_CONTENTS'
                ,'#PAY_TYPE_NO'
                ,'#EXCHANGE_TYPE'
                ,'#KE_PRICE'
                ,TO_DATE('#KE_PAY_DATE','YYYY-MM-DD')
             )";

                query = query.Replace("#US_EMAIL", hkVO1.Email);
                query = query.Replace("#IETYPE", "1");
                query = query.Replace("#KE_TYPE", "1");
                query = query.Replace("#KE_CONTENTS", hkVO1.Contents);
                query = query.Replace("#PAY_TYPE_NO", "" + hkVO1.PayNo);
                query = query.Replace("#EXCHANGE_TYPE", "" + hkVO1.ExchangeType);
                query = query.Replace("#KE_PRICE", "-" + hkVO1.Price);
                query = query.Replace("#KE_PAY_DATE", "" + hkVO1.RegisterDate.ToString("yyyy-MM-dd"));


                int result = db.ExecuteNonQuery(query);
                if (result > 0)
                {
                    try
                    {
                        query = @"
                        INSERT INTO HOUSE_T(
                            US_EMAIL
                            ,IETYPE
                            ,KE_TYPE
                            ,KE_CONTENTS
                            ,PAY_TYPE_NO
                            ,EXCHANGE_TYPE
                            ,KE_PRICE
                            ,KE_PAY_DATE
                        )
                        VALUES(
                            '#US_EMAIL'
                            ,'#IETYPE'
                            ,'#KE_TYPE'
                            ,'#KE_CONTENTS'
                            ,'#PAY_TYPE_NO'
                            ,'#EXCHANGE_TYPE'
                            ,'#KE_PRICE'
                            ,TO_DATE('#KE_PAY_DATE','YYYY-MM-DD')
                         )";

                        query = query.Replace("#US_EMAIL", hkVO2.Email);
                        query = query.Replace("#IETYPE", "1");
                        query = query.Replace("#KE_TYPE", "1");
                        query = query.Replace("#KE_CONTENTS", hkVO2.Contents);
                        query = query.Replace("#PAY_TYPE_NO", "" + hkVO2.PayNo);
                        query = query.Replace("#EXCHANGE_TYPE", "" + hkVO2.ExchangeType);
                        query = query.Replace("#KE_PRICE", "+" + hkVO2.Price);
                        query = query.Replace("#KE_PAY_DATE", "" + hkVO2.RegisterDate.ToString("yyyy-MM-dd"));


                        result = db.ExecuteNonQuery(query);
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
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public bool spend(HouseKeepVO hkVO)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO HOUSE_T(
                US_EMAIL
                ,IETYPE
                ,KE_TYPE
                ,KE_CONTENTS
                ,PAY_TYPE_NO
                ,EXCHANGE_TYPE
                ,KE_PRICE
                ,KE_PAY_DATE
            )
            VALUES(
                '#US_EMAIL'
                ,'#IETYPE'
                ,'#KE_TYPE'
                ,'#KE_CONTENTS'
                ,'#PAY_TYPE_NO'
                ,'#EXCHANGE_TYPE'
                ,'#KE_PRICE'
                ,TO_DATE('#KE_PAY_DATE','YYYY-MM-DD')
             )";

                query = query.Replace("#US_EMAIL", hkVO.Email);
                query = query.Replace("#IETYPE", "0");
                query = query.Replace("#KE_TYPE", ""+hkVO.HouseKeepTypeNo);
                query = query.Replace("#KE_CONTENTS", hkVO.Contents);
                query = query.Replace("#PAY_TYPE_NO", "" + hkVO.PayNo);
                query = query.Replace("#EXCHANGE_TYPE", "" + hkVO.ExchangeType);
                query = query.Replace("#KE_PRICE", "" + hkVO.Price);
                query = query.Replace("#KE_PAY_DATE", "" + hkVO.RegisterDate.ToString("yyyy-MM-dd"));


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





    }





}
