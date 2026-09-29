namespace Fintalks.Common.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public required string Nid { get; set; }
        public required string PhoneNumber { get; set; }
        public int DBUserID { get; set; }
        public User User { get; set; } = null!;
    }
}
