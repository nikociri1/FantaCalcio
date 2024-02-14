using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;
using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Service
{
    public class LeagueService
    {
        private FantaCalcioDBContext _context;


        public LeagueService (FantaCalcioDBContext context)
        {
            this._context = context;
        }

        public List<LeagueDTO> GetAllLeague()
        {
            var listLeague = _context.League.Select(LeagueMapper.LeagueToDTO).ToList();
            return listLeague;
        }

        public LeagueDTO GetLeagueById(int id)
        {
            var league = _context.League.Select(LeagueMapper.LeagueToDTO).Where(t => t.Id == id).FirstOrDefault();
            return league;
        }

        public LeagueDTO CreateLeague (LeagueDTO dto)
        {
            var league = LeagueMapper.DTOToLeague(dto);
            var result = _context.League.Add(league);
            _context.SaveChanges();
            return LeagueMapper.LeagueToDTO(result.Entity);
        }

        public bool UpdateLeague (LeagueDTO dto)
        {
            var leagueUpdate = _context.League.Update(LeagueMapper.DTOToLeague(dto));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLeague (int id)
        {
            var leagueSelect = _context.League.ToList().Find(u => u.Id == id);
            _context.League.Remove(leagueSelect);
            _context.SaveChanges();
            return true;
        }


        //VALIDATIONS
        public bool CheckIfLeagueExists (int id)
        {
            if(_context.League.Any(l=>l.Id== id))
            {
                return true;
            }
            return false;
        }
    }
}
