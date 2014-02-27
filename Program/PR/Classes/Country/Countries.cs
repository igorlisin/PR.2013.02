using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ �����
    /// </summary>
    public class Countries : ICountries
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� �����
        /// </summary>
        private DbSet<Country> _countriesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� �����
        /// </summary>
        public DbSet<Country> CountriesDbSet
        {
            get
            {
                return (_countriesDbSet);
            }
            set
            {
                _countriesDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Countries(DbSet<Country> countriesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _countriesDbSet = countriesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ������
        /// </summary>
        public ICountry Create()
        {
            ICountry country;

            country = (ICountry)new Country();

            country.Name = Country.DefaultName;

            return (country);
        }

        /// <summary>
        /// �����. ��������� ������ � ����� �����
        /// </summary>
        public void Add(ICountry country)
        {
            _countriesDbSet.Add((Country)country);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ �� ������ �����
        /// </summary>
        public void Remove(ICountry country)
        {
            _countriesDbSet.Remove((Country)country);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ � ��������� ��������������� �� ������ �����
        /// </summary>
        public void RemoveById(int id)
        {
            ICountry country;

            country = GetCountry(id);

            if (country != null)
            {
                _countriesDbSet.Remove((Country)country);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        public List<ICountry> ToList()
        {
            return (_countriesDbSet.ToList<ICountry>());
        }

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        public ICountry[] ToArray()
        {
            return (_countriesDbSet.ToArray<ICountry>());
        }

        /// <summary>
        /// �����. ���������� ������ � ��������� ��������������� �� ������ �����
        /// </summary>
        public ICountry GetCountry(int id)
        {
            return ((ICountry)_countriesDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_countriesDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ �����
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
            return (new EntityEnumerator(_countriesDbSet.ToArray<Country>()));
        }
    }
}
