using System.Collections;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ���������
    /// </summary>
    public interface IEntities : IEnumerable
    {
        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        int Count();
    }
}
