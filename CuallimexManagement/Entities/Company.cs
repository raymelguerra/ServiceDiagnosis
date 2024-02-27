using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Company
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Company")]
    public string CompanyName { get; set; }

    [BsonElement("FiscalAddress")]
    public string FiscalAddress { get; set; }

    [BsonElement("TaxId")]
    public string TaxId { get; set; }
}
