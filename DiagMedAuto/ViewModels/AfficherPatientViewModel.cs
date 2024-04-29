using DiagMedAuto.Models;
using DiagMedAuto.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DiagMedAuto.ViewModels
{
    public class AfficherPatientViewModel : BaseViewModel
    {
        private readonly PatientService _patientService;
        private ObservableCollection<Patient> _patients;


        public ICommand DeleteCommand { get; }
        public ICommand ModifyCommand { get; }

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                //PropertyChanged();
            }
        }

        public AfficherPatientViewModel(PatientService patientService)
        {

            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            var patients = _patientService.GetAll();
            Patients = patients != null ? new ObservableCollection<Patient>(patients) : new ObservableCollection<Patient>();

            DeleteCommand = new RelayCommand(DeletePatient);
            ModifyCommand = new RelayCommand(UpdatePatient);
        }

        private void DeletePatient(object parameter)
        {
            if (parameter is Patient patient)
            {
                _patientService.Delete(patient.Id);
                Patients.Remove(patient);
            }
        }

        private void UpdatePatient(object parameter)
        {
            if (parameter is Patient patient)
            {
                // Mettre à jour les informations du patient
                _patientService.UpdatePatient(patient.Id, patient);
            }
        }



    }
}
