using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AgendaBackendAPI.Entities
{
    public class Contact
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string CelularNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Alias { get; set; }

        public string? Email { get; set; }
        [JsonIgnore]
        public User User { get; set; } //Usuario al que pertenece
        public int UserId { get; set; }

        public State state { get; set; } = State.Active;
        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
    }
}
