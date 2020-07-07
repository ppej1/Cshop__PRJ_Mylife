using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro_0_Mylife.DTO
{
    class UserVO
    {
        public UserVO()
        {

        }

        public UserVO(string email, string pwd, string firstName, string lastName, int gender, string phone )
        {
            _email = email;
            _pwd = pwd;
            _firstName = firstName;
            _lastName = lastName;
            _sex = gender;
            _phone = phone;
        }
       

        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
   
        string _pwd;       
        public string Password
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        
        string _firstName;  
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        
        string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
        int _sex;
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        
        DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }

        int _userLv;
        public int UserLv
        {
            get { return _userLv; }
            set { _userLv = value; }
        }
        
        DateTime _withdawal;
        public DateTime Withdawal
        {
            get { return _withdawal; }
            set { _withdawal = value; }
        }
       
        string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        
        string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}
