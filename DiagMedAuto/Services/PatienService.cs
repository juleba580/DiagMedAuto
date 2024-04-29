using DiagMedAuto.Models;

namespace DiagMedAuto.Services
{
    public class PatientService
    {
        private readonly MyDbContext _context;

        public PatientService(MyDbContext context)
        {
            _context = context;
        }

        public PatientService()
        {
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(int id, Patient updatedPatient)
        {
            // Recherche du patient à mettre à jour
            var patientToUpdate = _context.Patients.Find(id);
            
            if (patientToUpdate != null)
            {
                // Mettre à jour les propriétés du patient existant avec les nouvelles valeurs
                patientToUpdate.Nom = updatedPatient.Nom;
                patientToUpdate.Prenom = updatedPatient.Prenom;
                // Mettez à jour d'autres propriétés comme ça
                
                // Enregistrement des modifications dans la base de données
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var patientToDelete = _context.Patients.Find(id);
            if (patientToDelete != null)
            {
                _context.Patients.Remove(patientToDelete);
                _context.SaveChanges();
            }
        }

        public Patient Get(int id)
        {
            return _context.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }
    }
}