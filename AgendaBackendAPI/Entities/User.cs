using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaBackendAPI.Entities
{
    public class User
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id unico, se autogenera
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public Rol Rol { get; set; } = Rol.User;
    }
}.
