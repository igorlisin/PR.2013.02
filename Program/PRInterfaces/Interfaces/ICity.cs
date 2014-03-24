using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. �����
    /// </summary>
    public interface ICity
    {
        /// <summary>
        /// ��������. ������ � ��������� ��������
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������
        /// </summary>
        IRegion Region { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ �������
        /// </summary>
        List<IDistrict> Districts { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����
        /// </summary>
        List<IStreet> Streets { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ������ ����������
        /// </summary>
        List<IComplex> Complexes { get; set; }
    }
}
