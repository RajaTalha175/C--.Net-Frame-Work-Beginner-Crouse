using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVMPractice.ViewModels
{
    public class SVMUsingIcommand : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Students { get; } = new();

        public ICommand AddCommand { get; }

        public SVMUsingIcommand()
        {
            AddCommand = new RelayCommand(_ => AddStudent(), _ => CanAdd());
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
        }

        private void AddStudent()
        {
            Students.Add($"{Name} - {Email}");
            Name = string.Empty;
            Email = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
