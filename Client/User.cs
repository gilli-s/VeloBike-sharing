using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    [DataContract]
    public class User
    {
        //Поля
        private string username;
        private string fio;
        private DateTime birthday;
        private string passport;
        private string card;
        private string password;
        //конструктор для ввода полей
        public User()
        {
            Username = "";
            FIO = "";
            Birthday = DateTime.Now;
            Passport = "";
            Card = "";
            Password = "";
        }

        public User(string _username, string _fio , DateTime _birthday,string _passport, string _card,string _password)
        {
            Username = _username;
            FIO = _fio;
            Birthday = _birthday;
            Passport = _passport;
            Card = _card;
            Password = _password;
        }
        //Свойства 
        [DataMember]
        public string Password { get => password; set => password = value; }

        public static explicit operator User(ServiceReference1.User v)
        {
            return new User(v.Username, v.FIO, v.Birthday, v.Passport, v.Card, v.Password);
        }

        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public DateTime Birthday { get => birthday; set=> birthday = value ; }
        [DataMember]
        public string Passport { get=>passport; set=>passport = value; }
        [DataMember]
        public string Card { get=>card; set=>card = value; }
       
    }
}
