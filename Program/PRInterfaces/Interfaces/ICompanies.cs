using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ��������
    /// </summary>
    public interface ICompanies : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        ICompany Create();

        /// <summary>
        /// �����. ��������� �������� � ������ ��������
        /// </summary>
        void Add(ICompany company);

        /// <summary>
        /// �����. ������� �������� �� ������ ��������
        /// </summary>
        void Remove(ICompany company);

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        List<ICompany> ToList();

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        ICompany[] ToArray();

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        ICompany GetCompany(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ��������
        /// </summary>
        void SaveChanges();
    }
}
