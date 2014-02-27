using System;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ��������
    /// </summary>
    public interface IEntity : ICloneable
    {
        /// <summary>
        /// ��������. ������ � ���������� �������������
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// ��������. ������ � ���������� ��������
        /// </summary>
        string Description { get; set; }
    }
}
