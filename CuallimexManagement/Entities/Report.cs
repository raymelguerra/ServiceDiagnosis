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

    [BsonElement("PhysicalDamage")]
    public string PhysicalDamage { get; set; }

    [BsonElement("RequiredParts")]
    public string RequiredParts { get; set; }

    [BsonElement("ExternalWorks")]
    public string ExternalWorks { get; set; }

    [BsonElement("CollectionDate")]
    public DateTime CollectionDate { get; set; }

    [BsonElement("ReportDate")]
    public DateTime ReportDate { get; set; }

    [BsonElement("EntryReason")]
    public string EntryReason { get; set; }

    [BsonElement("Company")]
    public Company Company { get; set; }

    [BsonElement("Equipment")]
    public Equipment Equipment { get; set; }

    [BsonElement("Responsible")]
    public Responsible Responsible { get; set; }

    [BsonElement("EquipmentInspection")]
    public EquipmentInspection EquipmentInspection { get; set; }

    [BsonElement("PhysicalInspection")]
    public PhysicalInspection PhysicalInspection { get; set; }

    [BsonElement("ModuleInspection")]
    public ModuleInspection ModuleInspection { get; set; }

}