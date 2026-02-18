namespace Fintalks.Common.Constants
{
    public static class UserConst
    {
        public static class Message
        {
            public const string invalidEmail = "Invalid email format.";
        }

        public static class Length
        {
            public const int minUserName = 3;
            public const int maxUserName = 10;
            public const int minName = 3;
            public const int maxName = 30;
            public const int maxFirstName = 15;
            public const int maxLastName = 15;
            public const int maxEmail = 255;
            public const int maxBio = 500;
        }
    }
}
