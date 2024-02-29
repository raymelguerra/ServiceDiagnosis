using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CuallimexManagement.Entities;
public class BaseEntity
{
    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
