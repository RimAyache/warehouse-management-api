public static class FakeWarehouseStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                SKU = "SKU-LAP-001",
                Description = "15-inch business laptop",
                Price = 899.99m,
                QuantityInStock = 25,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Mouse",
                SKU = "SKU-MOU-002",
                Description = "Wireless optical mouse",
                Price = 19.99m,
                QuantityInStock = 150,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Keyboard",
                SKU = "SKU-KEY-003",
                Description = "Mechanical keyboard, blue switches",
                Price = 49.99m,
                QuantityInStock = 100,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Scanner",
                SKU = "SKU-SCA-004",
                Description = "Flatbed document scanner",
                Price = 129.99m,
                QuantityInStock = 15,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Printer",
                SKU = "SKU-PRI-005",
                Description = "Color inkjet printer",
                Price = 179.99m,
                QuantityInStock = 20,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Monitor",
                SKU = "SKU-MON-006",
                Description = "27-inch 4K monitor",
                Price = 349.99m,
                QuantityInStock = 30,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Webcam",
                SKU = "SKU-WEB-007",
                Description = "1080p HD webcam with mic",
                Price = 39.99m,
                QuantityInStock = 60,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "USB Hub",
                SKU = "SKU-HUB-008",
                Description = "7-port USB 3.0 hub",
                Price = 24.99m,
                QuantityInStock = 80,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "External Hard Drive",
                SKU = "SKU-HDD-009",
                Description = "2TB portable external hard drive",
                Price = 89.99m,
                QuantityInStock = 40,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Label Printer Ribbon",
                SKU = "SKU-RIB-010",
                Description = "Replacement ribbon for label printers",
                Price = 12.99m,
                QuantityInStock = 200,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = DateTime.UtcNow.AddYears(2),
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            }
        };
    }
