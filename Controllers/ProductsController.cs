using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store_API.Data;
using Store_API.Models;

namespace Store_API.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductsController:ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<MProducts>>> GetProducts()
        {
            var function = new Dproducts();

            var list = await function.ShowProducts();

            return list;
        }

        [HttpPost]
        public async Task InserProduct([FromBody] MProducts parameters)
        {
            var function = new Dproducts();

            await function.InsertProducts(parameters);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> InserProduct(int id, [FromBody] MProducts parameters)
        {
            var function = new Dproducts();

            parameters.id = id;

            await function.editProduct(parameters);

            return NoContent();

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteProduct(int id)
        {
            var function = new Dproducts();
            var parameters = new MProducts();
            parameters.id = id;

            await function.deleteProducts(parameters);

            return NoContent();

        }

    }
}

