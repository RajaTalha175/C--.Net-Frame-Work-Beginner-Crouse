using MVVMPractice.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MVVMPractice.ViewModels
{
    public class SVMUsingManual : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Student> Students { get; set; } = new();

        public void AddStudent()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please enter Name and Email.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Students.Add(new Student
            {
                Name = Name,
                Email = Email,
                Password = Password,
                Address = Address
            });

            // Clear fields after adding
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Address = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
