using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVMPractice.Views
{
    /// <summary>
    /// Interaction logic for MenuTypes.xaml
    /// </summary>
    public partial class MenuTypes : Window
    {
        public MenuTypes()
        {
            InitializeComponent();
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.Clear();
            MessageBox.Show("New document created!", "Info");
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open file dialog would appear here.", "Open");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("File saved successfully.", "Save");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.Clear();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WPF Mixed Menu Example\nDeveloped by Talha Rasheed", "About");
        }
    }
}
