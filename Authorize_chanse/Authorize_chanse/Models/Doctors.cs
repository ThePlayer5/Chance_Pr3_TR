using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class Doctors
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int doctorId { get; set; }
    public string fullname { get; set; }
    public string special { get; set; }
    public string email { get; set; }
    public int phone { get; set; }
    public string workplace { get; set; }
    
    [Required]
    [ForeignKey("user")]
    public int userId { get; set; }
    public Users User { get; set; }
}