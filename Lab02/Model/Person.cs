using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02.Model
{
    class Person
    {
        private string _name, _surname, _email;
        private DateTime _birthDate;

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            this._name = name;
            this._surname = surname;
            this._email = email;
            this._birthDate = birthDate;
        }

        public Person(string name, string surname, string email)
        {
            this._name = name;
            this._surname = surname;
            this._email = email;
        }

        public Person(string name, string surname, DateTime birthDate)
        {
            this._name = name;
            this._surname = surname;
            this._birthDate = birthDate;
        }

        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        //власне можна використати readonly але цей запис рівносильний
        public bool IsAdult
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - _birthDate.Year;
                if (now.Month < _birthDate.Month || (now.Month == _birthDate.Month && now.Day < _birthDate.Day))
                    age--;
                return age >= 18;
            }
        }

        public string SunSign
        {
            get
            {
                int month = this._birthDate.Month, day = this._birthDate.Day;
                string sunSign="unknown";
                switch (month)
                {
                    case 1:
                        if (day <= 20)
                            sunSign = "Capricorn";
                        else
                            sunSign = "Aquarius";
                        break;
                    case 2:
                        if (day <= 19)
                            sunSign = "Aquarius";
                        else
                            sunSign = "Pisces";
                        break;
                    case 3:
                        if (day <= 20)
                            sunSign = "Pisces";
                        else
                            sunSign = "Aries";
                        break;
                    case 4:
                        if (day <= 20)
                            sunSign = "Aries";
                        else
                            sunSign = "Taurus";
                        break;
                    case 5:
                        if (day <= 21)
                            sunSign = "Taurus";
                        else
                            sunSign = "Gemini";
                        break;
                    case 6:
                        if (day <= 22)
                            sunSign = "Gemini";
                        else
                            sunSign = "Cancer";
                        break;
                    case 7:
                        if (day <= 22)
                            sunSign = "Cancer";
                        else
                            sunSign = "Leo";
                        break;
                    case 8:
                        if (day <= 23)
                            sunSign = "Leo";
                        else
                            sunSign = "Virgo";
                        break;
                    case 9:
                        if (day <= 23)
                            sunSign = "Virgo";
                        else
                            sunSign = "Libra";
                        break;
                    case 10:
                        if (day <= 23)
                            sunSign = "Libra";
                        else
                            sunSign = "Scorpio";
                        break;
                    case 11:
                        if (day <= 22)
                            sunSign = "Scorpio";
                        else
                            sunSign = "Sagittarius";
                        break;
                    case 12:
                        if (day <= 21)
                            sunSign = "Sagittarius";
                        else
                            sunSign = "Capricorn";
                        break;
                    default:
                        break;
                }
                return sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                var c = new System.Globalization.ChineseLunisolarCalendar();
                var y = c.GetSexagenaryYear(_birthDate);
                var s = c.GetCelestialStem(y) - 1;
                return
                  ",Rat,Ox,Tiger,Rabbit,Dragon,Snake,Horse,Goat,Monkey,Rooster,Dog,Pig".Split(',')[c.GetTerrestrialBranch(y)]
                  + " - "
                  + "Wood,Fire,Earth,Metal,Water".Split(',')[s / 2]
                  + " - Y" + (s % 2 > 0 ? "in" : "ang");
            }
        }

        public bool IsBirthday
        {
            get
            {
                return (DateTime.Now.Day == _birthDate.Day && DateTime.Now.Month == _birthDate.Month);
            }
        }
    }
}
