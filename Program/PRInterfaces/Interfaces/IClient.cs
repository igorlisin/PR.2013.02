namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        IMan Man { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �����
        /// </summary>
        IReport Report { get; set; }
    }
}
