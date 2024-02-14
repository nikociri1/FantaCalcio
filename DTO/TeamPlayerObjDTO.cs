using FantaCalcio.Models;

namespace FantaCalcio.DTO
{
    public class TeamPlayerObjDTO
    {

        public int Id { get; set; }

        public int PlayerId { get; set; }

        public PlayerDTO Player { get; set; }

        public int TeamId { get; set; }
    }
}
