namespace ChancePr3TRBlazor.ApiRequest.Models
{
    // GetDoctors
    public class DocDataShort
    {
        public int doctorId { get; set; }
        public string fullname { get; set; }
        public string special { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string workplace { get; set; }
        public int userId { get; set; }
    }

    public class DocDataContainer
    {
        public List<DocDataShort> docs { get; set; }
    }

    public class DocsData
    {
        public DocDataContainer data { get; set; }
        public bool status { get; set; }
    }
}
