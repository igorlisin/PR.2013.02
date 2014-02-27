using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������
    /// </summary>
    public interface ICountry
    {
        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ��������
        /// </summary>
        List<IRegion> Regions { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        IReport Report { get; set; }
    }
}
