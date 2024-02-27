using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class EntryReason
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Value")]
    public string Value { get; set; }

}
