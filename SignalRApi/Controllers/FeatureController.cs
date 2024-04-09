using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto p)
        {
            _featureService.TAdd(new Feature()
            {
                Title1 = p.Title1,
                Description1 = p.Description1,
                Title2 = p.Title2,
                Description2 = p.Description2,
                Title3 = p.Title3,
                Description3 = p.Description3
            });
            return Ok("Feature Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Feature Silindi");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto p)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = p.FeatureID,
                Title1 = p.Title1,
                Description1 = p.Description1,
                Title2 = p.Title2,
                Description2 = p.Description2,
                Title3 = p.Title3,
                Description3 = p.Description3
            });
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
