using Pro_0_Mylife.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife.Handler
{
    class ShoppingHandler
    {
        ShoppingWishDAO shoppingWishDAO = new ShoppingWishDAO();

        public string ExchangeSet(int exchangeType, String moneyType, String money)
        {
            return AddExchangeType(exchangeType, exchangePrice(exchangeType, moneyType, money));
        }

        public string exchangePrice(int exchangeType, String moneyType, String money)
        {
            float exchangeRate = getExchange(exchangeType.ToString());
            float nowRate = getExchange(moneyType);
            float exchange = Convert.ToSingle(money) / nowRate * exchangeRate;
            string exchangeMoney = "";
            //money % moneyTye * exchangeType
            exchangeMoney += exchange.ToString("N0");
            return exchangeMoney;
        }
        public string AddExchangeType(int exchangeType, String exchange)
        {
            String exchangeMoney = "";
            switch (exchangeType)
            {
                case 0:
                    exchangeMoney += "$";
                    break;
                case 1:
                    exchangeMoney += "￦";
                    break;
                case 2:
                    exchangeMoney += "￥";
                    break;
                default:
                    break;
            }
            return exchangeMoney + exchange;
        }
        private float getExchange(String exchangeType)
        {
            DataSet ds = new DataSet();
            shoppingWishDAO.selectExchange(ds, exchangeType);
            DataTable dt = ds.Tables[0];
            return Convert.ToSingle(dt.Rows[0]["EXCHANGE_MONEY"].ToString());
        }

        public List<float> CalshoppingList(int exchangeType, string email, int type) 
        {
            List<float> list = new List<float>();

            DataSet ds = new DataSet();
            shoppingWishDAO.loadshopList(ds, email, type);
            DataTable dt = ds.Tables[0];
            int wishNo = dt.Rows.Count;
            float money = 0;
            foreach (DataRow row in dt.Rows)
            {
                money += Convert.ToSingle(exchangePrice(exchangeType, row["EXCHANGE_TYPE"].ToString(), row["PRICE"].ToString()));
            }
            list.Add(wishNo);
            list.Add(money);


            return list;
        }
    }
}
