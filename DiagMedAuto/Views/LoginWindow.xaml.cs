using DiagMedAuto.Models;
using DiagMedAuto.Services;
using DiagMedAuto.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DiagMedAuto.Views
{
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {

            DataContext = new LoginViewModel(new UtilisateurService(new MyDbContext()));
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.MotDePasse = ((PasswordBox)sender).Password;
            }
        }


    }
}
