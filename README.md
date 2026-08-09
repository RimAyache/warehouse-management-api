# warehouse.Api

A small Web API for a warehouse, built with ASP.NET Core (.NET 10)

Then open Swagger: http://localhost:5057/swagger


### Supplier module

I added a supplier model with Id, Name, Country, ContactEmail, PhoneNumber and IsActive.
I also added a CreateSupplierRequest DTO, a SupplierService, and a SuppliersController.
The controller doesn't do the work itself, it just calls the service.
The service is registered in Program.cs

Files I added:

- models/Supplier.cs
- Contracts/CreateSupplierRequest.cs
- Services/SupplierService.cs
- Controllers/SuppliersController.cs
- data/FakeSupplierStore.cs (3 suppliers to start with)

Endpoints:

- GET /api/suppliers - returns all suppliers
- GET /api/suppliers/{id} - returns 404 if the id doesn't exist
- POST /api/suppliers - returns 201, or 400 if the email or phone is not valid
- DELETE /api/suppliers/{id} - doesn't really delete, it just sets IsActive to false and returns 204

### Product-supplier link

POST /api/products/{id}/assign-supplier/{supplierId}

This sets SupplierId on the product and also updates SupplierName so they stay the same.
I added SupplierId to the Product model for this.

The checks are:

- product doesn't exist -> 404
- supplier doesn't exist -> 404
- product is archived -> 409


## Additional endpoints

These are the product endpoints from the earlier tasks:

- GET /api/products - onlyAvailable only shows items in stock, includeArchived shows archived ones too
- GET /api/products/{id}
- GET /api/products/search - search by name and/or supplier
- POST /api/products
- POST /api/products/{id}/price
- POST /api/products/{id}/quantity
- POST /api/products/{id}/image - jpg or png, max 2 MB, saved in wwwroot/uploads
- DELETE /api/products/{id} - archives the product instead of deleting it

## Swagger screenshots

### Products

GET /api/products and its parameters:

![](screenshots/01-get-products-parameters.png)

The response:

![](screenshots/02-get-products-response.png)

Getting a product with an id that doesn't exist gives 404:

![](screenshots/03-get-product-unknown-id-404.png)

### Delete

Deleting a product returns 204:

![](screenshots/04-delete-product-204.png)

And after that, getting the same product gives 404, because it's archived now:

![](screenshots/05-get-archived-product-404.png)

### Updating the price

The request:

![](screenshots/06-update-price-request.png)

The response with the new price:

![](screenshots/07-update-price-response.png)

### Server time

I sent ar-lb in lowercase and it still worked, the date comes back in Arabic:

![](screenshots/08-server-time-ar-lb.png)

### Suppliers

All 3 suppliers, all active:

![](screenshots/09-get-suppliers.png)

Deactivating one of them:

![](screenshots/10-deactivate-supplier.png)

Now OfficeTech Ltd. has isActive false, but it's still there:

![](screenshots/11-get-suppliers-after-deactivate.png)

