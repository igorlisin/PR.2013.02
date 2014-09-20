using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ��������
    /// </summary>
    public interface IComplex
    {
        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        ICity City { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����� 
        /// </summary>
        List<IHome> Homes { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �����������
        /// </summary>
        string Loacals_1 { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �����������
        /// </summary>
        string Loacals_2 { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������
        /// </summary>
        string Banks { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        string Hospitals { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ��� �����
        /// </summary>
        string Kinders { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string RestPlaces { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ������ ����
        /// </summary>
        string Schools { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ������ ����������� ����
        /// </summary>
        string Services { get; set; }


        /// <summary>
        /// ��������. ������ � ���������� ������ �������� ��������
        /// </summary>
        string Tradings { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �����
        /// </summary>
        string PharmList { get; set; }

    }
}
