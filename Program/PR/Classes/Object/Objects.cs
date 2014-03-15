using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список объектов оценки
    /// </summary>
    class Objects : IObjects
    {
        #region Delegated

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка 
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка 
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Набор объектов оценки
        /// </summary>
        private DbSet<Object> _objectsDbSet;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает набор объектов оценки
        /// </summary>
        public DbSet<Object> ObjectsDbSet
        {
            get
            {
                return (_objectsDbSet);
            }
            set
            {
                _objectsDbSet = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор объектов оценки
        /// </summary>
        public Objects(DbSet<Object> objectsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _objectsDbSet = objectsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую объект оценки
        /// </summary>
        public IObject Create()
        {
            IObject Object;

            Object = (IObject)new Object();

            return (Object);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Добавляет объект оценки в набор 
        /// </summary>
        public void Add(IObject Object)
        {
            _objectsDbSet.Add((Object)Object);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет объект оценки из набора 
        /// </summary>
        public void Remove(IObject Object)
        {
            _objectsDbSet.Remove((Object)Object);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет объект оценки с указанным идентификатором из списка 
        /// </summary>
        public void RemoveById(int id)
        {
            IObject Object;

            Object = GetObject(id);

            if (Object != null)
            {
                _objectsDbSet.Remove((Object)Object);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список 
        /// </summary>
        public List<IObject> ToList()
        {
            return (_objectsDbSet.ToList<IObject>());
        }

        /// <summary>
        /// Метод. Возвращает массив 
        /// </summary>
        public IObject[] ToArray()
        {
            return (_objectsDbSet.ToArray<IObject>());
        }

        /// <summary>
        /// Метод. Возвращает объект оценки с указанным идентификатором из списка 
        /// </summary>
        public IObject GetObject(int id)
        {
            return ((IObject)_objectsDbSet.Where(a => a.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_objectsDbSet.Count());
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_objectsDbSet.ToArray<Object>()));
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка 
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

  
        #endregion
    }
    }

