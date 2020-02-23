using System;

namespace Business.Exceptions
{
    public class InvalidEventException:Exception
    {
        public InvalidEventException() : base() { }
        public InvalidEventException(string msg) : base(msg) { }
        public InvalidEventException(string msg,Exception inner) : base(msg, inner) { }
    }
}
