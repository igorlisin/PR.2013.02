using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. �����
    /// </summary>
    public interface IStreet
    {
        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Name { get; set; }

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
