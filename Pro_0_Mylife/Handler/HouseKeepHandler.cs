using Pro_0_Mylife.DAO;
using Pro_0_Mylife.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife.Handler
{
    class HouseKeepHandler
    {
       public List<String> SettingHouseKeepAccount(UserVO user)
        {
            HouseKeepDao hkDao = new HouseKeepDao();
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
            HouseKeepDao hkDao = new HouseKeepDao();
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
            HouseKeepDao hkDao = new HouseKeepDao();
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



    }
}
