using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Сущность
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        /// Поле. Идентификатор
        /// </summary>
        private int _id;

        /// <summary>
        /// Поле. Описание
        /// </summary>
        private string _description;

        /// <summary>
        /// Свойство. Задает и возвращает идентификатор
        /// </summary>
        public int Id
        {
            get
            {
                return (_id);
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает описание
        /// </summary>
        public string Description 
        {
            get
            {
                return (_description);
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Метод. Возвращает глубокую копию сущности
        /// </summary>
        public virtual object Clone()
        {
            IEntity entity;

            entity = new Entity();

            entity.Id  = Id;
            entity.Description = Description;

            return((object)entity);
        }
    }
}
