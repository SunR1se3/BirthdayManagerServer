using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday.Contracts
{
    /// <summary>
    /// Модель представления пользователя
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthdayDate { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public byte[] Photo { get; set; }
    }
}
