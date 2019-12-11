using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    class RegisterFormCheck
    {
        public string username;
        public string fio;
        public DateTime birthday;
        public string passport;
        public string card;

        private bool[] check = new bool[5];
        public bool[] Check { get => check; private set => check =value; }

        //проверка формы
        public bool[] CheckForm()
        {
            CheckUsername();
            CheckFIO();
            CheckBirthday();
            CheckPassport();
            CheckCard();
            return Check;
        }

        //проверка карты
        private void CheckCard()
        {
            Regex regexMaster = new Regex(@"^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$");
            MatchCollection[] matches = new MatchCollection[2];
            Regex regexVisa = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");
            matches[0] = regexMaster.Matches(card);
            matches[1] = regexVisa.Matches(card);
            foreach(MatchCollection match in matches)
            {
                if (match.Count > 0)
                {
                    Check[4] = true;
                    return;
                }
                else Check[4] = false;
            }
            
        }

        //проверка пасспорта серия номер через пробел
        private void CheckPassport()
        {
            Regex regex = new Regex(@"\d{4}\s\d{6}$");
            MatchCollection matches = regex.Matches(passport);
            Check[3] = matches.Count>0 ? true : false;
        }
        //проверка даты рождения
        private void CheckBirthday()
        {
            if (birthday < DateTime.Now)
            {
                Check[2] = true;
            }
            else Check[2] = false;
        }
        //проверка ФИО
        private void CheckFIO()
        {
            Regex regex = new Regex(@"^\p{Lu}\p{Ll}*(?:-\p{Lu}\p{Ll}*)? \p{Lu}\p{Ll}*(?:-\p{Lu}\p{Ll}*)? \p{Lu}\p{Ll}*(?:-\p{Lu}\p{Ll}*)?$");
            MatchCollection matches = regex.Matches(fio);
            Check[1] = matches.Count>0 ? true : false;
        }
        //проверка логина
        private void CheckUsername()
        {
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$");
            MatchCollection matches = regex.Matches(username);
            Check[0] = matches.Count > 0 ? true : false;
        }
    }
}
