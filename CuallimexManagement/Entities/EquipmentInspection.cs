using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CuallimexManagement.Entities;
public class EquipmentInspection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("EquipmentConditions")]
    public string EquipmentConditions { get; set; } // Puede ser "Buenas", "Regular", "Malas", "Golpeado", "Sucio"

    [BsonElement("EquipmentComments")]
    public string EquipmentComments { get; set; } // Comentarios sobre las condiciones del equipo

    [BsonElement("MotorCondition")]
    public string MotorCondition { get; set; } // Puede ser "Buenas", "Regular", "Malas", "Golpeado", "Sucio"

    [BsonElement("MotorComments")]
    public string MotorComments { get; set; } // Comentarios sobre la condición del motor

    [BsonElement("MotorBrand")]
    public string MotorBrand { get; set; }

    [BsonElement("MotorModel")]
    public string MotorModel { get; set; }

    [BsonElement("MotorYear")]
    public int MotorYear { get; set; }

    [BsonElement("MotorSerialNumber")]
    public string MotorSerialNumber { get; set; }

    [BsonElement("MotorPower")]
    public string MotorPower { get; set; }

    [BsonElement("MotorRPM")]
    public int MotorRPM { get; set; }

    [BsonElement("MotorCoverCondition")]
    public string MotorCoverCondition { get; set; } // Puede ser "Buenas", "Regular", "Malas", "Golpeado", "Sucio"

    [BsonElement("MotorCoverComments")]
    public string MotorCoverComments { get; set; } // Comentarios sobre la cubierta de motor

    [BsonElement("MotorFanCondition")]
    public string MotorFanCondition { get; set; } // Puede ser "Buenas", "Regular", "Malas", "Golpeado", "Sucio"

    [BsonElement("MotorFanComments")]
    public string MotorFanComments { get; set; } // Comentarios sobre el ventilador del motor

    [BsonElement("CanPerformTest")]
    public bool CanPerformTest { get; set; } // Puede ser "SI" o "NO"

    [BsonElement("TestComments")]
    public string TestComments { get; set; } // Comentarios sobre la posibilidad de realizar una prueba

    [BsonElement("DisassemblyRequired")]
    public bool DisassemblyRequired { get; set; } // Puede ser "SI" o "NO"
}
