using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class LeagueTeamObjMapper
    {

        public static LeagueTeamObjDTO LeagueTeamObjToDTO (LeagueTeam leagueTeam, League league)
        {

            var dto = new LeagueTeamObjDTO();
            dto.Id = leagueTeam.Id;
            dto.TeamId = leagueTeam.TeamId;
            dto.LeagueId = leagueTeam.LeagueId;
            dto.League = LeagueMapper.LeagueToDTO(league);
            return dto;
        }

        public static LeagueTeam DTOToLeagueTeam(LeagueTeamObjDTO dto)
        {

            var leagueTeam = new LeagueTeam();
            leagueTeam.Id = dto.Id;
            leagueTeam.TeamId = dto.TeamId;
            leagueTeam.LeagueId = dto.LeagueId;

            return leagueTeam;
        }
    }
}
