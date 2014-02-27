using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ��������
    /// </summary>
    public interface IRegions : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ������
        /// </summary>
        IRegion Create();

        /// <summary>
        /// �����. ��������� ������ � ������ ��������
        /// </summary>
        void Add(IRegion region);

        /// <summary>
        /// �����. ������� ������ �� ������ ��������
        /// </summary>
        void Remove(IRegion region);

        /// <summary>
        /// �����. ������� ������ � ��������� ��������������� �� ������ ��������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        List<IRegion> ToList();

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        IRegion[] ToArray();

        /// <summary>
        /// �����. ���������� ������ � ��������� ��������������� �� ������ ��������
        /// </summary>
        IRegion GetRegion(int index);

        /// <summary>
        /// �����. ��������� ��������� ������ ��������
        /// </summary>
        void SaveChanges();
    }
}
