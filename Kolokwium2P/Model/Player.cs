using System.ComponentModel.DataAnnotations;

namespace Kolokwium2P.Model;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}