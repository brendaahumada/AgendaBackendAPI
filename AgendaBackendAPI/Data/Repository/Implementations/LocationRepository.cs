using AgendaBackendAPI.Data;
using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;

namespace AgendaBackendAPI.Data.Repository.Implementations
{
    public class LocationRepository : ILocationRepository
      {
        private AgendaApiContext _context;
        private readonly IMapper _mapper;


        public LocationRepository (AgendaApiContext context)
        {
            _context = context;
        }
        public List<Location> GetAll()
        {
            return _context.Location.ToList();
        }


        public Location GetById(int locationId)
        {
            return _context.Location.SingleOrDefault(u => u.id == locationId);
        }
       public void Create(CreateAndUpdateLocationDTO dto)
        {
            _context.Location.Add(_mapper.Map<Location>(dto));
        }

        public void Delete(int id)
        {
            _context.Location.Remove(_context.Location
                .Single(c => c.id == id));
        }


        public void Update(CreateAndUpdateLocationDTO dto)
        {
            _context.Location.Update(_mapper.Map<Location>(dto));
        }
    }
}
