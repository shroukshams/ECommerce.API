using ECommerce.Application.Common;
using ECommerce.Domin.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Specification
{
    public class ProductwithBrandAndTypeSpec : BaseSpecification<Product, int>
    {
        public ProductwithBrandAndTypeSpec(ProuductQueryParams queryParams) : base
        // (P=>brandId == null || P.ProductBrandId == brandId && (typeId == null || P.ProductTypeId == typeId))
        (P => (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId)  && (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId)&&string.IsNullOrWhiteSpace(queryParams.Search) || P.Name.ToLower().Contains(queryParams.Search.ToLower()) )
        {  AddInclude(P=>P.ProductBrand);
            AddInclude(P=>P.ProductType);
            switch(queryParams.Sort)
            {
                case ProudectSortOptions.PriceAsc:
                    AddOrderBy(P => P.Price);
                    break;
                case ProudectSortOptions.PriceDesc:
                    AddOrderByDescending(P => P.Price);
                    break;
                case ProudectSortOptions.NameDesc:
                    AddOrderByDescending(P => P.Name);
                    break;
            }
        }
        public ProductwithBrandAndTypeSpec(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
    } 
}
