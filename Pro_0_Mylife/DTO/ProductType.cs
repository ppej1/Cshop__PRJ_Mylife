using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class ProductType
    {
        public ProductType(int prodType, String prodName)
        {
            _prodType = prodType;
            _prodName = prodName;
        }
        int _prodType;
        public int ProdType
        {
            get { return _prodType; }
            set { _prodType = value; }
        }
        String _prodName;
        public String ProdName
        {
            get { return _prodName; }
            set { _prodName = value; }
        }

    }
}
