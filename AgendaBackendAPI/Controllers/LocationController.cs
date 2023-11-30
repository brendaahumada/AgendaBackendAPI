
using AgendaBackendAPI.Data;
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
