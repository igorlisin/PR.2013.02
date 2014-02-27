using System;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// Интерфейс. Сущность
    /// </summary>
    public interface IEntity : ICloneable
    {
        /// <summary>
        /// Свойство. Задает и возвращает идентификатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает описание
        /// </summary>
        string Description { get; set; }
    }
}
