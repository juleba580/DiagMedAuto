using DiagMedAuto.Models;
using DiagMedAuto.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DiagMedAuto.ViewModels
{
    public class AjoutPatientViewModel : INotifyPropertyChanged
    {
        private readonly PatientService patientService;

        public ICommand EnregistrerCommand { get; }

        private Patient nouveauPatient;
        private string civiliteSelectionnee;



      
        public Patient NouveauPatient
        {
            get { return nouveauPatient; }
            set
            {
                nouveauPatient = value;
                OnPropertyChanged(); // Notifier l'interface user
            }
        }

        public AjoutPatientViewModel(PatientService patientService)
        {
            this.patientService = patientService;
            NouveauPatient = new Patient();
            EnregistrerCommand = new RelayCommand(Enregistrer);
        }

        public void Enregistrer(object parameter)
        {
            // Verifier que NouveauPatient n'est pas null
            if (NouveauPatient == null)
            {
                MessageBox.Show("Erreur : Aucun patient à enregistrer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NouveauPatient.cp="";
            NouveauPatient.thal="";
            NouveauPatient.ca="";
            NouveauPatient.oldpeak="";
            NouveauPatient.thalach="";
            // Verifier que toutes les infos necessaires sont pas null
            if (string.IsNullOrEmpty(NouveauPatient.Prenom) || string.IsNullOrEmpty(NouveauPatient.Nom) ||
                NouveauPatient.DateDeNaissance == null || string.IsNullOrEmpty(NouveauPatient.Civilite) ||
                string.IsNullOrEmpty(NouveauPatient.Email) || string.IsNullOrEmpty(NouveauPatient.Telephone) ||
                string.IsNullOrEmpty(NouveauPatient.Hopital) || string.IsNullOrEmpty(NouveauPatient.Ville) ||
                string.IsNullOrEmpty(NouveauPatient.Medecin))
            {
                // Afficher un message derreur au cas des infos manques
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          /*  
            // Afficher les détails du nouveau patient dans une MessageBox pour test
            MessageBox.Show($"Nouveau patient :\n" +
                            $"Prénom : {NouveauPatient.Prenom}\n" +
                            $"Nom : {NouveauPatient.Nom}\n" +
                            $"Date de naissance : {NouveauPatient.DateDeNaissance}\n" +
                            $"Civilité : {NouveauPatient.Civilite}\n" +
                            $"Email : {NouveauPatient.Email}\n" +
                            $"Téléphone : {NouveauPatient.Telephone}\n" +
                            $"Hôpital : {NouveauPatient.Hopital}\n" +
                            $"Ville : {NouveauPatient.Ville}\n" +
                            $"Médecin : {NouveauPatient.Medecin}",
                            "Nouveau patient",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);*/



            // Ajouter le nouveau patient en utilisant le service PatientService
            patientService.Add(NouveauPatient);

            // Afficher un message de confirmation
            MessageBox.Show("Le patient a été ajouté avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

            // Effacer les champs du formulaire apres ajout du patient
             NouveauPatient = new Patient();
        }


        // Methode pour notifier l'interface utilisateur des modifications de proprietes
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
