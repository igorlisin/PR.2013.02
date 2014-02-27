using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список комплексов
    /// </summary>
    public class Complexes : IComplexes
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка комплексов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор комплексов
        /// </summary>
        private DbSet<Complex> _complexesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка комплексов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор комплексов
        /// </summary>
        public DbSet<Complex> ComplexesDbSet
        {
            get
            {
                return (_complexesDbSet);
            }
            set
            {
                _complexesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Complexes(DbSet<Complex> complexesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _complexesDbSet = complexesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый комплекс
        /// </summary>
        public IComplex Create()
        {
            IComplex complex;

            complex = (IComplex)new Complex();

            complex.Number = Complex.DefaultNumber;

            return (complex);
        }

        /// <summary>
        /// Метод. Добавляет комплекс в набор комплексов
        /// </summary>
        public void Add(IComplex complex)
        {
            _complexesDbSet.Add((Complex)complex);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет комплекс из набора комплексов
        /// </summary>
        public void Remove(IComplex complex)
        {
            _complexesDbSet.Remove((Complex)complex);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет комплекс с указанным идентификатором из списка комплексов
        /// </summary>
        public void RemoveById(int id)
        {
            IComplex complex;

            complex = GetComplex(id);

            if (complex != null)
            {
                _complexesDbSet.Remove((Complex)complex);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список комплексов
        /// </summary>
        public List<IComplex> ToList()
        {
            return (_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToList<IComplex>());
        }

        /// <summary>
        /// Метод. Возвращает массив комплексов
        /// </summary>
        public IComplex[] ToArray()
        {
            return (_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<IComplex>());
        }

        /// <summary>
        /// Метод. Возвращает комплекс с указанным идентификатором из списка комплексов
        /// </summary>
        public IComplex GetComplex(int id)
        {
            return ((IComplex)_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Where(c => c.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_complexesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка комплексов
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
            return (new EntityEnumerator(_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<Complex>()));
        }
    }
}
