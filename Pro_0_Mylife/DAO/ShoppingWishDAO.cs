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
                MessageBox.Show(query);
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
