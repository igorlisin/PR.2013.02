using System;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
    /// <summary>
    /// Класс. Документ
    /// </summary>
    public class Document : Entity, IDocument
    {
        #region Static methods

        /// <summary>
        /// Статический метод. Преобразует объект типа IDocument в объект типа Document
        /// </summary>
        public static Document IDocumentToDocumentConverter(IDocument document)
        {
            return ((Document)document);
        }

        /// <summary>
        /// Статический метод. Преобразует объект типа Document в объект типа IDocument
        /// </summary>
        public static IDocument DocumentToIDocumentConverter(Document document)
        {
            return ((IDocument)document);
        }

        /// <summary>
        /// Статический метод. Возвращает тип документа как тестовую строку
        /// </summary>
        public static string GetDocumentTypeAsString(DocumentTypes documentType)
        {
            string documentTypeAsString;                                        // Тип документа (как тескстовая строка)

            switch (documentType)                                               // Проверить тип документа
            {
                case DocumentTypes.passport:                                     // Тип документа: паспорт
                    documentTypeAsString = "Паспорт";                           // Задать тип документа
                    break;
                case DocumentTypes.driverId:                                     // Тип документа: водительское удостоверение
                    documentTypeAsString = "Водительское удостоверение";        // Задать тип документа
                    break;
                case DocumentTypes.warId:                                        // Тип документа: военный билет
                    documentTypeAsString = "Военный билет";                     // Задать тип документа
                    break;
                default:                                                        // Тип документа: документ по умолчанию
                    documentTypeAsString = "";                                  // Задать тип документа
                    break;
            }

            return (documentTypeAsString);
        }

        #endregion

        #region Fields

        /// <summary>
        /// Поле. Тип
        /// </summary>
        private DocumentTypes _type;

        /// <summary>
        /// Поле. Серия
        /// </summary>
        private int _series;

        /// <summary>
        /// Поле. Номер
        /// </summary>
        private int _number;

        /// <summary>
        /// Поле. Дата выдачи
        /// </summary>
        private DateTime _dateOfIssue;

        /// <summary>
        /// Поле. Место выдачи
        /// </summary>
        private string _placeOfIssue;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Задает и возвращает тип
        /// </summary>
        public DocumentTypes Type
        {
            get
            {
                return (_type);
            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Свойство. Возвращает тип документа как текстовую строку
        /// </summary>
        public string TypeAsString
        {
            get
            {
                return (Document.GetDocumentTypeAsString(_type));
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает серию
        /// </summary>
        public int Series
        {
            get
            {
                return (_series);
            }
            set
            {
                _series = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает номер
        /// </summary>
        public int Number
        {
            get
            {
                return (_number);
            }
            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает дату выдачи
        /// </summary>
        public DateTime DataOfIssue
        {
            get
            {
                return (_dateOfIssue);
            }
            set
            {
                _dateOfIssue = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает место выдачи
        /// </summary>
        public string PlaceOfIssue
        {
            get
            {
                return (_placeOfIssue);
            }
            set
            {
                _placeOfIssue = value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает человека
        /// </summary>
        public IMan Man
        {
            get
            {
                return ((IMan)ManForEntityFramework);
            }
            set
            {
                ManForEntityFramework = (Man)value;
            }
        }

        /// <summary>
        /// Свойство. Задает и возвращает человека (используется в Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Метод. Возвращает копию документа
        /// </summary>
        public override object Clone()
        {
            IDocument document;

            document = (IDocument)base.Clone();
            document.Type = Type;
            document.Series = Series;
            document.Number = Number;
            document.DataOfIssue = DataOfIssue;
            document.PlaceOfIssue = PlaceOfIssue;

            return ((object)document);
        }

        #endregion
    }
}
