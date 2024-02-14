using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;
using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Service
{
    public class TeamPlayerService
    {

        private FantaCalcioDBContext _context;


        public TeamPlayerService(FantaCalcioDBContext context)
        {
            this._context = context;
        }


        //GET TEAM PLATER LAZY- EAGER
        public List<TeamPlayerDTO> GetAllTeamPlayer()
        {
            var listTeamPlayer = _context.TeamPlayer.Select(TeamPlayerMapper.TeamPlayerToDTO).ToList();
            return listTeamPlayer;

        }
        
        public List<TeamPlayerObjDTO> GetAllTeamPlayerObj()
        {
            
            var listTeamPlayer = _context.TeamPlayer.ToList();
            var newList = new List<TeamPlayerObjDTO>();

            foreach (var item in listTeamPlayer)
            {
                var player = _context.Player.ToList().Find(p => p.Id == item.PlayerId);
                var mapp = TeamPlayerObjMapper.TeamPlayerObjToDTO(item, player);
                newList.Add(mapp);
            }
            return newList;

        }


        //GET TEAM PLAYER BY ID LAZT -EAGER
        public TeamPlayerDTO GetTeamPlayerById( int id)
        {
            var teamPlayer = _context.TeamPlayer.Select(TeamPlayerMapper.TeamPlayerToDTO).Where(u => u.Id == id).FirstOrDefault();
            return teamPlayer;

        }

        public TeamPlayerObjDTO GetTeamPlayerObjById(int id)
        {
            var teamPlayerFilter = _context.TeamPlayer.Where(tp => tp.Id == id).FirstOrDefault();
            var playerFilter = _context.Player.FirstOrDefault(p => p.Id == teamPlayerFilter.PlayerId);

            var teamPlayerMapper = TeamPlayerObjMapper.TeamPlayerObjToDTO(teamPlayerFilter, playerFilter);
            return teamPlayerMapper;
        }


        //CREATE TEAM PLAYER
        public TeamPlayerDTO CreateTeamPlayer(TeamPlayerDTO dto)
        {
            var teamPlayer = TeamPlayerMapper.DTOToTeamPlayer(dto);
            var result = _context.TeamPlayer.Add(teamPlayer);
            _context.SaveChanges();
            return TeamPlayerMapper.TeamPlayerToDTO(result.Entity);
        }


        //UPDATE TEAM PLAYER
        public bool UpdateTeamPlayer(TeamPlayerDTO dto)
        {
            var teamPlayerUpdate = _context.TeamPlayer.Update(TeamPlayerMapper.DTOToTeamPlayer(dto));
            _context.SaveChanges();
            return true;
        }


        //DELETE TEAM PLAYER
        public bool DeleteTeamPlayer(int id)
        {
            var teamPlayerSelect = _context.TeamPlayer.ToList().Find(u => u.Id == id);
            _context.TeamPlayer.Remove(teamPlayerSelect);
            _context.SaveChanges();
            return true;
        }



        //VALIDATIONS
        public bool CheckIfTeamPlayerExists(int id)
        {
            if (_context.TeamPlayer.Any(u => u.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfPlayerExists(int playerId)
        {
            if (_context.Player.Any(p => p.Id == playerId))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfTeamExists(int teamId)
        {
            if (_context.Team.Any(t => t.Id == teamId))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfTeamHaveADuplicatePlayer (int playerId)
        {
            if(_context.TeamPlayer.Any(tp=> tp.PlayerId == playerId))
            {
                return true;
            }
           return false;
        }

        

    }
}
