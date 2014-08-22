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
        /// ��������. ������ � ���������� ��������� ���������������� ������������ ���������
        /// </summary>
        string Documents { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����������� ���������
        /// </summary>
        string TypeOfValue { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �������� ���������
        /// </summary>
        float Price { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������������� ���������
        /// </summary>
        float Discount { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� �������
        /// </summary>
        float Dollar { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string PurposeOfTheEvaluation { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������
        /// </summary>
        string DestOfTheEvaluation { get; set; }

        /// <summary>
        /// ��������. ����������
        /// </summary>
        float R { get; set; }

        /// <summary>
        /// ��������. ���� ���������� ������� �� �������� ���������
        /// </summary>
        float T_r { get; set; }

        /// <summary>
        /// ��������. ���� ���������� ������� �� �������������� ���������
        /// </summary>
        float T_l { get; set; }

        /// <summary>
        /// ��������. ��������� ����� ������������� ��������
        /// </summary>
        float EconSituationDown { get; set; }

        /// <summary>
        /// ��������. ���������� ����� ������������� ��������
        /// </summary>
        float ConcurentsUp { get; set; }

        /// <summary>
        /// ��������. ��������� ������������ ��� �������� ����������������
        /// </summary>
        float LowChange { get; set; }

        /// <summary>
        /// ��������. ��������� � ������������� ������������ ��������
        /// </summary>
        float ExtremalSituation { get; set; }

        /// <summary>
        /// ��������. ���������� ����� ������� ������
        /// </summary>
        float AcceleratedWear { get; set; }

        /// <summary>
        /// ��������. ����������� �������� ��������
        /// </summary>
        float NoRentalMoney { get; set; }

        /// <summary>
        /// ��������. ������������� ����������
        /// </summary>
        float BadManagment { get; set; }

        /// <summary>
        /// ��������. ������������� �������
        /// </summary>
        float Criminal { get; set; }

        /// <summary>
        /// ��������. ���������� ��������
        /// </summary>
        float FinanceChecking { get; set; }

        /// <summary>
        /// ��������. ������������ ���������� ��������� ������
        /// </summary>
        float NotCorrect { get; set; }

        /// <summary>
        /// ��������. ����������� ������
        /// </summary>
        float NoRisk { get; set; }

        /// <summary>
        /// ��������. �������������� ����������
        /// </summary>
        float InvestManage { get; set; }

        /// <summary>
        /// ��������. �����������, ����������� ������������
        /// </summary>
        float K_el { get; set; }

    }
}