using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ����������
    /// </summary>
    public interface IComplexes : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        IComplex Create();

        /// <summary>
        /// �����. ��������� �������� � ������ ����������
        /// </summary>
        void Add(IComplex complex);

        /// <summary>
        /// �����. ������� �������� �� ������ ����������
        /// </summary>
        void Remove(IComplex complex);

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        List<IComplex> ToList();

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        IComplex[] ToArray();

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        IComplex GetComplex(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ �������
        /// </summary>
        void SaveChanges();
    }
}
