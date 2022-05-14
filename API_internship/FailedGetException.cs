using System.Runtime.Serialization;

namespace API_internship
{
    [Serializable]
    internal class FailedGetException : Exception
    {
        public FailedGetException()
        {
        }

        public FailedGetException(string? message) : base(message)
        {
        }

        public FailedGetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedGetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}