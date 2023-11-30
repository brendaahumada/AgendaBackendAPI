using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;

namespace AgendaBackendAPI.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
        public User? GetById(int UserId);
        public List<User> GetAll();

        public void Create(CreateAndUpdateUserDTO userDTO);
        public User Update(CreateAndUpdateUserDTO userDTO);
        public void Delete(int Id);
        public void Archive(int Id);

    }
}
