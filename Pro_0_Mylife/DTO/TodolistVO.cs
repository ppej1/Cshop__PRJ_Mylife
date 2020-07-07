using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class TodolistVO
    {
        public TodolistVO()
        {

        }
        public TodolistVO(string todoContent,  DateTime todoStartDate, DateTime todoDeadLine, string email)
        {
            _todoContent = todoContent;
            _email = email;
            _todoStartDate = todoStartDate;
            _todoDeadLine = todoDeadLine;
        }
        public TodolistVO(int todoNo, string todoContent, DateTime todoStartDate, DateTime todoEndDate, DateTime todoDeadLine, int todoState, string email, DateTime _registerDate)
        {
            _todoContent = todoContent;
            _email = email;
            _todoStartDate = todoStartDate;
            _todoDeadLine = todoDeadLine;
            _todoEndDate = todoEndDate;
        }
        int _todoNo;
        public int TodoNo
        {
            get { return _todoNo; }
            set { _todoNo = value; }
        }
        
        string _todoContent;
        public string TodoContent
        {
            get { return _todoContent; }
            set { _todoContent = value; }
        }
        
        DateTime _todoStartDate;
        public DateTime TodoStartDate
        {
            get { return _todoStartDate; }
            set { _todoStartDate = value; }
        }
        
        DateTime _todoEndDate;
        public DateTime TodoEndDate
        {
            get { return _todoEndDate; }
            set { _todoEndDate = value; }
        }
        
        DateTime _todoDeadLine;
        public DateTime TodoDeadLine
        {
            get { return _todoDeadLine; }
            set { _todoDeadLine = value; }
        }
        
        int _todoState;
        public int TodoState
        {
            get { return _todoState; }
            set { _todoState = value; }
        }

        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }
    }

}
