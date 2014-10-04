using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ��������
    /// </summary>
    public interface IPictures : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        IPicture Create();

        /// <summary>
        /// �����. ��������� �������� � ������ ��������
        /// </summary>
        void Add(IPicture picture);

        /// <summary>
        /// �����. ������� �������� �� ������ ��������
        /// </summary>
        void Remove(IPicture picture);

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        List<IPicture> ToList();

        /// <summary>
        /// �����. ���������� ������ ��������
        /// </summary>
        IPicture[] ToArray();

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ��������
        /// </summary>
        IPicture GetPicture(int id);

        /// <summary>
        /// �����. ���������� ������ �������� ��� ��������� ��������
        /// </summary>
        IPictures PicturesForApartment(IApartment apartment);

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
