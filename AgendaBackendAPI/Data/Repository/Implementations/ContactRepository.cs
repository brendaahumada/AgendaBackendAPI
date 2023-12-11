using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;
using Microsoft.Data.Sqlite;
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
            return _context.Contacts
                .Include(c => c.location)
                .Single(c => c.id == id);
        }

        public List<Contact> GetAllByUser(int id)
        {
            return _context.Contacts
                .Where(c => c.UserId == id)
                .Include(c => c.location)
                .ToList();
        }

        public Contact Create(CreateAndUpdateContactDTO dto, int UserId)
        {
            // Mapea el DTO a la entidad Contact
            Contact contact = _mapper.Map<Contact>(dto);

            // Asigna el UserId
            contact.UserId = UserId;

            // Agrega el contacto al contexto y guarda los cambios en la base de datos
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            // Devuelve el contacto mapeado a DTO
            Contact contactDto = _mapper.Map<Contact>(contact);
            return contactDto;
        }



        public void Update(CreateAndUpdateContactDTO dto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var contactItem = _context.Contacts.Include(c => c.location).FirstOrDefault(x => x.id == dto.id);

                    if (contactItem != null)
                    {
                        // Verificar si el DTO tiene un ID válido
                        if (dto.id > 0)
                        {
                            // Modificar las propiedades de la entidad según el DTO
                            contactItem.name = dto.name;
                            contactItem.lastName = dto.lastName;
                            contactItem.description = dto.description;
                            contactItem.email = dto.email;
                            contactItem.celularNumber = dto.celularNumber;
                            contactItem.telephoneNumber = dto.telephoneNumber;
                            contactItem.UserId = dto.Userid;

                            // Actualizar propiedades de ubicación si están presentes en el DTO
                            if (dto.location != null)
                            {
                                // Mapear el objeto LocationDto a Location
                                contactItem.location = _mapper.Map<Location>(dto.location);
                            }

                            _context.ChangeTracker.DetectChanges();
                            _context.Entry(contactItem).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Manejar la excepción, por ejemplo, registrándola o lanzándola nuevamente
                }
            }
        }


        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.id == id));
            _context.SaveChanges();
        }
    }

}
