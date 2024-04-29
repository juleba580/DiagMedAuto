using DiagMedAuto.Models;
using DiagMedAuto.Services;
using DiagMedAuto.ViewModels;
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

namespace DiagMedAuto.Views
{
    /// <summary>
    /// Logique d'interaction pour AfficherPatientForm.xaml
    /// </summary>
    public partial class AfficherPatientForm : Window
    {
        public AfficherPatientForm(AfficherPatientViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new AjoutPatientViewModel(new PatientService(new MyDbContext()));
            // Créer une instance de MyDbContext
            var dbContext = new MyDbContext();
            // Initialiser le DataContext avec AjoutPatientViewModel en passant le PatientService
            DataContext = new AfficherPatientViewModel(new PatientService(dbContext));
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
