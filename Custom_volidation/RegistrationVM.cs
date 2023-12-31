﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_volidation
{
    public class RegistrationVM : ObservableObject, IDataErrorInfo
    {
        public string Error { get { return null; } }
        private string _username;

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Имя не может быть пустым";
                        else if (Username.Length < 5)
                            result = "Имя не может быть меньше 5 символов";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");

                return result;
            }
        }

        public string Username
        {
            get => _username;
            set => OnPropertyChanged(ref _username, value);
        }
    }
}
