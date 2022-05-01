using System;

namespace API_MySIRH.Exceptions
{
    /// <summary>
    /// the base exception Class for all Application Exceptions
    /// </summary>
    [Serializable]
    public class BCIException : Exception
    {
        public BCIException() { }

        public BCIException(string message) 
            : base(message) { }

        public BCIException(string message, Exception inner) 
            : base(message, inner) { }

        protected BCIException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) 
            : base(info, context) { }
    }
}
