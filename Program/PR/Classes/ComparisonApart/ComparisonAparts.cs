using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    class ComparisonAparts:IComparisonAparts
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
        private DbSet<ComparisonApart> _comparisonApartsDbSet;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает набор кварир сравнения
        /// </summary>
        public DbSet<ComparisonApart> ComparisonApartsDbSet
        {
            get
            {
                return (_comparisonApartsDbSet);
            }
            set
            {
                _comparisonApartsDbSet = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ComparisonAparts(DbSet<ComparisonApart> appartmentsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _comparisonApartsDbSet = appartmentsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую квартиру
        /// </summary>
        public IComparisonApart Create()
        {
            IComparisonApart appartment;

            appartment = (IComparisonApart)new ComparisonApart();

            return (appartment);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Добавляет квартиру в набор квартир
        /// </summary>
        public void Add(IComparisonApart appartment)
        {
            _comparisonApartsDbSet.Add((ComparisonApart)appartment);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет квартиру из набора квартир
        /// </summary>
        public void Remove(IComparisonApart appartment)
        {
            _comparisonApartsDbSet.Remove((ComparisonApart)appartment);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет квартиру с указанным идентификатором из списка квартир
        /// </summary>
        public void RemoveById(int id)
        {
            IComparisonApart appartment;
            
            appartment = GetComparisonApart(id);
            
            if (appartment != null)
            {
                _comparisonApartsDbSet.Remove((ComparisonApart)appartment);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список квартир
        /// </summary>
        public List<IComparisonApart> ToList()
        {
            return (_comparisonApartsDbSet.ToList<IComparisonApart>());
        }

        /// <summary>
        /// Метод. Возвращает массив квартир
        /// </summary>
        public IComparisonApart[] ToArray()
        {
            return (_comparisonApartsDbSet.ToArray<IComparisonApart>());
        }

        /// <summary>
        /// Метод. Возвращает квартиру с указанным идентификатором из списка квартир
        /// </summary>
        public IComparisonApart GetComparisonApart(int id)
        {
            return ((IComparisonApart)_comparisonApartsDbSet.First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_comparisonApartsDbSet.Count());
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
            return (new EntityEnumerator(_comparisonApartsDbSet.ToArray<ComparisonApart>()));
        }

        #endregion
    }
}
