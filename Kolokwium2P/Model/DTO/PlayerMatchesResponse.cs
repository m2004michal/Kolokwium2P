namespace Kolokwium2P.Model.DTO;

public class PlayerMatchesResponse
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MatchResponse> Matches { get; set; }
}