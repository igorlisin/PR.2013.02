using System;

using PRInterfaces.Interfaces;
using PRInterfaces.Enumerations;

namespace PR.Classes
{
    /// <summary>
    /// �����. ��������
    /// </summary>
    public class Document : Entity, IDocument
    {
        #region Static methods

        /// <summary>
        /// ����������� �����. ����������� ������ ���� IDocument � ������ ���� Document
        /// </summary>
        public static Document IDocumentToDocumentConverter(IDocument document)
        {
            return ((Document)document);
        }

        /// <summary>
        /// ����������� �����. ����������� ������ ���� Document � ������ ���� IDocument
        /// </summary>
        public static IDocument DocumentToIDocumentConverter(Document document)
        {
            return ((IDocument)document);
        }

        /// <summary>
        /// ����������� �����. ���������� ��� ��������� ��� �������� ������
        /// </summary>
        public static string GetDocumentTypeAsString(DocumentTypes documentType)
        {
            string documentTypeAsString;                                        // ��� ��������� (��� ���������� ������)

            switch (documentType)                                               // ��������� ��� ���������
            {
                case DocumentTypes.passport:                                     // ��� ���������: �������
                    documentTypeAsString = "�������";                           // ������ ��� ���������
                    break;
                case DocumentTypes.driverId:                                     // ��� ���������: ������������ �������������
                    documentTypeAsString = "������������ �������������";        // ������ ��� ���������
                    break;
                case DocumentTypes.warId:                                        // ��� ���������: ������� �����
                    documentTypeAsString = "������� �����";                     // ������ ��� ���������
                    break;
                default:                                                        // ��� ���������: �������� �� ���������
                    documentTypeAsString = "";                                  // ������ ��� ���������
                    break;
            }

            return (documentTypeAsString);
        }

        #endregion

        #region Fields

        /// <summary>
        /// ����. ���
        /// </summary>
        private DocumentTypes _type;

        /// <summary>
        /// ����. �����
        /// </summary>
        private int _series;

        /// <summary>
        /// ����. �����
        /// </summary>
        private int _number;

        /// <summary>
        /// ����. ���� ������
        /// </summary>
        private DateTime _dateOfIssue;

        /// <summary>
        /// ����. ����� ������
        /// </summary>
        private string _placeOfIssue;

        #endregion

        #region Properties

        /// <summary>
        /// ��������. ������ � ���������� ���
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
        /// ��������. ���������� ��� ��������� ��� ��������� ������
        /// </summary>
        public string TypeAsString
        {
            get
            {
                return (Document.GetDocumentTypeAsString(_type));
            }
        }

        /// <summary>
        /// ��������. ������ � ���������� �����
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
        /// ��������. ������ � ���������� �����
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
        /// ��������. ������ � ���������� ���� ������
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
        /// ��������. ������ � ���������� ����� ������
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
        /// ��������. ������ � ���������� ��������
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
        /// ��������. ������ � ���������� �������� (������������ � Entity Framework) 
        /// </summary>
        public Man ManForEntityFramework { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// �����. ���������� ����� ���������
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
