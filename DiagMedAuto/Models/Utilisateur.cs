using System.Security.Cryptography;
using System.Text;

namespace DiagMedAuto.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public string Hopital { get; set; }
        public string Civilite { get; set; }
        public string Specialite { get; set; }

        public string MotDePasse { get; set; } // Stocker le hachage de notre passeword

        // Notre methode pour définir le mot de passe et générer le hachage
        public void SetMotDePasse(string motDePasse)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
                MotDePasse = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // methode pour vérifier si un mot de passe correspond à celui stocké dans notre base
        public bool VerifyMotDePasse(string motDePasse)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] proposedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
                string proposedHashString = BitConverter.ToString(proposedHash).Replace("-", "").ToLower();
                return MotDePasse == proposedHashString;
            }
        }

    }
}
