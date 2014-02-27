using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �����
    /// </summary>
    public interface ICountries : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ������
        /// </summary>
        ICountry Create();

        /// <summary>
        /// �����. ��������� ������ � ������ �����
        /// </summary>
        void Add(ICountry country);

        /// <summary>
        /// �����. ������� ������ �� ������ �����
        /// </summary>
        void Remove(ICountry country);

        /// <summary>
        /// �����. ������� ������ � ��������� ��������������� �� ������ �����
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        List<ICountry> ToList();

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        ICountry[] ToArray();

        /// <summary>
        /// �����. ���������� ������ � ��������� ��������������� �� ������ �����
        /// </summary>
        ICountry GetCountry(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ �������
        /// </summary>
        void SaveChanges();
    }
}