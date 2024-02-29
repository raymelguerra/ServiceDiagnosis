using Microsoft.AspNetCore.Components;
using CuallimexManagement.Entities;

namespace CuallimexManagement.Components
{
    public partial class CompanyComponent : ComponentBase
    {
        [Parameter]
        public Company Model { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }
    }
}
