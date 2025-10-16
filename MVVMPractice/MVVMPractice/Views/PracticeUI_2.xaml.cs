using MVVMPractice.ViewModels;
using System.Windows;

namespace MVVMPractice.Views
{
    public partial class PracticeUI_2 : Window
    {
        private readonly BindingPractice _viewModel;
        private bool _isPasswordVisible = false;

        public PracticeUI_2()
        {
            InitializeComponent();
            _viewModel = new BindingPractice();
            DataContext = _viewModel;
            MessageBox.Show("View loaded successfully!");
        }

        // ✅ Add or Update Button Click
        public void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!_isPasswordVisible)
                _viewModel.Password = PasswordBox.Password;
            else
                _viewModel.Password = VisiblePasswordBox.Text;

            _viewModel.AddOrUpdateStudent();
        }

        // ✅ Delete Button Click
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteStudent();
        }

        // ✅ Clear Button Click
        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearFields();
            PasswordBox.Clear();
            VisiblePasswordBox.Clear();
        }

        // ✅ Show / Hide Password Toggle
        public void ShowHideButton_Click(object sender, RoutedEventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;

            if (_isPasswordVisible)
            {
                // Show text version
                VisiblePasswordBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                VisiblePasswordBox.Visibility = Visibility.Visible;
                ShowHideButton.Content = "🔒"; // Hide icon
            }
            else
            {
                // Switch back to hidden password box
                PasswordBox.Password = VisiblePasswordBox.Text;
                PasswordBox.Visibility = Visibility.Visible;
                VisiblePasswordBox.Visibility = Visibility.Collapsed;
                ShowHideButton.Content = "👁"; // Show icon
            }
        }
    }
}








//        public ObservableCollection<Student> Students { get; set; }
//        private Student selectedStudent = null;

//        public PracticeUI_2()
//        {
//            InitializeComponent();
//            Students = new ObservableCollection<Student>();
//            StudentList.ItemsSource = Students;
//            this.SizeChanged += (s, e) => AdjustGridViewColumns();
//        }

//        // Adjust columns when window resizes
//        private void AdjustGridViewColumns()
//        {
//            if (StudentGridView == null) return;
//            double totalWidth = StudentList.ActualWidth - 35;
//            if (totalWidth <= 0) return;

//            StudentGridView.Columns[0].Width = totalWidth * 0.3;
//            StudentGridView.Columns[1].Width = totalWidth * 0.35;
//            StudentGridView.Columns[2].Width = totalWidth * 0.45;
//        }

//        // Add or Update Student
//        private void AddUpdateStudent_Click(object sender, RoutedEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(StudentName.Text) ||
//                string.IsNullOrWhiteSpace(StudentEmail.Text) ||
//                string.IsNullOrWhiteSpace(StudentAddress.Text))
//            {
//                MessageBox.Show("Please fill all fields!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }

//            if (AddUpdateButton.Content.ToString() == "Add Student")
//            {
//                var student = new Student
//                {
//                    Name = StudentName.Text,
//                    Email = StudentEmail.Text,
//                    Address = StudentAddress.Text
//                };
//                Students.Add(student);
//                MessageBox.Show("Student added successfully!", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
//            }
//            else if (selectedStudent != null)
//            {
//                selectedStudent.Name = StudentName.Text;
//                selectedStudent.Email = StudentEmail.Text;
//                selectedStudent.Address = StudentAddress.Text;
//                StudentList.Items.Refresh();
//                MessageBox.Show("Student updated successfully!", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
//            }

//            ClearFields();
//        }

//        // When row clicked → fill text fields
//        private void StudentList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
//        {
//            if (StudentList.SelectedItem is Student student)
//            {
//                selectedStudent = student;
//                StudentName.Text = student.Name;
//                StudentEmail.Text = student.Email;
//                StudentAddress.Text = student.Address;
//                AddUpdateButton.Content = "Update Student";
//            }
//        }

//        // Delete selected student
//        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
//        {
//            if (StudentList.SelectedItem is Student student)
//            {
//                Students.Remove(student);
//                MessageBox.Show("Student deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
//                ClearFields();
//            }
//            else
//            {
//                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
//            }
//        }

//        // Reset fields & button state
//        private void ClearFields()
//        {
//            StudentName.Clear();
//            StudentEmail.Clear();
//            StudentAddress.Clear();
//            StudentList.SelectedItem = null;
//            AddUpdateButton.Content = "Add Student";
//            selectedStudent = null;
//        }
//    }
//}
