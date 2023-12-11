namespace AgendaBackendAPI.Models.Dtos
{
    public class ContactDTO
    {
        public string name { get; set; }
        public string? lastName { get; set; }
        public string? description { get; set; }
        public string? email { get; set; }
        public long celularNumber { get; set; }
        public long? telephoneNumber { get; set; }

        public LocationDto location { get; set; }
    }
}
