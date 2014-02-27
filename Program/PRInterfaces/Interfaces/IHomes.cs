using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ �����
    /// </summary>
    public interface IHomes : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ���
        /// </summary>
        IHome Create();

        /// <summary>
        /// �����. ��������� ��� � ������ �����
        /// </summary>
        void Add(IHome home);

        /// <summary>
        /// �����. ������� ��� �� ������ �����
        /// </summary>
        void Remove(IHome home);

        /// <summary>
        /// �����. ������� ��� � ��������� ��������������� �� ������ �����
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        List<IHome> ToList();

        /// <summary>
        /// �����. ���������� ������ �����
        /// </summary>
        IHome[] ToArray();

        /// <summary>
        /// �����. ���������� ��� � ��������� ��������������� �� ������ �����
        /// </summary>
        IHome GetHome(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
