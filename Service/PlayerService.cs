using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;
using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Service
{
    public class PlayerService
    {

        private FantaCalcioDBContext _context;


        public PlayerService (FantaCalcioDBContext context)
        {
            this._context = context;
        }

        //GET ALL PLAYER
        public List<PlayerDTO> GetAllPlayer()
        {
            var ListPlayer = _context.Player.Select(PlayerMapper.PlayerToDTO).ToList();
            return ListPlayer;
        }


        //GET PLAYER BY ID
        public PlayerDTO GetPlayerById(int id)
        {
            var player = _context.Player.Select(PlayerMapper.PlayerToDTO).Where(u => u.Id == id).FirstOrDefault();
            return player;
        }


        //CREATE PLAYER
        public PlayerDTO CreatePlayer (PlayerDTO dto)
        {
            var player = PlayerMapper.DTOToPlayer(dto);
            var result = _context.Player.Add(player);
            _context.SaveChanges();
            return PlayerMapper.PlayerToDTO(result.Entity);
        }


        //UPDATE PLAYER
        public bool UpdatePlayer (PlayerDTO dto)
        {
            var playerUpdate = _context.Player.Update(PlayerMapper.DTOToPlayer(dto));
            _context.SaveChanges();
            return true;
        }


        //DELETE PLAYER
        public bool DeletePlayer (int id)
        {
            var playerSelect = _context.Player.ToList().Find(u => u.Id == id);
            _context.Player.Remove(playerSelect);
            _context.SaveChanges();
            return true;
        }

        //VALIDATIONS
        public bool CheckIfPlayerExists(int id)
        {
            if (_context.Player.Any(u => u.Id == id))
            {
                return true;
            }
            return false;
        }

    }
}
