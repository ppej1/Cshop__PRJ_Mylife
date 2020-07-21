using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class HouseKeep_PaymentVO
    {

        public HouseKeep_PaymentVO()
        {

        }
        public HouseKeep_PaymentVO(int payType, String payName, String email)
        {
            _payType = payType;
            _payName = payName;
            _email = email;
        }


        int _payNo;
        public int PayNo
        {
            get { return _payNo; }
            set { _payNo = value; }
        }
        String _payName;
        public String PayName
        {
            get { return _payName; }
            set { _payName = value; }
        }

        String _email;
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        int _payType;
        public int payType
        {
            get { return _payType; }
            set { _payType = value; }
        }
    }
}
