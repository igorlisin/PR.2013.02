namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ��������
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// ��������. ������ � ���������� ������������
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����������� �����
        /// </summary>
        string LegalAddress { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������� �����
        /// </summary>
        string PostalAddress { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����
        /// </summary>
        string PSRN { get; set; }
    }
}
