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
       //Процедура формирования отчетов
        public static void Generate(IReport report, string reportTemplatesFolderPath, string reportsFolderPath)
        {
            string templateConclusReport = reportTemplatesFolderPath + @"\conclusion.dotx";                                        // Путь к шаблону договора
            string reportConclusName = reportsFolderPath + @"\conclusion " + DateTime.Now.ToString().Replace(":", ".") + @".docx"; // Путь к выходному файлу
            
            string tempContractReport = reportTemplatesFolderPath + @"\contract.xltx";
            string reportContractName = reportsFolderPath + @"\contract " + DateTime.Now.ToString().Replace(":", ".") + @".xlsx";

            string tempReport = reportTemplatesFolderPath + @"\report.dotx";
            string reportName = reportsFolderPath + @"\report " + DateTime.Now.ToString().Replace(":", ".") + @".docx";

            string[] bookmarks_conclusion = new string[50];                                                                       // Массив закладок
            string[] texts_conclusion = new string[50];                                                                           // Массив вставляемых вместо закладок строк

            string[] bookmarks_report = new string[275];                                                                       // Массив закладок
            string[] texts_report = new string[275];                                                                           // Массив вставляемых вместо закладок строк

            string client_in_padeg = null;
            int rod = 0;
            client_in_padeg = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, report.Client.Man.Name, report.Client.Man.Patronymic, BLL.Declension.DeclensionCase.Tvorit);
            rod = BLL.Declension.DeclensionBLL.GetGender(report.Client.Man.Patronymic);

            string client_in_padeg_dat = null;
            client_in_padeg_dat = BLL.Declension.DeclensionBLL.GetSNPDeclension(report.Client.Man.Surname, report.Client.Man.Name, report.Client.Man.Patronymic, BLL.Declension.DeclensionCase.Datel);

            ArrayFillConcusion(bookmarks_conclusion, texts_conclusion, report, client_in_padeg);
            ArrayFillReport(bookmarks_report, texts_report, report, client_in_padeg_dat);

            DocGenerate(templateConclusReport, reportConclusName, bookmarks_conclusion, texts_conclusion);                            // Сгенерировать отчет Договор
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

        //Процедура формирования закладок и текстов их замен в отчете Отчет
        public static void ArrayFillReport(string[] bookmarks_report, string[] texts_report, IReport report, string client_in_padeg)
        {
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
            bookmarks_report[126] = "image1";
            bookmarks_report[127] = "image2";
            bookmarks_report[128] = "image3";
            bookmarks_report[129] = "image4";
            bookmarks_report[130] = "image5";
            bookmarks_report[131] = "image6";
            bookmarks_report[132] = "image7";
            bookmarks_report[133] = "image8";
            bookmarks_report[134] = "image9";
            bookmarks_report[135] = "image10";
            bookmarks_report[136] = "image11";
            bookmarks_report[137] = "image12";
            bookmarks_report[138] = "image13";
            bookmarks_report[139] = "image1_comment";
            bookmarks_report[140] = "image2_comment";
            bookmarks_report[141] = "image3_comment";
            bookmarks_report[142] = "image4_comment";
            bookmarks_report[143] = "image5_comment";
            bookmarks_report[144] = "image6_comment";
            bookmarks_report[145] = "image7_comment";
            bookmarks_report[146] = "image8_comment";
            bookmarks_report[147] = "image9_comment";
            bookmarks_report[148] = "image10_comment";
            bookmarks_report[149] = "image_map1";
            bookmarks_report[150] = "image_map2";
            bookmarks_report[151] = "is_defect";
            bookmarks_report[152] = "is_defect2";
            bookmarks_report[153] = "is_pereplan";
            bookmarks_report[154] = "kanal_cond";
            bookmarks_report[155] = "kanal_devices";
            bookmarks_report[156] = "kanal_pipe";
            bookmarks_report[157] = "kapremont";
            bookmarks_report[158] = "kapremont_year";
            bookmarks_report[159] = "kapremont_year2";
            bookmarks_report[160] = "kinder_list";
            bookmarks_report[161] = "kitchen_area";
            bookmarks_report[162] = "lift";
            bookmarks_report[163] = "limits";
            bookmarks_report[164] = "limits2";
            bookmarks_report[165] = "living_area";
            bookmarks_report[166] = "living_area2";
            bookmarks_report[167] = "local1";
            bookmarks_report[168] = "local2";
            bookmarks_report[169] = "main_door_type";
            bookmarks_report[170] = "object_type";
            bookmarks_report[171] = "object_type2";
            bookmarks_report[172] = "object_type3";
            bookmarks_report[173] = "object_type4";
            bookmarks_report[174] = "object_type5";
            bookmarks_report[175] = "object_type6";
            bookmarks_report[176] = "parking";
            bookmarks_report[177] = "pharmacy_list";
            bookmarks_report[178] = "plan_now";
            bookmarks_report[179] = "posible_2_register";
            bookmarks_report[180] = "prestig";
            bookmarks_report[181] = "price";
            bookmarks_report[182] = "price2";
            bookmarks_report[183] = "price3";
            bookmarks_report[184] = "price4";
            bookmarks_report[185] = "price5";
            bookmarks_report[186] = "price6";
            bookmarks_report[187] = "price7";
            bookmarks_report[188] = "price8";
            bookmarks_report[189] = "price9";
            bookmarks_report[190] = "price8_write";
            bookmarks_report[191] = "price_discount";
            bookmarks_report[192] = "price_discount2";
            bookmarks_report[193] = "price_discount3";
            bookmarks_report[194] = "price_discount4";
            bookmarks_report[195] = "price_discount5";
            bookmarks_report[196] = "price_discount6";
            bookmarks_report[197] = "price_discount7";
            bookmarks_report[198] = "price_discount5_write";
            bookmarks_report[199] = "price_discount6_write";
            bookmarks_report[200] = "price_discount_dollar";
            bookmarks_report[201] = "price_discount_dollar2";
            bookmarks_report[202] = "price_discount_dollar3";
            bookmarks_report[203] = "price_discount_dollar4";
            bookmarks_report[204] = "price_discount_dollar5";
            bookmarks_report[205] = "price_discount_dollar4_write";
            bookmarks_report[206] = "price_discount_write";
            bookmarks_report[207] = "price_dollar";
            bookmarks_report[208] = "price_dollar2";
            bookmarks_report[209] = "price_dollar3";
            bookmarks_report[210] = "price_dollar4";
            bookmarks_report[211] = "price_dollar5";
            bookmarks_report[212] = "price_dollar_write";
            bookmarks_report[213] = "price_dollar_write2";
            bookmarks_report[214] = "price_write";
            bookmarks_report[215] = "price_write2";
            bookmarks_report[216] = "price_write3";
            bookmarks_report[217] = "prom_distance";
            bookmarks_report[218] = "purpose";
            bookmarks_report[219] = "repair";
            bookmarks_report[220] = "repair_quality";
            bookmarks_report[221] = "report_data2";
            bookmarks_report[222] = "report_data3";
            bookmarks_report[223] = "report_data4";
            bookmarks_report[224] = "report_data5";
            bookmarks_report[225] = "report_number";
            bookmarks_report[226] = "report_number2";
            bookmarks_report[227] = "report_number3";
            bookmarks_report[228] = "report_number4";
            bookmarks_report[229] = "report_number5";
            bookmarks_report[230] = "report_number6";
            bookmarks_report[231] = "rest_list";
            bookmarks_report[232] = "rights";
            bookmarks_report[233] = "rights2";
            bookmarks_report[234] = "roof_cond";
            bookmarks_report[235] = "room_door_type";
            bookmarks_report[236] = "room_type";
            bookmarks_report[237] = "sanuz_comb";
            bookmarks_report[238] = "sanuzel";
            bookmarks_report[239] = "school_list";
            bookmarks_report[240] = "separate";
            bookmarks_report[241] = "service_list";
            bookmarks_report[242] = "slabotoch";
            bookmarks_report[243] = "social_list";
            bookmarks_report[244] = "sqm_price";
            bookmarks_report[245] = "sqm_price2";
            bookmarks_report[246] = "sqm_price_dollar";
            bookmarks_report[247] = "stop_distance";
            bookmarks_report[248] = "systems_connection";
            bookmarks_report[249] = "technic_list";
            bookmarks_report[250] = "toilet_ceiling";
            bookmarks_report[251] = "toilet_floor";
            bookmarks_report[252] = "toilet_wall";
            bookmarks_report[253] = "trade_list";
            bookmarks_report[254] = "transport_type";
            bookmarks_report[255] = "vid";
            bookmarks_report[256] = "wall_corrd_type";
            bookmarks_report[257] = "wall_kitchen_type";
            bookmarks_report[258] = "wall_living_type";
            bookmarks_report[259] = "wall_type";
            bookmarks_report[260] = "wall_type2";
            bookmarks_report[261] = "wall_type3";
            bookmarks_report[262] = "wall_type4";
            bookmarks_report[263] = "wall_wear";
            bookmarks_report[264] = "wall_wear2";
            bookmarks_report[265] = "water_cond";
            bookmarks_report[266] = "water_razv";
            bookmarks_report[267] = "water_stoyak";
            bookmarks_report[268] = "window_cond";
            bookmarks_report[269] = "window_type";
            bookmarks_report[270] = "year";
            bookmarks_report[271] = "year2";



            texts_report[0] = "";
            texts_report[1] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[2] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[3] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[4] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[5] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[6] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[7] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[8] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[9] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
            texts_report[10] = report.Apartment.Home.Street.City.Name + ", " + report.Apartment.Home.Street.Name + ", кв." + report.Apartment.Number;
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
            texts_report[31] = "";
            texts_report[32] = report.Apartment.HasBalconyOrLoggia == true ? "есть" : "нет";//нужно дополнить размеры балкона и застекленность
            texts_report[33] = "";
            texts_report[34] = "";
            texts_report[35] = "";
            texts_report[36] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForWashroomCeiling);
            texts_report[37] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForWashroomFloor);
            texts_report[38] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForWashroomWall);
            texts_report[39] = report.Apartment.PlanMeets;
            texts_report[40] = "";
            texts_report[41] = "";
            texts_report[42] = "";
            texts_report[43] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForKitchenCeiling);
            texts_report[44] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomCeiling);
            texts_report[45] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForHallCeiling);
            texts_report[46] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[47] = client_in_padeg;
            texts_report[48] = report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[49] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[50] = report.Client.Man.Surname+" "+report.Client.Man.Name+" "+report.Client.Man.Patronymic;
            texts_report[51] = report.Client.Man.Surname + " " + report.Client.Man.Name + " " + report.Client.Man.Patronymic;
            texts_report[52] = " серия " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            texts_report[53] = "";
            texts_report[54] = "";
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
            texts_report[68] = "";
            texts_report[69] = Convert.ToString(report.Apartment.Object.Discount * 100) + "%";
            texts_report[70] = Convert.ToString(report.Apartment.Object.Discount * 100) + "%";
            texts_report[71] = "";
            texts_report[72] = " серия " +
                                        report.Client.Man.Document.Series + " номер " +
                                        report.Client.Man.Document.Number + " " +
                                        report.Client.Man.Document.PlaceOfIssue;
            texts_report[73] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[74] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[75] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[76] = Convert.ToString(report.Apartment.Object.Dollar);
            texts_report[77] = "";
            texts_report[78] = "";
            texts_report[79] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[80] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[81] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[82] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[83] = report.Employee.Man.Surname + " " + report.Employee.Man.Name + " " + report.Employee.Man.Patronymic;
            texts_report[84] = "";
            texts_report[85] = "";
            texts_report[86] = " серия " +
                                        report.Employee.Man.Document.Series + " номер " +
                                        report.Employee.Man.Document.Number + " " +
                                        report.Employee.Man.Document.PlaceOfIssue;
            texts_report[87] = report.Employee.FurtherEducation;
            texts_report[88] = report.Employee.FurtherEducation;
            texts_report[89] = report.Employee.Insurance;
            texts_report[90] = report.Employee.Insurance;
            texts_report[91] = report.Employee.Insurance;
            texts_report[92] = report.Employee.Insurance;
            texts_report[93] = report.Employee.Position;
            texts_report[94] = "";
            texts_report[95] = report.Employee.Membership;
            texts_report[96] = report.Employee.Membership;
            texts_report[97] = report.Employee.Membership;
            texts_report[98] = report.Employee.Membership;
            texts_report[99] = Convert.ToString(report.Employee.WorkTime);
            texts_report[100] = Convert.ToString(report.Employee.WorkTime);
            texts_report[101] = report.Apartment.AuxiliaryRooms;
            texts_report[102] = "";
            texts_report[103] = report.Apartment.GetApartmentStateAsString(report.Apartment.ApartmentState);
            texts_report[104] = Convert.ToString(report.Apartment.CeilingHeight);
            texts_report[105] = "";
            texts_report[106] = Convert.ToString(report.Apartment.Floor);
            texts_report[107] = Convert.ToString(report.Apartment.Floor);
            texts_report[108] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForHallFloor);
            texts_report[109] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForKitchenFloor);
            texts_report[110] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomFloor);
            texts_report[111] = Convert.ToString(report.Apartment.Floors);
            texts_report[112] = Convert.ToString(report.Apartment.Floors);
            texts_report[113] = "";
            texts_report[114] = "";
            texts_report[115] = "";
            texts_report[116] = "";
            texts_report[117] = "";
            texts_report[118] = report.Apartment.Object.Holders;
            texts_report[119] = report.Apartment.Object.Holders;
            texts_report[120] = "";
            texts_report[121] = "";
            texts_report[122] = "";
            texts_report[123] = "";
            texts_report[124] = "";
            texts_report[125] = "";
            texts_report[126] = "";
            texts_report[127] = "";
            texts_report[128] = "";
            texts_report[129] = "";
            texts_report[130] = "";
            texts_report[131] = "";
            texts_report[132] = "";
            texts_report[133] = "";
            texts_report[134] = "";
            texts_report[135] = "";
            texts_report[136] = "";
            texts_report[137] = ""; 
            texts_report[138] = "";
            texts_report[139] = "";
            texts_report[140] = "";
            texts_report[141] = "";
            texts_report[142] = "";
            texts_report[143] = "";
            texts_report[144] = "";
            texts_report[145] = "";
            texts_report[146] = "";
            texts_report[147] = "";
            texts_report[148] = "";
            texts_report[149] = "";
            texts_report[150] = "";
            texts_report[151] = "";
            texts_report[152] = "";
            texts_report[153] = report.Apartment.PlanMeets;
            texts_report[154] = "";
            texts_report[155] = "";
            texts_report[156] = "";
            texts_report[157] = "";
            texts_report[158] = "";
            texts_report[159] = "";
            texts_report[160] = "";
            texts_report[161] = Convert.ToString(report.Apartment.KitchenArea); ;
            texts_report[162] = "";
            texts_report[163] = report.Apartment.Object.Restriction;
            texts_report[164] = report.Apartment.Object.Restriction;
            texts_report[165] = Convert.ToString(report.Apartment.LivingArea);
            texts_report[166] = Convert.ToString(report.Apartment.LivingArea);
            texts_report[167] = "";
            texts_report[168] = "";
            texts_report[169] = "";
            texts_report[170] = report.Apartment.Object.ObjectType;
            texts_report[171] = report.Apartment.Object.ObjectType;
            texts_report[172] = report.Apartment.Object.ObjectType;
            texts_report[173] = report.Apartment.Object.ObjectType;
            texts_report[174] = report.Apartment.Object.ObjectType;
            texts_report[175] = report.Apartment.Object.ObjectType;
            texts_report[176] = "";
            texts_report[177] = "";
            texts_report[178] = report.Apartment.PlanMeets;
            texts_report[179] = report.Apartment.ViewOnApparment=="ok"?"регистрация возможна":"регистрация не возможна";
            texts_report[180] = "";
            texts_report[181] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[182] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[183] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[184] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[185] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[186] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[187] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[188] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[189] = Convert.ToString(report.Apartment.Object.Price);
            texts_report[190] = "";
            texts_report[191] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[192] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[193] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[194] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[195] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[196] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[197] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount));
            texts_report[198] = "";
            texts_report[199] = "";
            texts_report[200] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_report[201] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_report[202] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_report[203] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_report[204] = Convert.ToString(report.Apartment.Object.Price * (1 - report.Apartment.Object.Discount) / report.Apartment.Object.Dollar);
            texts_report[205] = "";
            texts_report[206] = "";
            texts_report[207] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[208] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[209] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[210] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[211] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.Object.Dollar);
            texts_report[212] = "";
            texts_report[213] = "";
            texts_report[214] = "";
            texts_report[215] = "";
            texts_report[216] = "";
            texts_report[217] = "";
            texts_report[218] = report.Apartment.Object.PurposeOfTheEvaluation;
            texts_report[219] = report.Apartment.GetRepairWorkAsString(report.Apartment.RepairWork);
            texts_report[220] = report.Apartment.GetRoomFinishingQualityAsString(report.Apartment.RoomFinishingQuality);
            texts_report[221] = report.ReportDate.ToShortDateString();
            texts_report[222] = report.ReportDate.ToShortDateString();
            texts_report[223] = report.ReportDate.ToLongDateString();
            texts_report[224] = report.ReportDate.ToLongDateString();
            texts_report[225] = report.ReportNumber;
            texts_report[226] = report.ReportNumber;
            texts_report[227] = report.ReportNumber;
            texts_report[228] = report.ReportNumber;
            texts_report[229] = report.ReportNumber;
            texts_report[230] = report.ReportNumber;
            texts_report[231] = "";
            texts_report[232] = report.Apartment.Object.Property;
            texts_report[233] = report.Apartment.Object.Property;
            texts_report[234] = "";
            texts_report[235] = "";
            texts_report[236] = report.Apartment.GetRoomTypeAsString(report.Apartment.RoomType);
            texts_report[237] = report.Apartment.GetWashroomTypeAsString(report.Apartment.WashroomType);
            texts_report[238] = "";
            texts_report[239] = "";
            texts_report[240] = report.Apartment.HasSeparateKitchenOrWashroom == true ? "есть" : "нет";
            texts_report[241] = "";
            texts_report[242] = report.Apartment.HasLowCurrent == true ? "есть" : "нет";
            texts_report[243] = "";
            texts_report[244] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.GrossArea);
            texts_report[245] = Convert.ToString(report.Apartment.Object.Price / report.Apartment.GrossArea);
            texts_report[246] = Convert.ToString((report.Apartment.Object.Price / report.Apartment.GrossArea) / report.Apartment.Object.Dollar);
            texts_report[247] = "";
            texts_report[248] = "";
            texts_report[249] = "";
            texts_report[250] = report.Apartment.GetCeilingMaterialAsString(report.Apartment.FinishingMaterialForWashroomCeiling);
            texts_report[251] = report.Apartment.GetFloorMaterialAsString(report.Apartment.FinishingMaterialForWashroomFloor);
            texts_report[252] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForWashroomWall);
            texts_report[253] = "";
            texts_report[254] = "";
            texts_report[255] = report.Apartment.Views;
            texts_report[256] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForHallWall);
            texts_report[257] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForKitchenWall);
            texts_report[258] = report.Apartment.GetWallMaterialAsString(report.Apartment.FinishingMaterialForLivingRoomWall);
            texts_report[259] = "";
            texts_report[260] = "";
            texts_report[261] = "";
            texts_report[262] = "";
            texts_report[263] = "";
            texts_report[264] = "";
            texts_report[265] = "";
            texts_report[266] = "верхняя";
            texts_report[267] = "";
            texts_report[268] = "";
            texts_report[269] = "";
            texts_report[270] = Convert.ToString(report.ReportDate.Year); 
            texts_report[271] = "";



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


//Генерация документа Excel и заполнение данных в отчете Договор
        public static void XLSGenerate(string templateFileName, string reportFileName, IReport report,  int rod) 
        {
            Microsoft.Office.Interop.Excel.Application excelAppl = new Microsoft.Office.Interop.Excel.Application();    // Создать документ Word
            object d = (object)templateFileName;                                                                            // Создать пустой объект

            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = excelAppl.Workbooks.Open(templateFileName);                                                      // Открыть документ по указанному в объекте адресу
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = excelAppl.Worksheets.get_Item(1);//ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;


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
