using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список квартир
    /// </summary>
    class Appartments : IApartments
    {
        #region Delegated

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка квартир
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка квартир
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Набор квартир
        /// </summary>
        private DbSet<Apartment> _appartmentsDbSet;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает набор городов
        /// </summary>
        public DbSet<Apartment> AppartmentsDbSet
        {
            get
            {
                return (_appartmentsDbSet);
            }
            set
            {
                _appartmentsDbSet = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public Appartments(DbSet<Apartment> appartmentsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _appartmentsDbSet = appartmentsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую квартиру
        /// </summary>
        public IApartment Create()
        {
            IApartment appartment;

            appartment = (IApartment)new Apartment();

            return (appartment);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Добавляет квартиру в набор квартир
        /// </summary>
        public void Add(IApartment appartment)
        {
            _appartmentsDbSet.Add((Apartment)appartment);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет квартиру из набора квартир
        /// </summary>
        public void Remove(IApartment appartment)
        {
            _appartmentsDbSet.Remove((Apartment)appartment);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет квартиру с указанным идентификатором из списка квартир
        /// </summary>
        public void RemoveById(int id)
        {
            IApartment appartment;

            appartment = GetAppartment(id);

            if (appartment != null)
            {
                _appartmentsDbSet.Remove((Apartment)appartment);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список квартир
        /// </summary>
        public List<IApartment> ToList()
        {
            return (_appartmentsDbSet.Include(a => a.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(a => a.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework).ToList<IApartment>());
        }

        /// <summary>
        /// Метод. Возвращает массив квартир
        /// </summary>
        public IApartment[] ToArray()
        {
            return (_appartmentsDbSet.Include(a => a.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(a => a.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework).ToArray<IApartment>());
        }

        /// <summary>
        /// Метод. Возвращает квартиру с указанным идентификатором из списка квартир
        /// </summary>
        public IApartment GetAppartment(int id)
        {
            return ((IApartment)_appartmentsDbSet.Include(a => a.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(a => a.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework).Where(a => a.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_appartmentsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка квартир
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
            return (new EntityEnumerator(_appartmentsDbSet.Include(a => a.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(a => a.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework).ToArray<Apartment>()));
        }

        #endregion
    }
}
