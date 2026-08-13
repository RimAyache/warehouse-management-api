using warehouse.Api.Models;

public static class FakeWarehouseStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product
            {
                Id = new Guid("a18b27ae-aff9-43b7-a893-607551ad8824"),
                Name = "Laptop",
                SKU = "SKU-LAP-001",
                Description = "15-inch business laptop",
                Price = 899.99m,
                QuantityInStock = 25,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 1, 5, 8, 0, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 3, 12, 14, 20, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("49287c40-c2d6-4223-8351-f07f46af51c6"),
                Name = "Mouse",
                SKU = "SKU-MOU-002",
                Description = "Wireless optical mouse",
                Price = 19.99m,
                QuantityInStock = 150,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 1, 18, 10, 15, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 1, 18, 10, 15, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("b45a7702-635d-4b08-80ab-c05c1a03bbeb"),
                Name = "Keyboard",
                SKU = "SKU-KEY-003",
                Description = "Mechanical keyboard, blue switches",
                Price = 49.99m,
                QuantityInStock = 100,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 2, 2, 9, 45, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 4, 1, 11, 5, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("fe457dec-a0f6-460e-af9d-078640087eb5"),
                Name = "Scanner",
                SKU = "SKU-SCA-004",
                Description = "Flatbed document scanner",
                Price = 129.99m,
                QuantityInStock = 15,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = null,
                IsArchived = true,
                CreatedAt = new DateTime(2026, 2, 20, 13, 30, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 2, 20, 13, 30, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("60eee5f8-0cc6-4118-8a37-6bb644a67c6b"),
                Name = "Printer",
                SKU = "SKU-PRI-005",
                Description = "Color inkjet printer",
                Price = 179.99m,
                QuantityInStock = 20,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 3, 8, 15, 0, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 5, 19, 8, 40, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("716be685-26e0-413f-a347-aa12d955eae2"),
                Name = "Monitor",
                SKU = "SKU-MON-006",
                Description = "27-inch 4K monitor",
                Price = 349.99m,
                QuantityInStock = 30,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 3, 25, 11, 20, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 6, 2, 16, 10, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("e9060b7b-17a6-4647-b89a-89d2c2693913"),
                Name = "Webcam",
                SKU = "SKU-WEB-007",
                Description = "1080p HD webcam with mic",
                Price = 39.99m,
                QuantityInStock = 60,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 4, 11, 10, 5, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 4, 11, 10, 5, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("e67a265e-5f6b-40a5-894b-0bbc8e339109"),
                Name = "USB Hub",
                SKU = "SKU-HUB-008",
                Description = "7-port USB 3.0 hub",
                Price = 24.99m,
                QuantityInStock = 80,
                SupplierName = "PeripheralsPlus",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 4, 29, 14, 50, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 6, 15, 9, 25, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("99ae4b47-3401-42ee-9709-fda9b4cec855"),
                Name = "External Hard Drive",
                SKU = "SKU-HDD-009",
                Description = "2TB portable external hard drive",
                Price = 89.99m,
                QuantityInStock = 40,
                SupplierName = "TechSupply Co.",
                ExpiryDate = null,
                IsArchived = false,
                CreatedAt = new DateTime(2026, 5, 14, 8, 35, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 5, 14, 8, 35, 0, DateTimeKind.Utc)
            },
            new Product
            {
                Id = new Guid("c091ee70-47f9-4f39-bd90-63eac00866dd"),
                Name = "Label Printer Ribbon",
                SKU = "SKU-RIB-010",
                Description = "Replacement ribbon for label printers",
                Price = 12.99m,
                QuantityInStock = 200,
                SupplierName = "OfficeTech Ltd.",
                ExpiryDate = new DateTime(2028, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                IsArchived = false,
                CreatedAt = new DateTime(2026, 6, 1, 12, 0, 0, DateTimeKind.Utc),
                LastUpdatedAt = new DateTime(2026, 7, 3, 10, 45, 0, DateTimeKind.Utc)
            }
        };
    }
