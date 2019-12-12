using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    class User
    {
        //Поля
        private string username;
        private string fio;
        private DateTime birthday;
        private string passport;
        private string card;
        //конструктор для ввода полей
        public User(string _username, string _fio , DateTime _birthday,string _passport, string _card)
        {
            Username = _username;
            FIO = _fio;
            Birthday = _birthday;
            Passport = _passport;
            Card = _card;
        }
        //Свойства 
        public string Username {
            get
            {
                return username;
            }
            set
            {
                
                    this.username = value;
            
            }
        }
        public string FIO {
            get
            {
                return fio;
            }
            set
            {
                
                    this.fio = value;
               
                
            }
        }
        public DateTime Birthday { get; set; }
        public string Passport { get; set; }
        public string Card { get; set; }


    }
}
