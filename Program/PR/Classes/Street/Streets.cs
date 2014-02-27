using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список улиц
    /// </summary>
    public class Streets : IStreets
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка улиц
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор улиц
        /// </summary>
        private DbSet<Street> _streetsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка улиц
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор улиц
        /// </summary>
        public DbSet<Street> StreetsDbSet
        {
            get
            {
                return (_streetsDbSet);
            }
            set
            {
                _streetsDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Streets(DbSet<Street> streetsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _streetsDbSet = streetsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую улицу
        /// </summary>
        public IStreet Create()
        {
            IStreet street;

            street = (IStreet)new Street();

            street.Name = Street.DefaultName;

            return (street);
        }

        /// <summary>
        /// Метод. Добавляет улицу в набор улиц
        /// </summary>
        public void Add(IStreet street)
        {
            _streetsDbSet.Add((Street)street);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет улицу из набора улиц
        /// </summary>
        public void Remove(IStreet street)
        {
            _streetsDbSet.Remove((Street)street);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет улицу с указанным идентификатором из списка улиц
        /// </summary>
        public void RemoveById(int id)
        {
            IStreet street;

            street = GetStreet(id);

            if (street != null)
            {
                _streetsDbSet.Remove((Street)street);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список улиц
        /// </summary>
        public List<IStreet> ToList()
        {
            return (_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToList<IStreet>());
        }

        /// <summary>
        /// Метод. Возвращает массив улиц
        /// </summary>
        public IStreet[] ToArray()
        {
            return (_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<IStreet>());
        }

        /// <summary>
        /// Метод. Возвращает улицу с указанным идентификатором из списка улиц
        /// </summary>
        public IStreet GetStreet(int id)
        {
            return ((IStreet)_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Where(s=>s.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_streetsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка улиц
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<Street>()));
        }
    }
}
