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
    public class Regions : IRegions
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ��������
        /// </summary>
        private DbSet<Region> _regionsDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ��������
        /// </summary>
        public DbSet<Region> RegionDbSet
        {
            get
            {
                return (_regionsDbSet);
            }
            set
            {
                _regionsDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Regions(DbSet<Region> regionsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _regionsDbSet = regionsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ������
        /// </summary>
        public IRegion Create()
        {
            IRegion region;

            region = (IRegion)new Region();

            region.Name = Region.DefaultName;

            return (region);
        }

        /// <summary>
        /// �����. ��������� ������ � ����� ��������
        /// </summary>
        public void Add(IRegion region)
        {
            _regionsDbSet.Add((Region)region);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ �� ������ ��������
        /// </summary>
        public void Remove(IRegion region)
        {
            _regionsDbSet.Remove((Region)region);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ � ��������� ��������������� �� ������ ��������
        /// </summary>
        public void RemoveById(int id)
        {
            IRegion region;

            region = GetRegion(id);

            if (region != null)
            {
                _regionsDbSet.Remove((Region)region);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public List<IRegion> ToList()
        {
            return (_regionsDbSet.Include(r => r.CountryForEntityFramework).ToList<IRegion>());
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public IRegion[] ToArray()
        {
            return (_regionsDbSet.Include(r => r.CountryForEntityFramework).ToArray<IRegion>());
        }

        /// <summary>
        /// �����. ���������� ������ � ��������� ��������������� �� ������ ��������
        /// </summary>
        public IRegion GetRegion(int id)
        {
           return ((IRegion)(_regionsDbSet.Include(r => r.CountryForEntityFramework).Where(r => r.Id == id).First()));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_regionsDbSet.Count());
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
            return (new EntityEnumerator(_regionsDbSet.Include(r => r.CountryForEntityFramework).ToArray<Region>()));
        }
    }
}
