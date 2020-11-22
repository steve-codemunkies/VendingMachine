using System.Runtime.Serialization;

namespace VendingMachine.Exceptions
{
    [System.Serializable]
    public class InvalidCoinException : System.Exception
    {
        public InvalidCoinException()
        {
        }

        public InvalidCoinException(string message) : base(message)
        {
        }

        public InvalidCoinException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCoinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}