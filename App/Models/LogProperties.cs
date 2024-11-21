using MongoDB;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class LogProperties
{
    [BsonElement("HttpMethod")]
    [BsonIgnoreIfNull]
    public string HttpMethod { get; set; } = null!; // "POST", "GET", "DELETE"

    [BsonElement("Email")]
    [BsonIgnoreIfNull]
    public string Email { get; set; } = null!; // The user performing the operation
}
