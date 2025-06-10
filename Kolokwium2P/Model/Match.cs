using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2P.Model;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    [ForeignKey("TournamentId")]
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    [ForeignKey("MapId")]
    public int MapId { get; set; }
    public Map Map { get; set; }
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public decimal BestRating { get; set; }
}