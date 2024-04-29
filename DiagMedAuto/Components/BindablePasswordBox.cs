using System.Windows;
using System.Windows.Controls;

namespace DiagMedAuto.Components
{
    public class BindablePasswordBox : Decorator
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = (PasswordBox)d;
            passwordBox.PasswordChanged -= PasswordChanged;
            if (e.NewValue != null)
            {
                passwordBox.Password = e.NewValue.ToString();
            }
            else
            {
                passwordBox.Password = string.Empty;
            }
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            SetPassword(passwordBox, passwordBox.Password);
        }

        private static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject d)
        {
            return (string)d.GetValue(BoundPassword);
        }

        public static void SetBoundPassword(DependencyObject d, string value)
        {
            d.SetValue(BoundPassword, value);
        }

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null)
                return;

            passwordBox.PasswordChanged -= PasswordChanged;

            if (GetIsUpdating(passwordBox))
                return;

            passwordBox.Password = e.NewValue == null ? string.Empty : e.NewValue.ToString();
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(BindablePasswordBox));

        private static bool GetIsUpdating(DependencyObject d)
        {
            return (bool)d.GetValue(IsUpdatingProperty);
        }

        private static void SetIsUpdating(DependencyObject d, bool value)
        {
            d.SetValue(IsUpdatingProperty, value);
        }

        private static void SetPassword(PasswordBox passwordBox, string password)
        {
            SetIsUpdating(passwordBox, true);
            SetBoundPassword(passwordBox, password);
            SetIsUpdating(passwordBox, false);
        }
    }
}
