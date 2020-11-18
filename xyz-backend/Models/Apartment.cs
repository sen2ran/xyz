using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace  xyz_backend.Models
{
    public class Apartment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string security { get; set; }
        public double maintenancePerUnitDefaultPrice { get; set; }
        public string apartmentName { get; set; }
        public string apartmentId { get; set; }
        public int noOfUnit { get; set; }
        public string address { get; set; }
        public string cityName { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> latAndLon { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}