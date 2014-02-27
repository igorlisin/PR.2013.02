using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Entity;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ �����
    /// </summary>
    public class Mans : IMans
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� �����
        /// </summary>
        private DbSet<Man> _mansDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ �����
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� �����
        /// </summary>
        public DbSet<Man> MansDbSet
        {
            get
            {
                return (_mansDbSet);
            }
            set
            {
                _mansDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Mans(DbSet<Man> mansDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _mansDbSet = mansDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ������ ��������
        /// </summary>
        public IMan Create()
        {
            IMan man;

            man = (IMan)new Man();

            man.Name = Man.DefaultName;
            man.Surname = Man.DefaultSurname;
            man.Patronymic = Man.DefaultPatronymic;

            return (man);
        }

        /// <summary>
        /// �����. ��������� �������� � ����� �����
        /// </summary>
        public void Add(IMan man)
        {
            _mansDbSet.Add((Man)man);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� �� ������ �����
        /// </summary>
        public void Remove(IMan man)
        {
            _mansDbSet.Remove((Man)man);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ �����
        /// </summary>
        public void RemoveById(int id)
        {
            IMan man;

            man = GetMan(id);

            if (man != null)
            {
                _mansDbSet.Remove((Man)man);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        public List<IMan> ToList()
        {
            return (_mansDbSet.Include(m => m.DocumentForEntityFramework).ToList<IMan>());
        }

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        public IMan[] ToArray()
        {
            return (_mansDbSet.Include(m => m.DocumentForEntityFramework).ToArray<IMan>());
        }

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        public IMan GetMan(int id)
        {
            return ((IMan)_mansDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_mansDbSet.Count());
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
        public System.Collections.IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_mansDbSet.Include(m => m.DocumentForEntityFramework).ToArray<Entity>()));
        }
    }
}
