using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;

namespace FantaCalcio.Service
{
    public class LeagueTeamService
    {

        private FantaCalcioDBContext _context;


        public LeagueTeamService (FantaCalcioDBContext context)
        {
            this._context = context;
        }

        public List<LeagueTeamDTO> GetAllLeagueTeam()
        {
            var listLeagueTeam = _context.LeagueTeam.Select(LeagueTeamMapper.LeagueTeamToDTO).ToList();
            return listLeagueTeam;
        }

        public LeagueTeamDTO GetLeagueTeamById(int id)
        {
            var leagueTeam = _context.LeagueTeam.Select(LeagueTeamMapper.LeagueTeamToDTO).Where(u => u.Id == id).FirstOrDefault();
            return leagueTeam;
        }

        public LeagueTeamObjDTO GetLeagueTeamObjById (int id)
        {
            var LeagueTeamFilter= _context.LeagueTeam.Where(lt => lt.Id == id).FirstOrDefault();
            var league = _context.League.Where(l => l.Id == LeagueTeamFilter.LeagueId).FirstOrDefault();
            return LeagueTeamObjMapper.LeagueTeamObjToDTO(LeagueTeamFilter, league);
        }

        public LeagueTeamDTO CreateLeagueTeam(LeagueTeamDTO dto)
        {
            var leagueTeam = LeagueTeamMapper.DTOToLeagueTeam(dto);
            var result = _context.LeagueTeam.Add(leagueTeam);
            _context.SaveChanges();
            return LeagueTeamMapper.LeagueTeamToDTO(result.Entity);
        }

        public bool UpdateLeagueTeam (LeagueTeamDTO dto)
        {
            var leagueTeamUpdate = _context.LeagueTeam.Update(LeagueTeamMapper.DTOToLeagueTeam(dto));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLeagueTeam (int id)
        {
            var leagueTeamSelect = _context.LeagueTeam.ToList().Find(u => u.Id == id);
            _context.LeagueTeam.Remove(leagueTeamSelect);
            _context.SaveChanges();
            return true;
        }


        //VALIDATIONS
        public bool CheckIfLeagueTeamExists(int id)
        {
            if (_context.LeagueTeam.Any(lt => lt.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfLeagueExists(int leagueId)
        {
            if (_context.LeagueTeam.Any(lt => lt.LeagueId == leagueId))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfTeamExists(int teamId)
        {
            if (_context.LeagueTeam.Any(lt => lt.TeamId == teamId))
            {
                return true;
            }
            return false;
        }
    }
}
