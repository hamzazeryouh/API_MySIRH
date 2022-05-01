namespace API_MySIRH.Exceptions
{

    using System;

    public class UnAuthorizedException : BCIException
    {
        public UnAuthorizedException()
        { }

        public UnAuthorizedException(string message) : base(message)
        { }

        public UnAuthorizedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
