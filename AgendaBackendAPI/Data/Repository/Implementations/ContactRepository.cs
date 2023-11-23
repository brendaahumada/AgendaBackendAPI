using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgendaBackendAPI.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private AgendaApiContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Contact GetContactById(int id)
        {
            return _context.Contactos
            .Include(c => c.location)
            .Single(c => c.id == id);

        }
        public List<Contact> GetAllByUser(int id)
        {
            return _context.Contactos.Where(c => c.UserId == id)
            .Include(c => c.location)
            .ToList();
        }

        public Contact Create(CreateAndUpdateContactDTO dto, int id)
        {
            Contact contact = _mapper.Map<Contact>(dto);
            contact.UserId = id;
            _context.Contactos.Add(contact);
            _context.SaveChanges();

            return contact;

        }

        public Contact Update(CreateAndUpdateContactDTO dto)
        {
            //contact = _context.Contacts.Single(c => c.id == dto.id);
            Contact contact = _mapper.Map<Contact>(dto);
            _context.Contactos.Update(contact);

            _context.SaveChanges();

            return contact;
        }

        public void Delete(int id)
        {
            _context.Contactos.Remove(_context.Contactos.Single(c => c.id == id));
            _context.SaveChanges();
        }
    }
}
