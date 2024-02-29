using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CuallimexManagement.Entities;
public class ModuleCoverCondition
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("MotorSide")]
    public string MotorSide { get; set; } // Condiciones de la tapa del módulo lado motor

    [BsonElement("PumpSide")]
    public string PumpSide { get; set; } // Condiciones de la tapa del módulo lado bomba

    [BsonElement("MotorSideComments")]
    public string MotorSideComments { get; set; } // Comentarios sobre la tapa del módulo lado motor

    [BsonElement("PumpSideComments")]
    public string PumpSideComments { get; set; } // Comentarios sobre la tapa del módulo lado bomba
}

