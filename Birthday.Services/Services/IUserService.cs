using Birthday.Contracts;
using Birthday.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday.Services.Services
{
    /// <summary>
    /// Сервис для работы с пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получает список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        Task<List<UserDto>> GetAll();

        /// <summary>
        /// Получает пользователя по id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель пользователя</returns>
        Task<UserDto> GetById(Guid id);

        /// <summary>
        /// Получает список ближайших ДР
        /// </summary>
        /// <returns>Список ближайших ДР</returns>
        Task<List<UserDto>> GetUpcomingBirthdays();

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(UserApiDto model, IFormFile photo);

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Успех/неудача удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns>Обновленную модель пользователя</returns>
        Task<UserDto> UpdateAsync(UserApiDto model, IFormFile photo);
    }
}
