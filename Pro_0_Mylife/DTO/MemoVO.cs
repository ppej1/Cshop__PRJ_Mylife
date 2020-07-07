using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class MemoVO
    {
        public MemoVO()
        {

        }
        public MemoVO(string memoContent, string email)
        {
            _memoContent = memoContent;
            _email = email;

        }
        public MemoVO(int memoNo,string memoContent, string email, DateTime registerDate)
        {
            _memoNo = memoNo;
            _memoContent = memoContent;
            _email = email;
            _registerDate = registerDate;
        }
        int _memoNo;
        public int MemoNo
        {
            get { return _memoNo; }
            set { _memoNo = value; }
        }
        string _memoContent;
        public string MemoContents
        {
            get { return _memoContent; }
            set { _memoContent = value; }
        }
        DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }
        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
