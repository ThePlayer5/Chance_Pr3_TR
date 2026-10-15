using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class MoodTrack
{
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int moodId { get; set; }
        
        public int moodLevel { get; set; }
        
        public string? note { get; set; }
        
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        
        
        [Required]
        [ForeignKey("userId")]
        public int userId { get; set; }
        public Users User { get; set; }
    
}