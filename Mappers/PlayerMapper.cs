using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class PlayerMapper
    {

        public static PlayerDTO PlayerToDTO (Player player)
        {

            var dto = new PlayerDTO();
            dto.Id = player.Id;
            dto.Name = player.Name;
            dto.Surname = player.Surname;
            dto.Number = player.Number;
            dto.PositionType = player.PositionType;

            return dto;
        }

        public static Player DTOToPlayer (PlayerDTO dto)
        {

            var player = new Player();
            player.Id = dto.Id;
            player.Name = dto.Name;
            player.Surname = dto.Surname;
            player.Number = dto.Number;
            player.PositionType = dto.PositionType;

            return player;
        }
    }
}
