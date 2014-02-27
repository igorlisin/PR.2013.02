using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �����
    /// </summary>
    public interface IMans : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ������ ��������
        /// </summary>
        IMan Create();

        /// <summary>
        /// �����. ��������� �������� � ������ �����
        /// </summary>
        void Add(IMan man);

        /// <summary>
        /// �����. ������� �������� �� ������ �����
        /// </summary>
        void Remove(IMan man);

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ �����
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        List<IMan> ToList();

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        IMan[] ToArray();

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ �����
        /// </summary>
        IMan GetMan(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ �����
        /// </summary>
        void SaveChanges();
    }
}
