using System;


namespace DAL.Exceptions
{
    public class NoSuchEventException:Exception
    {
        public NoSuchEventException() : base() { }
        public NoSuchEventException(string msg) : base(msg) { }
        public NoSuchEventException(string msg,Exception inner) : base(msg, inner) { }
    }
}
