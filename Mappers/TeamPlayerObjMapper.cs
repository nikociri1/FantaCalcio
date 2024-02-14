using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class TeamPlayerObjMapper
    {

        public static TeamPlayerObjDTO TeamPlayerObjToDTO (TeamPlayer teamPlayer, Player player)
        {
            var dto = new TeamPlayerObjDTO();
            dto.Id = teamPlayer.Id;
            dto.TeamId = teamPlayer.TeamId;
            dto.PlayerId = teamPlayer.PlayerId;
            dto.Player = PlayerMapper.PlayerToDTO(player);

            return dto;
        }

        public static TeamPlayer DTOToTeamPlayer (TeamPlayerObjDTO dto)
        {

            var teamPlayer = new TeamPlayer();
            teamPlayer.Id = dto.Id;
            teamPlayer.TeamId = dto.TeamId;
            teamPlayer.PlayerId = dto.PlayerId;

            return teamPlayer;
        }
    }
}
