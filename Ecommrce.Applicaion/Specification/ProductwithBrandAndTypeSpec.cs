using ECommerce.Domin.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Specification
{
    public class ProductwithBrandAndTypeSpec : BaseSpecification<Product, int>
    {
        public ProductwithBrandAndTypeSpec(int? brandId, int? typeId) : base
        // (P=>brandId == null || P.ProductBrandId == brandId && (typeId == null || P.ProductTypeId == typeId))
        (P => (!brandId.HasValue || P.BrandId == brandId) && (!typeId.HasValue || P.TypeId == typeId) && (!brandId.HasValue || P.BrandId == brandId) )
        {  AddInclude(P=>P.ProductBrand);
            AddInclude(P=>P.ProductType);
        }
        public ProductwithBrandAndTypeSpec(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
    } 
}
