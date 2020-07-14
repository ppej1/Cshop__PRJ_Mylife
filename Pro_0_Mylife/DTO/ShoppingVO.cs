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

        int _shpNo;
        public int ShpNo
        {
            get { return _shpNo; }
            set { _shpNo = value; }
        }
        String _shpComment;
        public String ShpComment
        {
            get { return _shpComment; }
            set { _shpComment = value; }
        }
        String _shpPrice;
        public String ShpPrice
        {
            get { return _shpPrice; }
            set { _shpPrice = value; }
        }
        DateTime _shpRegister;
        public DateTime ShpRegister
        {
            get { return _shpRegister; }
            set { _shpRegister = value; }
        }
        String _shpURL;
        public String ShpURL
        {
            get { return _shpURL; }
            set { _shpURL = value; }
        }
        int _shpState;
        public int ShpState
        {
            get { return _shpState; }
            set { _shpState = value; }
        }
        String _email;
        public String ShpEmail
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

    }
}
