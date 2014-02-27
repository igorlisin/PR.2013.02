using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ��������
    /// </summary>
    public interface IClients : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ������ �������
        /// </summary>
        IClient Create();

        /// <summary>
        /// �����. ��������� ������� � ������ ��������
        /// </summary>
        void Add(IClient client);

        /// <summary>
        /// �����. ������� ������� �� ������ ��������
        /// </summary>
        void Remove(IClient client);

        /// <summary>
        /// �����. ������� ������� � ���������� ��������������� �� ������ ��������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        List<IClient> ToList();

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        IClient[] ToArray();

        /// <summary>
        /// �����. ���������� ������� � ���������� ��������������� �� ������ ��������
        /// </summary>
        IClient GetClient(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ��������
        /// </summary>
        void SaveChanges();
    }
}
