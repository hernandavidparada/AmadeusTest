using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Core.Entites;
using ProductsManager.Core.Interfaces;
using ProductsManager.Repository.Repositories;

namespace ProductsManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _ProductsRepository;

        public ProductsController( IProductsRepository productsRepository)
        {            
            _ProductsRepository = productsRepository;
        }


        [HttpGet(Name = "GetProducts")]
        public  IActionResult GetProducts()
        {
            var response =  _ProductsRepository.GetProducts();

            return Ok(response);
        }

        [HttpPost(Name = "InsertProducts")]
        public IActionResult InsertProducts(Product product)
        {
            var response =  _ProductsRepository.InsertProducts(product);

            return Ok(response);
        }

        [HttpDelete(Name = "DeleteProducts")]
        public IActionResult DeleteProducts(int id)
        {
            var response = _ProductsRepository.DeleteProducts(id);

            return Ok(response);
        }

    }
}
