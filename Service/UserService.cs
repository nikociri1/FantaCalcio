using FantaCalcio.DTO;
using FantaCalcio.Mappers;
using FantaCalcio.Models;
using Microsoft.EntityFrameworkCore;

namespace FantaCalcio.Service
{
    public class UserService
    {
        private FantaCalcioDBContext _context;


        public UserService(FantaCalcioDBContext context)
        {
            this._context = context;
        }

        //AUTENTICATION
        public bool Autentication(Autentication autentication)
        {
            if (_context.User.Any(u => u.Email == autentication.Email) && _context.User.Any(u => u.Password == autentication.Password))
            {
                return true;
            }
            return false;
        }


        //GET USER
        public List<UserDTO> GetAllUser()
        {
            var ListUser = _context.User.Include(u => u.ListTeam).ThenInclude(lt => lt.ListTeamPlayer).Select(UserMapper.UserToDTO).ToList();
            return ListUser;
        }


        public List<UserObjDTO> GetAllUserObj()
        {
            var listUser = _context.User.Include(u => u.ListTeam).ThenInclude(t => t.ListTeamPlayer).ToList();
            var newListUser = new List<UserObjDTO>();
            var newListTeam = new List<TeamObjDTO>();
            var newListTeamPlayer = new List<TeamPlayerObjDTO>();

            foreach (var user in listUser)
            {
                var UserMapp = UserObjMapper.UserObjToDTO(user);

                foreach (var team in user.ListTeam)
                {
                    var teamMapp = TeamObjMapper.TeamObjToDTO(team);

                    foreach (var item in team.ListTeamPlayer)
                    {
                        var player = _context.Player.Where(p => p.Id == item.PlayerId).FirstOrDefault();
                        var itemMapp = TeamPlayerObjMapper.TeamPlayerObjToDTO(item, player);
                        newListTeamPlayer.Add(itemMapp);
                        teamMapp.ListTeamPlayerObj = newListTeamPlayer.Where(tp => tp.TeamId == team.Id).ToList();

                    }
                    newListTeam.Add(teamMapp);
                    UserMapp.ListTeamObj = newListTeam.Where(t => t.UserId == user.Id).ToList();
                }

                newListUser.Add(UserMapp);
            }

            return newListUser;
        }


        //GET USER BY ID LAZY - EAGER
        public UserDTO GetUserById(int id)
        {
            var user = _context.User.Include(u => u.ListTeam).ThenInclude(t => t.ListTeamPlayer).Select(UserMapper.UserToDTO).Where(u => u.Id == id).FirstOrDefault();
            return user;
        }
        public UserObjDTO GetUserObjById(int id)
        {
            var listUserFilter = _context.User.Include(u => u.ListTeam).ThenInclude(t => t.ListTeamPlayer).Where(u => u.Id == id).ToList();
            var newListUser = new List<UserObjDTO>();
            var newListTeam = new List<TeamObjDTO>();
            var newListTeamPlayer = new List<TeamPlayerObjDTO>();

            foreach (var user in listUserFilter)
            {
                var UserMapp = UserObjMapper.UserObjToDTO(user);

                foreach (var team in user.ListTeam)
                {
                    var teamMapp = TeamObjMapper.TeamObjToDTO(team);

                    foreach (var item in team.ListTeamPlayer)
                    {
                        var player = _context.Player.Where(p => p.Id == item.PlayerId).FirstOrDefault();
                        var itemMapp = TeamPlayerObjMapper.TeamPlayerObjToDTO(item, player);
                        newListTeamPlayer.Add(itemMapp);
                        teamMapp.ListTeamPlayerObj = newListTeamPlayer;
                    }
                    newListTeam.Add(teamMapp);
                    UserMapp.ListTeamObj = newListTeam;
                }

                newListUser.Add(UserMapp);
            }

            return newListUser.ToList().Find(u => u.Id == id);

        }


        //CREATE USER
        public UserDTO CreateUser(UserDTO dto)
        {
            var user = UserMapper.DTOToUser(dto);
            var result = _context.User.Add(user);
            _context.SaveChanges();
            return UserMapper.UserToDTO(result.Entity);
        }

        //UPDATE USER
        public bool UpdateUser(UserDTO dto)
        {
            var userUpdate = _context.User.Update(UserMapper.DTOToUser(dto));
            _context.SaveChanges();
            return true;
        }

        //DELETE USER
        public bool DeleteUser(int id)
        {
            var userSelect = _context.User.ToList().Find(u => u.Id == id);
            _context.User.Remove(userSelect);
            _context.SaveChanges();
            return true;
        }


        //VALIDATIONS
        public bool CheckIfUserExists(int id)
        {
            if (_context.User.Any(u => u.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfEmailExists(string email)
        {
            if (_context.User.Any(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfCodiceFiscaleExists(string codiceFiscale)
        {
            if (_context.User.Any(u => u.CodiceFiscale == codiceFiscale))
            {
                return true;
            }
            return false;
        }


    }
}
