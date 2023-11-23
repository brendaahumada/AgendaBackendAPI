using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;

namespace AgendaBackendAPI.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllByUser(int id);
        public Contact Create(CreateAndUpdateContactDTO dto, int id);
        //public Contact Update(CreateAndUpdateContactDTO dto);
        public Contact Update(CreateAndUpdateContactDTO dto);
        public void Delete(int id);
        public Contact GetContactById(int id);
    }
}
