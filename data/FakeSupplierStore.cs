using warehouse.Api.Models;

public static class FakeSupplierStore
    {
        public static List<Supplier> Suppliers { get; set; } = new List<Supplier>
        {
            new Supplier
            {
                Id = new Guid("3f2a1c58-9d41-4a7e-b2c6-1e5f8a0d7b34"),
                Name = "TechSupply Co.",
                Country = "Germany",
                ContactEmail = "orders@techsupply.example",
                PhoneNumber = "+49 30 1234567",
                IsActive = true
            },
            new Supplier
            {
                Id = new Guid("7c4e9b21-6a83-4f15-9d0e-2b7c3a5f8e91"),
                Name = "PeripheralsPlus",
                Country = "Netherlands",
                ContactEmail = "sales@peripheralsplus.example",
                PhoneNumber = "+31 20 7654321",
                IsActive = true
            },
            new Supplier
            {
                Id = new Guid("d81b5f36-2e74-4c09-8a3d-6f9e1b4c7a52"),
                Name = "OfficeTech Ltd.",
                Country = "Lebanon",
                ContactEmail = "contact@officetech.example",
                PhoneNumber = "+961 1 987654",
                IsActive = true
            }
        };
    }
