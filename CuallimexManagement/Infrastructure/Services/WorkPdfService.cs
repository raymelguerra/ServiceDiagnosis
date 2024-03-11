using CuallimexManagement.Entities;
using CuallimexManagement.Infrastructure.Interfaces;
using OfficeOpenXml;

namespace CuallimexManagement.Infrastructure.Services;
public class WorkPdfService : IWorkPdf
{
    public async Task<byte[]> Download(Report report)
    {
        var excelTemplatePath = "wwwroot/templates/template.xlsx";

        using (var templateStream = File.OpenRead(excelTemplatePath))
        {

            using (var excelPackage = new ExcelPackage(templateStream))
            {
                #region Work with excel
                var worksheet = excelPackage.Workbook.Worksheets[0];

                // Datos de la empresa
                worksheet.Cells["B5:E5"].Value = $"EMPRESA: {report.Company.CompanyName}";
                worksheet.Cells["B6:E8"].Value = $"DOMICILIO FISCAL: {report.Company.FiscalAddress}";
                worksheet.Cells["B9:C10"].Value = $"RFC: {report.Company.TaxId}";
                worksheet.Cells["E9:E10"].Value = $"{report.Folio}";

                // Datos del equipo
                worksheet.Cells["K5:M5"].Value = $"{report.Equipment.Brand}";
                worksheet.Cells["K6:M6"].Value = $"{report.Equipment.Model}";
                worksheet.Cells["K7:M7"].Value = $"{report.Equipment.SerialNumber}";
                worksheet.Cells["K8:M8"].Value = $"{report.Equipment.ManufactureYear}";
                worksheet.Cells["K9:M9"].Value = $"{report.CollectionDate}";
                worksheet.Cells["K10:M10"].Value = $"{report.EntryReason}";

                // Generales
                worksheet.Cells["B57:M59"].Value = $"{report.PhysicalDamage}";
                worksheet.Cells["B61:E64"].Value = $"{report.Comment}";
                worksheet.Cells["D65:E66"].Value = $"{report.Responsible.Name}";
                worksheet.Cells["F61:J66"].Value = $"{report.RequiredParts}";
                worksheet.Cells["K61:M64"].Value = $"{report.RequiredParts}";
                worksheet.Cells["K66"].Value = $"{report.ReportDate}";


                /* Inspeccion fisica*/
                if (report.PhysicalInspection != null)
                {
                    // Datos del motor
                    worksheet.Cells["F13"].Value = $"MARCA: {report.PhysicalInspection.Brand}";
                    worksheet.Cells["F14"].Value = $"MODELO: {report.PhysicalInspection.Model}";
                    worksheet.Cells["F15"].Value = $"AÑO: {report.PhysicalInspection.Year}";
                    worksheet.Cells["F16"].Value = $"SERIE: {report.PhysicalInspection.SerialNumber}";
                    worksheet.Cells["F18"].Value = $"RPM: {report.PhysicalInspection.RPM}";
                    worksheet.Cells["F17"].Value = $"POTENCIA: {report.PhysicalInspection.Power}";
                    worksheet.Cells["D21"].Value = report.PhysicalInspection.TestCanBePerformed ? "SI" : "NO";
                    worksheet.Cells["J22"].Value = report.PhysicalInspection.DisassemblyRequired ? "SI" : "NO";
                    worksheet.Cells["B22:I23"].Value = $"{report.PhysicalInspection.TestComments}";

                    // Condiciones del equipo
                    worksheet.Cells[$"B13:C17"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.PhysicalInspection.EquipmentConditions != null)
                    {
                        int rowIndex = 13; ;
                        foreach (string item in report.PhysicalInspection.EquipmentConditions.Split(", "))
                        {
                            worksheet.Cells[$"B{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["B18:C20"].Value = $"COMENTARIOS: {report.PhysicalInspection.EquipmentComments}";
                    }

                    // Condiciones del motor
                    worksheet.Cells[$"D13:E17"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.PhysicalInspection.MotorCondition != null)
                    {
                        int rowIndex = 13; ;
                        foreach (string item in report.PhysicalInspection.MotorCondition.Split(", "))
                        {
                            worksheet.Cells[$"D{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["D18:E20"].Value = $"COMENTARIOS: {report.PhysicalInspection.MotorComments}";
                    }

                    // Cubierta del motor
                    worksheet.Cells[$"H13:J17"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.PhysicalInspection.MotorCoverCondition != null)
                    {
                        int rowIndex = 13; ;
                        foreach (string item in report.PhysicalInspection.MotorCoverCondition.Split(", "))
                        {
                            worksheet.Cells[$"H{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["H18:J20"].Value = $"COMENTARIOS: {report.PhysicalInspection.MotorCoverComments}";
                    }

                    // Ventilador del motor
                    worksheet.Cells[$"K13:M17"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.PhysicalInspection.MotorFanCondition != null)
                    {
                        int rowIndex = 13; ;
                        foreach (string item in report.PhysicalInspection.MotorFanCondition.Split(", "))
                        {
                            worksheet.Cells[$"K{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["K18:M20"].Value = $"COMENTARIOS: {report.PhysicalInspection.MotorFanComments}";
                    }
                }

                /* Modulo de vacio y/o presion */
                if (report.ModuleInspection != null)
                {
                    // valvulas
                    worksheet.Cells[$"B26:C29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.VacuumPressureValves != null)
                    {
                        int rowIndex = 26; ;
                        foreach (string item in report.ModuleInspection.VacuumPressureValves.Split(", "))
                        {
                            worksheet.Cells[$"B{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["B30:C32"].Value = $"COMENTARIOS: {report.ModuleInspection.VacuumPressureValvesComments}";
                    }

                    // Filtros de aire
                    worksheet.Cells[$"H26:I29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.AirFilters != null)
                    {
                        int rowIndex = 26; ;
                        foreach (string item in report.ModuleInspection.AirFilters.Split(", "))
                        {
                            worksheet.Cells[$"H{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["H30:I32"].Value = $"COMENTARIOS: {report.ModuleInspection.AirFiltersComments}";
                    }

                    // Condiciones del radiador
                    worksheet.Cells[$"J26:K29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.RadiatorConditions != null)
                    {
                        int rowIndex = 26; ;
                        foreach (string item in report.ModuleInspection.RadiatorConditions.Split(", "))
                        {
                            worksheet.Cells[$"J{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["J30:K32"].Value = $"COMENTARIOS: {report.ModuleInspection.RadiatorConditionsComments}";
                    }

                    // Soportes
                    worksheet.Cells[$"L26:M29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.Supports != null)
                    {
                        int rowIndex = 26; ;
                        foreach (string item in report.ModuleInspection.Supports.Split(", "))
                        {
                            worksheet.Cells[$"L{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["L30:M32"].Value = $"COMENTARIOS: {report.ModuleInspection.SupportsComments}";
                    }

                    // Condicion de los retenes
                    worksheet.Cells[$"B34:C35"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.SealConditions != null)
                    {
                        int rowIndex = 34; ;
                        foreach (string item in report.ModuleInspection.SealConditions.Split(", "))
                        {
                            worksheet.Cells[$"B{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["B36:C39"].Value = $"COMENTARIOS: {report.ModuleInspection.SealConditionsComments}";
                    }

                    // Condicion de los coupling
                    worksheet.Cells[$"D34:E36"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.CouplingConditions != null)
                    {
                        int rowIndex = 34; ;
                        foreach (string item in report.ModuleInspection.CouplingConditions.Split(", "))
                        {
                            worksheet.Cells[$"D{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["D37:E39"].Value = $"COMENTARIOS: {report.ModuleInspection.CouplingConditionsComments}";
                    }

                    // Condicion de los baleros
                    worksheet.Cells[$"F34:G36"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.BearingConditions != null)
                    {
                        int rowIndex = 34; ;
                        foreach (string item in report.ModuleInspection.BearingConditions.Split(", "))
                        {
                            worksheet.Cells[$"F{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["B37:C39"].Value = $"COMENTARIOS: {report.ModuleInspection.BearingConditionsComments}";
                    }

                    // Condicion de las paletas
                    worksheet.Cells[$"H34:J36"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.BladeConditions != null)
                    {
                        int rowIndex = 34; ;
                        foreach (string item in report.ModuleInspection.BladeConditions.Split(", "))
                        {
                            worksheet.Cells[$"H{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["H38:J39"].Value = $"COMENTARIOS: {report.ModuleInspection.BladeConditionsComments}";
                    }

                    // Condicion de los exhaust filter
                    worksheet.Cells[$"K34:M36"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.ExhaustFilterConditions != null)
                    {
                        int rowIndex = 34; ;
                        foreach (string item in report.ModuleInspection.ExhaustFilterConditions.Split(", "))
                        {
                            worksheet.Cells[$"K{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["K37:M39"].Value = $"COMENTARIOS: {report.ModuleInspection.ExhaustFilterConditionsComments}";
                    }

                    // Condiciones del rotor
                    worksheet.Cells[$"E41:G43"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.RotorConditions != null)
                    {
                        int rowIndex = 41; ;
                        foreach (string item in report.ModuleInspection.RotorConditions.Split(", "))
                        {
                            worksheet.Cells[$"E{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["E44:G46"].Value = $"COMENTARIOS: {report.ModuleInspection.RotorConditionsComments}";
                    }

                    // Condiciones del cilindro
                    worksheet.Cells[$"K41:M43"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.CylinderConditions != null)
                    {
                        int rowIndex = 41; ;
                        foreach (string item in report.ModuleInspection.CylinderConditions.Split(", "))
                        {
                            worksheet.Cells[$"K{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["K44:M46"].Value = $"COMENTARIOS: {report.ModuleInspection.CylinderConditionsComments}";
                    }

                    // Condiciones cople lado motor
                    worksheet.Cells[$"F48:G51"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.MotorSideCouplingConditions != null)
                    {
                        int rowIndex = 48; ;
                        foreach (string item in report.ModuleInspection.MotorSideCouplingConditions.Split(", "))
                        {
                            worksheet.Cells[$"F{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["F52:G55"].Value = $"COMENTARIOS: {report.ModuleInspection.MotorSideCouplingConditionsComments}";
                    }

                    // Condiciones cople lado bomba
                    worksheet.Cells[$"H48:J51"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.PumpSideCouplingConditions != null)
                    {
                        int rowIndex = 48; ;
                        foreach (string item in report.ModuleInspection.PumpSideCouplingConditions.Split(", "))
                        {
                            worksheet.Cells[$"H{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["H52:H55"].Value = $"COMENTARIOS: {report.ModuleInspection.PumpSideCouplingConditionsComments}";
                    }

                    // Condiciones inserto cople
                    worksheet.Cells[$"K48:M51"].Value = ""; // Limpiar las celdas q pueden ser escritas
                    if (report.ModuleInspection.CouplingInsertConditions != null)
                    {
                        int rowIndex = 48; ;
                        foreach (string item in report.ModuleInspection.CouplingInsertConditions.Split(", "))
                        {
                            worksheet.Cells[$"K{rowIndex}"].Value = $"{item}";
                            rowIndex = rowIndex + 1;
                        }
                        worksheet.Cells["K52:M55"].Value = $"COMENTARIOS: {report.ModuleInspection.CouplingInsertConditionsComments}";
                    }

                    if (report.ModuleInspection.TurbineConditions != null)
                    {
                        // Abanico module
                        worksheet.Cells[$"D27:E29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                        if (report.ModuleInspection.TurbineConditions.FanModule != null)
                        {
                            int rowIndex = 27; ;
                            foreach (string item in report.ModuleInspection.TurbineConditions.FanModule.Split(", "))
                            {
                                worksheet.Cells[$"D{rowIndex}"].Value = $"{item}";
                                rowIndex = rowIndex + 1;
                            }
                            worksheet.Cells["D30:E32"].Value = $"COMENTARIOS: {report.ModuleInspection.TurbineConditions.FanModuleComments}";
                        }

                        // Turbina radiador
                        worksheet.Cells[$"F27:G29"].Value = ""; // Limpiar las celdas q pueden ser escritas
                        if (report.ModuleInspection.TurbineConditions.RadiatorTurbine != null)
                        {
                            int rowIndex = 27; ;
                            foreach (string item in report.ModuleInspection.TurbineConditions.RadiatorTurbine.Split(", "))
                            {
                                worksheet.Cells[$"F{rowIndex}"].Value = $"{item}";
                                rowIndex = rowIndex + 1;
                            }
                            worksheet.Cells["F30:G32"].Value = $"COMENTARIOS: {report.ModuleInspection.TurbineConditions.RadiatorTurbineComments}";
                        }
                    }

                    if (report.ModuleInspection.ModuleCoverConditions != null)
                    {
                        // lado motor
                        worksheet.Cells[$"B49:C53"].Value = ""; // Limpiar las celdas q pueden ser escritas
                        if (report.ModuleInspection.ModuleCoverConditions.MotorSide != null)
                        {
                            int rowIndex = 49; ;
                            foreach (string item in report.ModuleInspection.ModuleCoverConditions.MotorSide.Split(", "))
                            {
                                worksheet.Cells[$"B{rowIndex}"].Value = $"{item}";
                                rowIndex = rowIndex + 1;
                            }
                            worksheet.Cells["B54:C55"].Value = $"COMENTARIOS: {report.ModuleInspection.ModuleCoverConditions.MotorSideComments}";
                        }

                        // lado bomba
                        worksheet.Cells[$"D49:E53"].Value = ""; // Limpiar las celdas q pueden ser escritas
                        if (report.ModuleInspection.ModuleCoverConditions.PumpSide != null)
                        {
                            int rowIndex = 49; ;
                            foreach (string item in report.ModuleInspection.ModuleCoverConditions.PumpSide.Split(", "))
                            {
                                worksheet.Cells[$"D{rowIndex}"].Value = $"{item}";
                                rowIndex = rowIndex + 1;
                            }
                            worksheet.Cells["D54:E55"].Value = $"COMENTARIOS: {report.ModuleInspection.ModuleCoverConditions.PumpSideComments}";
                        }
                    }
                }

                return await excelPackage.GetAsByteArrayAsync();
                #endregion
            }
        }
    }

    public async Task<byte[]> Show(Report report)
    {
        throw new NotImplementedException();
    }
}
