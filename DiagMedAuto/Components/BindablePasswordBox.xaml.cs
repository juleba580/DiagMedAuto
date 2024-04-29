using System.Windows;
using System.Windows.Controls;

namespace DiagMedAuto.Components
{
    public class BindablePasswordBox : Decorator
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                if (passwordBox.Child is PasswordBox pb)
                {
                    pb.Password = e.NewValue?.ToString();
                }
            }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            Child = new PasswordBox();
        }
    }
}
