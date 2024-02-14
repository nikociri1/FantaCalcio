using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantaCalcio.Models
{
    public class LeagueTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int LeagueId { get; set; }

        public League League { get; set; }
    }
}
