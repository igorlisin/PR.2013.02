using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список стран
    /// </summary>
    public class Countries : ICountries
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка стран
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор стран
        /// </summary>
        private DbSet<Country> _countriesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка стран
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор стран
        /// </summary>
        public DbSet<Country> CountriesDbSet
        {
            get
            {
                return (_countriesDbSet);
            }
            set
            {
                _countriesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Countries(DbSet<Country> countriesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _countriesDbSet = countriesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую страну
        /// </summary>
        public ICountry Create()
        {
            ICountry country;

            country = (ICountry)new Country();

            country.Name = Country.DefaultName;

            return (country);
        }

        /// <summary>
        /// Метод. Добавляет страну в набор стран
        /// </summary>
        public void Add(ICountry country)
        {
            _countriesDbSet.Add((Country)country);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет страну из набора стран
        /// </summary>
        public void Remove(ICountry country)
        {
            _countriesDbSet.Remove((Country)country);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет страну с указанным идентификатором из списка стран
        /// </summary>
        public void RemoveById(int id)
        {
            ICountry country;

            country = GetCountry(id);

            if (country != null)
            {
                _countriesDbSet.Remove((Country)country);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список стран
        /// </summary>
        public List<ICountry> ToList()
        {
            return (_countriesDbSet.ToList<ICountry>());
        }

        /// <summary>
        /// Метод. Возвращает массив стран
        /// </summary>
        public ICountry[] ToArray()
        {
            return (_countriesDbSet.ToArray<ICountry>());
        }

        /// <summary>
        /// Метод. Возвращает страну с указанным идентификатором из списка стран
        /// </summary>
        public ICountry GetCountry(int id)
        {
            return ((ICountry)_countriesDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_countriesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка стран
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
            return (new EntityEnumerator(_countriesDbSet.ToArray<Country>()));
        }
    }
}
