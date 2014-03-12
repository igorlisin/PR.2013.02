using System.Collections.Generic;

using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ������
    /// </summary>
    public interface IObject
    {
        /// <summary>
        /// ��������. ������ � ���������� ��� ������� ������
        /// </summary>
        string ObjectType { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������� ������
        /// </summary>
        //int NumberOfRooms { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������������� ����� �� ������ ������
        /// </summary>
        string Property { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������������ ����������� �����
        /// </summary>
        string Restriction { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������������� ������������ ���������
        /// </summary>
        string Holders { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����������� ���������
        /// </summary>
        string TypeOfValue { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �������� ���������
        /// </summary>
        int Price { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �� �������������� ���������
        /// </summary>
        int Discount { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� �������
        /// </summary>
        int Dollar { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string PurposeOfTheEvaluation { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string DestOfTheEvaluation { get; set; }
    }
}