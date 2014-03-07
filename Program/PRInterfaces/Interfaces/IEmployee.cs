

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ���������
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        IMan Man { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������
        /// </summary>
        string Position { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������� � ���������, �������������� ��������� ���������������� ������ � ������� ��������� ������������
        /// </summary>
        string FurtherEducation { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���������� � �������� � ���������������� ����������� ���������
        /// </summary>
        string Membership { get; set; }

        /// <summary>
        /// ��������. ������ � ��������� �������� �� ������������ ����������� ����������� ���������������
        /// </summary>
        string Insurance { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ���� ������ � ��������� ������������
        /// </summary>
        int WorkTime { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        IReport Report { get; set; }
    }
}
