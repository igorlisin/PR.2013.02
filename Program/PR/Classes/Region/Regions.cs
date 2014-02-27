using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список регионов
    /// </summary>
    public class Regions : IRegions
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка регионов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор регионов
        /// </summary>
        private DbSet<Region> _regionsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка регионов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор регионов
        /// </summary>
        public DbSet<Region> RegionDbSet
        {
            get
            {
                return (_regionsDbSet);
            }
            set
            {
                _regionsDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Regions(DbSet<Region> regionsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _regionsDbSet = regionsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый регион
        /// </summary>
        public IRegion Create()
        {
            IRegion region;

            region = (IRegion)new Region();

            region.Name = Region.DefaultName;

            return (region);
        }

        /// <summary>
        /// Метод. Добавляет регион в набор регионов
        /// </summary>
        public void Add(IRegion region)
        {
            _regionsDbSet.Add((Region)region);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет регион из набора регионов
        /// </summary>
        public void Remove(IRegion region)
        {
            _regionsDbSet.Remove((Region)region);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет регион с указанным идентификатором из списка регионов
        /// </summary>
        public void RemoveById(int id)
        {
            IRegion region;

            region = GetRegion(id);

            if (region != null)
            {
                _regionsDbSet.Remove((Region)region);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список регионов
        /// </summary>
        public List<IRegion> ToList()
        {
            return (_regionsDbSet.Include(r => r.CountryForEntityFramework).ToList<IRegion>());
        }

        /// <summary>
        /// Метод. Возвращает массив регионов
        /// </summary>
        public IRegion[] ToArray()
        {
            return (_regionsDbSet.Include(r => r.CountryForEntityFramework).ToArray<IRegion>());
        }

        /// <summary>
        /// Метод. Возвращает регион с указанным идентификатором из списка регионов
        /// </summary>
        public IRegion GetRegion(int id)
        {
           return ((IRegion)(_regionsDbSet.Include(r => r.CountryForEntityFramework).Where(r => r.Id == id).First()));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_regionsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка регионов
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
            return (new EntityEnumerator(_regionsDbSet.Include(r => r.CountryForEntityFramework).ToArray<Region>()));
        }
    }
}
