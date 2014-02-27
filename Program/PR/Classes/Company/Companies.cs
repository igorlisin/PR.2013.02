using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ ��������
    /// </summary>
    public class Companies : ICompanies
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ��������
        /// </summary>
        private DbSet<Company> _companiesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ��������
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
        /// �����������
        /// </summary>
        public Companies(DbSet<Company> companiesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _companiesDbSet = companiesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        public ICompany Create()
        {
            ICompany company;

            company = (ICompany)new Company();

            return (company);
        }

        /// <summary>
        /// �����. ��������� �������� � ����� ��������
        /// </summary>
        public void Add(ICompany company)
        {
            _companiesDbSet.Add((Company)company);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� �� ������ ��������
        /// </summary>
        public void Remove(ICompany company)
        {
            _companiesDbSet.Remove((Company)company);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ��������
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
        /// ��������. ���������� ������ ��������
        /// </summary>
        public List<ICompany> ToList()
        {
            return (_companiesDbSet.ToList<ICompany>());
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public ICompany[] ToArray()
        {
            return (_companiesDbSet.ToArray<ICompany>());
        }

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        public ICompany GetCompany(int id)
        {
            return ((ICompany)_companiesDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_companiesDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ ��������
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
            return (new EntityEnumerator((Company[])ToArray()));
        }
    }
}
