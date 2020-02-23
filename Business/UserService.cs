using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared.DTOs;
using DAL.Exceptions;
using DAL.Operations;
using Business.Exceptions;

namespace Business
{
    public class UserService
    {
        private UserOperations UserOperations = new UserOperations();

        public UserDTO Login(UserDTO userDTO)
        {
            try
            {
                UserDTO LoggedInUser = UserOperations.Login(userDTO);
                return LoggedInUser;
            }
            catch(UserNotFoundException ex)
            {
                throw new InvalidUserException("Username or Password is incorrect", ex);
            }
            
        }

        //Return User 
        public bool Register(UserDTO userDTO)
        {
            if (UserOperations.IsPresent(userDTO.Email))
            {
                throw new UsernameAlreadyExists("User Name is Already taken");
            }
            else
            {
                UserOperations.Create(userDTO);
                return true;
            }
        }
    }
}
