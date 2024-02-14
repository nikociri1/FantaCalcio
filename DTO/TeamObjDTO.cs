namespace FantaCalcio.DTO
{
    public class TeamObjDTO
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public DateTime DataCreate { get => this.DataCreate = DateTime.Now; set { } }

        public int UserId { get; set; }

        public List<LeagueTeamObjDTO> ListLeagueTeam { get; set; }

        public List<TeamPlayerObjDTO> ListTeamPlayerObj { get; set; }
    }
}
