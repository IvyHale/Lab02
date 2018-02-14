using Lab02.Annotations;
using Lab02.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab02.ModelView
{
    class PersonEditViewModel: INotifyPropertyChanged
    {
        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate=DateTime.Now;
        private bool _dateChanged = false;
        private RelayCommand _proceedCommand;
        internal PersonEditViewModel()
        {
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                _dateChanged = true;
                OnPropertyChanged();
            }
        }

        public RelayCommand ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand(ProceedImpl,
                           o => !String.IsNullOrWhiteSpace(_name) &&
                                !String.IsNullOrWhiteSpace(_surname) &&
                                !String.IsNullOrWhiteSpace(_email) &&
                                _dateChanged));
            }
        }

        private async void ProceedImpl(object o)
        {
            
            await Task.Run((() =>
            {
                if (DateTime.Now.Year - _birthDate.Year < 135 && _birthDate < DateTime.Now)
                {
                    _person = new Person(_name, _surname, _email, _birthDate);
                    if (_person.IsBirthday)
                        MessageBox.Show("Happy Birthday!");
                    Thread.Sleep(500);
                }
            }));
            if (_person == null)
                MessageBox.Show("Wrong Date");
            else
            {
                MessageBox.Show($"Name: {_person.Name}{Environment.NewLine}Surname: {_person.Surname}{Environment.NewLine}E-mail: {_person.Email}{Environment.NewLine}Birth Date: {_person.BirthDate.ToShortDateString()}{Environment.NewLine}Is Adult: {_person.IsAdult}{Environment.NewLine}Sun Sign: {_person.SunSign}{Environment.NewLine}Chinese Sign: {_person.ChineseSign}{Environment.NewLine}Is Birthday: {_person.IsBirthday}");
            }
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;
   
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
