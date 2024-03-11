using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components
{
    public partial class ResponsibleComponent : ComponentBase
    {
        [Parameter]
        public Responsible Model { get; set; }
        [Parameter]
        public EventCallback<Responsible> ModelChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }
    }
}
