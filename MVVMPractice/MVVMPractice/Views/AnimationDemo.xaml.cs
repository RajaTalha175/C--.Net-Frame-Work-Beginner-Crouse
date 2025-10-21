using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace MVVMPractice
{
    public partial class AnimationDemo : Window
    {
        public AnimationDemo()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation moveY = new DoubleAnimation
            {
                From = 0,
                To = 150,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            translateTransform.BeginAnimation(System.Windows.Media.TranslateTransform.YProperty, moveY);
        }
    }
}
