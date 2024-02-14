using FantaCalcio.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantaCalcio.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Number { get; set; }

        public PositionType PositionType { get; set; }

        public List<TeamPlayer> ListTeamPlayer { get; set; }

    }
}
