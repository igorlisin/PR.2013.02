namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// �����. �������
    /// </summary>
    public interface IMan
    {
        /// <summary>
        /// ��������. ������ � ���������� ���
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Patronymic { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        IDocument Document { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� �������
        /// </summary>
        IClient Client { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ����������
        /// </summary>
        IEmployee Employee { get; set; }
    }
}
