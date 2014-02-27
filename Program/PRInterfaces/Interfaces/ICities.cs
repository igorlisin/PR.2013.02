using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �������
    /// </summary>
    public interface ICities : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� �����
        /// </summary>
        ICity Create();

        /// <summary>
        /// �����. ��������� ����� � ������ �������
        /// </summary>
        void Add(ICity city);

        /// <summary>
        /// �����. ������� ����� �� ������ �������
        /// </summary>
        void Remove(ICity city);

        /// <summary>
        /// �����. ������� ����� � ��������� ��������������� �� ������ �������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �������
        /// </summary>
        List<ICity> ToList();

        /// <summary>
        /// �����. ���������� ������ �������
        /// </summary>
        ICity[] ToArray();

        /// <summary>
        /// �����. ���������� ����� � ��������� ��������������� �� ������ �������
        /// </summary>
        ICity GetCity(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ �������
        /// </summary>
        void SaveChanges();
    }
}
