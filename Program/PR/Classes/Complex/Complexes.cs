using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ ����������
    /// </summary>
    public class Complexes : IComplexes
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ����������
        /// </summary>
        private DbSet<Complex> _complexesDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ����������
        /// </summary>
        public DbSet<Complex> ComplexesDbSet
        {
            get
            {
                return (_complexesDbSet);
            }
            set
            {
                _complexesDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Complexes(DbSet<Complex> complexesDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _complexesDbSet = complexesDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        public IComplex Create()
        {
            IComplex complex;

            complex = (IComplex)new Complex();

            complex.Number = Complex.DefaultNumber;

            return (complex);
        }

        /// <summary>
        /// �����. ��������� �������� � ����� ����������
        /// </summary>
        public void Add(IComplex complex)
        {
            _complexesDbSet.Add((Complex)complex);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� �� ������ ����������
        /// </summary>
        public void Remove(IComplex complex)
        {
            _complexesDbSet.Remove((Complex)complex);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        public void RemoveById(int id)
        {
            IComplex complex;

            complex = GetComplex(id);

            if (complex != null)
            {
                _complexesDbSet.Remove((Complex)complex);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        public List<IComplex> ToList()
        {
            return (_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToList<IComplex>());
        }

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        public IComplex[] ToArray()
        {
            return (_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<IComplex>());
        }

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        public IComplex GetComplex(int id)
        {
            return ((IComplex)_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).Where(c => c.Id == id).First());
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_complexesDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
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
            return (new EntityEnumerator(_complexesDbSet.Include(c => c.CityForEntityFramework.RegionForEntityFramework.CountryForEntityFramework).ToArray<Complex>()));
        }
    }
}
