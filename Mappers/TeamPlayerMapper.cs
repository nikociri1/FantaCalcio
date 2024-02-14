using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class TeamPlayerMapper
    {

        public static TeamPlayerDTO TeamPlayerToDTO (TeamPlayer teamPlayer)
        {

            var dto = new TeamPlayerDTO();
            dto.Id = teamPlayer.Id;
            dto.TeamId = teamPlayer.TeamId;
            dto.PlayerId = teamPlayer.PlayerId;

            return dto;
        }

        public static TeamPlayer DTOToTeamPlayer (TeamPlayerDTO dto)
        {

            var teamPlayer = new TeamPlayer();
            teamPlayer.Id = dto.Id;
            teamPlayer.TeamId = dto.TeamId;
            teamPlayer.PlayerId = dto.PlayerId;

            return teamPlayer;
        }
    }
}
