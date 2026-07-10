using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs;
using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Application.Specification;
namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync( ct);
            return Result<IReadOnlyList<BrandDto>>.Ok(_mapper.Map<IReadOnlyList<BrandDto>>(brands));
        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(int? brandId, int? typeId, CancellationToken ct = default)
        {
            var Spec = new ProductwithBrandAndTypeSpec(brandId, typeId);

            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(Spec, ct);
            return Result<IReadOnlyList<ProductDto>>.Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)
        {
            var productTypes = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct);
            return Result<IReadOnlyList<TypeDto>>.Ok(_mapper.Map<IReadOnlyList<TypeDto>>(productTypes));
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var Spec = new ProductwithBrandAndTypeSpec(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIDAsync(Spec, ct);
            if (product == null)
            return Result<ProductDto>.Fail(Erorr.NotFound("PRODUCT_NOT_FOUND_CODE", "Product with ID {id} not found"));
            return Result<ProductDto>.Ok(_mapper.Map<ProductDto>(product));
        }
    }
}