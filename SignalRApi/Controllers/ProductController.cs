using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            //var context = new SignalRContext();
            SignalRContext _context = new SignalRContext();
            var values = _context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                Description = y.Description,
                Price = y.Price,
                ImageUrl = y.ImageUrl,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto p)
        {
            _productService.TAdd(new Product()
            {
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                ProductStatus = true

            });
            return Ok("Ürün Bilgisi Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateProductDto p)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                ProductStatus = p.ProductStatus
            });
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
