﻿
using AgendaBackendAPI.Data;
using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AgendaBackendAPI.Models.Enum;
using AutoMapper;

namespace AgendaBack2023.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private AgendaApiContext _context;

        public UserRepository(AgendaApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.id == userId);
        }


        public void Create(CreateAndUpdateUserDTO userDTO)
        {
            _context.Users.Add(_mapper.Map<User>(userDTO));
            _context.SaveChanges();
        }


        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(u => u.email == authRequestBody.email && u.password == authRequestBody.password);
        }


        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.id == id));
            _context.SaveChanges();
        }

        public User Update(CreateAndUpdateUserDTO userDTO)
        {
            //_context.Users.Update(_mapper.Map<User>(userDTO));
            User user = _mapper.Map<User>(userDTO);
            _context.Users.Update(user);

            _context.SaveChanges();
            return user;
        }

        public void Archive(int Id)
        {
            User user = _context.Users.FirstOrDefault(u => u.id == Id);
            if (user != null)
            {
                user.state = State.Archived;
                _context.Update(user);
                _context.SaveChanges();
            }

        }
    }
}

