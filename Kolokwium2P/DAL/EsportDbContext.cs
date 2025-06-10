using Kolokwium2P.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2P.DAL;

public class EsportDbContext : DbContext {

    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Player_Match> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    
    protected EsportDbContext()
    {
    }

    public EsportDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Match>()
            .Property(w => w.BestRating)
            .HasPrecision(4, 2);
        modelBuilder.Entity<Player_Match>()
            .Property(w => w.Rating)
            .HasPrecision(4, 2);
        
        modelBuilder.Entity<Player_Match>()
            .HasKey(p => new { p.MatchId, p.PlayerId });
        
        base.OnModelCreating(modelBuilder);
        
        
        modelBuilder.Entity<Map>().HasData(
            new Map() { MapId = 1, Name = "MapName1", Type = "big" },
            new Map() { MapId = 2, Name = "MapName2", Type = "medium" },
            new Map() { MapId = 3, Name = "MapName3", Type = "small" }
        );
        
        modelBuilder.Entity<Player>().HasData(
            new Player() {PlayerId = 1, FirstName = "fn1", LastName = "ln1", BirthDate = DateTime.Now},
            new Player() {PlayerId = 2, FirstName = "fn2", LastName = "ln2", BirthDate = DateTime.Now},
            new Player() {PlayerId = 3, FirstName = "fn3", LastName = "ln3", BirthDate = DateTime.Now}
        );
        
        modelBuilder.Entity<Tournament>().HasData(
            new Tournament() {TournamentId = 1, Name = "tn1", StartDate = DateTime.Now, EndDate = DateTime.MaxValue},
            new Tournament() {TournamentId = 2, Name = "tn2", StartDate = DateTime.Now, EndDate = DateTime.MaxValue},
            new Tournament() {TournamentId = 3, Name = "tn3", StartDate = DateTime.Now, EndDate = DateTime.MaxValue}
        );
        
        modelBuilder.Entity<Match>().HasData(
            new Match() {MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Now, Team1Score = 1, Team2Score = 2, BestRating = 10.1m},
            new Match() {MatchId = 2, TournamentId = 2, MapId = 2, MatchDate = DateTime.Now, Team1Score = 1, Team2Score = 2, BestRating = 10.2m},
            new Match() {MatchId = 3, TournamentId = 3, MapId = 3, MatchDate = DateTime.Now, Team1Score = 1, Team2Score = 2, BestRating = 10.3m}
        );
        
        
        
        modelBuilder.Entity<Player_Match>().HasData(
            new Player_Match(){MatchId = 1, PlayerId = 1, MVPs = 1, Rating = 4.3m},
            new Player_Match(){MatchId = 2, PlayerId = 2, MVPs = 2, Rating = 10.2m}
        );
        
    }
}