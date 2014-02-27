using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������
    /// </summary>
    public interface IRegion
    {
        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������
        /// </summary>
        ICountry Country { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        List<ICity> Cities { get; set; }
    }
}
