﻿using System;

namespace DAL.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException() : base() { }
        public UserNotFoundException(string msg) : base(msg) { }
        public UserNotFoundException(string msg, Exception inner) : base(msg, inner) { }
    }
}
