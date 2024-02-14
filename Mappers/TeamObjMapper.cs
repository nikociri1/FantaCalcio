using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class TeamObjMapper
    {
        public static TeamObjDTO TeamObjToDTO(Team team)
        {


            var dto = new TeamObjDTO();
            dto.Id = team.Id;
            dto.Name = team.Name;
            dto.Location = team.Location;
            dto.DataCreate = team.DataCreate;
            dto.UserId = team.UserId;
            return dto;
        }

        public static Team DTOToTeam(TeamDTO dto)
        {

            var team = new Team();
            team.Id = dto.Id;
            team.Name = dto.Name;
            team.Location = dto.Location;
            team.DataCreate = dto.DataCreate;
            team.UserId = dto.UserId;

            return team;
        }

    }
}
