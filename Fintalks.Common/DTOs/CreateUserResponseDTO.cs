using System.ComponentModel.DataAnnotations.Schema;
using Fintalks.Common.Enums;

namespace Fintalks.Common.DTOs
{
    public class CreateUserResponseDTO
    {
        public Guid UserID { get; set; }
        public required string Email { get; set; }
    }
}
