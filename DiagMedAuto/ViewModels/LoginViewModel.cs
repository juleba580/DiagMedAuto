using DiagMedAuto.Models;
using DiagMedAuto.Services;
using DiagMedAuto.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DiagMedAuto.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Utilisateur utilisateur = new Utilisateur();
        private readonly UtilisateurService utilisateurService;

        public Utilisateur Utilisateur
        {
            get { return utilisateur; }
            set
            {
                utilisateur = value;
                OnPropertyChanged();
            }
        }

        private string motDePasse;
        public string MotDePasse
        {
            get { return motDePasse; }
            set
            {
                motDePasse = value;
                OnPropertyChanged(nameof(MotDePasse));
            }
        }

        private DateTime? dateDeNaissance;
        public DateTime? DateDeNaissance
        {
            get { return dateDeNaissance; }
            set
            {
                dateDeNaissance = value;
                OnPropertyChanged();
            }
        }


        // Propriete pour stocker l'email entre par le user
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Utilisateur> Utilisateurs { get; set; }

        public ICommand InscriptionCommand { get; }
        public ICommand ConnexionCommand { get; }
        public ICommand SaveChangesCommand { get; }

        public LoginViewModel(UtilisateurService utilisateurService)
        {
            this.utilisateurService = utilisateurService;
            Utilisateurs = new ObservableCollection<Utilisateur>(this.utilisateurService.GetAll());

            InscriptionCommand = new RelayCommand(Inscription);
            ConnexionCommand = new RelayCommand(Connexion);
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        private void Inscription(object parameter)
        {
            if (!string.IsNullOrEmpty(MotDePasse))
            {

                Utilisateur.SetMotDePasse(MotDePasse);

                utilisateurService.Add(Utilisateur);
                Utilisateurs.Add(Utilisateur);
                Utilisateur = new Utilisateur();

                string userInfo = $"Prénom : {Utilisateur.Prenom}\n" +
                  $"Nom : {Utilisateur.Nom}\n" +
                  $"Ville : {Utilisateur.Ville}\n" +
                  $"Email : {Utilisateur.Email}\n" +
                  $"password : {Utilisateur.MotDePasse}\n"+
                  $"Hôpital : {Utilisateur.Hopital}\n" +
                  $"Civilité : {Utilisateur.Civilite}\n" +
                  $"Spécialité : {Utilisateur.Specialite}";

                // Afficher les informations dans un MessageBox
                // MessageBox.Show($"Informations saisies :\n\n{userInfo}", "Informations", MessageBoxButton.OK, MessageBoxImage.Information);

                MessageBox.Show("L'utilisateur a été enregistré avec succès.", "Enregistrement réussi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Veuillez entrer un mot de passe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Connexion(object parameter)
        {
            if (!string.IsNullOrEmpty(MotDePasse))
            {
                // Rechercher l'utilisateur par son adresse e-mail
                Utilisateur utilisateur = Utilisateurs.FirstOrDefault(u => u.Email == Email);

                if (utilisateur != null)
                {
                    // Verifier si le mot de passe entre correspond au mot de passe stocke
                    if (utilisateur.VerifyMotDePasse(MotDePasse))
                    {
                        //MessageBox.Show("Connexion réussie !", "Connexion", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Ouvrir la fenetre de bienvenue
                        AccueilWindow accueilWindow = new AccueilWindow(utilisateur, utilisateurService);
                        // Utilisation de la methode Show() pour afficher la fenetre
                        accueilWindow.Show();


                        // Fermer la fentre de connexion
                        Application.Current.MainWindow.Close();
                        return;
                    }
                }
                // Authentificat echouee
                MessageBox.Show("Identifiants incorrects. Veuillez réessayer.", "Connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Veuillez entrer un mot de passe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveChanges(object parameter)
        {
            // Appeler la methode Update du service utilisateur pour mettre a jour les informations du user
            utilisateurService.Update(Utilisateur);
            MessageBox.Show("Modifications enregistrées avec succès.", "Sauvegarde", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
