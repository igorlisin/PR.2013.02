using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ����
    /// </summary>
    public interface IStreets : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� �����
        /// </summary>
        IStreet Create();

        /// <summary>
        /// �����. ��������� ����� � ������ ����
        /// </summary>
        void Add(IStreet street);

        /// <summary>
        /// �����. ������� ����� �� ������ ����
        /// </summary>
        void Remove(IStreet street);

        /// <summary>
        /// �����. ������� ����� � ��������� ��������������� �� ������ ����
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ����
        /// </summary>
        List<IStreet> ToList();

        /// <summary>
        /// �����. ���������� ������ ����
        /// </summary>
        IStreet[] ToArray();

        /// <summary>
        /// �����. ���������� ����� � ��������� ��������������� �� ������ ����
        /// </summary>
        IStreet GetStreet(int id);


        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
