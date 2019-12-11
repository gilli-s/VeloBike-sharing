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


        //Свойства 
        public string Username {
            get
            {
                return username;
            }
            set
            {
                //Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$");
                //MatchCollection matches = regex.Matches(value);
                //if (matches != null)
                //{
                    this.username = value;
                //}
            }
        }
        public string FIO {
            get
            {
                return fio;
            }
            set
            {
                //Regex regex = new Regex(@"^\p{Lu}\p{Ll}*(?:-\p{Lu}\p{Ll}*)?$");
                //MatchCollection matches = regex.Matches(value);
                //if (matches != null)
                //{
                    this.fio = value;
               // }
                
            }
        }
        public DateTime Birthday { get; set; }
        public string Passport { get; set; }
        public string Card { get; set; }


    }
}
