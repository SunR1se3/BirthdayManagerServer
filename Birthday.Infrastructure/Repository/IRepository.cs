using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday.Infrastructure.Repository
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Возвращает все записи
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Возвращает по id
        /// </summary>
        /// <param name="id">Уникальный номер</param>
        /// <returns></returns>
        ValueTask<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(TEntity model);

        /// <summary>
        /// Обновляет запись
        /// </summary>
        /// <param name="model">Модель записи</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity model);

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id">Уникальный номер</param>
        /// <returns></returns>
        Task RemoveAsync(TEntity model);

        /// <summary>
        /// Сохраняет результат
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
