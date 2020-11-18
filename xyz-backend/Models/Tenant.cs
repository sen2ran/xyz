using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace  xyz_backend.Models
{
    public class Tenant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string apartmentId { get; set; }
        public string unitId { get; set; }
        public string imageUrl { get; set; }
        public string tenantName { get; set; }
        public int phoneNo { get; set; }
        public string nic { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endEnd { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedOn { get; set; } = DateTime.Now;
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}