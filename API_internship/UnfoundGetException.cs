using System.Runtime.Serialization;

namespace API_internship
{
    [Serializable]
    internal class UnfoundGetException : Exception
    {
        public UnfoundGetException()
        {
        }

        public UnfoundGetException(string? message) : base(message)
        {
        }

        public UnfoundGetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnfoundGetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}