using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage="password should be between 4 and 8")]
        public string Password { get; set; }
    }
}