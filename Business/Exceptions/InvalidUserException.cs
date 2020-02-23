using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class InvalidUserException:Exception
    {
        public InvalidUserException() : base() { }
        public InvalidUserException(string msg) : base(msg) { }
        public InvalidUserException(string msg,Exception inner) : base(msg, inner) { }
    }
}
