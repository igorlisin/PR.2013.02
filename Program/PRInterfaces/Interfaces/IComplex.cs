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
    }
}
