using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MVVMPractice.Views
{
    public partial class PracticeUI_1 : Window
    {
        private List<string> _imagePaths;
        private int _currentIndex = 0;

        public PracticeUI_1()
        {
            InitializeComponent();

            // Student images list
            _imagePaths = new List<string>
            {
                @"D:\C#-DotNet-Crouse\MVVMPractice\MVVMPractice\Images\download1.jpg",
                @"D:\C#-DotNet-Crouse\MVVMPractice\MVVMPractice\Images\download2.jpg",
                @"D:\C#-DotNet-Crouse\MVVMPractice\MVVMPractice\Images\download3.jpg"
            };

            // Show first student image at startup
            ShowImage(_imagePaths[_currentIndex]);
        }

        private void ShowImage(string path)
        {
            StudentImage.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            if (_currentIndex >= _imagePaths.Count)
                _currentIndex = 0;

            ShowImage(_imagePaths[_currentIndex]);
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = StudentName.Text;
            string email = StudentEmail.Text;
            string dept = StudentDept.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all student details.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"✅ Student Added:\n\nName: {name}\nEmail: {email}\nDept: {dept}",
                            "Student Added",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

            // Clear inputs
            StudentName.Clear();
            StudentEmail.Clear();
            StudentDept.Clear();
        }
    }
}





