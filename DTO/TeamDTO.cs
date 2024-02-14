using FantaCalcio.Models;

namespace FantaCalcio.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public DateTime DataCreate { get => this.DataCreate = DateTime.Now; set { } }

        public int UserId { get; set; }

        public List<LeagueTeamDTO> ListLeagueTeam { get; set; }

        public List<TeamPlayerDTO> ListTeamPlayer { get; set; }
    }
}
