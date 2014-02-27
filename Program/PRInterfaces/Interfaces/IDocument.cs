using System;

using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ��������
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// ��������. ������ � ���������� ���
        /// </summary>
        DocumentTypes Type { get; set; }

        /// <summary>
        /// ��������. ���������� ��� ��������� ��� ��������� ������
        /// </summary>
        string TypeAsString { get; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        int Series { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        DateTime DataOfIssue { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����� ������
        /// </summary>
        string PlaceOfIssue { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        IMan Man { get; set; }
    }
}
