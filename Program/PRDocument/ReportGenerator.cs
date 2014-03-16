using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL.Declension;

using Microsoft.Office.Interop.Word;


using PRInterfaces.Interfaces;

namespace PRDocument
{
    public class ReportGenerator
    {
       
        public static void Generate(IReport report, string reportTemplatesFolderPath, string reportsFolderPath)
        {
            string templateConclusReport = reportTemplatesFolderPath + @"\conclusion.dotx";                                        // Путь к шаблону договора

            string reportConclusName = reportsFolderPath + @"\conclusion " + DateTime.Now.ToString().Replace(":", ".") + @".docx"; // Путь к выходному файлу
            
            string tempContractReport = reportTemplatesFolderPath + @"\contract.xltx";
            string reportContractName = reportsFolderPath + @"\contract" + DateTime.Now.ToString().Replace(":", ".") + @".xlsx";

            string[] bookmarks_conclusion = new string[200];                                                                       // Массив закладок
            string[] texts_conclusion = new string[200];                                                                           // Массив вставляемых вместо закладок строк
            
            string client_in_padeg = null;
            int rod = 0;
            client_in_padeg = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, report.Client.Man.Name, report.Client.Man.Patronymic, BLL.Declension.DeclensionCase.Tvorit);
            rod = BLL.Declension.DeclensionBLL.GetGender(report.Client.Man.Patronymic);

            ArrayFillConcusion(bookmarks_conclusion, texts_conclusion, report, client_in_padeg);


            DocGenerate(templateConclusReport, reportConclusName, bookmarks_conclusion, texts_conclusion);                                                      // Сгенерировать отчет для договора

            XLSGenerate(tempContractReport, reportContractName, report, rod);
        }

        public static void ArrayFillConcusion(string[] bookmarks_conclusion, string[] texts_conclusion, IReport report, string client_in_padeg) 
        {
            bookmarks_conclusion[0] = "apartment_type";
            bookmarks_conclusion[1] = "client_name";
            bookmarks_conclusion[2] = "contract";
            bookmarks_conclusion[3] = "contract2";
            bookmarks_conclusion[4] = "contract3";
            bookmarks_conclusion[5] = "date";
            bookmarks_conclusion[6] = "date2";
            bookmarks_conclusion[7] = "date3";
            bookmarks_conclusion[8] = "date4";
            bookmarks_conclusion[9] = "dest";
            bookmarks_conclusion[10] = "discount_dollar_price";
            bookmarks_conclusion[11] = "discount_dollar_price_write";
            bookmarks_conclusion[12] = "discount_price";
            bookmarks_conclusion[13] = "discount_price_write";
            bookmarks_conclusion[14] = "dollar";
            bookmarks_conclusion[15] = "dollar_price";
            bookmarks_conclusion[16] = "dollar_price_write";
            bookmarks_conclusion[17] = "employee_category";
            bookmarks_conclusion[18] = "employee_name2";
            bookmarks_conclusion[19] = "employee_name";
            bookmarks_conclusion[20] = "flat_nmbr";
            bookmarks_conclusion[21] = "floor";
            bookmarks_conclusion[22] = "floors_cnt";
            bookmarks_conclusion[23] = "gross_area";
            bookmarks_conclusion[24] = "komplex_addr";
            bookmarks_conclusion[25] = "limits";
            bookmarks_conclusion[26] = "price";
            bookmarks_conclusion[27] = "price_write";
            bookmarks_conclusion[28] = "purpose";
            bookmarks_conclusion[29] = "rights";
            bookmarks_conclusion[30] = "SNIP_area";
            bookmarks_conclusion[31] = "street_addr";
            bookmarks_conclusion[32] = "employee_SRO";

            texts_conclusion[0] = Convert.ToString(report.Apartment.RoomNumber);
            texts_conclusion[1] = client_in_padeg;
            texts_conclusion[2] = report.ReportNumber;
            texts_conclusion[3] = report.ReportNumber;
            texts_conclusion[4] = report.ReportNumber;
            texts_conclusion[5] = report.DateOfContract.ToShortDateString();
            texts_conclusion[6] = report.DateOfContract.ToLongDateString();
            texts_conclusion[7] = report.DateOfContract.ToLongDateString();
            texts_conclusion[8] = report.DateOfContract.ToLongDateString();
            texts_conclusion[9] = report.Apartment.Object.DestOfTheEvaluation;
            texts_conclusion[10] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_conclusion[11] = "";
            texts_conclusion[12] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_conclusion[13] = "";
            texts_conclusion[14] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_conclusion[15] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_conclusion[16] = "";
            texts_conclusion[17] = report.Employee.Position;
            texts_conclusion[18] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[19] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[20] = Convert.ToString(report.Apartment.Number);
            texts_conclusion[21] = Convert.ToString(report.Apartment.Floor);
            texts_conclusion[22] = Convert.ToString(report.Apartment.Floors);
            texts_conclusion[23] = Convert.ToString(report.Apartment.GrossArea);
            texts_conclusion[24] = report.Apartment.Home.ComplexNumber;
            texts_conclusion[25] = report.Apartment.Object.Restriction;
            texts_conclusion[26] = Convert.ToString(report.Apartment.Object.Price);
            texts_conclusion[27] = "";
            texts_conclusion[28] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_conclusion[29] = report.Apartment.Object.Property;
            texts_conclusion[30] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_conclusion[31] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name;
            texts_conclusion[32] = report.Employee.Membership;
        }

        public static void ArrayFillReport(string[] bookmarks_conclusion, string[] texts_conclusion, IReport report, string client_in_padeg,  int rod)
        {
            bookmarks_conclusion[0] = "apartment_type";
            bookmarks_conclusion[1] = "client_name";
            bookmarks_conclusion[2] = "contract";
            bookmarks_conclusion[3] = "contract2";
            bookmarks_conclusion[4] = "contract3";
            bookmarks_conclusion[5] = "date";
            bookmarks_conclusion[6] = "date2";
            bookmarks_conclusion[7] = "date3";
            bookmarks_conclusion[8] = "date4";
            bookmarks_conclusion[9] = "dest";
            bookmarks_conclusion[10] = "discount_dollar_price";
            bookmarks_conclusion[11] = "discount_dollar_price_write";
            bookmarks_conclusion[12] = "discount_price";
            bookmarks_conclusion[13] = "discount_price_write";
            bookmarks_conclusion[14] = "dollar";
            bookmarks_conclusion[15] = "dollar_price";
            bookmarks_conclusion[16] = "dollar_price_write";
            bookmarks_conclusion[17] = "employee_category";
            bookmarks_conclusion[18] = "employee_name2";
            bookmarks_conclusion[19] = "employee_name";
            bookmarks_conclusion[20] = "flat_nmbr";
            bookmarks_conclusion[21] = "floor";
            bookmarks_conclusion[22] = "floors_cnt";
            bookmarks_conclusion[23] = "gross_area";
            bookmarks_conclusion[24] = "komplex_addr";
            bookmarks_conclusion[25] = "limits";
            bookmarks_conclusion[26] = "price";
            bookmarks_conclusion[27] = "price_write";
            bookmarks_conclusion[28] = "purpose";
            bookmarks_conclusion[29] = "rights";
            bookmarks_conclusion[30] = "SNIP_area";
            bookmarks_conclusion[31] = "street_addr";
            bookmarks_conclusion[32] = "employee_SRO";

            texts_conclusion[0] = Convert.ToString(report.Apartment.RoomNumber);
            texts_conclusion[1] = client_in_padeg;
            texts_conclusion[2] = report.ReportNumber;
            texts_conclusion[3] = report.ReportNumber;
            texts_conclusion[4] = report.ReportNumber;
            texts_conclusion[5] = report.DateOfContract.ToShortDateString();
            texts_conclusion[6] = report.DateOfContract.ToLongDateString();
            texts_conclusion[7] = report.DateOfContract.ToLongDateString();
            texts_conclusion[8] = report.DateOfContract.ToLongDateString();
            texts_conclusion[9] = report.Apartment.Object.DestOfTheEvaluation;
            texts_conclusion[10] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_conclusion[11] = "";
            texts_conclusion[12] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_conclusion[13] = "";
            texts_conclusion[14] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_conclusion[15] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_conclusion[16] = "";
            texts_conclusion[17] = report.Employee.Position;
            texts_conclusion[18] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[19] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[20] = Convert.ToString(report.Apartment.Number);
            texts_conclusion[21] = Convert.ToString(report.Apartment.Floor);
            texts_conclusion[22] = Convert.ToString(report.Apartment.Floors);
            texts_conclusion[23] = Convert.ToString(report.Apartment.GrossArea);
            texts_conclusion[24] = report.Apartment.Home.ComplexNumber;
            texts_conclusion[25] = report.Apartment.Object.Restriction;
            texts_conclusion[26] = Convert.ToString(report.Apartment.Object.Price);
            texts_conclusion[27] = "";
            texts_conclusion[28] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_conclusion[29] = report.Apartment.Object.Property;
            texts_conclusion[30] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_conclusion[31] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name;
            texts_conclusion[32] = report.Employee.Membership;
        }

        public static void DocGenerate(string templateFileName, string reportFileName, string[] bookmarks, string[] text) 
        {
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();    // Создать документ Word
            object d = (object)templateFileName;                                                                            // Создать пустой объект

            Document MSWordDoc = wordApplication.Documents.Add(ref d);                                                      // Открыть документ по указанному в объекте адресу
            int array_len = 0;                      
            if (bookmarks.Length == text.Length)                                                                            // Сравнить длины массивов
                array_len = bookmarks.Length; 
            try
            {
                Paragraph pr = MSWordDoc.Paragraphs.Add();                                                                  // Начать документ
                Range rg;

                Bookmarks bk = MSWordDoc.Bookmarks;
                int bkcount = bk.Count;
                for (int i = 0; i < array_len; i++)                                                                         // Цикл выполняется только если длина массива закладок равено длине массиву заменяющих строк
                {
                    rg = bk[bookmarks[i]].Range;                                                                            // Выполнить замену

                    rg.Text = text[i];
                }
            }
            catch
            {
            }

            MSWordDoc.SaveAs2(reportFileName);                                                                              // Сохранить файл

            MSWordDoc.Close();                                                                                              // Закрыть файл

            wordApplication.Quit();                                                                                         // Закрыть приложение
        }



        public static void XLSGenerate(string templateFileName, string reportFileName, IReport report,  int rod) 
        {
            Microsoft.Office.Interop.Excel.Application excelAppl = new Microsoft.Office.Interop.Excel.Application();    // Создать документ Word
            object d = (object)templateFileName;                                                                            // Создать пустой объект

            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = excelAppl.Workbooks.Open(templateFileName);                                                      // Открыть документ по указанному в объекте адресу
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = excelAppl.Worksheets.get_Item(1);//ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;


            ObjWorkSheet.Cells[1, 2] = report.ReportNumber;
            ObjWorkSheet.Cells[2, 2] = report.DateOfContract.ToShortDateString(); ;
            ObjWorkSheet.Cells[3, 2] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            ObjWorkSheet.Cells[4, 2] = rod==1?"м":"ж";
            ObjWorkSheet.Cells[6, 2] = report.Apartment.RoomNumber.ToString()+"хкомнатная " + report.Apartment.Object.ObjectType + 
                                       " расположенная по адресу: "+
                                       report.Apartment.Home.Street.City.Name+", "+
                                       report.Apartment.Home.Street.Name+" "+
                                       report.Apartment.Home.Number+" ("+report.Apartment.Home.ComplexNumber+")"+", кв."+                                      
                                       report.Apartment.Number.ToString();
            ObjWorkSheet.Cells[7, 2] = "Собственник Объекта - "+report.Apartment.Object.Holders;
            ObjWorkSheet.Cells[8, 2] = report.ReportDate.ToLongDateString();
            ObjWorkSheet.Cells[9, 2] = report.Apartment.Object.PurposeOfTheEvaluation;
            ObjWorkSheet.Cells[14, 2] = //report.Client.Man.Document.Type 
                                        "паспорт"  + " серии " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            ObjWorkSheet.Cells[15, 2] = report.Client.Man.Surname + " " + report.Client.Man.Name + " " + report.Client.Man.Patronymic;
            ObjWorkSheet.Cells[17, 2] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            ObjWorkSheet.Cells[18, 2] = report.Employee.Insurance;

            ObjWorkBook.SaveAs(reportFileName);
            excelAppl.Quit();
    
    }
    
    }
}
