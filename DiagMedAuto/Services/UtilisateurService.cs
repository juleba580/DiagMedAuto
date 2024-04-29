using DiagMedAuto.Models;

namespace DiagMedAuto.Services
{
    public class UtilisateurService
    {
        private readonly MyDbContext _context;

        public UtilisateurService(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
        }

        public void Update(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Update(utilisateur);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var utilisateurToDelete = _context.Utilisateurs.Find(id);
            if (utilisateurToDelete != null)
            {
                _context.Utilisateurs.Remove(utilisateurToDelete);
                _context.SaveChanges();
            }
        }

        public Utilisateur Get(int id)
        {
            return _context.Utilisateurs.Find(id);
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            return _context.Utilisateurs.ToList();

        }

    }
}
