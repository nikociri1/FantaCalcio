namespace FantaCalcio.DTO
{
    public class LeagueTeamObjDTO
    {

        public int Id { get; set; }

        public int TeamId { get; set; }

        public int LeagueId { get; set; }

        public LeagueDTO League { get; set; }

    }
}
