using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

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
    public DateTime? CollectionDate { get; set; }

    [BsonElement("ReportDate")]
    public DateTime? ReportDate { get; set; }

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

    public UpdateDefinition<Report> ToUpdateDefinition()
    {
        var updateBuilder = Builders<Report>.Update;
        var updateDefinitionBuilder = Builders<Report>.Update.Combine();

        // Campos de Report
        if (!string.IsNullOrEmpty(Description))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Description, Description);
        }
        if (!string.IsNullOrEmpty(Summary))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Summary, Summary);
        }
        if (!string.IsNullOrEmpty(Comment))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Comment, Comment);
        }
        if (!string.IsNullOrEmpty(PhysicalDamage))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.PhysicalDamage, PhysicalDamage);
        }
        if (!string.IsNullOrEmpty(RequiredParts))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.RequiredParts, RequiredParts);
        }
        if (!string.IsNullOrEmpty(ExternalWorks))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.ExternalWorks, ExternalWorks);
        }
        if (CollectionDate.HasValue)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.CollectionDate, CollectionDate);
        }
        if (ReportDate.HasValue)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.ReportDate, ReportDate);
        }
        if (!string.IsNullOrEmpty(EntryReason))
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.EntryReason, EntryReason);
        }

        // Campos de subclases
        if (Company != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Company, Company);
        }
        if (Equipment != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Equipment, Equipment);
        }
        if (Responsible != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.Responsible, Responsible);
        }
        if (EquipmentInspection != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.EquipmentInspection, EquipmentInspection);
        }
        if (PhysicalInspection != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.PhysicalInspection, PhysicalInspection);
        }
        if (ModuleInspection != null)
        {
            updateDefinitionBuilder = updateDefinitionBuilder.Set(x => x.ModuleInspection, ModuleInspection);
        }

        return updateDefinitionBuilder;
    }
}