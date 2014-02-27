using System;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. �����
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// ��������. ������ � ���������� ����� ������
        /// </summary>
        string ReportNumber { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ���������� ������
        /// </summary>
        DateTime EvaluationDate { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ����������� ������
        /// </summary>
        DateTime ReportDate { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        string Contract { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ���������� ��������
        /// </summary>
        DateTime DateOfContract { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        IClient Client { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������� ��������
        /// </summary>
        ICompany Company { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����������
        /// </summary>
        IEmployee Employee { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ������
        /// </summary>
        IObject Object { get; set; }
    }
}
