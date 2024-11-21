using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class LogEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Level")]
    public string Level { get; set; }

    [BsonElement("RenderedMessage")]
    public string Message { get; set; }

    [BsonElement("Timestamp")]
    public DateTime Timestamp { get; set; }

    [BsonElement("Properties")]
    public LogProperties Properties { get; set; }
}
