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
        int ObjectType { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������� ������
        /// </summary>
        int NumberOfRooms { get; set; }

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
        List<IMan> Holders { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����������� ���������
        /// </summary>
        int TypeOfValue { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string PurposeOfTheEvaluation { get; set; }
    }
}