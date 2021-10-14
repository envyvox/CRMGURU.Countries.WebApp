using System;

namespace CRMGURU.Data.Extensions
{
    public class ExceptionExtensions
    {
        public class NotFoundException : Exception
        {
            public NotFoundException()
            {
            }

            public NotFoundException(string message)
                : base(message)
            {
            }

            public NotFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class AlreadyExistException : Exception
        {
            public AlreadyExistException()
            {
            }

            public AlreadyExistException(string message)
                : base(message)
            {
            }

            public AlreadyExistException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}
