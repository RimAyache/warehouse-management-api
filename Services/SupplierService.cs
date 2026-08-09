public class SupplierService
    {
        public List<Supplier> GetAll()
        {
            return FakeSupplierStore.Suppliers.OrderBy(s => s.Name).ToList();
        }

        public Supplier? GetById(Guid id)
        {
            return FakeSupplierStore.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public Supplier Create(CreateSupplierRequest request)
        {
            var supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Country = request.Country,
                ContactEmail = request.ContactEmail,
                PhoneNumber = request.PhoneNumber,
                IsActive = true
            };

            FakeSupplierStore.Suppliers.Add(supplier);
            return supplier;
        }

        public bool Deactivate(Guid id)
        {
            var supplier = GetById(id);

            if (supplier == null)
            {
                return false;
            }

            supplier.IsActive = false;
            return true;
        }
    }
