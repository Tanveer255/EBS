using EBS.Models.DTO;
using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.DAL.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Method declaration of IAssetRepository to searches for assets based on the provided search criteria and returns a collection of AssetDTO objects.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //public Task<IEnumerable<ProductDTO>> GetAssetsSearch(SearchAssetDTO dto);
    }
}
