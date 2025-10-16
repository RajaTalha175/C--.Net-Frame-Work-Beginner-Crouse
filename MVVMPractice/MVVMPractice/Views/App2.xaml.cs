using System.Windows;

namespace MVVMPractice.Views
{
    public partial class App2 : Window
    {
        public App2()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow app1 = new MainWindow();
            app1.Show();
            this.Close();
        }
    }
}
