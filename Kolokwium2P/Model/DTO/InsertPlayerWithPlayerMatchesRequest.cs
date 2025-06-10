namespace Kolokwium2P.Model.DTO;

public class InsertPlayerWithPlayerMatchesRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public List<InsertPlayerMatchRequest> Matches { get; set; }
}