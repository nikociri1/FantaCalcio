using FantaCalcio.Models.Enum;
using FantaCalcio.Models;

namespace FantaCalcio.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Number { get; set; }

        public PositionType PositionType { get; set; }

       

    }
}
