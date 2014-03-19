using System;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������
    /// </summary>
    public class Client : Entity, IClient 
    {
        /// <summary>
        /// ����������� ����. �������� �� ���������
        /// </summary>
        private static string _clientAddress;

        /// <summary>
        /// ����������� �����. ����������� ������ ���� IClient � ������ ���� Client
        /// </summary>
        public static Client IClientToClientConverter(IClient client)
        {
            return ((Client)client);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Client � ������ ���� IClient
        /// </summary>
        public static IClient ClientToIClientConverter(Client client)
        {
            return ((IClient)client);
        }

        /// <summary>
        /// ��������. ������ � ���������� ��������
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
        /// ��������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����� �������
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
        /// �����. ���������� ����� �������
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
