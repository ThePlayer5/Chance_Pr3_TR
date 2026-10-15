using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class Session
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string token { get; set; }
    
    [Required]
    [ForeignKey("User")]
    public int userId { get; set; }
    public Users User { get; set; }
}