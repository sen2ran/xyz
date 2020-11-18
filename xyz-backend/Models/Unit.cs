using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Unit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string apartmentId { get; set; }
        public string ownerId { get; set; }
        public int noOfRooms { get; set; }
        public double rentFee { get; set; } = 0;
        public bool isRented { get; set; } = false;
        public bool isAvailable { get; set; } = true;
        public string unitNo { get; set; }
        public string address { get; set; }
        public string cityName { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}