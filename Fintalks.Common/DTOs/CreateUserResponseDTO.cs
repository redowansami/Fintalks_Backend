namespace Fintalks.Common.DTOs
{
    public class CreateUserResponseDTO
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public required string Email { get; set; }
    }
}
