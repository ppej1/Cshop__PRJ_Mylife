using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class HouseKeep_TypeVO
    {

        public HouseKeep_TypeVO()
        {

        }
        public HouseKeep_TypeVO(int houseKeepTypeNo, String houseKeepTypeName)
        {
            _houseKeepTypeNo = houseKeepTypeNo;
            _houseKeepTypeName = houseKeepTypeName;
        }

        int _houseKeepTypeNo;
        public int HouseKeepTypeNo
        {
            get { return _houseKeepTypeNo; }
            set { _houseKeepTypeNo = value; }
        }

        String _houseKeepTypeName;
        public String HouseKeepName
        {
            get { return _houseKeepTypeName; }
            set { _houseKeepTypeName = value; }
        }


    }
}
