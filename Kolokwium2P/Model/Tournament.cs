using System.ComponentModel.DataAnnotations;

namespace Kolokwium2P.Model;

public class Tournament
{
    [Key]
    public int TournamentId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}