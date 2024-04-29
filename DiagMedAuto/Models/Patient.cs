namespace DiagMedAuto.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public string Civilite { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Hopital { get; set; }
        public string Ville { get; set; }
        public string Medecin { get; set; }
        public string? cp  { get; set; }
        public string? thal { get; set; }
        public string? ca  { get; set; }
        public string? oldpeak { get; set; }
        public string? thalach { get; set; }
}
}
