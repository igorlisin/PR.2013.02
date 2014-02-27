namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ����������
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// �����. ����������� � ���������� ������ �������������� �����������
        /// </summary>
        void Interfaces();

        /// <summary>
        /// �����. �������� ���������� ������ ��� ��������������
        /// </summary>
        void SetData();

        /// <summary>
        /// �����. ��������� ���������� ����������
        /// </summary>
        void Run();
    }
}
