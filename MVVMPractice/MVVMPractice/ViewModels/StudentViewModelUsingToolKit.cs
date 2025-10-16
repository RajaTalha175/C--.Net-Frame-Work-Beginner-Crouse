using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMPractice.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Xml.Linq;

namespace MVVMPractice.ViewModels
{
    public partial class StudentViewModelUsingToolKit : ObservableObject
    {
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string address = string.Empty;

        public ObservableCollection<Student> Students { get; } = new();

        [RelayCommand]
        private void AddStudent()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please fill in Name and Email.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var student = new Student
            {
                Name = Name.Trim(),
                Email = Email.Trim(),
                Password = Password,
                Address = Address.Trim()
            };

            Students.Add(student);

            // Reset form fields
            Name = Email = Password = Address = string.Empty;

            MessageBox.Show("Student added successfully!", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
