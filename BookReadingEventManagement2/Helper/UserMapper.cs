using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared.DTOs;
using BookReadingEventManagement2.Models;
using AutoMapper;

namespace BookReadingEventManagement2.Helper
{
    public class UserMapper
    {
        public UserDTO UserViewModel2userDTO(UserViewModel userViewModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>());
            var mapper = config.CreateMapper();

            UserDTO UserDTO = mapper.Map<UserDTO>(userViewModel);
            return UserDTO;
        }

        public UserViewModel UserDTO2UserViewModel(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>());
            var mapper = config.CreateMapper();

            UserViewModel UserViewModel = mapper.Map<UserViewModel>(userDTO);
            return UserViewModel;
        }

        public UserDTO RegisterViewModel2UserDTO(RegisterViewModel registerViewModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, UserDTO>());
            var mapper = config.CreateMapper();

            UserDTO UserDTO = mapper.Map<UserDTO>(registerViewModel);
            return UserDTO;
        }
    }
}