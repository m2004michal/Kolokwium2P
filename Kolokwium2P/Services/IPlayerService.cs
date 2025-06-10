using Kolokwium2P.Model.DTO;

namespace Kolokwium2P.Services;

public interface IPlayerService
{
    public Task<PlayerMatchesResponse> GetPlayerMatchesForGivenIdAsync(int playerId, CancellationToken token);
    public Task? InsertNewPlayerWithPlayerMatches(InsertPlayerWithPlayerMatchesRequest insertPlayerWithPlayerMatchesRequest);

}