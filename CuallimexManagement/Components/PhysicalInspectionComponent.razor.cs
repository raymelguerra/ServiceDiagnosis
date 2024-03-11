using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components
{
    public partial class PhysicalInspectionComponent : ComponentBase
    {
        [Parameter]
        public PhysicalInspection Model { get; set; }
        [Parameter]
        public EventCallback<PhysicalInspection> ModelChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Model = Model ?? new();
            Model.EquipmentConditionsImages = Model.EquipmentConditionsImages ?? new();
            Model.MotorConditionImages = Model.MotorConditionImages ?? new();
            Model.MotorCoverConditionImages = Model.MotorCoverConditionImages ?? new();
            Model.MotorFanConditionImages = Model.MotorFanConditionImages ?? new();
        }
    }
}
