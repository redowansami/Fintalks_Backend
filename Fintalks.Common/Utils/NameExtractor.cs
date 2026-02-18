namespace Fintalks.Common.Utils
{
    public static class NameExtractor
    {
        public static string FirstName(string name)
        {
            return name.Split(' ')[0];
        }

        public static string LastName(string name)
        {
            if (name.Split(" ").Length > 0)
                return name.Split(" ")[1];
            else
                return "";
        }
    }
}
