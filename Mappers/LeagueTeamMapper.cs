using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class LeagueTeamMapper
    {

        public static LeagueTeamDTO LeagueTeamToDTO (LeagueTeam leagueTeam)
        {

            var dto = new LeagueTeamDTO();
            dto.Id = leagueTeam.Id;
            dto.TeamId = leagueTeam.TeamId;
            dto.LeagueId = leagueTeam.LeagueId;
            return dto;
        }

        public static LeagueTeam DTOToLeagueTeam (LeagueTeamDTO dto)
        {

            var leagueTeam = new LeagueTeam();
            leagueTeam.Id = dto.Id;
            leagueTeam.TeamId = dto.TeamId;
            leagueTeam.LeagueId = dto.LeagueId;

            return leagueTeam;
        }
    }
}
