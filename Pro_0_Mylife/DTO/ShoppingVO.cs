using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class ShoppingVO
    {
        public ShoppingVO()
        {

        }
        public ShoppingVO(String email, int prodType, String shpComment, int exchangeType, int shpPrice, String shpURL)
        {
            _email = email;
            _prodType = prodType;
            _shpComment = shpComment;
            _exchangeType = exchangeType;
            _shpPrice = shpPrice;
            _shpURL = shpURL;
        }
        int _shpNo;
        public int ShpNo
        {
            get { return _shpNo; }
            set { _shpNo = value; }
        }

        String _email;
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        int _prodType;
        public int ProdType
        {
            get { return _prodType; }
            set { _prodType = value; }
        }

        String _shpComment;
        public String Comment
        {
            get { return _shpComment; }
            set { _shpComment = value; }
        }
        int _exchangeType;
        public int ExchangeType
        {
            get { return _exchangeType; }
            set { _exchangeType = value; }
        }
        int _shpPrice;
        public int Price
        {
            get { return _shpPrice; }
            set { _shpPrice = value; }
        }

        DateTime _shpRegister;
        public DateTime RegisterDate
        {
            get { return _shpRegister; }
            set { _shpRegister = value; }
        }

        String _shpURL;
        public String URL
        {
            get { return _shpURL; }
            set { _shpURL = value; }
        }

        int _shpState;
        public int State
        {
            get { return _shpState; }
            set { _shpState = value;  }
        }

        DateTime _shpBuyDate;
        public DateTime BuyDate
        {
            get { return _shpBuyDate; }
            set { _shpBuyDate = value; }
        }


    }
}
