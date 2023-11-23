using System.ComponentModel.DataAnnotations;

namespace AgendaBackendAPI.Models.Dtos
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
