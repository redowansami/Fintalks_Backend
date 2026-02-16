using System.Net;

namespace Fintalks.Api.Exceptions
{
    public sealed class ConflictException : AppException
    {
        public ConflictException(string message)
            : base(message, HttpStatusCode.Conflict) { }
    }
}
