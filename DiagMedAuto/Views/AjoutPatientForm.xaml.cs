using DiagMedAuto.Models;
using DiagMedAuto.Services;
using DiagMedAuto.ViewModels;
using System.Windows;

namespace DiagMedAuto.Views
{
    public partial class AjoutPatientForm : Window
    {
        private readonly AjoutPatientViewModel _viewModel;
        public AjoutPatientForm(AjoutPatientViewModel viewModel)
        {
            InitializeComponent();
            DataContext = new AjoutPatientViewModel(new PatientService(new MyDbContext()));
            // Créer une instance de MyDbContext
            var dbContext = new MyDbContext();
            // Initialiser le DataContext avec AjoutPatientViewModel en passant le PatientService
            DataContext = new AjoutPatientViewModel(new PatientService(dbContext));
        }



    }
}
