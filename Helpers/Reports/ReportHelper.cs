using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels.Reports;
using ZAVOD_KZZ.Helpers.Enums;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Helpers.Reports
{
    public static class ReportHelper
    {
        public static byte[] RoadsReport(IEnumerable<Road> roads)
        {
            byte[] result;

            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Prikaz");

                string[] colNames = new string[]
                {
                    "RB",
                    "Kategorija",
                    "Oznaka",
                    "Opis",
                    "NN",
                    "Mjereno na DOF-u"
                };

                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[1, i + 1].Value = colNames[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int row = 2;
                int rowCount = 1;


                foreach (var road in roads)
                {
                    for (int col = 1; col <= colNames.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 11;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    worksheet.Cells[row, 1].Value = rowCount;
                    worksheet.Cells[row, 2].Value = road.RoadCategory.Name;
                    worksheet.Cells[row, 3].Value = road.Code;
                    worksheet.Cells[row, 4].Value = road.Description;
                    worksheet.Cells[row, 5].Value = road.DigitalOrthophotoLength;
                    worksheet.Cells[row, 6].Value = road.SpatialNewslength;

                    if (row % 2 == 0)
                    {
                        var styledCells = string.Format("A{0}:F{0}", row);
                        worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
                    }

                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                if (roads.Any())
                {
                    var lastRow = row - 1;
                    var mergedCells = string.Format("A{0}:D{0}", row);

                    MergeCellsHorizontal(worksheet, mergedCells);

                    worksheet.Cells[row, 5].FormulaR1C1 = string.Format("=SUM(E2:E{0})", lastRow);
                    worksheet.Cells[row, 6].FormulaR1C1 = string.Format("=SUM(F2:F{0})", lastRow);

                    string finalRowRange = string.Format("A{0}:F{0}", row);
                    StyleFinalRow(worksheet, finalRowRange);
                }
                result = excel.GetAsByteArray();
            }
            return result;
        }
        public static byte[] RoadsByLocalGovernmentReport(IEnumerable<RoadLocalGovernment> roads)
        {
            byte[] result;

            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Prikaz");

                string[] colNames = new string[]
                {
                    "RB",
                    "JLS",
                    "Kategorija",
                    "Oznaka",
                    "Opis",
                    "Duljina u JLS",
                    "Ukupna duljina (NN)"
                };

                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[1, i + 1].Value = colNames[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int row = 2;
                int rowCount = 1;
                foreach (var road in roads)
                {
                    for (int col = 1; col <= colNames.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 11;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    worksheet.Cells[row, 1].Value = rowCount;
                    worksheet.Cells[row, 2].Value = road.LocalGovernmentAdministration.Name;
                    worksheet.Cells[row, 3].Value = road.Road.RoadCategory.Name;
                    worksheet.Cells[row, 4].Value = road.Road.Code;
                    worksheet.Cells[row, 5].Value = road.Road.Description;
                    worksheet.Cells[row, 6].Value = road.RoadLength;
                    worksheet.Cells[row, 7].Value = road.Road.SpatialNewslength;

                    if (row % 2 == 0)
                    {
                        var styledCells = string.Format("A{0}:G{0}", row);
                        StyleEvenRows(worksheet,styledCells);
                    }

                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                if (roads.Any())
                {
                    var lastRow = row - 1;
                    var mergedCells = string.Format("A{0}:E{0}", row);
                    MergeCellsHorizontal(worksheet, mergedCells);

                    worksheet.Cells[row, 6].FormulaR1C1 = string.Format("=SUM(F2:F{0})", lastRow);
                    worksheet.Cells[row, 7].FormulaR1C1 = string.Format("=SUM(G2:G{0})", lastRow);

                    string finalRowRange = string.Format("A{0}:G{0}", row);
                    StyleFinalRow(worksheet, finalRowRange);

                }

                result = excel.GetAsByteArray();
            }
            return result;
        }
        public static byte[] SpatialPlansReport(IEnumerable<SpatialPlanDocument> spatialPlans)
        {
            byte[] result;

            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Prikaz");

                string[] colNames = new string[]
                {
                    "RB",
                    "JLS",
                    "Vrsta",
                    "Naziv",
                    "Puni naziv plana",
                    "Naziv revizije Plana",
                    "ISPU",
                    "Status",
                    "Mjerilo",
                    "Datum donošenja",
                    "Glasnik",
                    "Veza na glasnik",
                    "Odluka na snazi",
                    "Objava glasnika",
                    "Napomena na glasnik",
                    "Odluka o izradi",
                    "Suglasnost",
                    "Izrađivač",
                    "Projekcija",
                    "Stanje dokumenta",
                    "Konzervatorska",
                    "SPUO/PUO",
                    "Napomena na plan",
                    "Broj priloga"
                };
           

                var mergedCells = string.Format("A{0}:D{0}", 1);
                worksheet.Cells[mergedCells].Merge = true;
                worksheet.Cells[mergedCells].Value = string.Format("Stanje planova na {0}",DateTime.Now.ToShortDateString());
                worksheet.Cells[mergedCells].Style.Font.Color.SetColor(Color.Black);
                worksheet.Cells[mergedCells].Style.Font.Size = 15;
                worksheet.Cells[mergedCells].Style.Font.Italic = true;
                worksheet.Cells[mergedCells].Style.Font.Bold = true;
                worksheet.Cells[mergedCells].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[3, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[3, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[3, i + 1].Value = colNames[i];
                    worksheet.Cells[3, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[3, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[3, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int row = 4;
                int rowCount = 1;

                foreach (var plan in spatialPlans)
                {
                    for (int col = 1; col <= colNames.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 11;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    worksheet.Cells[row, 1].Value = rowCount;
                    worksheet.Cells[row, 2].Value = plan.LocalGovernmentAdministration.Name;
                    worksheet.Cells[row, 3].Value = plan.SpatialPlanLevel.ShortName;
                    worksheet.Cells[row, 4].Value = plan.Name;
                    worksheet.Cells[row, 5].Value = plan.FullName;
                    worksheet.Cells[row, 6].Value = plan.RevisionName;
                    worksheet.Cells[row, 7].Value = plan.IspuName;
                    worksheet.Cells[row, 8].Value = plan.SpatialPlanStatus.Name;
                    worksheet.Cells[row, 9].Value = plan.SpatialMeasure.Name;
                    worksheet.Cells[row, 10].Value = (plan.SpatialPlanEnactmentDate.HasValue) ? plan.SpatialPlanEnactmentDate.Value.ToShortDateString(): string.Empty;
                    worksheet.Cells[row, 11].Value = string.Format("{0} - (NN - {1})", plan.OfficalSpatialNews.Name, plan.OfficialSpatialNewsNumber);
                    worksheet.Cells[row, 12].Value = plan.OfficialSpatialNewsNumberUrl;
                    worksheet.Cells[row, 13].Value = (plan.SpatialPlanEffectiveDate.HasValue) ? plan.SpatialPlanEffectiveDate.Value.ToShortDateString() : string.Empty;
                    worksheet.Cells[row, 14].Value = (plan.SpatialPlanPublicationDate.HasValue) ? plan.SpatialPlanPublicationDate.Value.ToShortDateString() : string.Empty;
                    worksheet.Cells[row, 15].Value = plan.OfficialSpatialNewsRemark;
                    worksheet.Cells[row, 16].Value = (plan.SpatialPlanAnnouncementDevelopDate.HasValue) ? plan.SpatialPlanAnnouncementDevelopDate.Value.ToShortDateString() : string.Empty;
                    worksheet.Cells[row, 17].Value = plan.SpatialPlanApprovalRemark;
                    worksheet.Cells[row, 18].Value = plan.SpatialPlanner.Name;
                    worksheet.Cells[row, 19].Value = plan.SpatialProjection.ShortName;
                    worksheet.Cells[row, 20].Value = plan.SpatialPlanDelivery.DeliveryStatus;
                    worksheet.Cells[row, 21].Value = plan.ConservationDocument.ValidationStatus;
                    worksheet.Cells[row, 22].Value = plan.SpuoPuoDocument.Name;
                    worksheet.Cells[row, 23].Value = plan.SpatialPlanDocumentationRemark;
                    worksheet.Cells[row, 24].Value = plan.SpatialPlanAdditionalDocuments.Count();


                    if (row % 2 == 0)
                    {
                        var styledCells = string.Format("A{0}:X{0}", row);
                        worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
                    }

                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
               
                result = excel.GetAsByteArray();
            }
            return result;
        }
        public static byte[] RailoadsReport(IEnumerable<Railroad> railroads)
        {
            byte[] result;

            var unsortedCategory = new List<int>
            {
                (int)Enums.Enums.RailroadCategory.PLANNED,
                (int)Enums.Enums.RailroadCategory.ALL
            };

            var totalSum = railroads.Where(x => !unsortedCategory.Contains(x.RailroadCategoryID)).Sum(x => x.Lenght);

            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Prikaz");

                string[] colNames = new string[]
                {
                    "RB",
                    "Oznaka",
                    "Kategorija",
                    "Puni naziv",
                    "Skraćeni naziv",
                    "Građevinska duljina",
                    "Duljina u KZŽ",
                    "Broj kolodvora",
                    "Broj stajališta",
                    "Udio u %"
                };

                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[1, i + 1].Value = colNames[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int row = 2;
                int rowCount = 1;


                foreach (var railroad in railroads)
                {
                    for (int col = 1; col <= colNames.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 11;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }


                    var percentageValue = TotalPercentage.GetTotalPercentageValue(railroad.Lenght, totalSum);
                    worksheet.Cells[row, 1].Value = rowCount;
                    worksheet.Cells[row, 2].Value = railroad.Code;
                    worksheet.Cells[row, 3].Value = railroad.RailroadCategory.Name;
                    worksheet.Cells[row, 4].Value = railroad.FullName;
                    worksheet.Cells[row, 5].Value = railroad.ShortName;
                    worksheet.Cells[row, 6].Value = railroad.ConstructionLength;
                    worksheet.Cells[row, 7].Value = railroad.Lenght;
                    worksheet.Cells[row, 8].Value = railroad.TrainStationNumber;
                    worksheet.Cells[row, 9].Value = railroad.TrainPositionNumber;
                    worksheet.Cells[row, 10].Value = percentageValue;



                    if (row % 2 == 0)
                    {
                        var styledCells = string.Format("A{0}:J{0}", row);
                        worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
                    }

                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                if (railroads.Any())
                {
                    var lastRow = row - 1;
                    var mergedCells = string.Format("A{0}:E{0}", row);

                    MergeCellsHorizontal(worksheet, mergedCells);

                    worksheet.Cells[row, 6].FormulaR1C1 = string.Format("=SUM(F2:F{0})", lastRow);
                    worksheet.Cells[row, 7].FormulaR1C1 = string.Format("=SUM(G2:G{0})", lastRow);
                    worksheet.Cells[row, 8].FormulaR1C1 = string.Format("=SUM(H2:H{0})", lastRow);
                    worksheet.Cells[row, 9].FormulaR1C1 = string.Format("=SUM(I2:I{0})", lastRow);
                    worksheet.Cells[row, 10].FormulaR1C1 = string.Format("=SUM(J2:J{0})", lastRow);

                    string finalRowRange = string.Format("A{0}:J{0}", row);
                    StyleFinalRow(worksheet, finalRowRange);
                }
                result = excel.GetAsByteArray();
            }
            return result;
        }
        public static byte[] RailroadsByLocalGovernmentReport(IEnumerable<RailroadLocalGovernment> railroads)
        {
            byte[] result;

            var unsortedCategory = new List<int>
            {
                (int)Enums.Enums.RailroadCategory.PLANNED,
                (int)Enums.Enums.RailroadCategory.ALL
            };

            var totalSum = railroads.Where(x => !unsortedCategory.Contains(x.Railroad.RailroadCategoryID)).Sum(x => x.Railroad.Lenght);

            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Prikaz");

                string[] colNames = new string[]
                {
                    "RB",
                    "JLS",
                    "Oznaka",
                    "Kategorija",
                    "Puni naziv",
                    "Skraćeni naziv",
                    "Građevinska duljina",
                    "Duljina u KZŽ",
                    "Broj kolodvora",
                    "Broj stajališta",
                    "Udio u %"
                };

                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[1, i + 1].Value = colNames[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int row = 2;
                int rowCount = 1;


                foreach (var railroad in railroads)
                {
                    for (int col = 1; col <= colNames.Length; col++)
                    {
                        worksheet.Cells[row, col].Style.Font.Size = 11;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }


                    var percentageValue = TotalPercentage.GetTotalPercentageValue(railroad.RailroadLength, totalSum);
                    worksheet.Cells[row, 1].Value = rowCount;
                    worksheet.Cells[row, 2].Value = railroad.LocalGovernmentAdministration.Name;
                    worksheet.Cells[row, 3].Value = railroad.Railroad.Code;
                    worksheet.Cells[row, 4].Value = railroad.Railroad.RailroadCategory.Name;
                    worksheet.Cells[row, 5].Value = railroad.Railroad.FullName;
                    worksheet.Cells[row, 6].Value = railroad.Railroad.ShortName;
                    worksheet.Cells[row, 7].Value = railroad.Railroad.ConstructionLength;
                    worksheet.Cells[row, 8].Value = railroad.Railroad.Lenght;
                    worksheet.Cells[row, 9].Value = railroad.Railroad.TrainStationNumber;
                    worksheet.Cells[row, 10].Value = railroad.Railroad.TrainPositionNumber;
                    worksheet.Cells[row, 11].Value = percentageValue;



                    if (row % 2 == 0)
                    {
                        var styledCells = string.Format("A{0}:K{0}", row);
                        worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
                    }

                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                if (railroads.Any())
                {
                    var lastRow = row - 1;
                    var mergedCells = string.Format("A{0}:F{0}", row);

                    MergeCellsHorizontal(worksheet, mergedCells);

                    worksheet.Cells[row, 7].FormulaR1C1 = string.Format("=SUM(G2:G{0})", lastRow);
                    worksheet.Cells[row, 8].FormulaR1C1 = string.Format("=SUM(H2:H{0})", lastRow);
                    worksheet.Cells[row, 9].FormulaR1C1 = string.Format("=SUM(I2:I{0})", lastRow);
                    worksheet.Cells[row, 10].FormulaR1C1 = string.Format("=SUM(J2:J{0})", lastRow);
                    worksheet.Cells[row, 11].FormulaR1C1 = string.Format("=SUM(K2:K{0})", lastRow);

                    string finalRowRange = string.Format("A{0}:K{0}", row);
                    StyleFinalRow(worksheet, finalRowRange);
                }
                result = excel.GetAsByteArray();
            }
            return result;
        }

        public static byte[] NaturalChangeReport(IEnumerable<NaturalChangePopulation> naturalChanges) {
            byte[] result;
            string[] colNames = new string[]
            {
                    "RB",
                    "JLS",
                    "Broj stanovnika (zadnji popis)",
                    "Živorođeni",
                    "Mrtvorođeni",
                    "Ukupno rođeni",
                    "Umrli",
                    "Umrla dojenčad",
                    "Ukupno umrlih",
                    "Prirodni prirast",
                    "Vitalni indeks",
                    "Stopa nataliteta",
                    "Stopa mortaliteta"
            };


            // group by year
            var groupYears = naturalChanges.GroupBy(x => x.Year).Select(y => y.Key).OrderByDescending(z => z);
            using (var excel = new ExcelPackage())
            {

                foreach (var year in groupYears)
                {
                    var worksheet = excel.Workbook.Worksheets.Add(string.Format("{0}. godina", year));
                    for (int i = 0; i < colNames.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                        worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                        worksheet.Cells[1, i + 1].Value = colNames[i];
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                    }

                    int row = 2;
                    int rowCount = 1;

                    foreach (var natural in naturalChanges)
                    {

                        if (natural.Year == year)
                        {
                            for (int col = 1; col <= colNames.Length; col++)
                            {
                                worksheet.Cells[row, col].Style.Font.Size = 11;
                                worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            worksheet.Cells[row, 1].Value = rowCount;
                            worksheet.Cells[row, 2].Value = natural.LocalGovernmentAdministration.Name;
                            worksheet.Cells[row, 3].Value = natural.LocalGovernmentAdministration.Population2021.HasValue 
                                                            ? (natural.LocalGovernmentAdministration.Population2011.HasValue ? natural.LocalGovernmentAdministration.Population2011 : 0)
                                                            : 0;
                            worksheet.Cells[row, 4].Value = natural.LiveBirth;
                            worksheet.Cells[row, 5].Value = natural.StillBirth;
                            worksheet.Cells[row, 6].Value = natural.TotalBirth;
                            worksheet.Cells[row, 7].Value = natural.Death;
                            worksheet.Cells[row, 8].Value = natural.InfantDeath;
                            worksheet.Cells[row, 9].Value = natural.TotalDeathBirth;
                            worksheet.Cells[row, 10].Value = natural.NaturalIncrease;
                            worksheet.Cells[row, 11].Value = natural.VitalIndex;
                            worksheet.Cells[row, 12].Value = natural.BirthRate;
                            worksheet.Cells[row, 13].Value = natural.DeathRate;


                            if (row % 2 == 0)
                            {
                                var styledCells = string.Format("A{0}:M{0}", row);
                                worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
                            }

                            row++;
                            rowCount++;
                        }
                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    if (naturalChanges.Any())
                    {
                        foreach (var styling in naturalChanges)
                        {
                            if (styling.Year == year)
                            {
                                var lastRow = row - 1;
                                var mergedCells = string.Format("A{0}:B{0}", row);

                                MergeCellsHorizontal(worksheet, mergedCells);

                                worksheet.Cells[row, 3].Formula = string.Format("=SUM(C2:C{0})", lastRow);
                                worksheet.Cells[row, 4].FormulaR1C1 = string.Format("=SUM(D2:D{0})", lastRow);
                                worksheet.Cells[row, 5].FormulaR1C1 = string.Format("=SUM(E2:E{0})", lastRow);
                                worksheet.Cells[row, 6].FormulaR1C1 = string.Format("=SUM(F2:F{0})", lastRow);
                                worksheet.Cells[row, 7].FormulaR1C1 = string.Format("=SUM(G2:G{0})", lastRow);
                                worksheet.Cells[row, 8].FormulaR1C1 = string.Format("=SUM(H2:H{0})", lastRow);
                                worksheet.Cells[row, 9].FormulaR1C1 = string.Format("=SUM(I2:I{0})", lastRow);

                                string finalRowRange = string.Format("A{0}:I{0}", row);
                                StyleFinalRow(worksheet, finalRowRange);
                            }
                        }
                       
                    }

                }
            
                result = excel.GetAsByteArray();
            }
            return result;
        }


        public static byte[] OfficialDocumentsZaraReport( IEnumerable<OfficialDocumentZaraReportVM> zaraReportVM)
        {
            byte[] result;
            string[] colNames = new string[]
            {
                    "RB",
                    "Naziv",
                    "Skraćeni naziv",
                    "Tip dokumenta",
                    "Status dokumenta",
                    "Glasnik",
                    "Broj Sl. gl",
                    "Veza na glasnik",
                    "Datum stupanja na snagu",
                    "Datum stupanja van snage",
                    "Obavezni dokumentacija",
                    "Dodatna dokumentacija",
                    "Opis"
            };


            using (var excel = new ExcelPackage())
            {
                var worksheet = excel.Workbook.Worksheets.Add("Dokumenti");


                for (int i = 0; i < colNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Style.Font.Size = 12;
                    worksheet.Cells[1, i + 1].Style.Font.Name = "Calibri";
                    worksheet.Cells[1, i + 1].Value = colNames[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 243, 214));
                }

                int rowCount = 1;

                int requiredRow = 2;
                int additionalRow = 2;
                int row = 2;
               

                foreach (var report in zaraReportVM)
                {
                    var totalRowCount = new List<int> { row, requiredRow, additionalRow }.Max();

                    worksheet.Cells[totalRowCount, 1].Value = rowCount;
                    worksheet.Cells[totalRowCount, 2].Value = report.Name;
                    worksheet.Cells[totalRowCount, 3].Value = report.ShortName;
                    worksheet.Cells[totalRowCount, 4].Value = report.DocumentType;
                    worksheet.Cells[totalRowCount, 5].Value = report.DocumentStatus;
                    worksheet.Cells[totalRowCount, 6].Value = report.OfficialNews;
                    worksheet.Cells[totalRowCount, 7].Value = report.OfficialNewsNumber;
                    worksheet.Cells[totalRowCount, 13].Value = report.DocumentRemark;
                    if (string.IsNullOrEmpty(report.OfficialNewsUrl))
                    {
                        worksheet.Cells[totalRowCount, 8].Value = string.Empty;
                    }
                    else
                    {
                        CreateHyperLink(worksheet, totalRowCount, 8, report.OfficialNewsUrl);
                    }
                    worksheet.Cells[totalRowCount, 9].Value = report.DateEffective;
                    worksheet.Cells[totalRowCount, 10].Value = report.DateIneffective;

                    if (report.RequiredDocumentsZara.Any())
                    {
                        
                        foreach (var required in report.RequiredDocumentsZara)
                        {
                            CreateHyperLink(worksheet, requiredRow, 11, required.DocumentUrl);
                            requiredRow++;
                        }
                    }

                    if (report.AdditionalDocumentsZara.Any())
                    {

                        foreach (var additional in report.AdditionalDocumentsZara)
                        {
                            CreateHyperLink(worksheet, additionalRow, 12, additional.DocumentUrl);
                            additionalRow++;
                        }

                        var addRowToAdditional= report.RequiredDocumentsZara.Count() != report.AdditionalDocumentsZara.Count() 
                            ? Math.Abs(report.RequiredDocumentsZara.Count() - report.AdditionalDocumentsZara.Count()) 
                            : 0;
                        additionalRow += addRowToAdditional;
                    }


                    row++;
                    rowCount++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                result = excel.GetAsByteArray();
            }
            return result;
        }

        private static void StyleFinalRow(ExcelWorksheet worksheet, string finalRowRange)
        {
            worksheet.Cells[finalRowRange].Style.Font.Color.SetColor(Color.Green);
            worksheet.Cells[finalRowRange].Style.Border.Top.Style = ExcelBorderStyle.Medium;
            worksheet.Cells[finalRowRange].Style.Font.Size = 12;
            worksheet.Cells[finalRowRange].Style.Font.Italic = true;
            worksheet.Cells[finalRowRange].Style.Font.Bold = true;
        }

        private static void StyleEvenRows(ExcelWorksheet worksheet, string styledCells)
        {
            worksheet.Cells[styledCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[styledCells].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(229, 245, 224));
        }

        private static void MergeCellsHorizontal(ExcelWorksheet worksheet, string mergedCells)
        {
            worksheet.Cells[mergedCells].Merge = true;
            worksheet.Cells[mergedCells].Value = "UKUPNO";
            worksheet.Cells[mergedCells].Style.Font.Color.SetColor(Color.Green);
            worksheet.Cells[mergedCells].Style.Font.Size = 12;
            worksheet.Cells[mergedCells].Style.Font.Italic = true;
            worksheet.Cells[mergedCells].Style.Font.Bold = true;
            worksheet.Cells[mergedCells].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        private static void MergeCellsVertical(ExcelWorksheet worksheet, string mergedCells)
        {
            worksheet.Cells[mergedCells].Merge = true;
            worksheet.Cells[mergedCells].Style.Font.Size = 12;
            worksheet.Cells[mergedCells].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        private static void CreateHyperLink(ExcelWorksheet worksheet, int row, int column, string urlValue)
        {
            worksheet.Cells[row, column].Style.Font.UnderLine = true;
            worksheet.Cells[row, column].Style.Font.Bold = true;
            worksheet.Cells[row, column].Style.Font.Color.SetColor(Color.Green);
            worksheet.Cells[row, column].Hyperlink = new Uri(urlValue);
        }

      
    }
}
