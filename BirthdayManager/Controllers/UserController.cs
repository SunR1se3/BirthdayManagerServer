using Birthday.Contracts;
using Birthday.Domain.Entities;
using Birthday.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayManager.Controllers
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Введение зависимостей через конструктор
        /// </summary>
        /// <param name="userService">Сервис, обслуживающий контроллер</param>
        public UserController (IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получает список пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель пользователя</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Получает список ближайших ДР
        /// </summary>
        /// <returns>Список ближайших ДР</returns>
        [HttpGet("UpcomingBirthdays")]
        public async Task<IActionResult> GetUpcomingBirthdays()
        {
            var result = await _userService.GetUpcomingBirthdays();
            return Ok(result);
        }

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] UserApiDto model, IFormFile photo)
        {
            await _userService.AddAsync(model, photo);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновляет данные
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UserApiDto model, IFormFile photo)
        {
            var result = await _userService.UpdateAsync(model, photo);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }
    }
}
