using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Components
{
    public partial class VacuumPressureModuleComponent : ComponentBase
    {
        [Parameter]
        public ModuleInspection Model { get; set; }
        [Parameter]
        public EventCallback<ModuleInspection> ModelChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }

            Model.VacuumPressureValvesImages = Model.VacuumPressureValvesImages ?? new();
            Model.AirFiltersImages = Model.AirFiltersImages ?? new();
            Model.RadiatorConditionsImages = Model.RadiatorConditionsImages ?? new();
            Model.SupportsImages = Model.SupportsImages ?? new();
            Model.SealConditionsImages = Model.SealConditionsImages ?? new();
            Model.CouplingConditionsImages = Model.CouplingConditionsImages ?? new();
            Model.BearingConditionsImages = Model.BearingConditionsImages ?? new();
            Model.BladeConditionsImages = Model.BladeConditionsImages ?? new();
            Model.ExhaustFilterConditionsImages = Model.ExhaustFilterConditionsImages ?? new();
            Model.RotorConditionsImages = Model.RotorConditionsImages ?? new();
            Model.CylinderConditionsImages = Model.CylinderConditionsImages ?? new();
            Model.MotorSideCouplingConditionsImages = Model.MotorSideCouplingConditionsImages ?? new();
            Model.PumpSideCouplingConditionsImages = Model.PumpSideCouplingConditionsImages ?? new();
            Model.CouplingInsertConditionsImages = Model.CouplingInsertConditionsImages ?? new();

            if (Model.ModuleCoverConditions == null)
            {
                Model.ModuleCoverConditions = new();
            }
            if (Model.TurbineConditions == null)
            {
                Model.TurbineConditions = new();
            }

        }
    }
}
