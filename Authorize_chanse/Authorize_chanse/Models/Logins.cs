using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class Logins
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int loginId { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    [Required]
    [ForeignKey("User")]
    public int userId { get; set; }
    public Users User { get; set; }
}