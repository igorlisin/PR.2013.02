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
    public class Homes : IHomes
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� �����
        /// </summary>
        private DbSet<Home> _homesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� �����
        /// </summary>
        public DbSet<Home> HomesDbSet
        {
            get
            {
                return (_homesDbSet);
            }
            set
            {
                _homesDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Homes(DbSet<Home> homesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _homesDbSet = homesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ���
        /// </summary>
        public IHome Create()
        {
            IHome home;

            home = (IHome)new Home();

            home.Number = Home.DefaultNumber;
            home.ComplexNumber = Home.DefaultComplexNumber; 

            return (home);
        }

        /// <summary>
        /// �����. ��������� ��� � ����� �����
        /// </summary>
        public void Add(IHome home)
        {
            _homesDbSet.Add((Home)home);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ��� �� ������ �����
        /// </summary>
        public void Remove(IHome home)
        {
            _homesDbSet.Remove((Home)home);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ��� � ��������� ��������������� �� ������ �����
        /// </summary>
        public void RemoveById(int id)
        {
            IHome home;

            home = GetHome(id);

            if (home != null)
            {
                _homesDbSet.Remove((Home)home);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        public List<IHome> ToList()
        {
            return (_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToList<IHome>());
        }

        /// <summary>
        /// �����. ���������� ������ �����������
        /// </summary>
        public IHome[] ToArray()
        {
            return (_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToArray<IHome>());
        }

        /// <summary>
        /// �����. ���������� ��� � ��������� ��������������� �� ������ �����
        /// </summary>
        public IHome GetHome(int id)
        {
            return ((IHome)_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework)/*.Include(h => h.ComplexForEntityFramework.CityForEntityFramework).Where(h=>h.Id == id)*/.First());
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_homesDbSet.Count());
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
            return (new EntityEnumerator(_homesDbSet.Include(h => h.StreetForEntityFramework.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Include(h => h.ComplexForEntityFramework.CityForEntityFramework).ToArray<Home>()));
        }
    }
}
