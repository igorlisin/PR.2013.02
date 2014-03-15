using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ �������� ������
    /// </summary>
    class Objects : IObjects
    {
        #region Delegated

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ 
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ 
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        #endregion

        #region Fields

        /// <summary>
        /// ����. ����� �������� ������
        /// </summary>
        private DbSet<Object> _objectsDbSet;

        #endregion

        #region Properties

        /// <summary>
        /// ��������. ������ � ���������� ����� �������� ������
        /// </summary>
        public DbSet<Object> ObjectsDbSet
        {
            get
            {
                return (_objectsDbSet);
            }
            set
            {
                _objectsDbSet = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// ����������� �������� ������
        /// </summary>
        public Objects(DbSet<Object> objectsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _objectsDbSet = objectsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ������ ������
        /// </summary>
        public IObject Create()
        {
            IObject Object;

            Object = (IObject)new Object();

            return (Object);
        }

        #endregion

        #region Methods

        /// <summary>
        /// �����. ��������� ������ ������ � ����� 
        /// </summary>
        public void Add(IObject Object)
        {
            _objectsDbSet.Add((Object)Object);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ ������ �� ������ 
        /// </summary>
        public void Remove(IObject Object)
        {
            _objectsDbSet.Remove((Object)Object);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������ ������ � ��������� ��������������� �� ������ 
        /// </summary>
        public void RemoveById(int id)
        {
            IObject Object;

            Object = GetObject(id);

            if (Object != null)
            {
                _objectsDbSet.Remove((Object)Object);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ 
        /// </summary>
        public List<IObject> ToList()
        {
            return (_objectsDbSet.ToList<IObject>());
        }

        /// <summary>
        /// �����. ���������� ������ 
        /// </summary>
        public IObject[] ToArray()
        {
            return (_objectsDbSet.ToArray<IObject>());
        }

        /// <summary>
        /// �����. ���������� ������ ������ � ��������� ��������������� �� ������ 
        /// </summary>
        public IObject GetObject(int id)
        {
            return ((IObject)_objectsDbSet.Where(a => a.Id == id).First());
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_objectsDbSet.Count());
        }

        /// <summary>
        /// �����. ���������� �������������
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_objectsDbSet.ToArray<Object>()));
        }

        /// <summary>
        /// �����. ��������� ��������� ������ 
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

  
        #endregion
    }
    }

