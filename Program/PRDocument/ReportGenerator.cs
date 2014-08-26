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
using Slepov.Russian.СуммаПрописью;

using Microsoft.Office.Interop.Word;


using PRInterfaces.Interfaces;

namespace PRDocument
{
    public class ReportGenerator
    {
        /// <summary>
        /// Поле. Массив картинок квартиры
        /// </summary>
        private static IPicture[] pics;
        /// <summary>
        /// Поле. Массив картинок схем квариры
        /// </summary>
        private static IPicture[] apartmentMaps;
        /// <summary>
        /// Поле. Массив сканов документов
        /// </summary>
        private static IPicture[] documents;
        /// <summary>
        /// Поле. Массив скриншотов карт
        /// </summary>
        private static IPicture[] maps;
        /// <summary>
        /// Поле. Массив фотографий
        /// </summary>
        private static IPicture[] photo;
        /// <summary>
        /// Поле. Массив скриншотов
        /// </summary>
        private static IPicture[] screenshot;


       //Процедура формирования отчетов
        public static void Generate(IReport report, string reportTemplatesFolderPath, string reportsFolderPath)
        {
            string templateConclusReport = reportTemplatesFolderPath + @"\conclusion.dotx";                                        // Путь к шаблону заключения
            string reportConclusName = reportsFolderPath + @"\conclusion " + DateTime.Now.ToString().Replace(":", ".") + @".docx"; // Путь к выходному файлу

            string tempContractReport = reportTemplatesFolderPath + @"\contract.xltx";                                          // Путь к шаблону договора
            string reportContractName = reportsFolderPath + @"\contract " + DateTime.Now.ToString().Replace(":", ".") + @".xlsx";// Путь к выходному файлу

            string tempReport = reportTemplatesFolderPath + @"\report.dotx";                                            // Путь к шаблону отчета
            string reportName = reportsFolderPath + @"\report " + DateTime.Now.ToString().Replace(":", ".") + @".docx";// Путь к выходному файлу

            string[] bookmarks_conclusion = new string[50];                                                                       // Массив закладок
            string[] texts_conclusion = new string[50];                                                                           // Массив вставляемых вместо закладок строк

            string[] bookmarks_report = new string[437];                                                                       // Массив закладок
            string[] texts_report = new string[437];                                                                           // Массив вставляемых вместо закладок строк

            string client_in_padeg = null;      //склонение ФИО па падежам
            int rod = 0;
            client_in_padeg = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, 
                                                                                report.Client.Man.Name, 
                                                                                report.Client.Man.Patronymic, 
                                                                                BLL.Declension.DeclensionCase.Tvorit);//получить ФИО в творительном падеже
            rod = BLL.Declension.DeclensionBLL.GetGender(report.Client.Man.Patronymic); // Определить пол по отчеству

            string client_in_padeg_dat = null;
            client_in_padeg_dat = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, 
                                                    report.Client.Man.Name,     
                                                    report.Client.Man.Patronymic, 
                                                    BLL.Declension.DeclensionCase.Datel);//ФИО клиента в дательном падеже

            ArrayFillConcusion(bookmarks_conclusion, texts_conclusion, report, client_in_padeg);        //Заполнить массив закладок для файла Заключение
            ArrayFillReport(bookmarks_report, texts_report, report, client_in_padeg_dat);              //Заполнить массив закладок для файла Отчет 

            DocGenerate(templateConclusReport, reportConclusName, bookmarks_conclusion, texts_conclusion);                            // Сгенерировать отчет Заключение
            DocGenerate(tempReport, reportName, bookmarks_report, texts_report);                                                      // Сгенерировать отчет Отчет
            XLSGenerate(tempContractReport, reportContractName, report, rod);                                                         // Генерировать отчет Договор


        }

//Процедура заполнеия закладок и текстов их замен для отчета Заключение
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

            //Шаблоны написания сумм в валютах
            Валюта rouble = new Валюта(
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "рубль", "рубля", "рублей"),
                            new ЕдиницаИзмерения(РодЧисло.Женский, "копейка", "копейки", "копеек"));
            Валюта dollar = new Валюта(
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "доллар США", "доллара США", "долларов США"),
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "цент", "цента", "центов"));
            Валюта empty = new Валюта(
                           new ЕдиницаИзмерения(РодЧисло.Мужской, "-", "-", "-"),
                           new ЕдиницаИзмерения(РодЧисло.Мужской, "", "", ""));
            //Сумма прописью без указания валюты
            string writePrice = Сумма.Пропись(report.Apartment.Object.Price, empty);
            //Сумма в долларах прописью без указания валюты 
            string writePriceDollar = Сумма.Пропись(report.Apartment.Object.Price / report.Apartment.Object.Dollar, empty);
            //Сумма с уценкой прописью без указания валюты
            string writePriceDiscount = Сумма.Пропись(report.Apartment.Object.Discount, empty);
            //Сумма с уценкой прописью в долларах без указания валюты
            string witePriceDiscountDollar = Сумма.Пропись(report.Apartment.Object.Discount / report.Apartment.Object.Dollar, empty);

            //Массив замен
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
            texts_conclusion[10] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);//сумма с уценкой вдолларах
            texts_conclusion[11] = witePriceDiscountDollar; 
            texts_conclusion[12] = Convert.ToString(report.Apartment.Object.Discount);//сумма с уценкой
            texts_conclusion[13] = writePriceDiscount;
            texts_conclusion[14] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_conclusion[15] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);//сумма в долларах
            texts_conclusion[16] = writePriceDollar;
            texts_conclusion[17] = report.Employee.Position;
            texts_conclusion[18] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[19] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_conclusion[20] = Convert.ToString(report.Apartment.Number);
            texts_conclusion[21] = Convert.ToString(report.Apartment.Floor);
            texts_conclusion[22] = Convert.ToString(report.Apartment.Home.Floors);
            texts_conclusion[23] = Convert.ToString(report.Apartment.GrossArea);
            texts_conclusion[24] = report.Apartment.Home.ComplexNumber;
            texts_conclusion[25] = report.Apartment.Object.Restriction;
            texts_conclusion[26] = Convert.ToString(report.Apartment.Object.Price);
            texts_conclusion[27] = writePrice;  //стоимость прописью
            texts_conclusion[28] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_conclusion[29] = report.Apartment.Object.Property;
            texts_conclusion[30] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_conclusion[31] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name;
            texts_conclusion[32] = report.Employee.Membership;
        }

        // Заполнить массив картинок
        public static void FillPicturesArray(IReport report)
        {
            //инициализация массивов
            pics = report.Apartment.Pictures.ToArray();
            apartmentMaps = new IPicture[13];
            documents = new IPicture[13];
            maps = new IPicture[13];
            photo = new IPicture[25];
            screenshot = new IPicture[13];

            //счетчики
            int am = 0;
            int d = 0;
            int m = 0;
            int p = 0;
            int ss = 0;


            for (int j = 0; j < report.Apartment.Pictures.Count; j++)       // Заполняем массивы в зависимости от типа рисунка
            {
                if (pics[j].Type == PRInterfaces.Enumerations.PictureTypes.appartmentMap)
                {
                    apartmentMaps[am] = report.Apartment.Pictures.ToArray()[j];
                    am++;
                }
                if (pics[j].Type == PRInterfaces.Enumerations.PictureTypes.document)
                {
                    documents[d] = report.Apartment.Pictures.ToArray()[j];
                    d++;
                }
                if (pics[j].Type == PRInterfaces.Enumerations.PictureTypes.map)
                {
                    maps[m] = report.Apartment.Pictures.ToArray()[j];
                    m++;
                }
                if (pics[j].Type == PRInterfaces.Enumerations.PictureTypes.photo)
                {
                    photo[p] = report.Apartment.Pictures.ToArray()[j];
                    p++;
                }
                if (pics[j].Type == PRInterfaces.Enumerations.PictureTypes.screenshot)
                {
                    screenshot[ss] = report.Apartment.Pictures.ToArray()[j];
                    ss++;
                }
            }
        }

        //Процедура формирования закладок и текстов их замен в отчете Отчет
        public static void ArrayFillReport(string[] bookmarks_report, string[] texts_report, IReport report, string client_in_padeg)
        {
            Валюта rouble = new Валюта(
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "рубль", "рубля", "рублей"),
                            new ЕдиницаИзмерения(РодЧисло.Женский, "копейка", "копейки", "копеек"));
            Валюта dollar = new Валюта(
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "доллар США", "доллара США", "долларов США"),
                            new ЕдиницаИзмерения(РодЧисло.Мужской, "цент", "цента", "центов"));
            Валюта empty = new Валюта(
                           new ЕдиницаИзмерения(РодЧисло.Мужской, "-", "-", "-"),
                           new ЕдиницаИзмерения(РодЧисло.Мужской, "", "", ""));
            //Сумма прописью без указания валюты
            string writePrice = Сумма.Пропись(report.Apartment.Object.Price, empty);
            //Сумма в долларах прописью без указания валюты 
            string writePriceDollar = Сумма.Пропись(report.Apartment.Object.Price / report.Apartment.Object.Dollar, empty);
            //Сумма с уценкой прописью без указания валюты
            string writePriceDiscount = Сумма.Пропись(report.Apartment.Object.Discount, empty);
            //Сумма с уценкой прописью в долларах без указания валюты
            string witePriceDiscountDollar = Сумма.Пропись(report.Apartment.Object.Discount / report.Apartment.Object.Dollar, empty);

            float k_sdv; //коэффициент стоимости денег во времени
            float r12;//требуемая доходность инвестирования в объект оценки в год
            double r;//требуемая доходность инвестирования в объект оценки 
            float risks;//коэффициент по рискам
            double tm; //разница во времени при продаже с рыночной ценой и ликвидационной

            risks = (report.Apartment.Object.AcceleratedWear + report.Apartment.Object.BadManagment +
                report.Apartment.Object.ConcurentsUp + report.Apartment.Object.Criminal +
                report.Apartment.Object.EconSituationDown + report.Apartment.Object.ExtremalSituation +
                report.Apartment.Object.FinanceChecking + report.Apartment.Object.LowChange +
                report.Apartment.Object.NoRentalMoney + report.Apartment.Object.NotCorrect);
            r12 = report.Apartment.Object.NoRisk + risks/10 + (report.Apartment.Object.NoRisk / 12)*report.Apartment.Object.T_r + report.Apartment.Object.InvestManage;
            r = r12 / 12;
            tm = report.Apartment.Object.T_r - report.Apartment.Object.T_l;
            k_sdv = Convert.ToSingle(1 / (System.Math.Pow((1 + r/100) , tm)));


            //Массив квартир сравнения
            IComparisonApart[] ca;  
            ca = report.Apartment.ComparApart.ToArray();

            bookmarks_report[0] = "address_client";
            bookmarks_report[1] = "address_street";
            bookmarks_report[2] = "address_street10";
            bookmarks_report[3] = "address_street2";
            bookmarks_report[4] = "address_street3";
            bookmarks_report[5] = "address_street4";
            bookmarks_report[6] = "address_street5";
            bookmarks_report[7] = "address_street6";
            bookmarks_report[8] = "address_street7";
            bookmarks_report[9] = "address_street8";
            bookmarks_report[10] = "address_street9";
            bookmarks_report[11] = "adress_complex";
            bookmarks_report[12] = "adress_complex2";
            bookmarks_report[13] = "adress_complex3";
            bookmarks_report[14] = "adress_complex4";
            bookmarks_report[15] = "adress_complex5";
            bookmarks_report[16] = "adress_complex6";
            bookmarks_report[17] = "apartment_type";
            bookmarks_report[18] = "apartment_type2";
            bookmarks_report[19] = "apartment_type3";
            bookmarks_report[20] = "apartment_type4";
            bookmarks_report[21] = "apartment_type5";
            bookmarks_report[22] = "apartment_type6";
            bookmarks_report[23] = "apartment_type7";
            bookmarks_report[24] = "apartment_type8";
            bookmarks_report[25] = "apartment_type9";
            bookmarks_report[26] = "area";
            bookmarks_report[27] = "area2";
            bookmarks_report[28] = "area3";
            bookmarks_report[29] = "area_snip";
            bookmarks_report[30] = "area_snip2";
            bookmarks_report[31] = "attic";
            bookmarks_report[32] = "balkon";
            bookmarks_report[33] = "bank_list";
            bookmarks_report[34] = "basement";
            bookmarks_report[35] = "basement_wear";
            bookmarks_report[36] = "bath_ceiling";
            bookmarks_report[37] = "bath_floor";
            bookmarks_report[38] = "bath_wall";
            bookmarks_report[39] = "bti_ok";
            bookmarks_report[40] = "ceiling_state";
            bookmarks_report[41] = "ceiling_type";
            bookmarks_report[42] = "ceiling_wear";
            bookmarks_report[43] = "ceilingl_kitchen_type";
            bookmarks_report[44] = "ceilingl_living_type";
            bookmarks_report[45] = "ceilng_corrd_type";
            bookmarks_report[46] = "client";
            bookmarks_report[47] = "client2";
            bookmarks_report[48] = "client3";
            bookmarks_report[49] = "client4";
            bookmarks_report[50] = "client5";
            bookmarks_report[51] = "client6";
            bookmarks_report[52] = "client_document";
            bookmarks_report[53] = "closest_stop";
            bookmarks_report[54] = "concerge";
            bookmarks_report[55] = "data_eval";
            bookmarks_report[56] = "data_eval2";
            bookmarks_report[57] = "data_eval3";
            bookmarks_report[58] = "data_eval4";
            bookmarks_report[59] = "data_eval5";
            bookmarks_report[60] = "data_eval6";
            bookmarks_report[61] = "data_eval7";
            bookmarks_report[62] = "data_report";
            bookmarks_report[63] = "data_report2";
            bookmarks_report[64] = "data_report3";
            bookmarks_report[65] = "data_report4";
            bookmarks_report[66] = "price10";
            bookmarks_report[67] = "dest";
            bookmarks_report[68] = "devices_4_system";
            bookmarks_report[69] = "discount";
            bookmarks_report[70] = "discount2";
            bookmarks_report[71] = "district";
            bookmarks_report[72] = "document";
            bookmarks_report[73] = "dollar";
            bookmarks_report[74] = "dollar2";
            bookmarks_report[75] = "dollar3";
            bookmarks_report[76] = "dollar4";
            bookmarks_report[77] = "domofon";
            bookmarks_report[78] = "doors_condition";
            bookmarks_report[79] = "employee";
            bookmarks_report[80] = "employee2";
            bookmarks_report[81] = "employee3";
            bookmarks_report[82] = "employee4";
            bookmarks_report[83] = "employee5";
            bookmarks_report[84] = "employee6";
            bookmarks_report[85] = "employee7";
            bookmarks_report[86] = "employee_document";
            bookmarks_report[87] = "employee_edu";
            bookmarks_report[88] = "employee_edu2";
            bookmarks_report[89] = "employee_insur";
            bookmarks_report[90] = "employee_insur2";
            bookmarks_report[91] = "employee_insur3";
            bookmarks_report[92] = "employee_insur4";
            bookmarks_report[93] = "employee_pos";
            bookmarks_report[94] = "employee_qnt";
            bookmarks_report[95] = "employee_sro";
            bookmarks_report[96] = "employee_sro2";
            bookmarks_report[97] = "employee_sro3";
            bookmarks_report[98] = "employee_sro4";
            bookmarks_report[99] = "employee_stag";
            bookmarks_report[100] = "employee_stag2";
            bookmarks_report[101] = "extend_area";
            bookmarks_report[102] = "extended_factors";
            bookmarks_report[103] = "flat_cond";
            bookmarks_report[104] = "flat_height";
            bookmarks_report[105] = "flats_in_floor";
            bookmarks_report[106] = "floor";
            bookmarks_report[107] = "floor2";
            bookmarks_report[108] = "floor_corrd_type";
            bookmarks_report[109] = "floor_kitchen_type";
            bookmarks_report[110] = "floor_living_type";
            bookmarks_report[111] = "floors";
            bookmarks_report[112] = "floors2";
            bookmarks_report[113] = "garbage";
            bookmarks_report[114] = "heating_cond";
            bookmarks_report[115] = "heating_pipe";
            bookmarks_report[116] = "heating_radiator";
            bookmarks_report[117] = "heating_type";
            bookmarks_report[118] = "holders";
            bookmarks_report[119] = "holders2";
            bookmarks_report[120] = "holders_documents";
            bookmarks_report[121] = "holders_documents2";
            bookmarks_report[122] = "hospital_list";
            bookmarks_report[123] = "house_wear";
            bookmarks_report[124] = "house_wear2";
            bookmarks_report[125] = "house_year";
            bookmarks_report[126] = "is_defect";
            bookmarks_report[127] = "is_defect2";
            bookmarks_report[128] = "is_pereplan";
            bookmarks_report[129] = "kanal_cond";
            bookmarks_report[130] = "kanal_devices";
            bookmarks_report[131] = "kanal_pipe";
            bookmarks_report[132] = "kapremont";
            bookmarks_report[133] = "kapremont_year";
            bookmarks_report[134] = "kapremont_year2";
            bookmarks_report[135] = "kinder_list";
            bookmarks_report[136] = "kitchen_area";
            bookmarks_report[137] = "lift";
            bookmarks_report[138] = "limits";
            bookmarks_report[139] = "limits2";
            bookmarks_report[140] = "living_area";
            bookmarks_report[141] = "living_area2";
            bookmarks_report[142] = "local1";
            bookmarks_report[143] = "local2";
            bookmarks_report[144] = "main_door_type";
            bookmarks_report[145] = "object_type";
            bookmarks_report[146] = "object_type2";
            bookmarks_report[147] = "object_type3";
            bookmarks_report[148] = "object_type4";
            bookmarks_report[149] = "object_type5";
            bookmarks_report[150] = "object_type6";
            bookmarks_report[151] = "parking";
            bookmarks_report[152] = "pharmacy_list";
            bookmarks_report[153] = "plan_now";
            bookmarks_report[154] = "posible_2_register";
            bookmarks_report[155] = "prestig";
            bookmarks_report[156] = "price";
            bookmarks_report[157] = "price2";
            bookmarks_report[158] = "price3";
            bookmarks_report[159] = "price4";
            bookmarks_report[160] = "price5";
            bookmarks_report[161] = "price6";
            bookmarks_report[162] = "price7";
            bookmarks_report[163] = "price8";
            bookmarks_report[164] = "price9";
            bookmarks_report[165] = "price8_write";
            bookmarks_report[166] = "price_discount";
            bookmarks_report[167] = "price_discount2";
            bookmarks_report[168] = "price_discount3";
            bookmarks_report[169] = "price_discount4";
            bookmarks_report[170] = "price_discount5";
            bookmarks_report[171] = "price_discount6";
            bookmarks_report[172] = "price_discount7";
            bookmarks_report[173] = "price_discount5_write";
            bookmarks_report[174] = "price_discount6_write";
            bookmarks_report[175] = "price_discount_dollar";
            bookmarks_report[176] = "price_discount_dollar2";
            bookmarks_report[177] = "price_discount_dollar3";
            bookmarks_report[178] = "price_discount_dollar4";
            bookmarks_report[179] = "price_discount_dollar5";
            bookmarks_report[180] = "price_discount_dollar4_write";
            bookmarks_report[181] = "price_discount_write";
            bookmarks_report[182] = "price_dollar";
            bookmarks_report[183] = "price_dollar2";
            bookmarks_report[184] = "price_dollar3";
            bookmarks_report[185] = "price_dollar4";
            bookmarks_report[186] = "price_dollar5";
            bookmarks_report[187] = "price_dollar_write";
            bookmarks_report[188] = "price_dollar_write2";
            bookmarks_report[189] = "price_write";
            bookmarks_report[190] = "price_write2";
            bookmarks_report[191] = "price_write3";
            bookmarks_report[192] = "prom_distance";
            bookmarks_report[193] = "purpose";
            bookmarks_report[194] = "repair";
            bookmarks_report[195] = "repair_quality";
            bookmarks_report[196] = "report_data2";
            bookmarks_report[197] = "report_data3";
            bookmarks_report[198] = "report_data4";
            bookmarks_report[199] = "report_data5";
            bookmarks_report[200] = "report_number";
            bookmarks_report[201] = "report_number2";
            bookmarks_report[202] = "report_number3";
            bookmarks_report[203] = "report_number4";
            bookmarks_report[204] = "report_number5";
            bookmarks_report[205] = "report_number6";
            bookmarks_report[206] = "rest_list";
            bookmarks_report[207] = "rights";
            bookmarks_report[208] = "rights2";
            bookmarks_report[209] = "roof_cond";
            bookmarks_report[210] = "room_door_type";
            bookmarks_report[211] = "room_type";
            bookmarks_report[212] = "sanuz_comb";
            bookmarks_report[213] = "sanuzel";
            bookmarks_report[214] = "school_list";
            bookmarks_report[215] = "separate";
            bookmarks_report[216] = "service_list";
            bookmarks_report[217] = "slabotoch";
            bookmarks_report[218] = "social_list";
            bookmarks_report[219] = "sqm_price";
            bookmarks_report[220] = "sqm_price2";
            bookmarks_report[221] = "sqm_price_dollar";
            bookmarks_report[222] = "stop_distance";
            bookmarks_report[223] = "data_spravka";
            bookmarks_report[224] = "technic_list";
            bookmarks_report[225] = "toilet_ceiling";
            bookmarks_report[226] = "toilet_floor";
            bookmarks_report[227] = "toilet_wall";
            bookmarks_report[228] = "trade_list";
            bookmarks_report[229] = "transport_type";
            bookmarks_report[230] = "vid";
            bookmarks_report[231] = "wall_corrd_type";
            bookmarks_report[232] = "wall_kitchen_type";
            bookmarks_report[233] = "wall_living_type";
            bookmarks_report[234] = "wall_type";
            bookmarks_report[235] = "wall_type2";
            bookmarks_report[236] = "wall_type3";
            bookmarks_report[237] = "wall_type4";
            bookmarks_report[238] = "wall_wear";
            bookmarks_report[239] = "wall_wear2";
            bookmarks_report[240] = "water_cond";
            bookmarks_report[241] = "water_razv";
            bookmarks_report[242] = "water_stoyak";
            bookmarks_report[243] = "window_cond";
            bookmarks_report[244] = "window_type";
            bookmarks_report[245] = "year";
            bookmarks_report[246] = "year2";
            bookmarks_report[247] = "home_age";
            bookmarks_report[248] = "image1_comment";
            bookmarks_report[249] = "image2_comment";
            bookmarks_report[250] = "image3_comment";
            bookmarks_report[251] = "image4_comment";
            bookmarks_report[252] = "image5_comment";
            bookmarks_report[253] = "image6_comment";
            bookmarks_report[254] = "image7_comment";
            bookmarks_report[255] = "image8_comment";
            bookmarks_report[256] = "image9_comment";
            bookmarks_report[257] = "image10_comment";
            bookmarks_report[258] = "image1";                          // Фото
            bookmarks_report[259] = "image2";                          // Фото
            bookmarks_report[260] = "image3";                          // Фото
            bookmarks_report[261] = "image4";                          // Фото
            bookmarks_report[262] = "image5";                          // Фото
            bookmarks_report[263] = "image6";                          // Фото
            bookmarks_report[264] = "image7";                          // Фото
            bookmarks_report[265] = "image8";                          // Фото
            bookmarks_report[266] = "image9";                          // Фото
            bookmarks_report[267] = "image10";                          // Схема квартиры
            bookmarks_report[268] = "image11";                          // Скан документов
            bookmarks_report[269] = "image12";                          // Скан документов
            bookmarks_report[270] = "image13";                          // Скан документов
            bookmarks_report[271] = "image_map1";
            bookmarks_report[272] = "image_map2";

            bookmarks_report[273] = "k_Balkon1";
            bookmarks_report[274] = "k_Balkon2";
            bookmarks_report[275] = "k_Balkon3";
            bookmarks_report[276] = "k_Balkon4";
            bookmarks_report[277] = "k_Balkon5";
            bookmarks_report[278] = "k_Floor1";
            bookmarks_report[279] = "k_Floor2";
            bookmarks_report[280] = "k_Floor3";
            bookmarks_report[281] = "k_Floor4";
            bookmarks_report[282] = "k_Floor5";
            bookmarks_report[283] = "k_Floors1";
            bookmarks_report[284] = "k_Floors2";
            bookmarks_report[285] = "k_Floors3";
            bookmarks_report[286] = "k_Floors4";
            bookmarks_report[287] = "k_Floors5";
            bookmarks_report[288] = "k_FullPrc1";
            bookmarks_report[289] = "k_FullPrc2";
            bookmarks_report[290] = "k_FullPrc3";
            bookmarks_report[291] = "k_FullPrc4";
            bookmarks_report[292] = "k_FullPrc5";
            bookmarks_report[293] = "k_RemontPrice1";
            bookmarks_report[294] = "k_RemontPrice2";
            bookmarks_report[295] = "k_RemontPrice3";
            bookmarks_report[296] = "k_RemontPrice4";
            bookmarks_report[297] = "k_RemontPrice5";
            bookmarks_report[298] = "k_Sanuzel1";
            bookmarks_report[299] = "k_Sanuzel2";
            bookmarks_report[300] = "k_Sanuzel3";
            bookmarks_report[301] = "k_Sanuzel4";
            bookmarks_report[302] = "k_Sanuzel5";
            bookmarks_report[303] = "k_SKitchen1";
            bookmarks_report[304] = "k_SKitchen2";
            bookmarks_report[305] = "k_SKitchen3";
            bookmarks_report[306] = "k_SKitchen4";
            bookmarks_report[307] = "k_SKitchen5";
            bookmarks_report[308] = "k_sqmCorrPrice1";
            bookmarks_report[309] = "k_sqmCorrPrice2";
            bookmarks_report[310] = "k_sqmCorrPrice3";
            bookmarks_report[311] = "k_sqmCorrPrice4";
            bookmarks_report[312] = "k_sqmCorrPrice5";
            bookmarks_report[313] = "k_sqmPrcPrice1";
            bookmarks_report[314] = "k_sqmPrcPrice2";
            bookmarks_report[315] = "k_sqmPrcPrice3";
            bookmarks_report[316] = "k_sqmPrcPrice4";
            bookmarks_report[317] = "k_sqmPrcPrice5";
            bookmarks_report[318] = "k_Torg1";
            bookmarks_report[319] = "k_Torg2";
            bookmarks_report[320] = "k_Torg3";
            bookmarks_report[321] = "k_Torg4";
            bookmarks_report[322] = "k_Torg5";
            bookmarks_report[323] = "k_Type1";
            bookmarks_report[324] = "k_Type2";
            bookmarks_report[325] = "k_Type3";
            bookmarks_report[326] = "k_Type4";
            bookmarks_report[327] = "k_Type5";
            bookmarks_report[328] = "k_Vid1";
            bookmarks_report[329] = "k_Vid2";
            bookmarks_report[330] = "k_Vid3";
            bookmarks_report[331] = "k_Vid4";
            bookmarks_report[332] = "k_Vid5";
            bookmarks_report[332] = "k_Vid5";
            bookmarks_report[333] = "k_aBalcon0";
            bookmarks_report[334] = "k_aBalcon1";
            bookmarks_report[335] = "k_aBalcon2";
            bookmarks_report[336] = "k_aBalcon3";
            bookmarks_report[337] = "k_aBalcon4";
            bookmarks_report[338] = "k_aBalcon5";
            bookmarks_report[339] = "k_addr0";
            bookmarks_report[340] = "k_addr1";
            bookmarks_report[341] = "k_addr2";
            bookmarks_report[342] = "k_addr3";
            bookmarks_report[343] = "k_addr4";
            bookmarks_report[344] = "k_addr5";
            bookmarks_report[345] = "k_addr00";
            bookmarks_report[346] = "k_addr01";
            bookmarks_report[347] = "k_addr02";
            bookmarks_report[348] = "k_addr03";
            bookmarks_report[349] = "k_addr04";
            bookmarks_report[350] = "k_addr05";
            bookmarks_report[351] = "k_aFloor0";
            bookmarks_report[352] = "k_aFloor1";
            bookmarks_report[353] = "k_aFloor2";
            bookmarks_report[354] = "k_aFloor3";
            bookmarks_report[355] = "k_aFloor4";
            bookmarks_report[356] = "k_aFloor5";
            bookmarks_report[357] = "k_aFloors0";
            bookmarks_report[358] = "k_aFloors1";
            bookmarks_report[359] = "k_aFloors2";
            bookmarks_report[360] = "k_aFloors3";
            bookmarks_report[361] = "k_aFloors4";
            bookmarks_report[362] = "k_aFloors5";
            bookmarks_report[363] = "k_area0";
            bookmarks_report[364] = "k_area1";
            bookmarks_report[365] = "k_area2";
            bookmarks_report[366] = "k_area3";
            bookmarks_report[367] = "k_area4";
            bookmarks_report[368] = "k_area5";
            bookmarks_report[369] = "k_aSKitchen0";
            bookmarks_report[370] = "k_aSKitchen1";
            bookmarks_report[371] = "k_aSKitchen2";
            bookmarks_report[372] = "k_aSKitchen3";
            bookmarks_report[373] = "k_aSKitchen4";
            bookmarks_report[374] = "k_aSKitchen5";
            bookmarks_report[375] = "k_Dollar";
            bookmarks_report[376] = "k_DollarPrice0";
            bookmarks_report[377] = "k_Price0";
            bookmarks_report[378] = "k_Rooms0";
            bookmarks_report[379] = "k_Rooms1";
            bookmarks_report[380] = "k_Rooms2";
            bookmarks_report[381] = "k_Rooms3";
            bookmarks_report[382] = "k_Rooms4";
            bookmarks_report[383] = "k_Rooms5";
            bookmarks_report[384] = "k_SanType0";
            bookmarks_report[385] = "k_SanType1";
            bookmarks_report[386] = "k_SanType2";
            bookmarks_report[387] = "k_SanType3";
            bookmarks_report[388] = "k_SanType4";
            bookmarks_report[389] = "k_SanType5";
            bookmarks_report[390] = "k_wall0";
            bookmarks_report[391] = "k_wall1";
            bookmarks_report[392] = "k_wall2";
            bookmarks_report[393] = "k_wall3";
            bookmarks_report[394] = "k_wall4";
            bookmarks_report[395] = "k_wall5";
            bookmarks_report[396] = "k_sqmPrice0";
            bookmarks_report[397] = "k_sqmPrice1";
            bookmarks_report[398] = "k_sqmPrice2";
            bookmarks_report[399] = "k_sqmPrice3";
            bookmarks_report[400] = "k_sqmPrice4";
            bookmarks_report[401] = "k_sqmPrice5";
            bookmarks_report[402] = "k_seller1";
            bookmarks_report[403] = "k_seller2";
            bookmarks_report[404] = "k_seller3";
            bookmarks_report[405] = "k_seller4";
            bookmarks_report[406] = "k_seller5";
            bookmarks_report[407] = "k_Price1";
            bookmarks_report[408] = "k_Price2";
            bookmarks_report[409] = "k_Price3";
            bookmarks_report[410] = "k_Price4";
            bookmarks_report[411] = "k_Price5";

            bookmarks_report[412] = "econSituation";
            bookmarks_report[413] = "concurUp";
            bookmarks_report[414] = "LowsChange";
            bookmarks_report[415] = "extremalSituations";
            bookmarks_report[416] = "AcceleratedWear";
            bookmarks_report[417] = "NoRental";
            bookmarks_report[418] = "Managment";
            bookmarks_report[419] = "Criminal";
            bookmarks_report[420] = "FinChecks";
            bookmarks_report[421] = "NotCorrect";
            bookmarks_report[422] = "RiskSumm";
            bookmarks_report[423] = "RiskPrc";
            bookmarks_report[424] = "NoRisk";
            bookmarks_report[425] = "RiskPrc2";
            bookmarks_report[426] = "NoRisk1m";
            bookmarks_report[427] = "InvestManag";
            bookmarks_report[428] = "InvestSalary";
            bookmarks_report[429] = "K_el";
            bookmarks_report[430] = "price11";
            bookmarks_report[431] = "InvestSalary2";
            bookmarks_report[432] = "InvestSalary1m";
            bookmarks_report[433] = "t_l";
            bookmarks_report[434] = "t_r";
            bookmarks_report[435] = "K_sdv";
            bookmarks_report[436] = "K_el2";


            FillPicturesArray(report);

            double wear = Convert.ToDouble(report.DateOfContract.Year - report.Apartment.Home.BuildYear) / 150.0 * 100.0;    // вычисление износа дома

            texts_report[0] = report.Client.Address;
            texts_report[1] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name +" "+report.Apartment.Home.Number+", кв." + report.Apartment.Number;
            texts_report[2] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name +" "+report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[3] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[4] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[5] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[6] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[7] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[8] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[9] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[10] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + " " + report.Apartment.Home.Number + ", кв." + report.Apartment.Number;
            texts_report[11] = report.Apartment.Home.ComplexNumber;
            texts_report[12] = report.Apartment.Home.ComplexNumber;
            texts_report[13] = report.Apartment.Home.ComplexNumber;
            texts_report[14] = report.Apartment.Home.ComplexNumber;
            texts_report[15] = report.Apartment.Home.ComplexNumber;
            texts_report[16] = report.Apartment.Home.ComplexNumber;
            texts_report[17] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[18] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[19] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[20] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[21] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[22] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[23] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[24] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[25] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[26] = Convert.ToString(report.Apartment.GrossArea);
            texts_report[27] = Convert.ToString(report.Apartment.GrossArea);
            texts_report[28] = Convert.ToString(report.Apartment.GrossArea);
            texts_report[29] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_report[30] = Convert.ToString(report.Apartment.GrossAreaSNIP);
            texts_report[31] = report.Apartment.Home.Attic == true ? "есть" : "нет";
            texts_report[32] = report.Apartment.HasBalconyOrLoggia == true ? "есть" : "нет";//нужно дополнить размеры балкона и застекленность
            texts_report[33] = report.Apartment.Home.Banks;
            texts_report[34] = report.Apartment.Home.Basement;
            texts_report[35] = report.Apartment.Home.BasementWear;
            texts_report[36] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForWashroomCeiling);
            texts_report[37] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForWashroomFloor);
            texts_report[38] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForWashroomWall);
            texts_report[39] = report.Apartment.PlanMeets;
            texts_report[40] = report.Apartment.GetConditionTypeAsString(report.Apartment.Home.CeilingCondition);
            texts_report[41] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.CeilingType);
            texts_report[42] = Convert.ToString(Convert.ToInt32(wear));        // вычисление износа дома
            texts_report[43] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForKitchenCeiling);
            texts_report[44] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomCeiling);
            texts_report[45] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForHallCeiling);
            texts_report[46] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[47] = client_in_padeg;                             // имя в творительном падеже
            texts_report[48] = report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[49] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[50] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[51] = report.Client.Man.Surname + " " + report.Client.Man.Name + " " + report.Client.Man.Patronymic;
            texts_report[52] = "серия " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            texts_report[53] = report.Apartment.Home.StopName;
            texts_report[54] = report.Apartment.Home.Conserge == true ? "есть" : "нет";
            texts_report[55] = report.ReportDate.ToLongDateString();
            texts_report[56] = report.ReportDate.ToLongDateString();
            texts_report[57] = report.ReportDate.ToLongDateString();
            texts_report[58] = report.ReportDate.ToLongDateString();
            texts_report[59] = report.ReportDate.ToLongDateString();
            texts_report[60] = report.ReportDate.ToShortDateString();
            texts_report[61] = report.ReportDate.ToShortDateString();
            texts_report[62] = report.DateOfContract.ToLongDateString();
            texts_report[63] = report.DateOfContract.ToShortDateString();
            texts_report[64] = report.DateOfContract.ToShortDateString();
            texts_report[65] = report.DateOfContract.ToShortDateString();
            texts_report[66] = Convert.ToString(report.Apartment.Object.Price); 
            texts_report[67] = report.Apartment.Object.DestOfTheEvaluation;
            texts_report[68] = "имеются";
            texts_report[69] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Price * 100) + "%";
            texts_report[70] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Price * 100) + "%";
            texts_report[71] = report.Apartment.Home.District.Name;
            texts_report[72] = "серия " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            texts_report[73] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[74] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[75] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[76] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[77] = report.Apartment.Domofon == true ? "есть" : "нет";
            texts_report[78] = report.Apartment.GetConditionTypeAsString(report.Apartment.DoorsCondition);
            texts_report[79] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[80] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[81] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[82] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[83] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[84] = "Доценко Ирина Анатольевна";
            texts_report[85] = "Фадеев Владимир Петрович";
            texts_report[86] = "серия " +
                                        report.Employee.Man.Document.Series + " номер " +
                                        report.Employee.Man.Document.Number + " " +
                                        report.Employee.Man.Document.PlaceOfIssue;
            texts_report[87] = report.Employee.FurtherEducation;
            texts_report[88] = report.Employee.FurtherEducation;
            texts_report[89] = report.Employee.Insurance;
            texts_report[90] = report.Employee.Insurance;
            texts_report[91] = "Договор страхования ответственности оценщика №49915/776/01006/3 от 28.01.2013 г.\r\n Страховой полис № 49915/776/01006/3 от 10 февраля 2013 г. выдан ОАО «АльфаСтрахование». Период действия – с 10.02.2013 г. по 09.02.2014 г. Страховая сумма -3 млн. рублей";
            texts_report[92] = "Договор страхования ответственности оценщика №49915/776/01007/3 от 28.01.2013 г. \r\n Страховой полис № 49915/776/01007/3 от 01 марта 2013 г. выдан ОАО «АльфаСтрахование». Период действия – с 01.03.2013 г. по 28.02.2014 г. Страховая сумма -3 млн. рублей.";
            texts_report[93] = report.Employee.Position;
            texts_report[94] = "2";
            texts_report[95] = report.Employee.Membership;
            texts_report[96] = report.Employee.Membership;
            texts_report[97] = "Член НП «СРО «Национальная Коллегия Специалистов-Оценщиков» (г. Москва), регистрационный № (номер в реестре) 01956. Свидетельство о членстве дата выдачи 25.03.2013 года.";
            texts_report[98] = "Член НП «СРО «Национальная Коллегия Специалистов-Оценщиков» (г. Москва), регистрационный № (номер в реестре) 00017. Свидетельство о членстве дата выдачи 13.02.2008 года.";
            texts_report[99] = Convert.ToString(report.Employee.WorkTime);
            texts_report[100] = Convert.ToString(report.Employee.WorkTime);
            texts_report[101] = report.Apartment.AuxiliaryRooms;
            texts_report[102] = report.Apartment.Home.ExtraFactors;
            texts_report[103] = report.Apartment.GetApartmentStateAsString(report.Apartment.ApartmentState);
            texts_report[104] = Convert.ToString(report.Apartment.CeilingHeight);
            texts_report[105] = report.Apartment.FlatsOnFloor;
            texts_report[106] = Convert.ToString(report.Apartment.Floor);
            texts_report[107] = Convert.ToString(report.Apartment.Floor);
            texts_report[108] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForHallFloor);
            texts_report[109] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForKitchenFloor);
            texts_report[110] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomFloor);
            texts_report[111] = Convert.ToString(report.Apartment.Home.Floors);
            texts_report[112] = Convert.ToString(report.Apartment.Home.Floors);
            texts_report[113] = report.Apartment.Home.Garbadge == true ? "есть" : "нет";
            texts_report[114] = report.Apartment.GetConditionTypeAsString(report.Apartment.HeatingCondition);
            texts_report[115] = report.Apartment.GetPipesTypeAsString(report.Apartment.HeatingPipesType);
            texts_report[116] = report.Apartment.GetHeaterTypeAsString(report.Apartment.HeatersType);
            texts_report[117] = report.Apartment.GetHeatingSystemAsString(report.Apartment.HeatingSystem);
            texts_report[118] = report.Apartment.Object.Holders;
            texts_report[119] = report.Apartment.Object.Holders;
            texts_report[120] = report.Apartment.Object.Documents;
            texts_report[121] = report.Apartment.Object.Documents;
            texts_report[122] = report.Apartment.Home.Hospitals;
            texts_report[123] = Convert.ToString(Convert.ToInt32(wear));        // вычисление износа дома;
            texts_report[124] = Convert.ToString(Convert.ToInt32(wear));        // вычисление износа дома;
            texts_report[125] = Convert.ToString(report.Apartment.Home.BuildYear);
            texts_report[126] = report.Apartment.Home.Defects == true ? "присутствии" : "отсутствии";
            texts_report[127] = report.Apartment.Home.Defects == true ? "присутствии" : "отсутствии"; ;
            texts_report[128] = report.Apartment.PlanMeets;
            texts_report[129] = report.Apartment.GetConditionTypeAsString(report.Apartment.CanaliztionCondition);
            texts_report[130] = report.Apartment.Counters;
            texts_report[131] = report.Apartment.GetPipesTypeAsString(report.Apartment.CanalizationPipesType);
            texts_report[132] = report.Apartment.Home.KapremontPeriod;
            texts_report[133] = report.Apartment.Home.KapremontYear;
            texts_report[134] = report.Apartment.Home.KapremontYear;
            texts_report[135] = report.Apartment.Home.Kinders;
            texts_report[136] = Convert.ToString(report.Apartment.KitchenArea); ;
            texts_report[137] = report.Apartment.Home.Lift == true ? "есть" : "нет";
            texts_report[138] = report.Apartment.Object.Restriction;
            texts_report[139] = report.Apartment.Object.Restriction;
            texts_report[140] = Convert.ToString(report.Apartment.LivingArea);
            texts_report[141] = Convert.ToString(report.Apartment.LivingArea);
            texts_report[142] = report.Apartment.Home.Loacals_1;
            texts_report[143] = report.Apartment.Home.Loacals_2;
            texts_report[144] = report.Apartment.GetDoorsTypeAsString(report.Apartment.MainDoorType);
            texts_report[145] = report.Apartment.Object.ObjectType;
            texts_report[146] = report.Apartment.Object.ObjectType;
            texts_report[147] = report.Apartment.Object.ObjectType;
            texts_report[148] = report.Apartment.Object.ObjectType;
            texts_report[149] = report.Apartment.Object.ObjectType;
            texts_report[150] = report.Apartment.Object.ObjectType;
            texts_report[151] = report.Apartment.Home.Parking == true ? "есть" : "нет";
            texts_report[152] = report.Apartment.Home.PharmList;
            texts_report[153] = report.Apartment.PlanMeets;
            texts_report[154] = report.Apartment.ViewOnApparment;
            texts_report[155] = report.Apartment.Home.District.GetPrestigeAsString(report.Apartment.Home.District.Prestige);
            texts_report[156] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[157] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[158] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[159] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[160] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[161] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[162] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[163] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[164] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[165] = writePrice;     //сумма прописью
            texts_report[166] = Convert.ToString(report.Apartment.Object.Discount);       // Вычисление ликвидационной стоимости
            texts_report[167] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[168] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[169] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[170] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[171] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[172] = Convert.ToString(report.Apartment.Object.Discount);
            texts_report[173] = writePriceDiscount; //Сумма с уценкой прописью
            texts_report[174] = writePriceDiscount;
            texts_report[175] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);  // Вычисление ликвидационной стоимости в долларах
            texts_report[176] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);
            texts_report[177] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);
            texts_report[178] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);
            texts_report[179] = Convert.ToString(report.Apartment.Object.Discount / report.Apartment.Object.Dollar);
            texts_report[180] = witePriceDiscountDollar; //Сумма с уценкой прописью в долларах
            texts_report[181] = writePriceDiscount; //Сумма с уценкой прописью
            texts_report[182] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);       // Вычисление стоимости в долларах
            texts_report[183] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[184] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[185] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[186] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[187] = writePriceDollar; //Сумма прописью в долларах
            texts_report[188] = writePriceDollar;
            texts_report[189] = writePrice;     //Сумма прописью
            texts_report[190] = writePrice;
            texts_report[191] = writePrice;
            texts_report[192] = report.Apartment.Home.PromzoneDistance;
            texts_report[193] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_report[194] = report.Apartment.GetRepairWorkAsString(report.Apartment.RepairWork);
            texts_report[195] = report.Apartment.GetRoomFinishingQualityAsString(report.Apartment.RoomFinishingQuality);
            texts_report[196] = report.ReportDate.ToShortDateString();
            texts_report[197] = report.ReportDate.ToShortDateString();
            texts_report[198] = report.ReportDate.ToLongDateString();
            texts_report[199] = report.ReportDate.ToLongDateString();
            texts_report[200] = report.ReportNumber;
            texts_report[201] = report.ReportNumber;
            texts_report[202] = report.ReportNumber;
            texts_report[203] = report.ReportNumber;
            texts_report[204] = report.ReportNumber;
            texts_report[205] = report.ReportNumber;
            texts_report[206] = report.Apartment.Home.RestPlaces;
            texts_report[207] = report.Apartment.Object.Property;
            texts_report[208] = report.Apartment.Object.Property;
            texts_report[209] = report.Apartment.GetConditionTypeAsString(report.Apartment.Home.RoofCondition);
            texts_report[210] = report.Apartment.GetDoorsTypeAsString(report.Apartment.RoomDoorsType); ;
            texts_report[211] = report.Apartment.GetRoomTypeAsString(report.Apartment.RoomType);
            texts_report[212] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[213] = report.Apartment.SanuzelQnt + " " + report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[214] = report.Apartment.Home.Schools;
            texts_report[215] = report.Apartment.HasSeparateKitchenOrWashroom == true ? "есть" : "нет";
            texts_report[216] = report.Apartment.Home.Services;
            texts_report[217] = report.Apartment.HasLowCurrent == true ? "есть" : "нет";
            texts_report[218] = report.Apartment.Home.Social;
            texts_report[219] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.GrossArea);               // Вычисление стоимости квадратного метра
            texts_report[220] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.GrossArea);               // Вычисление стоимости квадратного метра
            texts_report[221] = Convert.ToString((report.Apartment.Object.Price / report.Apartment.GrossArea) / report.Apartment.Object.Dollar);// Вычисление стоимости квадратного метра в долларах
            texts_report[222] = report.Apartment.Home.StopDistance;
            texts_report[223] = report.ReportDate.ToShortDateString(); ;
            texts_report[224] = "электроосвещение, центральное отопление, централизованное водоснабжение, "
                                + "канализация, вытяжная вентиляция, телевидение, телефон" + 
                                (report.Apartment.Home.Gaz == true ? ", газоснабжение" : "") + 
                                (report.Apartment.Home.Garbadge == true ? ", мусоропровод" : "");
            texts_report[225] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForWashroomCeiling);
            texts_report[226] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForWashroomFloor);
            texts_report[227] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForWashroomWall);
            texts_report[228] = report.Apartment.Home.Tradings;
            texts_report[229] = report.Apartment.Home.Transport == true ? "Автобусы и трамваи" : "Автобусы";
            texts_report[230] = report.Apartment.Views;
            texts_report[231] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForHallWall);
            texts_report[232] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForKitchenWall);
            texts_report[233] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomWall);
            texts_report[234] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[235] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[236] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.InsideWall);
            texts_report[237] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[238] = Convert.ToString(Convert.ToInt32(wear));        // вычисление износа дома;
            texts_report[239] = Convert.ToString(Convert.ToInt32(wear));         // вычисление износа дома;
            texts_report[240] = report.Apartment.GetConditionTypeAsString(report.Apartment.WaterCondition);
            texts_report[241] = "верхняя";
            texts_report[242] = "верхний";
            texts_report[243] = report.Apartment.GetConditionTypeAsString(report.Apartment.WindowsCondition); ;
            texts_report[244] = report.Apartment.GetWindowsTypeAsString(report.Apartment.WindowsType);
            texts_report[245] = Convert.ToString(report.ReportDate.Year);
            texts_report[246] = Convert.ToString(report.Apartment.Home.BuildYear);
            texts_report[247] = Convert.ToString(report.Apartment.Home.BuildYear - report.ReportDate.Year); //Вычисление возраста дома
            texts_report[248] = photo[0] != null ? photo[0].Name : "";  //Комментарии к фото
            texts_report[249] = photo[1] != null ? photo[1].Name : "";
            texts_report[250] = photo[2] != null ? photo[2].Name : "";
            texts_report[251] = photo[3] != null ? photo[3].Name : "";
            texts_report[252] = photo[4] != null ? photo[4].Name : "";
            texts_report[253] = photo[5] != null ? photo[5].Name : "";
            texts_report[254] = photo[6] != null ? photo[6].Name : "";
            texts_report[255] = photo[7] != null ? photo[7].Name : "";
            texts_report[256] = photo[8] != null ? photo[8].Name : "";
            texts_report[257] = apartmentMaps[0] != null ? apartmentMaps[0].Name : ""; //Комментарий к схеме квартиры
            //texts_report[258] = "";
            //texts_report[259] = "";
            //texts_report[260] = "";
            //texts_report[261] = "";
            //texts_report[262] = "";
            //texts_report[263] = "";
            //texts_report[264] = "";
            //texts_report[265] = "";
            //texts_report[266] = "";
            //texts_report[267] = "";
            //texts_report[268] = "";
            //texts_report[269] = "";
            //texts_report[270] = "";
            //texts_report[271] = "";
            //texts_report[272] = "";
            texts_report[273] = ca[0].kBalcon == 0 ? "-" : Convert.ToString(ca[0].kBalcon * 100)+"%";
            texts_report[274] = ca[1].kBalcon == 0 ? "-" : Convert.ToString(ca[1].kBalcon * 100)+"%";
            texts_report[275] = ca[2].kBalcon == 0 ? "-" : Convert.ToString(ca[2].kBalcon * 100)+"%";
            texts_report[276] = ca[3].kBalcon == 0 ? "-" : Convert.ToString(ca[3].kBalcon * 100)+"%";
            texts_report[277] = ca[4].kBalcon == 0 ? "-" : Convert.ToString(ca[4].kBalcon * 100)+"%";
            texts_report[278] = ca[0].kFloor == 0 ? "-" : Convert.ToString(ca[0].kFloor * 100)+"%";
            texts_report[279] = ca[1].kFloor == 0 ? "-" : Convert.ToString(ca[1].kFloor * 100)+"%";
            texts_report[280] = ca[2].kFloor == 0 ? "-" : Convert.ToString(ca[2].kFloor * 100)+"%";
            texts_report[281] = ca[3].kFloor == 0 ? "-" : Convert.ToString(ca[3].kFloor * 100)+"%";
            texts_report[282] = ca[4].kFloor == 0 ? "-" : Convert.ToString(ca[4].kFloor * 100)+"%";
            texts_report[283] = ca[0].kFloors == 0 ? "-" : Convert.ToString(ca[0].kFloors * 100)+"%";
            texts_report[284] = ca[1].kFloors == 0 ? "-" : Convert.ToString(ca[1].kFloors * 100)+"%";
            texts_report[285] = ca[2].kFloors == 0 ? "-" : Convert.ToString(ca[2].kFloors * 100)+"%";
            texts_report[286] = ca[3].kFloors == 0 ? "-" : Convert.ToString(ca[3].kFloors * 100)+"%";
            texts_report[287] = ca[4].kFloors == 0 ? "-" : Convert.ToString(ca[4].kFloors * 100)+"%";
            texts_report[288] = Convert.ToString((ca[0].kBalcon+ca[0].kFloor+ca[0].kFloors+ca[0].kSanuzel+
                                                 ca[0].kSKitchen+ca[0].kTorg+ca[0].kView+ca[0].kWallType)*100)+"%";
            texts_report[289] = Convert.ToString((ca[1].kBalcon+ca[1].kFloor+ca[1].kFloors+ca[1].kSanuzel+
                                                 ca[1].kSKitchen+ca[1].kTorg+ca[1].kView+ca[1].kWallType)*100)+"%";
            texts_report[290] = Convert.ToString((ca[2].kBalcon+ca[2].kFloor+ca[2].kFloors+ca[2].kSanuzel+
                                                 ca[2].kSKitchen+ca[2].kTorg+ca[2].kView+ca[2].kWallType)*100)+"%";
            texts_report[291] = Convert.ToString((ca[3].kBalcon+ca[3].kFloor+ca[3].kFloors+ca[3].kSanuzel+
                                                 ca[3].kSKitchen+ca[3].kTorg+ca[3].kView+ca[3].kWallType)*100)+"%";
            texts_report[292] = Convert.ToString((ca[4].kBalcon+ca[4].kFloor+ca[4].kFloors+ca[4].kSanuzel+
                                                 ca[4].kSKitchen+ca[4].kTorg+ca[4].kView+ca[4].kWallType)*100)+"%";
            texts_report[293] = Convert.ToString(ca[0].finishingQualityPrice);
            texts_report[294] = Convert.ToString(ca[1].finishingQualityPrice);
            texts_report[295] = Convert.ToString(ca[2].finishingQualityPrice);
            texts_report[296] = Convert.ToString(ca[3].finishingQualityPrice);
            texts_report[297] = Convert.ToString(ca[4].finishingQualityPrice);
            texts_report[298] = ca[0].kSanuzel == 0 ? "-" : Convert.ToString(ca[0].kSanuzel * 100)+"%";
            texts_report[299] = ca[1].kSanuzel == 0 ? "-" : Convert.ToString(ca[1].kSanuzel * 100)+"%";
            texts_report[300] = ca[2].kSanuzel == 0 ? "-" : Convert.ToString(ca[2].kSanuzel * 100)+"%";
            texts_report[301] = ca[3].kSanuzel == 0 ? "-" : Convert.ToString(ca[3].kSanuzel * 100)+"%";
            texts_report[302] = ca[4].kSanuzel == 0 ? "-" : Convert.ToString(ca[4].kSanuzel * 100)+"%";
            texts_report[303] = ca[0].kSKitchen == 0 ? "-" : Convert.ToString(ca[0].kSKitchen * 100)+"%";
            texts_report[304] = ca[1].kSKitchen == 0 ? "-" : Convert.ToString(ca[1].kSKitchen * 100)+"%";
            texts_report[305] = ca[2].kSKitchen == 0 ? "-" : Convert.ToString(ca[2].kSKitchen * 100)+"%";
            texts_report[306] = ca[3].kSKitchen == 0 ? "-" : Convert.ToString(ca[3].kSKitchen * 100)+"%";
            texts_report[307] = ca[4].kSKitchen == 0 ? "-" : Convert.ToString(ca[4].kSKitchen * 100)+"%";
            texts_report[308] = Convert.ToString(ca[0].sqmCalcPrice);
            texts_report[309] = Convert.ToString(ca[1].sqmCalcPrice);
            texts_report[310] = Convert.ToString(ca[2].sqmCalcPrice);
            texts_report[311] = Convert.ToString(ca[3].sqmCalcPrice);
            texts_report[312] = Convert.ToString(ca[4].sqmCalcPrice);
            texts_report[313] = Convert.ToString(ca[0].sqmCalcPrice - ca[0].finishingQualityPrice);
            texts_report[314] = Convert.ToString(ca[1].sqmCalcPrice - ca[1].finishingQualityPrice);
            texts_report[315] = Convert.ToString(ca[2].sqmCalcPrice - ca[2].finishingQualityPrice);
            texts_report[316] = Convert.ToString(ca[3].sqmCalcPrice - ca[3].finishingQualityPrice);
            texts_report[317] = Convert.ToString(ca[4].sqmCalcPrice - ca[4].finishingQualityPrice);
            texts_report[318] = ca[0].kTorg == 0 ? "-" : Convert.ToString(ca[0].kTorg * 100)+"%";
            texts_report[319] = ca[1].kTorg == 0 ? "-" : Convert.ToString(ca[1].kTorg * 100)+"%";
            texts_report[320] = ca[2].kTorg == 0 ? "-" : Convert.ToString(ca[2].kTorg * 100)+"%";
            texts_report[321] = ca[3].kTorg == 0 ? "-" : Convert.ToString(ca[3].kTorg * 100)+"%";
            texts_report[322] = ca[4].kTorg == 0 ? "-" : Convert.ToString(ca[4].kTorg * 100) + "%";
            texts_report[323] = ca[0].kWallType == 0 ? "-" : Convert.ToString(ca[0].kWallType * 100)+"%";
            texts_report[324] = ca[1].kWallType == 0 ? "-" : Convert.ToString(ca[1].kWallType * 100)+"%";
            texts_report[325] = ca[2].kWallType == 0 ? "-" : Convert.ToString(ca[2].kWallType * 100)+"%";
            texts_report[326] = ca[3].kWallType == 0 ? "-" : Convert.ToString(ca[3].kWallType * 100)+"%";
            texts_report[327] = ca[4].kWallType == 0 ? "-" : Convert.ToString(ca[4].kWallType * 100) + "%";
            texts_report[328] = ca[0].kView == 0 ? "-" : Convert.ToString(ca[0].kView * 100)+"%";
            texts_report[329] = ca[1].kView == 0 ? "-" : Convert.ToString(ca[1].kView * 100)+"%";
            texts_report[330] = ca[2].kView == 0 ? "-" : Convert.ToString(ca[2].kView * 100)+"%";
            texts_report[331] = ca[3].kView == 0 ? "-" : Convert.ToString(ca[3].kView * 100)+"%";
            texts_report[332] = ca[4].kView == 0 ? "-" : Convert.ToString(ca[4].kView * 100) + "%";
            texts_report[333] = report.Apartment.HasBalconyOrLoggia == true ? "есть" : "нет";
            texts_report[334] = ca[0].hasBalcony == true ? "есть" : "нет";
            texts_report[335] = ca[1].hasBalcony == true ? "есть" : "нет";
            texts_report[336] = ca[2].hasBalcony == true ? "есть" : "нет";
            texts_report[337] = ca[3].hasBalcony == true ? "есть" : "нет";
            texts_report[338] = ca[4].hasBalcony == true ? "есть" : "нет";
            texts_report[339] = report.Apartment.Home.Street.City.Name + ", "+report.Apartment.Home.ComplexNumber;
            texts_report[340] = "г. Наб. Челны, " + ca[0].address;
            texts_report[341] = "г. Наб. Челны, " + ca[1].address;
            texts_report[342] = "г. Наб. Челны, " + ca[2].address;
            texts_report[343] = "г. Наб. Челны, " + ca[3].address;
            texts_report[344] = "г. Наб. Челны, " + ca[4].address;
            texts_report[345] = report.Apartment.Home.Street.City.Name + ", "+report.Apartment.Home.ComplexNumber;
            texts_report[346] = "г. Наб. Челны, " + ca[0].address;
            texts_report[347] = "г. Наб. Челны, " + ca[1].address;
            texts_report[348] = "г. Наб. Челны, " + ca[2].address;
            texts_report[349] = "г. Наб. Челны, " + ca[3].address;
            texts_report[350] = "г. Наб. Челны, " + ca[4].address;
            texts_report[351] = Convert.ToString(report.Apartment.Floor);
            texts_report[352] = Convert.ToString(ca[0].floor);
            texts_report[353] = Convert.ToString(ca[1].floor);
            texts_report[354] = Convert.ToString(ca[2].floor);
            texts_report[355] = Convert.ToString(ca[3].floor);
            texts_report[356] = Convert.ToString(ca[4].floor);
            texts_report[357] = Convert.ToString(report.Apartment.Home.Floors);
            texts_report[358] = Convert.ToString(ca[0].maxFloor);
            texts_report[359] = Convert.ToString(ca[1].maxFloor);
            texts_report[360] = Convert.ToString(ca[2].maxFloor);
            texts_report[361] = Convert.ToString(ca[3].maxFloor);
            texts_report[362] = Convert.ToString(ca[4].maxFloor);
            texts_report[363] = Convert.ToString(report.Apartment.GrossArea);
            texts_report[364] = Convert.ToString(ca[0].grossArea);
            texts_report[365] = Convert.ToString(ca[1].grossArea);
            texts_report[366] = Convert.ToString(ca[2].grossArea);
            texts_report[367] = Convert.ToString(ca[3].grossArea);
            texts_report[368] = Convert.ToString(ca[4].grossArea);
            texts_report[369] = Convert.ToString(report.Apartment.KitchenArea);
            texts_report[370] = Convert.ToString(ca[0].kitchenArea);
            texts_report[371] = Convert.ToString(ca[1].kitchenArea);
            texts_report[372] = Convert.ToString(ca[2].kitchenArea);
            texts_report[373] = Convert.ToString(ca[3].kitchenArea);
            texts_report[374] = Convert.ToString(ca[4].kitchenArea);
            texts_report[375] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[376] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[377] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[378] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[379] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[380] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[381] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[382] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[383] = Convert.ToString(report.Apartment.RoomNumber);
            texts_report[384] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[385] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType); 
            texts_report[386] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[387] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[388] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[389] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[390] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[391] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[392] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[393] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[394] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[395] = report.Apartment.Home.GetMaterialTypeAsString(report.Apartment.Home.OutsideWall);
            texts_report[396] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.GrossArea);
            texts_report[397] = Convert.ToString(ca[0].price * 1000 / ca[0].grossArea);
            texts_report[398] = Convert.ToString(ca[1].price * 1000 / ca[1].grossArea);
            texts_report[399] = Convert.ToString(ca[2].price * 1000 / ca[2].grossArea);
            texts_report[400] = Convert.ToString(ca[3].price * 1000 / ca[3].grossArea);
            texts_report[401] = Convert.ToString(ca[4].price * 1000 / ca[4].grossArea);
            texts_report[402] = ca[0].company;
            texts_report[403] = ca[1].company;
            texts_report[404] = ca[2].company;
            texts_report[405] = ca[3].company;
            texts_report[406] = ca[4].company;
            texts_report[407] = Convert.ToString(ca[0].price * 1000);
            texts_report[408] = Convert.ToString(ca[1].price * 1000);
            texts_report[409] = Convert.ToString(ca[2].price * 1000);
            texts_report[410] = Convert.ToString(ca[3].price * 1000);
            texts_report[411] = Convert.ToString(ca[4].price * 1000);

            texts_report[412] = Convert.ToString(report.Apartment.Object.EconSituationDown);
            texts_report[413] = Convert.ToString(report.Apartment.Object.ConcurentsUp);
            texts_report[414] = Convert.ToString(report.Apartment.Object.LowChange);
            texts_report[415] = Convert.ToString(report.Apartment.Object.ExtremalSituation);
            texts_report[416] = Convert.ToString(report.Apartment.Object.AcceleratedWear);
            texts_report[417] = Convert.ToString(report.Apartment.Object.NoRentalMoney);
            texts_report[418] = Convert.ToString(report.Apartment.Object.BadManagment);
            texts_report[419] = Convert.ToString(report.Apartment.Object.Criminal);
            texts_report[420] = Convert.ToString(report.Apartment.Object.FinanceChecking);
            texts_report[421] = Convert.ToString(report.Apartment.Object.NotCorrect);
            texts_report[422] = Convert.ToString(Convert.ToDecimal(risks));
            texts_report[423] = Convert.ToString(Convert.ToDecimal(risks / 10));
            texts_report[424] = Convert.ToString(report.Apartment.Object.NoRisk);
            texts_report[425] = Convert.ToString(Convert.ToDecimal(risks / 10));
            texts_report[426] = Convert.ToString(report.Apartment.Object.NoRisk / 4);
            texts_report[427] = Convert.ToString(report.Apartment.Object.InvestManage);
            texts_report[428] = Convert.ToString(Convert.ToDecimal(r12));
            texts_report[429] = Convert.ToString(report.Apartment.Object.K_el);
            texts_report[430] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[431] = Convert.ToString(Convert.ToDecimal(r12));
            texts_report[432] = Convert.ToString(Convert.ToDecimal(r12 / 12));
            texts_report[433] = Convert.ToString(report.Apartment.Object.T_l);
            texts_report[434] = Convert.ToString(report.Apartment.Object.T_r);
            texts_report[435] = Convert.ToString(Convert.ToDecimal(k_sdv));
            texts_report[436] = Convert.ToString(report.Apartment.Object.K_el);



        }
    //Генерация документа Word
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
                    rg = bk[bookmarks[i]].Range;
                    if (i < 258)
                    {                                                                                           
                        rg.Text = text[i];                                  // Выполнить замену строк
                    }

                    if (i > 257 & i < 267 )                                // Здесь начинаются фотографии
                    {
                        if (photo[i - 258] != null)
                        {
                            rg.InlineShapes.AddPicture(photo[i - 258].ImageFileName);
                        }
                    }
                    if (i == 267 & apartmentMaps[0] != null)                                // Здесь начинаются план квартиры
                    {
                        rg.InlineShapes.AddPicture(apartmentMaps[0].ImageFileName);
                    }
                    if (i > 267 & i < 271 )                                // Здесь начинаются скан документов
                    {
                        if (documents[i - 268] != null)
                        {
                            rg.InlineShapes.AddPicture(documents[i - 268].ImageFileName);
                        }
                    }
                    if (i > 270 & i < 273)                                // Здесь начинаются скриншоты карт
                    {
                        if (screenshot[i - 271] != null)
                        {
                            rg.InlineShapes.AddPicture(screenshot[i - 271].ImageFileName);
                        }
                    }

                    if (i > 272)                                            // Заполнение таблицы сравнений
                    {
                        rg.Text = text[i];                                  // Выполнить замену строк
                    }
                    
                }
            }
            catch
            {
            }

            MSWordDoc.SaveAs2(reportFileName);                                                                              // Сохранить файл

            MSWordDoc.Close();                                                                                              // Закрыть файл

            wordApplication.Quit();                                                                                         // Закрыть приложение
        }


//Генерация документа Excel и заполнение данных в отчете Договор
        public static void XLSGenerate(string templateFileName, string reportFileName, IReport report,  int rod) 
        {
            Microsoft.Office.Interop.Excel.Application excelAppl = new Microsoft.Office.Interop.Excel.Application();    // Создать документ Excel
           // object d = (object)templateFileName;                                                                            // Создать пустой объект

            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = excelAppl.Workbooks.Open(templateFileName);          // Создать книгу                                            // Открыть документ по указанному в объекте адресу
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = excelAppl.Worksheets.get_Item(1);             //Открыть лист 1

            // Заполнить ячейки данными
            ObjWorkSheet.Cells[1, 2] = report.ReportNumber;
            ObjWorkSheet.Cells[2, 2] = report.DateOfContract.ToShortDateString(); 
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
            ObjWorkSheet.Cells[13, 2] = report.Client.Address;     // Адрес заказчика
            ObjWorkSheet.Cells[14, 2] = //report.Client.Man.Document.Type 
                                        "паспорт"  + " серии " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            ObjWorkSheet.Cells[15, 2] = report.Client.Man.Surname + " " + report.Client.Man.Name + " " + report.Client.Man.Patronymic;
            ObjWorkSheet.Cells[17, 2] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            ObjWorkSheet.Cells[18, 2] = report.Employee.Insurance;

            ObjWorkBook.SaveAs(reportFileName); // Сохранить
            excelAppl.Quit();                   // Закрыть
    
    }


    }
}
