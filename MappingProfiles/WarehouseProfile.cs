using AutoMapper;
using warehouse.Api.Models;
using warehouse.Api.ViewModels;

namespace warehouse.Api.MappingProfiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SupplierName,
                    opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : src.SupplierName));

            CreateMap<Supplier, SupplierViewModel>()
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.Id));
        }
    }
}