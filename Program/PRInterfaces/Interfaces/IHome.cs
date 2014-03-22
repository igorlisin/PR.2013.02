using System.Collections.Generic;
using PRInterfaces.Enumerations;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ���
    /// </summary>
    public interface IHome
    {
        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����� �� ���������
        /// </summary>
        string ComplexNumber { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        IStreet Street { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        IComplex Complex { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        List<IApartment> Appartments { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ��������� ����
        /// </summary>
        int BuildYear { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� �����
        /// </summary>
        Condition RoofCondition { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ������� ���� ����
        /// </summary>
        MaterialType OutsideWall { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������������ ����
        /// </summary>
        MaterialType InsideWall { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������� �����
        /// </summary>
        bool Lift { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ���������� ����������
        /// </summary>
        string KapremontYear { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������������� ����������
        /// </summary>
        string KapremontPeriod { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������� �������� ������
        /// </summary>
        bool Defects { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������� �������������
        /// </summary>
        bool Garbadge { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������������� ��������
        /// </summary>
        string ExtraFactors { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������� ���������
        /// </summary>
        bool Conserge { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ����������
        /// </summary>
        MaterialType CeilingType { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������� ����������
        /// </summary>
        Condition CeilingCondition { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������
        /// </summary>
        string Basement { get; set; }
        
        /// <summary>
        /// ��������. ������ � ���������� ����� ����������
        /// </summary>
        string BasementWear { get; set; }
        
        /// <summary>
        /// ��������. ������ � ���������� ������� �������
        /// </summary>
        bool Attic { get; set; }
        
        /// <summary>
        /// ��������. ������ � ���������� ���������� �� ��������
        /// </summary>
        string PromzoneDistance { get; set; }
        
        /// <summary>
        /// ��������. ������ � ���������� ���������� �� ���������
        /// </summary>
        string StopDistance { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��� ���� �������
        /// </summary>
        string Social { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������������ ���������
        /// </summary>
        string Transport { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������� ����
        /// </summary>
        bool Gaz { get; set; }
    }
}
