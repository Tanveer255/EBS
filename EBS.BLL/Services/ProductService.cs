using EBS.BLL.Interfaces;
using EBS.DAL.Interface;
using EBS.Models.Model.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.BLL.Services
{
    public class ProductService : CrudService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;
        public ProductService(IProductRepository productRepository,
             IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(productRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _httpContext = httpContextAccessor.HttpContext;
        }
        /// <summary>
        /// Method to searches for assets based on the provided search criteria and returns a collection of AssetDTO objects.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //public async Task<IEnumerable<AssetDTO>> GetAssetsSearch(SearchAssetDTO dto)
        //{
        //    var assets = await _assetRepository.GetAssetsSearch(dto);
        //    return assets;
        //}
    }
}
