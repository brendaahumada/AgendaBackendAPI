
using AgendaBackendAPI.Data;
using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaBack2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IContactRepository _contactRepository;
        private readonly AgendaApiContext _context;
        private readonly IMapper _mapper;

        public LocationController(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var locations = await _context.Location.ToListAsync();

                var LocationsDTO = _mapper.Map<IEnumerable<LocationDto>>(locations);

                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var location = _context.Location.SingleOrDefault(u => u.id == id);

                if (location == null)
                {
                    return NotFound(); // Devuelve un 404 Not Found si no se encuentra la ubicación con el ID proporcionado.
                }

                return Ok(location); // Devuelve un 200 OK con la ubicación si se encuentra.
            }
            catch (Exception ex)
            {
                // Loguea el error o maneja de otra manera según tus necesidades.
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpPost]

        public async Task<IActionResult> Post(CreateAndUpdateLocationDTO locationDTO)
        {
            try
            {
                var location = _mapper.Map<Location>(locationDTO);

                _context.Add(location);
                await _context.SaveChangesAsync();

                var locationItemDTO = _mapper.Map<LocationDto>(location);

                return Ok(locationItemDTO);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {

                    string innerExceptionMessage = ex.InnerException.Message;
                    string innerExceptionStackTrace = ex.InnerException.StackTrace;
                }


                return BadRequest(ex.Message);
            }
        }

    }
}
