using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PRInterfaces.Interfaces;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Список документов
    /// </summary>
    public class Documents : IDocuments
    {
        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка документов
        /// </summary>
        public delegate void SaveChangesDelegate();

        /// <summary>
        /// Поле. Набор документов
        /// </summary>
        private DbSet<Document> _documentsDbSet;

        /// <summary>
        /// Делегат. Представляет метод сохранения изменений списка документов
        /// </summary>
        private SaveChangesDelegate _saveChangesDelegate;

        /// <summary>
        /// Свойство. Задает и возвращает набор документов
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
        /// Конструктор
        /// </summary>
        public Documents(DbSet<Document> documentsDbSet, SaveChangesDelegate saveChangesDelegate)
        {
            _documentsDbSet = documentsDbSet;
            _saveChangesDelegate = saveChangesDelegate;
        }

        /// <summary>
        /// Метод. Создает и возвращает новый документ
        /// </summary>
        public IDocument Create()
        {
            IDocument document;

            document = (IDocument)new Document();

            document.DataOfIssue = new DateTime(1950, 1, 1);

            return (document);
        }

        /// <summary>
        /// Метод. Добавляет документ в набор документов
        /// </summary>
        public void Add(IDocument document)
        {
            _documentsDbSet.Add((Document)document);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет документ из набора документов
        /// </summary>
        public void Remove(IDocument document)
        {
            _documentsDbSet.Remove((Document)document);
            SaveChanges();
        }

        /// <summary>
        /// Метод. Удаляет документ с указанным идентификатором из списка документов
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
        /// Метод. Возвращает список документов
        /// </summary>
        public List<IDocument> ToList()
        {
            return (_documentsDbSet.ToList<IDocument>());
        }

        /// <summary>
        /// Метод. Возвращает массив документов
        /// </summary>
        public IDocument[] ToArray()
        {
            return (_documentsDbSet.ToArray<IDocument>());
        }

        /// <summary>
        /// Метод. Возвращает документ с указанным идентификатором из списка документов
        /// </summary>
        public IDocument GetDocument(int id)
        {
            return ((IDocument)_documentsDbSet.Find(id));
        }

        /// <summary>
        /// Метод. Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return (_documentsDbSet.Count());
        }

        /// <summary>
        /// Метод. Сохраняет изменения списка документов
        /// </summary>
        public void SaveChanges()
        {
            _saveChangesDelegate();
        }

        /// <summary>
        /// Метод. Возвращает перечислитель
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return (new EntityEnumerator(_documentsDbSet.ToArray<Document>()));
        }
    }
}
