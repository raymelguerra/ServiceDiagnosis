using CuallimexManagement.Components;
using CuallimexManagement.Entities;
using MudBlazor;
using System.Collections.ObjectModel;

namespace CuallimexManagement.Pages;

public partial class ReportListPage : Microsoft.AspNetCore.Components.ComponentBase
{
    ObservableCollection<Report> Reports = new ObservableCollection<Report>();
    DataGridFilterMode _filterMode = DataGridFilterMode.Simple;
    DataGridFilterCaseSensitivity _caseSensitivity = DataGridFilterCaseSensitivity.CaseInsensitive;

    private bool Loading = false;

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            Loading = true;
            Reports = new ObservableCollection<Report>(await ReportService.GetAllAsync());
        }
        catch // (Exception e)
        {
            Snackbar.Add("Ha ocurrido un error al listar los diagnóstico.", Severity.Error);
        }
        finally
        {
            Loading = false;
        }
    }

    private async void DeleteDiagnosis(string Id)
    {
        var parameters = new DialogParameters<DeleteDialog>
        {
            { x => x.TitleLabel, Id }
        };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = await DialogService.ShowAsync<DeleteDialog>("Eliminar", parameters, options);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            try
            {
                var deleted_report = await ReportService.DeleteAsync(Id);
                if (deleted_report.DeletedCount > 0)
                {
                    Snackbar.Add("El diagnóstico se ha eliminado con exito", Severity.Success);
                    var reportToRemove = Reports.FirstOrDefault(r => r.Id == Id);
                    if (reportToRemove != null)
                    {
                        Reports.Remove(reportToRemove);
                        StateHasChanged();
                    }
                }
                else
                {
                    Snackbar.Add("No se encontró el diagnóstico.", Severity.Info);
                }
            }
            catch
            {

                Snackbar.Add("Error al eliminar el diagnóstico.", Severity.Error);
            }
        }

    }

    private void RedirectToEdit(string Id)
    {
        NavigationManager.NavigateTo($"/createreport/{Id}");
    }  
    
    private void GoToNew()
    {
        NavigationManager.NavigateTo($"/createreport");
    }
}