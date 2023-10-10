namespace Mango.Web.Controllers
{
    using Mango.Web.Models.ProductDtos;
    using Mango.Web.Service.IService;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();

            var response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
               var response = await _productService.CreateProductAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex), "Product");
                }
                else
                {
                    TempData["error"] = response.Message;
                }
            }

            return View(model);
        }
                
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(product);
            }
            else
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDto model)
        {
            var response = await _productService.DeleteProductAsync(model.ProductId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Successfuly delete product";

                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response.Message;
                return RedirectToAction(nameof(ProductIndex));
            }
        }

        public async Task<IActionResult> UpdateProduct(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(product);
            }
            else
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }


		[HttpPost]
		public async Task<IActionResult> UpdateProduct(ProductDto model)
		{
			var response = await _productService.UpdateProductAsync(model);

			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Successfuly update product";

				return RedirectToAction(nameof(ProductIndex));
			}
			else
			{
				TempData["error"] = response.Message;
				return RedirectToAction(nameof(ProductIndex));
			}
		}
	}
}
