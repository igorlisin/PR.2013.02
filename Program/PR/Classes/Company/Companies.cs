using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список компаний
    /// </summary>
    public class Companies : ICompanies
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка компаний
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор компаний
        /// </summary>
        private DbSet<Company> _companiesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка компаний
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор компаний
        /// </summary>
        public DbSet<Company> CompaniesDbSet
        {
            get
            {
                return (_companiesDbSet);
            }
            set
            {
                _companiesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Companies(DbSet<Company> companiesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _companiesDbSet = companiesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новую компанию
        /// </summary>
        public ICompany Create()
        {
            ICompany company;

            company = (ICompany)new Company();

            return (company);
        }

        /// <summary>
        /// Метод. Добавляет компанию в набор компаний
        /// </summary>
        public void Add(ICompany company)
        {
            _companiesDbSet.Add((Company)company);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет компанию из набора компаний
        /// </summary>
        public void Remove(ICompany company)
        {
            _companiesDbSet.Remove((Company)company);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет компанию с указанным идентификатором из списка компаний
        /// </summary>
        public void RemoveById(int id)
        {
            ICompany company;

            company = GetCompany(id);

            if (company != null)
            {
                _companiesDbSet.Remove((Company)company);
                SaveChanges();
            }
        }

        /// <summary>
        /// Свойство. Возвращает список компаний
        /// </summary>
        public List<ICompany> ToList()
        {
            return (_companiesDbSet.ToList<ICompany>());
        }

        /// <summary>
        /// Метод. Возвращает массив компаний
        /// </summary>
        public ICompany[] ToArray()
        {
            return (_companiesDbSet.ToArray<ICompany>());
        }

        /// <summary>
        /// Метод. Возвращает компанию с указанным идентификатором из списка компаний
        /// </summary>
        public ICompany GetCompany(int id)
        {
            return ((ICompany)_companiesDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_companiesDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка компаний
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
            return (new EntityEnumerator((Company[])ToArray()));
        }
    }
}
