using Kolokwium2P.DAL;
using Kolokwium2P.Exceptions;
using Kolokwium2P.Model;
using Kolokwium2P.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2P.Services;

public class PlayerService : IPlayerService
{
    
    private readonly EsportDbContext _dbContext;
    
    public PlayerService(EsportDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PlayerMatchesResponse> GetPlayerMatchesForGivenIdAsync(int playerId, CancellationToken token)
    {
        var playerFromDb = await _dbContext.Players.FindAsync(new object[] { playerId }, token);
        
        if(playerFromDb == null)
            throw new NotFoundException("Player not found");

        var playerMatchesFromDb = await _dbContext.PlayerMatches.ToListAsync(token);

        var matches = new List<MatchResponse>();
        
        foreach (var playerMatch in playerMatchesFromDb)
        {
            if (playerMatch.PlayerId == playerId)
            {
                var matchFromDb = await _dbContext.Matches.FindAsync(playerMatch.MatchId, token);
                matches.Add(new MatchResponse()
                {
                    Tournament = _dbContext.Tournaments.Find(matchFromDb.TournamentId)!.Name,
                    Map =  _dbContext.Maps.Find(matchFromDb.MapId)!.Name,
                    Date = matchFromDb.MatchDate,
                    MVPs = playerMatch.MVPs,
                    Rating = playerMatch.Rating,
                    Team1Score = matchFromDb.Team1Score,
                    Team2Score = matchFromDb.Team2Score
                });
            }
        }

        return new PlayerMatchesResponse()
        {
            PlayerId = playerFromDb.PlayerId,
            FirstName = playerFromDb.FirstName,
            LastName = playerFromDb.LastName,
            BirthDate = playerFromDb.BirthDate,
            Matches = matches
        };
    }
}