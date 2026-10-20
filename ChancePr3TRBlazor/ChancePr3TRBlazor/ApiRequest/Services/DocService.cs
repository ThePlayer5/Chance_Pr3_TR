namespace ChancePr3TRBlazor.ApiRequest.Services
{
    public class DocService
    {
        public Doctor CurrentDoc { get; private set; }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        public void SetDoc(Doctor doctor)
        {
            CurrentDoc = doctor;
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            CurrentDoc = null;
        }
    }

    public class Doctor
    {
        public int doctorId { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
    }
}
