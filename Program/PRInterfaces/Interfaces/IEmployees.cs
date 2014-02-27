using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �����������
    /// </summary>
    public interface IEmployees : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ������ ����������
        /// </summary>
        IEmployee Create();

        /// <summary>
        /// �����. ��������� ���������� � ������ �����������
        /// </summary>
        void Add(IEmployee employee);

        /// <summary>
        /// �����. ������� ���������� �� ������ �����������
        /// </summary>
        void Remove(IEmployee employee);

        /// <summary>
        /// �����. ������� ���������� � ��������� ��������������� �� ������ �����������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �����������
        /// </summary>
        List<IEmployee> ToList();

        /// <summary>
        /// �����. ���������� ������ �����������
        /// </summary>
        IEmployee[] ToArray();

        /// <summary>
        /// �����. ���������� ���������� � ��������� ��������������� �� ������ �����������
        /// </summary>
        IEmployee GetEmployee(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
