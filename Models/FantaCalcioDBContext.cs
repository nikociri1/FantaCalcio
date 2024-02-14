using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Models
{
    public class FantaCalcioDBContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<LeagueTeam> LeagueTeam { get; set; }

        public DbSet<League> League { get; set; }

        public DbSet<TeamPlayer> TeamPlayer { get; set; }

        public DbSet<Player> Player { get; set; }



        public FantaCalcioDBContext(DbContextOptions<FantaCalcioDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //MODEL USER
            modelBuilder.Entity<User>().HasMany(u => u.ListTeam).WithOne(t => t.User).HasForeignKey(t => t.UserId);

            //MODEL TEAM
            modelBuilder.Entity<Team>().HasMany(t => t.ListLeagueTeam).WithOne(lt => lt.Team).HasForeignKey(lt => lt.TeamId);
            modelBuilder.Entity<Team>().HasMany(t => t.ListTeamPlayer).WithOne(tp => tp.Team).HasForeignKey(tp => tp.TeamId);

            //MODEL LEAGUE
            modelBuilder.Entity<League>().HasMany(l => l.ListLeagueTeam).WithOne(lt => lt.League).HasForeignKey(lt => lt.LeagueId);

            //MODEL PLAYER
            modelBuilder.Entity<Player>().HasMany(p => p.ListTeamPlayer).WithOne(tp => tp.Player).HasForeignKey(tp => tp.PlayerId);
            
        }

    }
}
