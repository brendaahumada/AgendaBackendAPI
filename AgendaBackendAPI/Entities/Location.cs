namespace AgendaBackendAPI.Entities
{
    public class Location
    {
        public int? id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string description { get; set; }
    }
}
