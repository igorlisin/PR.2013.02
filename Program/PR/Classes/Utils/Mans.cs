using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список людей
    /// </summary>
    public class Mans : IMans
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка людей
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор людей
        /// </summary>
        private DbSet<Man> _mansDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка людей
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор людей
        /// </summary>
        public DbSet<Man> MansDbSet
        {
            get
            {
                return (_mansDbSet);
            }
            set
            {
                _mansDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Mans(DbSet<Man> mansDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _mansDbSet = mansDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает нового человека
        /// </summary>
        public IMan Create()
        {
            IMan man;

            man = (IMan)new Man();

            man.Name = Man.DefaultName;
            man.Surname = Man.DefaultSurname;
            man.Patronymic = Man.DefaultPatronymic;

            return (man);
        }

        /// <summary>
        /// Метод. Добавляет человека в набор людей
        /// </summary>
        public void Add(IMan man)
        {
            _mansDbSet.Add((Man)man);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет человека из набора людей
        /// </summary>
        public void Remove(IMan man)
        {
            _mansDbSet.Remove((Man)man);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет человека с указанным идентификатором из списка людей
        /// </summary>
        public void RemoveById(int id)
        {
            IMan man;

            man = GetMan(id);

            if (man != null)
            {
                _mansDbSet.Remove((Man)man);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список людей
        /// </summary>
        public List<IMan> ToList()
        {
            return (_mansDbSet.Include(m => m.DocumentForEntityFramework).ToList<IMan>());
        }

        /// <summary>
        /// Метод. Возвращает массив людей
        /// </summary>
        public IMan[] ToArray()
        {
            return (_mansDbSet.Include(m => m.DocumentForEntityFramework).ToArray<IMan>());
        }

        /// <summary>
        /// Метод. Возвращает человека с указанным идентификатором из списка документов
        /// </summary>
        public IMan GetMan(int id)
        {
            return ((IMan)_mansDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_mansDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public System.Collections.IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_mansDbSet.Include(m => m.DocumentForEntityFramework).ToArray<Entity>()));
        }
    }
}
