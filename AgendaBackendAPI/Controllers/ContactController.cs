
using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;


namespace AgendaBack2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;


        public ContactController(IContactRepository contactRepository, IUserRepository userRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
            //_mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetAllByUser(userId));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            // si se quisiese mayor seguridad, se podria comprobar que el usuario que hace la peticion es el mismo que el que tiene el contacto
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_contactRepository.GetContactById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAndUpdateContactDTO dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            Contact c = _contactRepository.Create(dto, userId);
            return Created("Created", c);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateAndUpdateContactDTO dto) //modificar el update como el post (interface y repo tmb)
        {
            // si se quisiese mayor seguridad, se podria comprobar que el usuario que hace la peticion es el mismo que el que tiene el contacto
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _contactRepository.Update(dto);
            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _contactRepository.Delete(id);
            return Ok();


        }

    }
}