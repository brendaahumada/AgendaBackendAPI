namespace AgendaBackendAPI.Models.Dtos
{
    public class CreateAndUpdateLocationDTO
    {
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string? description { get; set; }
    }
}
