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
    public class Pictures : IPictures
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ��������
        /// </summary>
        private DbSet<Picture> _picturesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ��������
        /// </summary>
        public DbSet<Picture> PicturesDbSet
        {
            get
            {
                return (_picturesDbSet);
            }
            set
            {
                _picturesDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Pictures(DbSet<Picture> picturesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _picturesDbSet = picturesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        public IPicture Create()
        {
            IPicture picture;

            picture = (IPicture)new Picture();

            picture.CreationDate = DateTime.Now;
            picture.Name = Picture.DefaultName;

            return (picture);
        }

        /// <summary>
        /// �����. ��������� �������� � ����� ��������
        /// </summary>
        public void Add(IPicture picture)
        {
            _picturesDbSet.Add((Picture)picture);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� �� ������ ��������
        /// </summary>
        public void Remove(IPicture picture)
        {
            _picturesDbSet.Remove((Picture)picture);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        public void RemoveById(int id)
        {
            IPicture picture;

            picture = GetPicture(id);

            if (picture != null)
            {
                _picturesDbSet.Remove((Picture)picture);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public List<IPicture> ToList()
        {
            return (_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToList<IPicture>());
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public IPicture[] ToArray()
        {
            return (_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToArray<IPicture>());
        }

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        public IPicture GetPicture(int id)
        {
            return ((IPicture)_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).Where(p => p.Id == id).First());
        }

        /// <summary>
        /// �����. ���������� ������ �������� ��� ��������� ��������
        /// </summary>
        public IPictures PicturesForApartment(IApartment apartment)
        {
            return (IPictures)_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).Where(p => p.Apartment == apartment);
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_picturesDbSet.Count());
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
            return (new EntityEnumerator(_picturesDbSet.Include(p => p.ApartmentForEntityFramework.HomeForEntityFramework.StreetForEntityFramework).ToArray<Picture>()));
        }
    }
}
