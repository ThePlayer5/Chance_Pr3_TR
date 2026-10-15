using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class DoctorProblems
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    [ForeignKey("User")]
    public int userId { get; set; }
    public Users User { get; set; }
    
    [Required]
    [ForeignKey("Problem")]
    public int problemsId { get; set; }
    public Problems Problem { get; set; }
}