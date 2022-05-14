using System.Runtime.Serialization;

namespace API_internship
{
    [Serializable]
    internal class UnrecordedItemException : Exception
    {
        public UnrecordedItemException()
        {
        }

        public UnrecordedItemException(string? message) : base(message)
        {
        }

        public UnrecordedItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnrecordedItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}