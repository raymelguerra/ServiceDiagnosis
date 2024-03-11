using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components;

public partial class ModuleCoverConditionComponent : ComponentBase
{
    [Parameter]
    public ModuleCoverCondition Model { get; set; }
    [Parameter]
    public EventCallback<ModuleCoverCondition> ModelChanged { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Model == null)
        {
            Model = new();
        }
        Model.PumpSideImages = Model.PumpSideImages ?? new();
        Model.MotorSideImages = Model.MotorSideImages ?? new();
    }
}