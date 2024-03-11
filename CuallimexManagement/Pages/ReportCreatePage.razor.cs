using CuallimexManagement.Entities;
using CuallimexManagement.Utils;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace CuallimexManagement.Pages;

public partial class ReportCreatePage : ComponentBase
{
    [Parameter]
    public string ReportId { get; set; }

    public Report Model { get; set; }
    public bool AutomticUpdate { get; set; } = true;
    protected override async Task OnParametersSetAsync()
    {
        if (ReportId != null) {
            Model = await this.ReportService.GetByIdAsync(ReportId);
            Model.Company = Model.Company ?? new();
            Model.Equipment = Model.Equipment ?? new();
            Model.PhysicalInspection = Model.PhysicalInspection ?? new();
            Model.ModuleInspection = Model.ModuleInspection ?? new();
            Model.Responsible = Model.Responsible ?? new();
        }
        else if (Model == null)
        {
            Model = new();
            Model.Company = new Company();
            Model.Equipment = new Equipment();
            Model.PhysicalInspection = new PhysicalInspection();
            Model.ModuleInspection = new ModuleInspection();
            Model.Responsible = new Responsible();
        }
    }

    public async Task Save()
    {
        if (ReportId != null && Model.Company.CompanyName != null)
        {
            try
            {
                var report = await ReportService.UpdateAsync(ReportId, Model);
                if (report != null)
                {
                    Snackbar.Add("El diagnóstico se ha actualizado con exito", Severity.Success);
                }
            }
            catch
            {
                Snackbar.Add("Ha ocurrido un error al actualizar el diagnóstico.", Severity.Error);
            }
        }
        else if (Model.Company.CompanyName != null)
        {
            try
            {
                Report report = await ReportService.CreateAsync(Model);
                if (report != null)
                {
                    Snackbar.Add("El diagnóstico se ha creado con exito", Severity.Success);
                }
            }
            catch
            {
                Snackbar.Add("Ha ocurrido un error al crear el diagnóstico.", Severity.Error);
            }
        }

    }

    public async Task GeneratePdf() {
        var excelBytes = await PdfService.Download(Model);

        var fileName = $"{Model.Folio}.xlsx";
        var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        await FileUtil.SaveAs(NavigationManager, fileName, excelBytes, contentType);
    }
}
