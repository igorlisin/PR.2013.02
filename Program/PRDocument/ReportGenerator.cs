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
            string templateConcusReport = reportTemplatesFolderPath + @"\conclusion.dotx";                                        // Путь к шаблону договора

            string reportConclusName = reportsFolderPath + @"\conclusion " + DateTime.Now.ToString().Replace(":", ".") + @".docx"; // Путь к выходному файлу
            string[] bookmarks_conclusion = new string[33];                                                                       // Массив закладок
            string[] texts_conclusion = new string[33];                                                                           // Массив вставляемых вместо закладок строк
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

            string client_in_padeg = null;
            int rod = 0;
            client_in_padeg = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, report.Client.Man.Name, report.Client.Man.Patronymic, BLL.Declension.DeclensionCase.Tvorit);
            rod = BLL.Declension.DeclensionBLL.GetGender(report.Client.Man.Patronymic);


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
            texts_conclusion[10] = Convert.ToString(report.Apartment.Object.Price * (1-report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_conclusion[11] = "";
            texts_conclusion[12] = Convert.ToString(report.Apartment.Object.Price * (1-report.Apartment.Object.Discount));
            texts_conclusion[13] = "";
            texts_conclusion[14] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_conclusion[15] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_conclusion[16] = "";
            texts_conclusion[17] = report.Employee.Position;
            texts_conclusion[18] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[19] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[20] = Convert.ToString(report.Apartment.Number);
            texts_conclusion[21] = Convert.ToString(report.Apartment.Floor);
            texts_conclusion[22] = Convert.ToString(report.Apartment.Floors) ;
            texts_conclusion[23] = Convert.ToString(report.Apartment.GrossArea);
            texts_conclusion[24] = report.Apartment.Home.ComplexNumber;
            texts_conclusion[25] = report.Apartment.Object.Restriction;
            texts_conclusion[26] = Convert.ToString(report.Apartment.Object.Price);
            texts_conclusion[27] = "";
            texts_conclusion[28] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_conclusion[29] = report.Apartment.Object.Property;
            texts_conclusion[30] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_conclusion[31] = report.Apartment.Home.Street.City.Name +", " +report.Apartment.Home.Street.Name;
            texts_conclusion[32] = report.Employee.Membership;

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

        //#region Padeg.dll functions and structs
        //[DllImport("Padeg.dll", EntryPoint = "GetFIOPadegAS")]
        //private static extern Int32 decGetFIOPadegAS(IntPtr surname, IntPtr name, IntPtr patronimic,
        //                                             Int32 padeg, IntPtr result, ref Int32 resultLength);
        //#endregion Padeg.dll functions and structs
    
    }
}
