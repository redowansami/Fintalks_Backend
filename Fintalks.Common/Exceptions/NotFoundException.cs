using System.Net;
using Fintalks.Common.Constants;

namespace Fintalks.Common.Exceptions
{
    public sealed class NotFoundException : AppException
    {
        public NotFoundException(string resourceName, object key)
            : base(ErrorConst.Message.NotFound(resourceName, key), HttpStatusCode.NotFound) { }
    }
}
