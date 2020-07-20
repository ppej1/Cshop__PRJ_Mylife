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
    class ShoppingWishDAO
    {
        OracleDBManager db = new OracleDBManager();
        public void SelectProdType(DataSet ds)
        {
            try
            {
                string query = @"SELECT * FROM PROD_T ORDER BY PROD_TYPE ASC";

                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SelectOneProdType(DataSet ds, int prodType)
        {
            try
            {
                string query = @"SELECT PROD_T_NAME FROM PROD_T WHERE PROD_TYPE = '#PROD_TYPE'";
                query = query.Replace("#PROD_TYPE", "" + prodType);

                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void selectExchange(DataSet ds, string exchangeType)
        {
            try
            {

                string query = @"SELECT EXCHANGE_MONEY FROM EXCHANGE_T WHERE EXCHANGE_TYPE = '#EXCHANGE_TYPE'";
                query = query.Replace("#EXCHANGE_TYPE", "" + exchangeType);

                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool purchaseShpList(string shopNo)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            UPDATE root2.shop_t
               SET
                    SHP_STATE = '#SHP_STATE',
                    BUY_DATE = sysdate
               WHERE
                    SHOP_NO = '#SHOP_NO'
                ";

                query = query.Replace("#SHOP_NO", shopNo);
                query = query.Replace("#SHP_STATE", ""+1);

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

        public void loadshopList(DataSet ds,String email,int state)
        {
            try
            {

                string query = @"select * from shop_t where US_EMAIL ='#US_EMAIL' and SHP_STATE = '#SHP_STATE' order by SHOP_REGISTER desc";
                query = query.Replace("#US_EMAIL", email);
                query = query.Replace("#SHP_STATE", "" + state);
                db.ExecuteDsQuery(ds, query);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool InsertShoppingList(ShoppingVO data)
        {
            DataSet ds = new DataSet();
            string query = string.Empty;

            try
            {
                query = @"
            INSERT INTO root2.SHOP_T(
                US_EMAIL
                ,PROD_TYPE
                ,SHOP_NAME
                ,EXCHANGE_TYPE
                ,PRICE
                ,SHOP_REGISTER
                ,SHOP_URL
            )
            VALUES(
                '#US_EMAIL'
                ,'#PROD_TYPE'
                ,'#SHOP_NAME'
                ,'#EXCHANGE_TYPE'
                ,'#PRICE'
                ,sysdate
                ,'#SHOP_URL'
             )";

                query = query.Replace("#US_EMAIL", data.Email);
                query = query.Replace("#PROD_TYPE", ""+data.ProdType);
                query = query.Replace("#SHOP_NAME", data.Comment);
                query = query.Replace("#EXCHANGE_TYPE", "" + data.ExchangeType);
                query = query.Replace("#PRICE", "" + data.Price);
                query = query.Replace("#SHOP_URL", data.URL);
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
