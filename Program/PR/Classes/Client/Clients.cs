using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список клиентов
    /// </summary>
    public class Clients : IClients
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка клиентов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор клиентов
        /// </summary>
        private DbSet<Client> _clientsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка клиентов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор клиентов
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
        /// Конструктор
        /// </summary>
        public Clients(DbSet<Client> clientsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _clientsDbSet = clientsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает нового клиента
        /// </summary>
        public IClient Create()
        {
            IClient client;

            client = (IClient)new Client();

            return (client);
        }

        /// <summary>
        /// Метод. Добавляет клиента в набор клиентов
        /// </summary>
        public void Add(IClient client)
        {
            _clientsDbSet.Add((Client)client);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет клиента из набора клиентов
        /// </summary>
        public void Remove(IClient client)
        {
            _clientsDbSet.Remove((Client)client);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет клиента с указанным идентификатором из списка клиентов
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
        /// Метод. Возвращает список клиентов
        /// </summary>
        public List<IClient> ToList()
        {
            return (_clientsDbSet.Include(c=>c.ManForEntityFramework.DocumentForEntityFramework).ToList<IClient>());
        }

        /// <summary>
        /// Метод. Возвращает массив клиентов
        /// </summary>
        public IClient[] ToArray()
        {
            return (_clientsDbSet.Include(c => c.ManForEntityFramework.DocumentForEntityFramework).ToArray<IClient>());
        }

        /// <summary>
        /// Метод. Возвращает клиента с указанным идентификатором из списка клиентов
        /// </summary>
        public IClient GetClient(int id)
        {
            return ((IClient)_clientsDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_clientsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка клиентов
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_clientsDbSet.Include(c => c.ManForEntityFramework.DocumentForEntityFramework).ToArray<Client>()));
        }
    }
}
