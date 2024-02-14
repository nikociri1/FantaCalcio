namespace FantaCalcio.DTO
{
    public class UserObjDTO
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? CodiceFiscale { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime DataCreate { get => this.DataCreate = DateTime.Now; set { } }

        public List<TeamObjDTO> ListTeamObj { get; set; }
    }
}
