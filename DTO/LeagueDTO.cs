using FantaCalcio.Models;

namespace FantaCalcio.DTO
{
    public class LeagueDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public DateTime DataCreate { get => this.DataCreate = DateTime.Now; set { } }

        //public List<LeagueTeamDTO> ListLeagueTeam { get; set; }
    }
}
