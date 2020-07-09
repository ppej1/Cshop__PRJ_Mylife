using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife.Handler
{
    class TodolistHandler
    {
        public string selectDDay(DateTime deadLine)
        {
            TimeSpan dday = DateTime.Parse(deadLine.ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            if (dday.Days > 0)
            {
                return String.Format("D - {0}", dday.Days);
            }
            else if (dday.Days == 0)
            {
                return String.Format("D - Day");

            }
            else
            {
                return String.Format("D + {0}", System.Math.Abs(dday.Days));
            }
        }

        public string todoState(string state, DateTime deadLine)
        {
            TimeSpan dday = DateTime.Parse(deadLine.ToString("yyyy-MM-dd")) - DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            if (state.Equals("0"))
            {
                if (dday.Days > 3)
                {
                    return String.Format("미완료");
                }
                else if (dday.Days >= 0 && dday.Days <= 3)
                {
                    return String.Format("임박");
                }
                else
                {
                    return String.Format("기한지남");
                }
            }
            else
            {
                return String.Format("완료");
            }
        }

        public bool chekDate(DateTime startDate, DateTime deadLine)
        {
            int result = DateTime.Compare(startDate, deadLine);

            if(result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool CheckTextEmpty(string txt)
        {
            if (txt.Equals(""))
            {
                MessageBox.Show("Please Input the Text");
                return false;
            }
            return true;
        }


    }
}
