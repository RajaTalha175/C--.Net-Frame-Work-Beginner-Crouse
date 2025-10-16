using System.Windows;
using MVVMPractice.ViewModels;

namespace MVVMPractice.Views
{
    public partial class MainWindow : Window
    {
        private StudentViewModelUsingToolKit ViewModel =>
            (StudentViewModelUsingToolKit)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.Password = pwdBox.Password;
            }
        }

        private void GoToApp1_Click(object sender, RoutedEventArgs e)
        {
            App1 app1Window = new App1();
            app1Window.Show();
            this.Close(); // optional — close current window
        }
    }
}
