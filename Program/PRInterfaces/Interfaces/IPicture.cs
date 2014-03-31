using System;
using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ��������
    /// </summary>
    public interface IPicture
    {
        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���
        /// </summary>
        PictureTypes Type { get; set; }

        /// <summary>
        /// ��������. ���������� ��� �������� ��� ��������� ������
        /// </summary>
        string TypeAsString { get; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����� �����������
        /// </summary>
        string ImageFileName { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� � ����� ��������
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        IApartment Apartment { get; set; }

        /// <summary>
        /// �����. ���������� ��� �������� ��� ��������� ������
        /// </summary>
        string GetPictureTypeAsString(PictureTypes pictureType);
    }
}
