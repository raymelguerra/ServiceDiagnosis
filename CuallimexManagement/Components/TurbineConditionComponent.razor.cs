using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components;


public partial class TurbineConditionComponent : ComponentBase
{
    [Parameter]
    public TurbineCondition Model { get; set; }
    [Parameter]
    public EventCallback<TurbineCondition> ModelChanged { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Model == null)
        {
            Model = new();
        }
        Model.FanModuleImages = Model.FanModuleImages ?? new();
        Model.RadiatorTurbineImages = Model.RadiatorTurbineImages ?? new();
    }
}
