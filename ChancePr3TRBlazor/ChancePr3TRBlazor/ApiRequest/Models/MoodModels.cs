namespace ChancePr3TRBlazor.ApiRequest.Models
{
    // GetMood
    public class MoodDataShort
    {
        public int moodId { get; set; }
        public int moodLevel { get; set; }
        public string? note { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public int userId { get; set; }
    }

    public class MoodDataContainer
    {
        public List<MoodDataShort> moods { get; set; }
    }

    public class MoodData
    {
        public MoodDataContainer data { get; set; }
        public bool status { get; set; }
    }

    // CreateMood
    public class ReqDataMood
    {
        public int moodLevel { get; set; }
        public string? note { get; set; }
        public DateTime moodDate { get; set; } = DateTime.UtcNow;
    }

    public class MoodCreateData
    {
        public bool status { get; set; }
    }
}
