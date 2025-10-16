using MVVMPractice.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MVVMPractice.ViewModels
{
    public class BindingPractice : INotifyPropertyChanged
    {
        private Student _student = new Student();
        private Student _selectedStudent;
        private string _errorMessageName;
        private string _errorMessageEmail;
        private string _errorMessagePassword;
        private string _errorMessageAddress;

        public ObservableCollection<Student> Students { get; set; }

        public BindingPractice()
        {
            Students = new ObservableCollection<Student>();
        }

        public string Name
        {
            get => _student.Name;
            set { _student.Name = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _student.Email;
            set { _student.Email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _student.Password;
            set { _student.Password = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _student.Address;
            set { _student.Address = value; OnPropertyChanged(); }
        }

        public string ErrorMessageName
        {
            get => _errorMessageName;
            set { _errorMessageName = value; OnPropertyChanged(); }
        }

        public string ErrorMessageEmail
        {
            get => _errorMessageEmail;
            set { _errorMessageEmail = value; OnPropertyChanged(); }
        }

        public string ErrorMessagePassword
        {
            get => _errorMessagePassword;
            set { _errorMessagePassword = value; OnPropertyChanged(); }
        }

        public string ErrorMessageAddress
        {
            get => _errorMessageAddress;
            set { _errorMessageAddress = value; OnPropertyChanged(); }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                if (_selectedStudent != null)
                {
                    Name = _selectedStudent.Name;
                    Email = _selectedStudent.Email;
                    Password = _selectedStudent.Password;
                    Address = _selectedStudent.Address;
                }
                OnPropertyChanged();
            }
        }

        // ✅ Validation Methods
        public void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                ErrorMessageName = "Name is required.";
            else if (!Regex.IsMatch(Name, @"^[A-Za-z\s]+$"))
                ErrorMessageName = "Name should contain only letters.";
            else
                ErrorMessageName = string.Empty;
        }

        public void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                ErrorMessageEmail = "Email is required.";
            else if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ErrorMessageEmail = "Invalid email format.";
            else
                ErrorMessageEmail = string.Empty;
        }

        public void ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
                ErrorMessagePassword = "Password is required.";
            else if (Password.Length < 6)
                ErrorMessagePassword = "Password must be at least 6 characters.";
            else
                ErrorMessagePassword = string.Empty;
        }

        public void ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(Address))
                ErrorMessageAddress = "Address is required.";
            else
                ErrorMessageAddress = string.Empty;
        }

        // ✅ Add / Update / Delete
        public void AddOrUpdateStudent()
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
            ValidateAddress();

            if (!string.IsNullOrEmpty(ErrorMessageName) ||
                !string.IsNullOrEmpty(ErrorMessageEmail) ||
                !string.IsNullOrEmpty(ErrorMessagePassword) ||
                !string.IsNullOrEmpty(ErrorMessageAddress))
                return;

            if (SelectedStudent == null)
            {
                Students.Add(new Student
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Address = Address
                });
            }
            else
            {
                var index = Students.IndexOf(SelectedStudent);
                Students[index] = new Student
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                    Address = Address
                };
            }

            ClearFields();
        }

        public void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                Students.Remove(SelectedStudent);
                ClearFields();
            }
        }

        public void ClearFields()
        {
            Name = Email = Password = Address = string.Empty;
            ErrorMessageName = ErrorMessageEmail = ErrorMessagePassword = ErrorMessageAddress = string.Empty;
            SelectedStudent = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
