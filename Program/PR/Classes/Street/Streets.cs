using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ ����
    /// </summary>
    public class Streets : IStreets
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ����
        /// </summary>
        private DbSet<Street> _streetsDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ����
        /// </summary>
        public DbSet<Street> StreetsDbSet
        {
            get
            {
                return (_streetsDbSet);
            }
            set
            {
                _streetsDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Streets(DbSet<Street> streetsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _streetsDbSet = streetsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� �����
        /// </summary>
        public IStreet Create()
        {
            IStreet street;

            street = (IStreet)new Street();

            street.Name = Street.DefaultName;

            return (street);
        }

        /// <summary>
        /// �����. ��������� ����� � ����� ����
        /// </summary>
        public void Add(IStreet street)
        {
            _streetsDbSet.Add((Street)street);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ����� �� ������ ����
        /// </summary>
        public void Remove(IStreet street)
        {
            _streetsDbSet.Remove((Street)street);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ����� � ��������� ��������������� �� ������ ����
        /// </summary>
        public void RemoveById(int id)
        {
            IStreet street;

            street = GetStreet(id);

            if (street != null)
            {
                _streetsDbSet.Remove((Street)street);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ����
        /// </summary>
        public List<IStreet> ToList()
        {
            return (_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToList<IStreet>());
        }

        /// <summary>
        /// �����. ���������� ������ ����
        /// </summary>
        public IStreet[] ToArray()
        {
            return (_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<IStreet>());
        }

        /// <summary>
        /// �����. ���������� ����� � ��������� ��������������� �� ������ ����
        /// </summary>
        public IStreet GetStreet(int id)
        {
            return ((IStreet)_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Where(s=>s.Id == id).First());
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_streetsDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ ����
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
            return (new EntityEnumerator(_streetsDbSet.Include(s => s.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<Street>()));
        }
    }
}
