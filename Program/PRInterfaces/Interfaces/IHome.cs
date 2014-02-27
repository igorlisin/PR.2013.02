using System.Collections.Generic;

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
    }
}
