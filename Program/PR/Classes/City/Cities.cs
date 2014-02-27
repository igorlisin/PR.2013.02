using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ �������
    /// </summary>
    public class Cities : ICities
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� �������
        /// </summary>
        private DbSet<City> _citiesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� �������
        /// </summary>
        public DbSet<City> CitiesDbSet
        {
            get
            {
                return (_citiesDbSet);
            }
            set
            {
                _citiesDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Cities(DbSet<City> citiesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _citiesDbSet = citiesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� �����
        /// </summary>
        public ICity Create()
        {
            ICity city;

            city = (ICity)new City();

            city.Name = City.DefaultName;

            return (city);
        }

        /// <summary>
        /// �����. ��������� ����� � ����� �������
        /// </summary>
        public void Add(ICity city)
        {
            _citiesDbSet.Add((City)city);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ����� �� ������ �������
        /// </summary>
        public void Remove(ICity city)
        {
            _citiesDbSet.Remove((City)city);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ����� � ��������� ��������������� �� ������ �������
        /// </summary>
        public void RemoveById(int id)
        {
            ICity city;

            city = GetCity(id);

            if (city != null)
            {
                _citiesDbSet.Remove((City)city);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ �������
        /// </summary>
        public List<ICity> ToList()
        {
            return (_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToList<ICity>());
        }

        /// <summary>
        /// �����. ���������� ������ �������
        /// </summary>
        public ICity[] ToArray()
        {
            return (_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToArray<ICity>());
        }

        /// <summary>
        /// �����. ���������� ����� � ��������� ��������������� �� ������ �������
        /// </summary>
        public ICity GetCity(int id)
        {
            return ((ICity)_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).Where(c => c.Id == id).First());
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_citiesDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ �������
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
            return (new EntityEnumerator(_citiesDbSet.Include(c => c.RegionForEntityFramework.CountryForEntityFramework).ToArray<City>()));
        }
    }
}
