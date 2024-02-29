﻿using Microsoft.AspNetCore.Components;
using CuallimexManagement.Entities;

namespace CuallimexManagement.Components
{
    public partial class EquipmentComponent : ComponentBase
    {
        [Parameter]
        public Equipment Model { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }
    }
}
