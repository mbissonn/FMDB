using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Model.Exceptions
{
    [Serializable]
    public class MovieException : Exception
    {
        public MovieException() { }

        public  MovieException(string message)
            : base(message) { }

        public  MovieException(string message, Exception inner)
            : base(message, inner) { }
    }
}
