using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Shared.DTOs;
using DAL.Entity;

namespace DAL.Helper
{
    public class UserMapper
    {
        public User UserDTO2User(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = config.CreateMapper();

            User User = mapper.Map<User>(userDTO);
       

            return User;
        }

        public UserDTO User2UserDTO(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = config.CreateMapper();

            UserDTO UserDTO = mapper.Map<UserDTO>(user);
            UserDTO.Password = null;
            return UserDTO;
        }
    }
}
