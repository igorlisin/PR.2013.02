using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список домов
    /// </summary>
    public class Homes : IHomes
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка домов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор домов
        /// </summary>
        private DbSet<Home> _homesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка домов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор домов
        /// </summary>
        public DbSet<Home> HomesDbSet
        {
            get
            {
                return (_homesDbSet);
            }
            set
            {
                _homesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Homes(DbSet<Home> homesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _homesDbSet = homesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый дом
        /// </summary>
        public IHome Create()
        {
            IHome home;

            home = (IHome)new Home();

            home.Number = Home.DefaultNumber;
            home.ComplexNumber = Home.DefaultComplexNumber; 

            return (home);
        }

        /// <summary>
        /// Метод. Добавляет дом в набор домов
        /// </summary>
        public void Add(IHome home)
        {
            _homesDbSet.Add((Home)home);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет дом из набора домов
        /// </summary>
        public void Remove(IHome home)
        {
            _homesDbSet.Remove((Home)home);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет дом с указанным идентификатором из списка домов
        /// </summary>
        public void RemoveById(int id)
        {
            IHome home;

            home = GetHome(id);

            if (home != null)
            {
                _homesDbSet.Remove((Home)home);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список домов
        /// </summary>
        public List<IHome> ToList()
        {
            return (_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToList<IHome>());
        }

        /// <summary>
        /// Метод. Возвращает массив сотрудников
        /// </summary>
        public IHome[] ToArray()
        {
            return (_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToArray<IHome>());
        }

        /// <summary>
        /// Метод. Возвращает дом с указанным идентификатором из списка домов
        /// </summary>
        public IHome GetHome(int id)
        {
            return ((IHome)_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework)/*.Include(h => h.ComplexForEntityFramework.CityForEntityFramework).Where(h=>h.Id == id)*/.First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_homesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка домов
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
            return (new EntityEnumerator(_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToArray<Home>()));
        }
    }
}
