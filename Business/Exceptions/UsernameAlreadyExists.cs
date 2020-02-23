using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UsernameAlreadyExists:Exception
    {
        public UsernameAlreadyExists() : base() { }
        public UsernameAlreadyExists(string msg) : base(msg) { }
        public UsernameAlreadyExists(string msg,Exception inner) : base(msg, inner) { }
    }
}
