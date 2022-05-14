using System.Runtime.Serialization;

namespace API_internship
{
    [Serializable]
    internal class EmptyFieldsException : Exception
    {
        public EmptyFieldsException()
        {
        }

        public EmptyFieldsException(string? message) : base(message)
        {
        }

        public EmptyFieldsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyFieldsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}