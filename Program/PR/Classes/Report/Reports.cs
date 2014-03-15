using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список отчетов
    /// </summary>
    public class Reports : IReports
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка отчетов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор отчетов
        /// </summary>
        private DbSet<Report> _reportsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка отчетов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор отчетов
        /// </summary>
        public DbSet<Report> CitiesDbSet
        {
            get
            {
                return (_reportsDbSet);
            }
            set
            {
                _reportsDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Reports(DbSet<Report> reportsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _reportsDbSet = reportsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый отчет
        /// </summary>
        public IReport Create()
        {
            IReport report;

            report = (IReport)new Report();

            report.DateOfContract = DateTime.Now.Date;
            report.EvaluationDate = DateTime.Now.Date;
            report.ReportDate = DateTime.Now.Date;

            return (report);
        }

        /// <summary>
        /// Метод. Добавляет отчет в набор отчетов
        /// </summary>
        public void Add(IReport report)
        {
            _reportsDbSet.Add((Report)report);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет отчет из набора отчетов
        /// </summary>
        public void Remove(IReport report)
        {
            _reportsDbSet.Remove((Report)report);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет отчет с указанным идентификатором из списка отчетов
        /// </summary>
        public void RemoveById(int id)
        {
            IReport report;

            report = GetReport(id);

            if (report != null)
            {
                _reportsDbSet.Remove((Report)report);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список отчетов
        /// </summary>
        public List<IReport> ToList()
        {
            return (_reportsDbSet.Include(r => r.ClientForEntityFramwork.ManForEntityFramework)
                                 .Include(r => r.EmployeeForEntityFramework.ManForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.ObjectForEntityFramework)
                                 .ToList<IReport>());
        }

        /// <summary>
        /// Метод. Возвращает массив отчетов
        /// </summary>
        public IReport[] ToArray()
        {
            return (_reportsDbSet.Include(r => r.ClientForEntityFramwork.ManForEntityFramework)
                                 .Include(r => r.EmployeeForEntityFramework.ManForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework)
                                 .Include(r => r.ApartmentForEntityFramework.ObjectForEntityFramework)
                                 .ToArray<IReport>());
        }

        /// <summary>
        /// Метод. Возвращает отчет с указанным идентификатором из списка отчетов
        /// </summary>
        public IReport GetReport(int id)
        {
            return ((IReport)_reportsDbSet.Include(r => r.ClientForEntityFramwork.ManForEntityFramework)
                            .Include(r => r.EmployeeForEntityFramework.ManForEntityFramework)
                            .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework)
                            .Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework)
                            .Include(r=>r.ApartmentForEntityFramework.ObjectForEntityFramework)
                            .Where(r => r.Id == id).First());
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_reportsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка отчетов
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
            return (new EntityEnumerator(_reportsDbSet.Include(r => r.ClientForEntityFramwork.ManForEntityFramework).Include(r => r.EmployeeForEntityFramework.ManForEntityFramework).Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework.CityForEntityFramework).Include(r => r.ApartmentForEntityFramework.HomeForEntityFramework.ComplexForEntityFramework.CityForEntityFramework).ToArray<Report>()));
        }
    }
}
