using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components
{
    public partial class VacuumPressureModuleComponent : ComponentBase
    {
        [Parameter]
        public ModuleInspection Model { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }
    }
}
