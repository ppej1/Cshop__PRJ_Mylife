using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class HouseKeepVO
    {

        public HouseKeepVO()
        {

        }
        public HouseKeepVO(String email, String contents, int payNo, int exchangeType, float price, DateTime registerDate )
        {
            _email = email;
            _contents = contents;
            _payNo = payNo;
            _exchangeType = exchangeType;
            _price = price;
            _registerDate = registerDate;
        }
        public HouseKeepVO(String email, int houseKeepTypeNo, String contents, int payNo, int exchangeType, float price, DateTime registerDate)
        {
            _email = email;
            _houseKeepTypeNo = houseKeepTypeNo;
            _contents = contents;
            _payNo = payNo;
            _exchangeType = exchangeType;
            _price = price;
            _registerDate = registerDate;
        }

        int _houseKeepNo;
        public int HouseKeepNo
        {
            get { return _houseKeepNo; }
            set { _houseKeepNo = value; }
        }

        String _email;
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        int _ieType;
        public int IeType
        {
            get { return _ieType; }
            set { _ieType = value; }
        }

        int _houseKeepTypeNo;
        public int HouseKeepTypeNo
        {
            get { return _houseKeepTypeNo; }
            set { _houseKeepTypeNo = value; }
        }
        String _contents;
        public String  Contents
        {
            get { return _contents; }
            set { _contents = value; }
        }
        int _payNo;
        public int PayNo
        {
            get { return _payNo; }
            set { _payNo = value; }
        }

        int _exchangeType;
        public int ExchangeType
        {
            get { return _exchangeType; }
            set { _exchangeType = value; }
        }

        float _price;
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }



    }
}
