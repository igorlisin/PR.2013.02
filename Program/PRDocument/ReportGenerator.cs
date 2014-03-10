using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;

using PRInterfaces.Interfaces;

namespace PRDocument
{
    public class ReportGenerator
    {
        public static void Generate(IReport report, string reportTemplatesFolderPath, string reportsFolderPath)
        {
            string templateConcusReport = reportTemplatesFolderPath + @"\conclusion.dotx";                                        // Путь к шаблону договора

            string reportConclusName = reportsFolderPath + @"\conclusion " + DateTime.Now.ToString().Replace(":", ".") + @".docx"; // Путь к выходному файлу
            string[] bookmarks_conclusion = new string[16];                                                                       // Массив закладок
            string[] texts_conclusion = new string[16];                                                                           // Массив вставляемых вместо закладок строк
            bookmarks_conclusion[0] = "apartment_type";
            bookmarks_conclusion[1] = "client_name";
            bookmarks_conclusion[2] = "contract";
            bookmarks_conclusion[3] = "contract2";
            bookmarks_conclusion[4] = "contract3";
            bookmarks_conclusion[5] = "date";
            bookmarks_conclusion[6] = "date2";
            bookmarks_conclusion[7] = "date3";
            bookmarks_conclusion[8] = "employee_category";
            bookmarks_conclusion[9] = "employee_name";
            bookmarks_conclusion[10] = "flat_nmbr";
            bookmarks_conclusion[11] = "floor";
            bookmarks_conclusion[12] = "floors_cnt";
            bookmarks_conclusion[13] = "gross_area";
            bookmarks_conclusion[14] = "komplex_addr";
            bookmarks_conclusion[15] = "street_addr";

            texts_conclusion[0] = Convert.ToString(report.Apartment.RoomNumber);
            texts_conclusion[1] = report.Client.Man.Surname + " " + report.Client.Man.Name + " " + report.Client.Man.Patronymic;
            texts_conclusion[2] = report.ReportNumber;
            texts_conclusion[3] = report.ReportNumber;
            texts_conclusion[4] = report.ReportNumber;
            texts_conclusion[5] = report.DateOfContract.ToShortDateString();
            texts_conclusion[6] = report.DateOfContract.ToLongDateString();
            texts_conclusion[7] = report.DateOfContract.ToLongDateString();
            texts_conclusion[8] = report.Employee.Position;
            texts_conclusion[9] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[10] = Convert.ToString(report.Apartment.Number);
            texts_conclusion[11] = Convert.ToString(report.Apartment.Floor);
            texts_conclusion[12] = "666" ;
            texts_conclusion[13] = Convert.ToString(report.Apartment.GrossArea);
            texts_conclusion[14] = report.Apartment.Home.ComplexNumber;
            texts_conclusion[15] = report.Apartment.Home.Street.City.Name +", " +report.Apartment.Home.Street.Name;


            DocGenerate(templateConcusReport, reportConclusName, bookmarks_conclusion, texts_conclusion);                                                      // Сгенерировать отчет для договора


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
    }
}
