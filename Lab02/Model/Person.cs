using System;

namespace Lab02.Model
{
    internal class Person
    {
        private readonly string _name;
        private readonly string _surname;
        private readonly string _email;
        private DateTime _birthDate;

        internal Person(string name, string surname, string email, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDate = birthDate;
        }

        internal Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        internal Person(string name, string surname, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
        }

        internal string Name
        {
            get { return _name;}
        }

        internal string Surname
        {
            get { return _surname; }
        }

        internal string Email
        {
            get { return _email; }
        }
        internal DateTime BirthDate
        {
            get { return _birthDate; }
        }

        //власне можна використати readonly але цей запис рівносильний
        internal bool IsAdult
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

        internal string SunSign
        {
            get
            {
                int month = _birthDate.Month, day = _birthDate.Day;
                string sunSign="unknown";
                switch (month)
                {
                    case 1:
                        sunSign = day <= 20 ? "Capricorn" : "Aquarius";
                        break;
                    case 2:
                        sunSign = day <= 19 ? "Aquarius" : "Pisces";
                        break;
                    case 3:
                        sunSign = day <= 20 ? "Pisces" : "Aries";
                        break;
                    case 4:
                        sunSign = day <= 20 ? "Aries" : "Taurus";
                        break;
                    case 5:
                        sunSign = day <= 21 ? "Taurus" : "Gemini";
                        break;
                    case 6:
                        sunSign = day <= 22 ? "Gemini" : "Cancer";
                        break;
                    case 7:
                        sunSign = day <= 22 ? "Cancer" : "Leo";
                        break;
                    case 8:
                        sunSign = day <= 23 ? "Leo" : "Virgo";
                        break;
                    case 9:
                        sunSign = day <= 23 ? "Virgo" : "Libra";
                        break;
                    case 10:
                        sunSign = day <= 23 ? "Libra" : "Scorpio";
                        break;
                    case 11:
                        sunSign = day <= 22 ? "Scorpio" : "Sagittarius";
                        break;
                    case 12:
                        sunSign = day <= 21 ? "Sagittarius" : "Capricorn";
                        break;
                    default:
                        break;
                }
                return sunSign;
            }
        }

        internal string ChineseSign
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

        internal bool IsBirthday
        {
            get
            {
                return DateTime.Now.Day == _birthDate.Day && DateTime.Now.Month == _birthDate.Month;
            }
        }
    }
}
