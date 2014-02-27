using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// �����. ������ ����������
    /// </summary>
    public class Documents : IDocuments
    {
        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����������
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// ����. ����� ����������
        /// </summary>
        private DbSet<Document> _documentsDbSet;

        /// <summary>
        /// �������. ������������ ����� ���������� ��������� ������ ����������
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// ��������. ������ � ���������� ����� ����������
        /// </summary>
        public DbSet<Document> DocumentsDbSet
        {
            get
            {
                return (_documentsDbSet);
            }
            set
            {
                _documentsDbSet = value;
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public Documents(DbSet<Document> documentsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _documentsDbSet = documentsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// �����. ������� � ���������� ����� ��������
        /// </summary>
        public IDocument Create()
        {
            IDocument document;

            document = (IDocument)new Document();

            document.DataOfIssue = new DateTime(1950, 1, 1);

            return (document);
        }

        /// <summary>
        /// �����. ��������� �������� � ����� ����������
        /// </summary>
        public void Add(IDocument document)
        {
            _documentsDbSet.Add((Document)document);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� �� ������ ����������
        /// </summary>
        public void Remove(IDocument document)
        {
            _documentsDbSet.Remove((Document)document);
            SaveChanges();
        }

        /// <summary>
        /// �����. ������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        public void RemoveById(int id)
        {
            IDocument document;

            document = GetDocument(id);

            if (document != null)
            {
                _documentsDbSet.Remove((Document)document);
                SaveChanges();
            }
        }

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        public List<IDocument> ToList()
        {
            return (_documentsDbSet.ToList<IDocument>());
        }

        /// <summary>
        /// �����. ���������� ������ ����������
        /// </summary>
        public IDocument[] ToArray()
        {
            return (_documentsDbSet.ToArray<IDocument>());
        }

        /// <summary>
        /// �����. ���������� �������� � ��������� ��������������� �� ������ ����������
        /// </summary>
        public IDocument GetDocument(int id)
        {
            return ((IDocument)_documentsDbSet.Find(id));
        }

        /// <summary>
        /// �����. ���������� ���������� ��������� � ������
        /// </summary>
        public int Count()
        {
            return (_documentsDbSet.Count());
        }

        /// <summary>
        /// �����. ��������� ��������� ������ ����������
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// �����. ���������� �������������
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_documentsDbSet.ToArray<Document>()));
        }
    }
}
