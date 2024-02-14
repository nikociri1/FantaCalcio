using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class LeagueMapper
    {

        public static LeagueDTO LeagueToDTO (League league)
        {

            var dto = new LeagueDTO();
            dto.Id = league.Id;
            dto.Name = league.Name;
            dto.Description = league.Description;
            dto.Location = league.Location;
            dto.DataCreate = league.DataCreate;

            return dto;
        }

        public static League DTOToLeague (LeagueDTO dto)
        {

            var league = new League();
            league.Id = dto.Id;
            league.Name = dto.Name;
            league.Description = dto.Description;
            league.Location = dto.Location;
            league.DataCreate = dto.DataCreate;

            return league;
        }
    }
}
