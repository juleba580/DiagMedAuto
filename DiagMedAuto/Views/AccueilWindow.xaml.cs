using DiagMedAuto.Models;
using DiagMedAuto.Services;
using DiagMedAuto.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DiagMedAuto.Views
{
    public partial class AccueilWindow : Window
    {
        private Utilisateur utilisateur;
        private PatientService patientService;
        private readonly UtilisateurService utilisateurService; // Declaration du service utilisateur

        public AccueilWindow(Utilisateur utilisateur, UtilisateurService utilisateurService)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            this.utilisateurService = utilisateurService; // Initialisation du service utilisateur
            DataContext = utilisateur;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Fermer la fenetre actuelle (accueilWindow)
            Close();

            // Creer une nouvelle fenetre de connexion (LoginWindow)
            LoginWindow loginWindow = new LoginWindow();

            // Afficher la fenetre de connexion
            loginWindow.ShowDialog();

            // Fermer la fenetre actuelle (accueilWindow)
            Close();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

        }


        private void AddEntity_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            // recuperer l'utilisateur directement a partir du DataContext
            Utilisateur utilisateur = (Utilisateur)DataContext;

            // Appeler la methode Update du service utilisateur pour mettre a jour les informations de l'utilisateur
            utilisateurService.Update(utilisateur);

            // Afficher un message de confirmation
            MessageBox.Show("Modifications enregistrées avec succes.", "Sauvegarde", MessageBoxButton.OK, MessageBoxImage.Information);

            // Ouvrir une nouvelle instance de la page AccueilWindow avec les infos de user mis a jour
            AccueilWindow accueilWindow = new AccueilWindow(utilisateur, utilisateurService);
            accueilWindow.Show();

            // Fermer la fenetre actuelle (Modification des infos personnelles)
            Close();
        }

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Entity -------------------------------------------


        public AccueilWindow(PatientService patientService)
        {
            InitializeComponent();
            this.patientService = patientService;
        }


        private void ModifierPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SupprimerPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AfficherPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenAjoutPatientForm_Click(object sender, RoutedEventArgs e)
        {
            AjoutPatientViewModel ajoutPatientViewModel = new AjoutPatientViewModel(patientService);
            AjoutPatientForm addPatientForm = new AjoutPatientForm(ajoutPatientViewModel);

            // Affichez le formulaire d'ajout de patient en tant que nouvelle fenêtre modale
            addPatientForm.ShowDialog();
        }


        //afficher patient 
        private void OpenAfficherPatient_Click(object sender, RoutedEventArgs e)
        {
            var dbContext = new MyDbContext();
            
            PatientService patientService = new PatientService(dbContext);
            AfficherPatientViewModel viewModel = new AfficherPatientViewModel(patientService);

            // Utilisez l'instance de viewModel pour créer la fenêtre AfficherPatientForm
            AfficherPatientForm afficherPatientForm = new AfficherPatientForm(viewModel);
            afficherPatientForm.Show();
        }

        //afficher dossier 
        private void OpenDossierPatient_Click(object sender, RoutedEventArgs e)
        {
            var dbContext = new MyDbContext();

            PatientService patientService = new PatientService(dbContext);
            AfficherPatientViewModel viewModel = new AfficherPatientViewModel(patientService);

            // Utilisez l'instance de viewModel pour créer la fenêtre AfficherPatientForm
            DossierPatientForm dossierPatientForm = new DossierPatientForm(viewModel);
            dossierPatientForm.Show();
        }


    }
}
