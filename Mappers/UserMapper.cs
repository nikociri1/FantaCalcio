﻿using FantaCalcio.DTO;
using FantaCalcio.Models;

namespace FantaCalcio.Mappers
{
    public class UserMapper
    {

        public static UserDTO UserToDTO (User user)
        {

            var dto = new UserDTO();
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.Surname = user.Surname;
            dto.CodiceFiscale = user.CodiceFiscale;
            dto.Address = user.Address;
            dto.Email = user.Email;
            dto.Password = user.Password;
            dto.DataCreate = user.DataCreate;
            dto.ListTeam = user.ListTeam?.Select(TeamMapper.TeamToDTO).ToList();
            return dto;
        }

        public static User DTOToUser (UserDTO dto)
        {

            var user = new User();
            user.Id = dto.Id;
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.CodiceFiscale = dto.CodiceFiscale;
            user.Address = dto.Address;
            user.Email = dto.Email;
            user.Password = dto.Password;

            return user;
        }
    }
}
