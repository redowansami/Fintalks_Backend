using System.Net;

namespace Fintalks.Common.Exceptions
{
    public sealed class ConflictException : AppException
    {
        public ConflictException(string message)
            : base(message, HttpStatusCode.Conflict) { }
    }
}
