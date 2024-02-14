using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;
using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Service
{
    public class TeamService
    {
        private FantaCalcioDBContext _context;


        public TeamService(FantaCalcioDBContext context)
        {
            this._context = context;
        }

        //GET TEAM LAZY -EAGER
        public List<TeamDTO> GetAllTeam()
        {
            var ListTeam = _context.Team.Include(t => t.ListTeamPlayer).Select(TeamMapper.TeamToDTO).ToList();
            return ListTeam;
        }

        public List<TeamObjDTO> GetAllTeamObj()
        {
            var ListTeam = _context.Team.Include(t => t.ListTeamPlayer).ToList();
            var ListTeamObj = new List<TeamObjDTO>();
            var newListTeamPlayer = new List<TeamPlayerObjDTO>();

            foreach (var team in ListTeam)
            {
                var TeamMapp = TeamObjMapper.TeamObjToDTO(team);

                foreach (var item in team.ListTeamPlayer)
                {
                    var player = _context.Player.Where(p => p.Id == item.PlayerId).FirstOrDefault();
                    var TeamPlayerMapp = TeamPlayerObjMapper.TeamPlayerObjToDTO(item, player);
                    newListTeamPlayer.Add(TeamPlayerMapp);
                    TeamMapp.ListTeamPlayerObj = newListTeamPlayer.Where(tp => tp.TeamId == team.Id).ToList();
                }
                ListTeamObj.Add(TeamMapp);
            }
            return ListTeamObj;
        }


        //GET TEAM BY ID (PLAYERS) LAZY-EAGER
        public TeamDTO GetTeamByIdWithPlayers(int id)
        {
            var Team = _context.Team.Include(t => t.ListTeamPlayer).Select(TeamMapper.TeamToDTO).Where(t => t.Id == id).FirstOrDefault();
            return Team;

        }
        
        public TeamObjDTO GetTeamByIdWithPlayersOBJ(int id)
        {
            var team = _context.Team.Include(t => t.ListTeamPlayer).Where(t => t.Id == id).FirstOrDefault();
            var newTeamObjDTO = TeamObjMapper.TeamObjToDTO(team);
            var newListTeamPlayerObj = new List<TeamPlayerObjDTO>();
            foreach (var item in team.ListTeamPlayer)
            {
                var player = _context.Player.Where(p => p.Id == item.PlayerId).FirstOrDefault();
                var mapp = TeamPlayerObjMapper.TeamPlayerObjToDTO(item, player);
                newListTeamPlayerObj.Add(mapp);
                newTeamObjDTO.ListTeamPlayerObj = newListTeamPlayerObj;

            }
            return newTeamObjDTO;
        }

        //GET TEAM BY ID (LEAGUE) LAZY- EAGER
        public TeamDTO GetTeamByIdWithLeague(int id)
        {
            var Team = _context.Team.Include(t => t.ListLeagueTeam).Select(TeamMapper.TeamToDTO).Where(t => t.Id == id).FirstOrDefault();
            return Team;
        }

        public TeamObjDTO GetTeamObjByIdWithLeague(int id)
        {
            var team = _context.Team.Include(t => t.ListLeagueTeam).Where(t => t.Id == id).FirstOrDefault();
            var newLeagueObj = TeamObjMapper.TeamObjToDTO(team);
            var newListLegueTeamObj = new List<LeagueTeamObjDTO>();
            foreach (var item in team.ListLeagueTeam)
            {
                var league = _context.League.Where(p => p.Id == item.LeagueId).FirstOrDefault();
                var mapp = LeagueTeamObjMapper.LeagueTeamObjToDTO(item, league);
                newListLegueTeamObj.Add(mapp);
                newLeagueObj.ListLeagueTeam = newListLegueTeamObj;

            }
            return newLeagueObj;
        }


        //CREATE TEAM
        public TeamDTO CreateTeam(TeamDTO dto)
        {
            var team = TeamMapper.DTOToTeam(dto);
            var result = _context.Team.Add(team);
            _context.SaveChanges();
            return TeamMapper.TeamToDTO(result.Entity);
        }


        //UPDATE TEAM
        public bool UpdateTeam(TeamDTO dto)
        {
            var teamUpdate = _context.Team.Update(TeamMapper.DTOToTeam(dto));
            _context.SaveChanges();
            return true;
        }


        //DELETE TEAM
        public bool DeleteTeam(int id)
        {
            var TeamSelect = _context.Team.ToList().Find(u => u.Id == id);
            _context.Team.Remove(TeamSelect);
            _context.SaveChanges();
            return true;
        }



        //VALIDATIONS
        public bool CheckIfTeamExists(int id)
        {
            if (_context.Team.Any(t => t.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfUserHaveMoreThan5Teams(int userId)
        {
            var UserSelect = _context.User.Include(u => u.ListTeam).ToList().Find(u => u.Id == userId);
            var ListTeamUserSelect = UserSelect.ListTeam.Capacity;
            if (ListTeamUserSelect <= 5)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfUserExists(int userId)
        {
            if (_context.User.Any(t => t.Id == userId))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfNameExistsOrDuplicate(string name)
        {
            if (_context.Team.Any(t => t.Name == name))
            {
                return true;
            }
            return false;
        }



    }
}
