using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список городов
    /// </summary>
    public class Cities : ICities
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка городов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор городов
        /// </summary>
        private DbSet<City> _citiesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка городов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор городов
        /// </summary>
        public DbSet<City> CitiesDbSet
        {
            get
            {
                return (_citiesDbSet);
            }
            set
            {
                _citiesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Cities(DbSet<City> citiesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _citiesDbSet = citiesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый город
        /// </summary>
        public ICity Create()
        {
            ICity city;

            city = (ICity)new City();

            city.Name = City.DefaultName;

            return (city);
        }

        /// <summary>
        /// Метод. Добавляет город в набор городов
        /// </summary>
        public void Add(ICity city)
        {
            _citiesDbSet.Add((City)city);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет город из набора городов
        /// </summary>
        public void Remove(ICity city)
        {
            _citiesDbSet.Remove((City)city);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет город с указанным идентификатором из списка городов
        /// </summary>
        public void RemoveById(int id)
        {
            ICity city;

            city = GetCity(id);

            if (city != null)
            {
                _citiesDbSet.Remove((City)city);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список городов
        /// </summary>
        public List<ICity> ToList()
        {
            return (_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToList<ICity>());
        }

        /// <summary>
        /// Метод. Возвращает массив городов
        /// </summary>
        public ICity[] ToArray()
        {
            return (_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToArray<ICity>());
        }

        /// <summary>
        /// Метод. Возвращает город с указанным идентификатором из списка городов
        /// </summary>
        public ICity GetCity(int id)
        {
            return ((ICity)_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).Where(c => c.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_citiesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка городов
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
            return (new EntityEnumerator(_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToArray<City>()));
        }
    }
}
