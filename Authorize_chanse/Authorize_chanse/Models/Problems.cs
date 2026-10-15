using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorize_chanse.Models;

public class Problems
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int problemsId { get; set; }
    public string name { get; set; }
}