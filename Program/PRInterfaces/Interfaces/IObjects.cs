using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �������� ������
    /// </summary>
    public interface IObjects : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ������ ������
        /// </summary>
        IObject Create();

        /// <summary>
        /// �����. ��������� ������ ������ � ������ �������� ������
        /// </summary>
        void Add(IObject assessObject);

        /// <summary>
        /// �����. ������� ������ ������ �� ������ �������� ������
        /// </summary>
        void Remove(IObject assessObject);

        /// <summary>
        /// �����. ������� ������ ������ � ��������� ��������������� �� ������ �������� ������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �������� ������
        /// </summary>
        List<IObject> ToList();

        /// <summary>
        /// �����. ���������� ������ �������� ������
        /// </summary>
        IObject[] ToArray();

        /// <summary>
        /// �����. ���������� ������ ������ � ��������� ��������������� �� ������ �������� ������
        /// </summary>
        IObject GetObject(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
