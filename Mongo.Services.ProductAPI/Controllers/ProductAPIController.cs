namespace Mongo.Services.ProductAPI.Controllers
{
    using AutoMapper;
    using Mango.Services.ProductAPI.Models.Dto;
    using Mango.Services.ProductAPI.Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Mongo.Services.ProductAPI.Data;
    using Mongo.Services.ProductAPI.Models;
    using Mongo.Services.ProductAPI.Models.Models.Dto;

    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContex _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ProductAPIController(AppDbContex db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        public ResponseDto GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> products = _db.Products
                                                      .Select(p => _mapper.Map<ProductDto>(p))
                                                      .ToList();
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetProduct(int id)
        {
            try
            {
                Product product = _db.Products.First(p => p.ProductId == id);
                ProductDto productDto = _mapper.Map<ProductDto>(product);

                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("GetByName/{productName}")]
        public ResponseDto GetProductByName(string productName)
        {
            try
            {
                Product product = _db.Products.First(p => p.Name.ToLower() == productName.ToLower());
                ProductDto productDto = _mapper.Map<ProductDto>(product);

                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Post([FromBody] ProductDto productDto) 
        {
            try
            {
                Product product = new()
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    CategoryName = productDto.CategoryName,
                    Price = productDto.Price,
                    ImgUrl = productDto.ImgUrl
                };

                _db.Products.Add(product);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(product);               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _db.Products.First(p => p.ProductId == productDto.ProductId);

                product.ImgUrl = productDto.ImgUrl;
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.CategoryName = productDto.CategoryName;
                product.Description = productDto.Description;

                _db.Products.Update(product);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product product = _db.Products.First(p => p.ProductId == id);

                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
