using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Клиент
    /// </summary>
    public class Client : Entity, IClient 
    {
        /// <summary>
        /// Статическое поле. Название по умолчанию
        /// </summary>
        private static string _clientAddress;

        /// <summary>
        /// Статический метод. Преобразует объект типа IClient в объект типа Client
        /// </summary>
        public static Client IClientToClientConverter(IClient client)
        {
            return ((Client)client);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Client в объект типа IClient
        /// </summary>
        public static IClient ClientToIClientConverter(Client client)
        {
            return ((IClient)client);
        }

        /// <summary>
        /// Свойство. Задает и возвращает человека
        /// </summary>
        public IMan Man
        {
            get
            {
                return ((IMan)ManForEntityFramework);
            }
            set
            {
                ManForEntityFramework = (Man)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает человека (используется в Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        /// <summary>
        /// Свойство. Задает и возвращает адрес клиента
        /// </summary>
        public string Address
        {
            get
            {
                return _clientAddress;
            }
            set
            {
                _clientAddress = value;
            }
        }

        /// <summary>
        /// Метод. Возвращает копию клиента
        /// </summary>
        public override object Clone()
        {
            IClient client;

            client = (IClient)base.Clone();

            client.Man = Man;

            return ((object)client);
        }
    }
}
