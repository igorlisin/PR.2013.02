using System.Collections.Generic;

namespace PRInterfaces.Interfaces
{
    /// <summary>
    /// ���������. ������ ����������
    /// </summary>
    public interface IDocuments : IEntities
    {
        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        IDocument Create();

        /// <summary>
        /// �����. ��������� �������� � ������ ����������
        /// </summary>
        void Add(IDocument document);

        /// <summary>
        /// �����. ������� �������� �� ������ ����������
        /// </summary>
        void Remove(IDocument document);

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        void RemoveById(int id);

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        List<IDocument> ToList();

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        IDocument[] ToArray();

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        IDocument GetDocument(int id);

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        void SaveChanges();
    }
}
