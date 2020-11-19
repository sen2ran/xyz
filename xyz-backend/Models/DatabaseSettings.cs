namespace xyz_backend.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string RoleCollectionName { get; set; }
        public string ApartmentCollectionName { get; set; }
        public string UnitCollectionName { get; set; }
        public string OwnerCollectionName { get; set; }
        public string TenantCollectionName { get; set; }
        public string DressTypeCollectionName { get; set; }
        public string OrdersCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string AdminCollectionName { get; set; }
        public string LogCollectionName { get; set; }
        public string SecurityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string RoleCollectionName { get; set; }
        string ApartmentCollectionName { get; set; }
        string UnitCollectionName { get; set; }
        string OwnerCollectionName { get; set; }
        string TenantCollectionName { get; set; }
        string OrdersCollectionName { get; set; }
        string DressTypeCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string AdminCollectionName { get; set; }

        string LogCollectionName { get; set; }
        string SecurityCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}