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

    public Task? InsertNewPlayerWithPlayerMatches(InsertPlayerWithPlayerMatchesRequest insertPlayerWithPlayerMatchesRequest)
    {
        if (insertPlayerWithPlayerMatchesRequest == null)
            throw new BadRequestException("Invalid request");

        Player playerToSave = new Player()
        {
            FirstName = insertPlayerWithPlayerMatchesRequest.FirstName,
            LastName = insertPlayerWithPlayerMatchesRequest.LastName,
            BirthDate = DateTime.Parse(insertPlayerWithPlayerMatchesRequest.BirthDate)
        };
        
        _dbContext.Players.Add(playerToSave);
        _dbContext.SaveChanges();
        
        var playerMatchesToSave = new List<Player_Match>();
        
        foreach (var playerMatchRequest in insertPlayerWithPlayerMatchesRequest.Matches)
        {
            if (_dbContext.Matches.Find(playerMatchRequest.MatchId) == null)
            {
                throw new NotFoundException("Match with id " + playerMatchRequest.MatchId + " not found");
            }
            
            var playerMatchToSave = new Player_Match()
            {
                PlayerId = playerToSave.PlayerId,
                MatchId = playerMatchRequest.MatchId,
                MVPs = playerMatchRequest.MVPs,
                Rating = playerMatchRequest.Rating
            };
            if (playerMatchToSave.Rating > _dbContext.Matches.Find(playerMatchRequest.MatchId)!.BestRating)
            {
                if (playerMatchToSave.Rating > 99.9999m)
                {
                    throw new ArgumentException("Provided player match rating is invalid");
                }
                _dbContext.Matches.Find(playerMatchRequest.MatchId)!.BestRating = playerMatchToSave.Rating;
            }

            playerMatchesToSave.Add(playerMatchToSave);
        }
        

        _dbContext.PlayerMatches.AddRange(playerMatchesToSave);
        _dbContext.SaveChanges();



        return null;
    }
}