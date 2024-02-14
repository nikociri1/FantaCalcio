using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantaCalcio.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public DateTime DataCreate { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }

        public List<LeagueTeam> ListLeagueTeam { get; set; }

        public List<TeamPlayer> ListTeamPlayer { get; set; }
    }
}
