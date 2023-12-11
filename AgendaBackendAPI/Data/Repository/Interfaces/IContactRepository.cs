using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;

namespace AgendaBackendAPI.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllByUser(int id);
        Contact Create(CreateAndUpdateContactDTO dto, int UserId);
        public void Update(CreateAndUpdateContactDTO dto);

        public void Delete(int id);
        public Contact GetContactById(int id);
    }
}
