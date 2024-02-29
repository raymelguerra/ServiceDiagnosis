using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CuallimexManagement.Entities;
public class TurbineCondition
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("FanModule")]
    public string FanModule { get; set; } // Condiciones del abanico del módulo

    [BsonElement("RadiatorTurbine")]
    public string RadiatorTurbine { get; set; } // Condiciones de la turbina del radiador

    [BsonElement("FanModuleComments")]
    public string FanModuleComments { get; set; } // Comentarios sobre el abanico del módulo

    [BsonElement("RadiatorTurbineComments")]
    public string RadiatorTurbineComments { get; set; }
}
