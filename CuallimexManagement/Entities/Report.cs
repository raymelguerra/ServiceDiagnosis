using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CuallimexManagement.Entities;

public class Report : BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Folio")]
    public string Folio { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }
    
    [BsonElement("Summary")]
    public string Summary { get; set; }
    
    [BsonElement("Comment")]
    public string Comment { get; set; }

    [BsonElement("CollectionDate")]
    public DateTime CollectionDate { get; set; }

    [BsonElement("EntryReason")]
    public EntryReason EntryReason { get; set; }
   
    [BsonElement("Company")]
    public Company Company { get; set; }
    
    [BsonElement("Equipment")]
    public Company Equipment { get; set; }

}