using System;
using System.Windows;

namespace MVVMPractice
{
    public partial class Nav_Delegation : Window
    {
        public delegate void Notify(string message);
        public event Notify OnButtonClicked;

        public Nav_Delegation()
        {
            InitializeComponent();
            OnButtonClicked += ShowMessage;
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            OnButtonClicked?.Invoke("Button was clicked! Event triggered successfully.");
        }

        private void ShowMessage(string message)
        {
            txtMessage.Text = message;
        }
    }
}
