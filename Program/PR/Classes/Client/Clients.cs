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
    public class Clients : IClients
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ��������
        /// </summary>
        private DbSet<Client> _clientsDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ��������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ��������
        /// </summary>
        public DbSet<Client> ClientDbSet
        {
            get
            {
                return (_clientsDbSet);
            }
            set
            {
                _clientsDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Clients(DbSet<Client> clientsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _clientsDbSet = clientsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ������ �������
        /// </summary>
        public IClient Create()
        {
            IClient client;

            client = (IClient)new Client();

            return (client);
        }

        /// <summary>
        /// �����. ��������� ������� � ����� ��������
        /// </summary>
        public void Add(IClient client)
        {
            _clientsDbSet.Add((Client)client);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������� �� ������ ��������
        /// </summary>
        public void Remove(IClient client)
        {
            _clientsDbSet.Remove((Client)client);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� ������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        public void RemoveById(int id)
        {
            IClient client;

            client = GetClient(id);

            if (client != null)
            {
                _clientsDbSet.Remove((Client)client);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public List<IClient> ToList()
        {
            return (_clientsDbSet.Include(c=>c.ManForEntityFramework.DocumentForEntityFramework).ToList<IClient>());
        }

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        public IClient[] ToArray()
        {
            return (_clientsDbSet.Include(c => c.ManForEntityFramework.DocumentForEntityFramework).ToArray<IClient>());
        }

        /// <summary>
        /// �����. ���������� ������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        public IClient GetClient(int id)
        {
            return ((IClient)_clientsDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_clientsDbSet.Count());
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
            return (new EntityEnumerator(_clientsDbSet.Include(c => c.ManForEntityFramework.DocumentForEntityFramework).ToArray<Client>()));
        }
    }
}
