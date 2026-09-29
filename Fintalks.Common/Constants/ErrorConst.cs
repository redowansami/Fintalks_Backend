using System.Globalization;

namespace Fintalks.Common.Constants
{
    public static class ErrorConst
    {
        public static class Message
        {
            public const string validationError = "One or more validation errors occurred.";
            public const string genericError = "An unexpected error occurred";
            public const string emailExists = "Email exists";
            public const string userNameExists = "UserName exists";

            public static string NotFound(string resourceName, object key)
            {
                return $"{resourceName} with identifier '{key}' was not found.";
            }
        }
    }
}
