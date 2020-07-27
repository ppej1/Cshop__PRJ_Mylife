using Pro_0_Mylife.DAO;
using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife.Handler
{
    class HouseKeepHandler
    {
        HouseKeepDao hkDao = new HouseKeepDao();
        ShoppingHandler shoppingHandler = new ShoppingHandler();

        public List<String> SettingHouseKeepAccount(UserVO user)
        {
            DataSet paymentDs = hkDao.LoadPayment(user);

            DataTable dt = paymentDs.Tables[0];
            List<String> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["PAY_NAME"].ToString());
            }
            return list;
        }
        public List<String> SettingHouseKeepType()
        {
            DataSet ds = hkDao.LoadHouseKeepType();

            DataTable dt = ds.Tables[0];
            List<String> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                if(!(row["KE_TYPE"].ToString().Equals("0") || row["KE_TYPE"].ToString().Equals("1")))
                {
                    list.Add(row["KEEP_TYPE_NAME"].ToString());

                }
            }
            return list;
        }


        public int selectPaymentNo(String pamentName, UserVO user)
        {
            DataSet ds = new DataSet();
            hkDao.selectPaymentNo(ds, pamentName, user);
            DataTable dt = ds.Tables[0];
            int result = 0;
            foreach (DataRow row in dt.Rows)
            {
                result = Convert.ToInt32(row["PAY_TYPE_NO"].ToString());
            }
            return result;
        }

        public string selectPaymentName(String pamentNo, UserVO user)
        {
            DataSet ds = new DataSet();
            hkDao.selectPaymentName(ds, pamentNo, user);
            DataTable dt = ds.Tables[0];

            return dt.Rows[0]["PAY_NAME"].ToString();
        }
        
        public string SelectHKTypeName(String TypeNo)
        {
            DataSet ds = new DataSet();
            hkDao.SelectHKTypeName(ds, TypeNo);
            DataTable dt = ds.Tables[0];

            return dt.Rows[0]["KEEP_TYPE_NAME"].ToString();
        }


        public float SelectMontlyIncomeByAccount(String year, String month, String payType, UserVO user, int exchangeType)
        {
            DataSet ds = new DataSet();
            hkDao.SelectMontlyIncomeByAccount(ds, year, month, payType, user);
            DataTable dt = ds.Tables[0];
            float money = 0;
            foreach (DataRow row in dt.Rows)
            {
                money += Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
            }

            return money;
        }


        
        public float SelectMontlySpendByAccount(String year, String month, String payType, UserVO user, int exchangeType)
        {
            DataSet ds = new DataSet();
            hkDao.SelectMontlySpendByAccount(ds, year, month, payType, user);
            DataTable dt = ds.Tables[0];
            float money = 0;
            foreach (DataRow row in dt.Rows)
            {
                money += Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
            }

            return money;
        }

        public float CarryForewardByAccount(String year, String month, String payType, UserVO user, int exchangeType)
        {
            DataSet ds = new DataSet();
            hkDao.CarryForewardByAccount(ds, year, month, payType, user);
            DataTable dt = ds.Tables[0];
            float money = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["IETYPE"].ToString().Equals("1"))
                {
                    money += Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
                }
                else
                {
                    money -= Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["KE_PRICE"].ToString()));
                }
            }
            return money;
        }


        public Dictionary<String, float> AnalysisHkByDate(String year, String month, UserVO user, int exchangeType)
        {
            DataSet ds = new DataSet();
            hkDao.AnalysisHkByDate(ds, year, month, user);
            DataTable dt = ds.Tables[0];
            Dictionary<String, float> _Dic = new Dictionary<string, float>();

            foreach (DataRow row in dt.Rows)
            {
                if(exchangeType == Convert.ToInt32(row["EXCHANGE_TYPE"].ToString())){
                    if (_Dic.ContainsKey(DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")))
                    {
                        float temp = _Dic[DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")];
                        _Dic[DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")] = temp + Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["TOTALPRICE"].ToString()));
                    }
                    else
                    {
                        _Dic.Add(DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd"), Convert.ToSingle(row["TOTALPRICE"].ToString()));
                    }
                }
                else
                {
                    if (_Dic.ContainsKey(DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")))
                    {
                        float temp = _Dic[DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")];
                        _Dic[DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd")] = temp + Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["TOTALPRICE"].ToString()));
                    }
                    else
                    {
                        _Dic.Add(DateTime.Parse(row["KE_PAY_DATE"].ToString()).ToString("yyyy-MM-dd"), Convert.ToSingle(shoppingHandler.exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["TOTALPRICE"].ToString())));
                    }


                }
            }
            return _Dic;

        }

    }
}
