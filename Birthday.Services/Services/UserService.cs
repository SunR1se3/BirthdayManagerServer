using AutoMapper;
using Birthday.Contracts;
using Birthday.Domain.Entities;
using Birthday.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Birthday.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService (IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }   

        public Task AddAsync(UserApiDto model, IFormFile photo)
        {
            using var fileStream = photo.OpenReadStream();
            byte[] bytes = new byte[photo.Length];
            fileStream.Read(bytes, 0, (int)photo.Length);
            //string byteArrayPhoto = Convert.ToBase64String(bytes);
            //var user = _mapper.Map<User>(model);
            var user = new User();
            user.Fio = model.Fio;
            user.BirthdayDate = model.BirthdayDate;
            user.Photo = bytes;
            return _userRepository.AddAsync(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var result = await _userRepository.GetAll().ToListAsync();
            return result.Count > 0 ? _mapper.Map<List<UserDto>>(result) : new List<UserDto>();
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception($"Не найден пользователь с id: {id}");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetUpcomingBirthdays()
        {
            var upcomingBirthdays = await _userRepository.GetAll().Where(d => DateTime.Now.Month == d.BirthdayDate.Month
            && d.BirthdayDate.Day - DateTime.Now.Day < 10
            && d.BirthdayDate.Day - DateTime.Now.Day >= 0).ToListAsync();

            return upcomingBirthdays.Count > 0 ? _mapper.Map<List<UserDto>>(upcomingBirthdays) : new List<UserDto>();
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"Не найден пользователь с id: {id}");
            }
            await _userRepository.RemoveAsync(user);
        }

        public async Task<UserDto> UpdateAsync(UserApiDto model, IFormFile photo)
        {
            using var fileStream = photo.OpenReadStream();
            byte[] bytes = new byte[photo.Length];
            fileStream.Read(bytes, 0, (int)photo.Length);
            var user = new User();
            user.Id = model.Id;
            user.Fio = model.Fio;
            user.BirthdayDate = model.BirthdayDate;
            user.Photo = bytes;

            //var user = _mapper.Map<User>(model);
            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}
