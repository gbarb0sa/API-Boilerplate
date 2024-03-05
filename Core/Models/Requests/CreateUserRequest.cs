using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
