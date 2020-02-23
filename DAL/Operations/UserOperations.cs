using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Helper;
using DAL.Entity;
using DAL.Exceptions;
using Shared.DTOs;

namespace DAL.Operations
{

    public class UserOperations
    {
        private BookReadingEventManagementContext db = new BookReadingEventManagementContext();
        private UserMapper UserMapper = new UserMapper();

        public void Create(UserDTO userDTO)
        {
            User User = UserMapper.UserDTO2User(userDTO);
            db.Users.Add(User);
            db.SaveChanges();
        }

        public bool IsPresent(string email)
        {
            return db.Users.Any(user => user.Email == email);
        }

        public UserDTO Login(UserDTO userDTO)
        {
            User User;
          
            User = db.Users.Where(user => user.Email == userDTO.Email).SingleOrDefault();
            if(User == null)
            {
                throw new UserNotFoundException("");
            }
            
            db.SaveChanges();

            UserDTO ReturnUserDTO;
            if (User.Password == userDTO.Password)
            {
                ReturnUserDTO = UserMapper.User2UserDTO(User);
            }
            else
            {
                ReturnUserDTO = null;
            }

            return ReturnUserDTO;
        }
        
        //Update

    }
}
