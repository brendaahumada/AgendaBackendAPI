using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;

namespace AgendaBackendAPI.Data.Repository.Interfaces
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        void Create(CreateAndUpdateLocationDTO dto);
        void Update(CreateAndUpdateLocationDTO dto);
        void Delete(int id);
    }
}
