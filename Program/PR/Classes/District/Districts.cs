using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    class Districts:IDistricts
    {
               /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка сотрудников
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор 
        /// </summary>
        private DbSet<District> _districtsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка сотрудников
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор сотрудников
        /// </summary>
        public DbSet<District> DistrictsDbSet
        {
            get
            {
                return (_districtsDbSet);
            }
            set
            {
                _districtsDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Districts(DbSet<District> districtsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _districtsDbSet = districtsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает нового 
        /// </summary>
        public IDistrict Create()
        {
            IDistrict district;

            district = (IDistrict)new District();

            return (district);
        }

        /// <summary>
        /// Метод. Добавляет  в набор 
        /// </summary>
        public void Add(IDistrict district)
        {
            _districtsDbSet.Add((District)district);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет  из набора 
        /// </summary>
        public void Remove(IDistrict district)
        {
            _districtsDbSet.Remove((District)district);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет сотрудника с указанным идентификатором из списка сотрудников
        /// </summary>
        public void RemoveById(int id)
        {
            IDistrict district;

            district = GetDistrict(id);

            if (district != null)
            {
                _districtsDbSet.Remove((District)district);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список 
        /// </summary>
        public List<IDistrict> ToList()
        {
            return (_districtsDbSet.ToList<IDistrict>());
        }

        /// <summary>
        /// Метод. Возвращает массив сотрудников
        /// </summary>
        public IDistrict[] ToArray()
        {
            return (_districtsDbSet.ToArray<IDistrict>());
        }

        /// <summary>
        /// Метод. Возвращает  с указанным идентификатором из списка 
        /// </summary>
        public IDistrict GetDistrict(int id)
        {
            return ((IDistrict)_districtsDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_districtsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка сотрудников
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
            return (new EntityEnumerator(_districtsDbSet.ToArray<District>()));
        }
    }
}
