﻿using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var usersDTO = _mapper.Map<IEnumerable<UserDto>>(User);
                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            User user = _userRepository.GetById(id);
            var userDTO = _mapper.Map<UserDto>(user);
            try
            {
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateAndUpdateUserDTO userDTO)
        {
            try
            {

                _userRepository.Create(userDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", userDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(CreateAndUpdateUserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                _userRepository.Update(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}

       // [HttpDelete]
       // [Route("{Id}")]
//        public IActionResult DeleteUsersById(int Id)
//        {
//            try
//            {
//                var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
//                if (role.Value == "Admin")
//                {
//                    _userRepository.DeleteUsers(Id);
//                }
//                else
//                {
//                    _userRepository.ArchiveUsers(Id);
//                }
//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//}

