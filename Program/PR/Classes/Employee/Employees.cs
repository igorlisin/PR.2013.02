using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{

    /// <summary>
    /// �����. ������ �����������
    /// </summary>
    public class Employees : IEmployees
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� �����������
        /// </summary>
        private DbSet<Employee> _employeesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� �����������
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
        /// �����������
        /// </summary>
        public Employees(DbSet<Employee> employeesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _employeesDbSet = employeesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ������ ����������
        /// </summary>
        public IEmployee Create()
        {
            IEmployee employee;

            employee = (IEmployee)new Employee();

            return (employee);
        }

        /// <summary>
        /// �����. ��������� ���������� � ����� �����������
        /// </summary>
        public void Add(IEmployee employee)
        {
            _employeesDbSet.Add((Employee)employee);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ���������� �� ������ �����������
        /// </summary>
        public void Remove(IEmployee employee)
        {
            _employeesDbSet.Remove((Employee)employee);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ���������� � ��������� ��������������� �� ������ �����������
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
        /// �����. ���������� ������ �����������
        /// </summary>
        public List<IEmployee> ToList()
        {
            return (_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToList<IEmployee>());
        }

        /// <summary>
        /// �����. ���������� ������ �����������
        /// </summary>
        public IEmployee[] ToArray()
        {
            return (_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToArray<IEmployee>());
        }

        /// <summary>
        /// �����. ���������� ���������� � ��������� ��������������� �� ������ �����������
        /// </summary>
        public IEmployee GetEmployee(int id)
        {
            return ((IEmployee)_employeesDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_employeesDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ �����������
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// �����. ���������� �������������
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_employeesDbSet.Include(e => e.ManForEntityFramework.DocumentForEntityFramework).ToArray<Employee>()));
        }
    }
}
