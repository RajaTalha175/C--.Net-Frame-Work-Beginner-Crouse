using MVVMPractice.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MVVMPractice.Views
{
    public partial class App1 : Window
    {
        private SVMUsingManual viewModel;

        public App1()
        {
            InitializeComponent();
            viewModel = DataContext as SVMUsingManual;
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (viewModel != null)
                viewModel.Password = ((PasswordBox)sender).Password;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            viewModel?.AddStudent();
        }

        private void GoToApp2_Click(object sender, RoutedEventArgs e)
        {
            App2 app2 = new App2();
            app2.Show();
            this.Close();
        }
    }
}
