using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components
{
    public partial class PhysicalInspectionComponent : ComponentBase
    {
        [Parameter]
        public PhysicalInspection Model { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }
    }
}
