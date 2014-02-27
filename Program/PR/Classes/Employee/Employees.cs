using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

    /// <summary>
    /// Класс. Список сотрудников
    /// </summary>
    public class Employees : IEmployees
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка сотрудников
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор сотрудников
        /// </summary>
        private DbSet<Employee> _employeesDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка сотрудников
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор сотрудников
        /// </summary>
        public DbSet<Employee> EmployeesDbSet
        {
            get
            {
                return (_employeesDbSet);
            }
            set
            {
                _employeesDbSet = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Employees(DbSet<Employee> employeesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _employeesDbSet = employeesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает нового сотрудника
        /// </summary>
        public IEmployee Create()
        {
            IEmployee employee;

            employee = (IEmployee)new Employee();

            return (employee);
        }

        /// <summary>
        /// Метод. Добавляет сотрудника в набор сотрудников
        /// </summary>
        public void Add(IEmployee employee)
        {
            _employeesDbSet.Add((Employee)employee);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет сотрудника из набора сотрудников
        /// </summary>
        public void Remove(IEmployee employee)
        {
            _employeesDbSet.Remove((Employee)employee);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет сотрудника с указанным идентификатором из списка сотрудников
        /// </summary>
        public void RemoveById(int id)
        {
            IEmployee employee;

            employee = GetEmployee(id);

            if (employee != null)
            {
                _employeesDbSet.Remove((Employee)employee);
                SaveChanges();
            }
        }

        /// <summary>
        /// Метод. Возвращает список сотрудников
        /// </summary>
        public List<IEmployee> ToList()
        {
            return (_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToList<IEmployee>());
        }

        /// <summary>
        /// Метод. Возвращает массив сотрудников
        /// </summary>
        public IEmployee[] ToArray()
        {
            return (_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToArray<IEmployee>());
        }

        /// <summary>
        /// Метод. Возвращает сотрудника с указанным идентификатором из списка сотрудников
        /// </summary>
        public IEmployee GetEmployee(int id)
        {
            return ((IEmployee)_employeesDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_employeesDbSet.Count());
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
            return (new EntityEnumerator(_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToArray<Employee>()));
        }
    }
}
