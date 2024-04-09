using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto p)
        {
            _discountService.TAdd(new Discount()
            {
                Description = p.Description,
                Amount = p.Amount,
                ImageUrl = p.ImageUrl,
                Title = p.Title
            });
            return Ok("İndirim Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim Silindi");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto p)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = p.DiscountID,
                Description = p.Description,
                Amount = p.Amount,
                ImageUrl = p.ImageUrl,
                Title = p.Title
            });
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
