namespace API_MySIRH.Exceptions
{
    using System;

    public class NotFoundException : BCIException
    {
        public string MessageCode { get; set; }

        public NotFoundException()
        { }

        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, string messageCode) : base(message)
        {
            MessageCode = messageCode;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
