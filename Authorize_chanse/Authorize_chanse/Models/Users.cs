using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int userId { get; set; }
    public string fullname { get; set; }
    public string college { get; set; }
    public string email { get; set; }
    
    [Required]
    [ForeignKey("Role")]
    public int roleId { get; set; }
    public Roles role { get; set; }
}