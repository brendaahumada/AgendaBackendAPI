using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AgendaBackendAPI.Entities
{
    public class Contact
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int? id { get; set; }
            public string name { get; set; }
            public string lastName { get; set; }
            public string description { get; set; }
            public string? email { get; set; }
            public long celularNumber { get; set; }
            public long? telephoneNumber { get; set; }

            [ForeignKey("User")]
            public int UserId { get; set; }
            public User User { get; set; } // Propiedad de navegación hacia User

            public Location location { get; set; }
    }

 }

