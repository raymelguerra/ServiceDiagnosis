using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CuallimexManagement.Entities;
public class ModuleInspection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    // Válvulas de Vacío y/o Presión
    [BsonElement("VacuumPressureValves")]
    public string? VacuumPressureValves { get; set; } // Condiciones de las válvulas de vacío y/o presión

    [BsonElement("VacuumPressureValvesComments")]
    public string? VacuumPressureValvesComments { get; set; } // Comentarios sobre las válvulas de vacío y/o presión

    [BsonElement("VacuumPressureValvesImages")]
    public List<string>? VacuumPressureValvesImages { get; set; }

    // Condiciones de Turbinas
    [BsonElement("TurbineConditions")]
    public TurbineCondition? TurbineConditions { get; set; }

    // Filtros de Aire
    [BsonElement("AirFilters")]
    public string? AirFilters { get; set; } // Condiciones de los filtros de aire

    [BsonElement("AirFiltersComments")]
    public string? AirFiltersComments { get; set; } // Comentarios sobre los filtros de aire
    [BsonElement("AirFiltersImages")]
    public List<string>? AirFiltersImages { get; set; }

    // Condiciones del Radiador
    [BsonElement("RadiatorConditions")]
    public string? RadiatorConditions { get; set; } // Condiciones del radiador

    [BsonElement("RadiatorConditionsComments")]
    public string? RadiatorConditionsComments { get; set; } // Comentarios sobre las condiciones del radiador

    [BsonElement("RadiatorConditionsImages")]
    public List<string>? RadiatorConditionsImages { get; set; } // Imagenes sobre las condiciones del radiador

    // Soportes
    [BsonElement("Supports")]
    public string? Supports { get; set; } // Condiciones de los soportes

    [BsonElement("SupportsComments")]
    public string? SupportsComments { get; set; } // Comentarios sobre los soportes

    [BsonElement("SupportsImages")]
    public List<string>? SupportsImages { get; set; }

    // Condiciones de los Retenes
    [BsonElement("SealConditions")]
    public string SealConditions { get; set; } // Condiciones de los retenes

    [BsonElement("SealConditionsComments")]
    public string? SealConditionsComments { get; set; } // Comentarios sobre las condiciones de los retenes
    [BsonElement("SealConditionsImages")]
    public List<string>? SealConditionsImages { get; set; }

    // Condiciones de los Couplings
    [BsonElement("CouplingConditions")]
    public string? CouplingConditions { get; set; } // Condiciones de los couplings

    [BsonElement("CouplingConditionsComments")]
    public string CouplingConditionsComments { get; set; } // Comentarios sobre las condiciones de los couplings
    [BsonElement("CouplingConditionsImages")]
    public List<string>? CouplingConditionsImages { get; set; }

    // Condiciones de los Baleros
    [BsonElement("BearingConditions")]
    public string? BearingConditions { get; set; } // Condiciones de los baleros

    [BsonElement("BearingConditionsComments")]
    public string? BearingConditionsComments { get; set; } // Comentarios sobre las condiciones de los baleros
    [BsonElement("BearingConditionsImages")]
    public List<string>? BearingConditionsImages { get; set; }
    // Condiciones de las Paletas
    [BsonElement("BladeConditions")]
    public string? BladeConditions { get; set; } // Condiciones de las paletas

    [BsonElement("BladeConditionsComments")]
    public string? BladeConditionsComments { get; set; } // Comentarios sobre las condiciones de las paletas
    [BsonElement("BladeConditionsImages")]
    public List<string>? BladeConditionsImages { get; set; }

    // Condiciones de los Exhaust Filter
    [BsonElement("ExhaustFilterConditions")]
    public string? ExhaustFilterConditions { get; set; } // Condiciones del filtro de escape
    [BsonElement("ExhaustFilterConditionsImages")]
    public List<string>? ExhaustFilterConditionsImages { get; set; }

    [BsonElement("ExhaustFilterConditionsComments")]
    public string? ExhaustFilterConditionsComments { get; set; } // Comentarios sobre las condiciones del filtro de escape

    // Condiciones del Rotor
    [BsonElement("RotorConditions")]
    public string? RotorConditions { get; set; } // Condiciones del rotor

    [BsonElement("RotorConditionsComments")]
    public string? RotorConditionsComments { get; set; } // Comentarios sobre las condiciones del rotor

    [BsonElement("RotorConditionsImages")]
    public List<string>? RotorConditionsImages { get; set; }

    // Condiciones del Cilindro
    [BsonElement("CylinderConditions")]
    public string? CylinderConditions { get; set; } // Condiciones del cilindro

    [BsonElement("CylinderConditionsComments")]
    public string? CylinderConditionsComments { get; set; } // Comentarios sobre las condiciones del cilindro

    [BsonElement("CylinderConditionsImages")]
    public List<string>? CylinderConditionsImages { get; set; }
    // Condiciones de las Tapas del Módulo
    [BsonElement("ModuleCoverConditions")]
    public ModuleCoverCondition? ModuleCoverConditions { get; set; } // Condiciones de las tapas del módulo


    // Condiciones del Cople Lado Motor
    [BsonElement("MotorSideCouplingConditions")]
    public string? MotorSideCouplingConditions { get; set; } // Condiciones del cople lado motor

    [BsonElement("MotorSideCouplingConditionsComments")]
    public string? MotorSideCouplingConditionsComments { get; set; } // Comentarios sobre las condiciones del cople lado motor

    [BsonElement("MotorSideCouplingConditionsImages")]
    public List<string>? MotorSideCouplingConditionsImages { get; set; }

    // Condiciones del Cople Lado Bomba
    [BsonElement("PumpSideCouplingConditions")]
    public string? PumpSideCouplingConditions { get; set; } // Condiciones del cople lado bomba

    [BsonElement("PumpSideCouplingConditionsComments")]
    public string? PumpSideCouplingConditionsComments { get; set; } // Comentarios sobre las condiciones del cople lado bomba

    [BsonElement("PumpSideCouplingConditionsImages")]
    public List<string>? PumpSideCouplingConditionsImages { get; set; }

    // Condiciones del Inserto Cople
    [BsonElement("CouplingInsertConditions")]
    public string? CouplingInsertConditions { get; set; } // Condiciones del inserto cople

    [BsonElement("CouplingInsertConditionsComments")]
    public string? CouplingInsertConditionsComments { get; set; } // Comentarios sobre las condiciones del inserto cople
    [BsonElement("CouplingInsertConditionsImages")]
    public List<string>? CouplingInsertConditionsImages { get; set; }
}
