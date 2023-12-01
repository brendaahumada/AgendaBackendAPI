using System.ComponentModel.DataAnnotations;

namespace AgendaBackendAPI.Models.Dtos
{
    public class CreateAndUpdateContactDTO
    {
        [Required]
        public string name { get; set; }
        public string? lastName { get; set; }
        [Required]
        public string? description { get; set; }
        public string? email { get; set; }
        public long? celularNumber { get; set; }
        public long? telephoneNumber { get; set; }
        public int? id { get; set; }

        //public User? user { get; set; }
        public int? Userid { get; set; }
        public LocationDto? location { get; set; }
    }
}
