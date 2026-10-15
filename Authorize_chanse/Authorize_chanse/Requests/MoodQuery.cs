namespace Authorize_chanse.Requests;

public class MoodQuery
{
    public int moodLevel { get; set; }
        
    public string? note { get; set; }
        
    public DateTime moodDate { get; set; }
}