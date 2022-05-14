using System.Runtime.Serialization;

namespace API_internship
{
    [Serializable]
    internal class FailedPostException : Exception
    {
        public FailedPostException()
        {
        }

        public FailedPostException(string? message) : base(message)
        {
        }

        public FailedPostException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedPostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}