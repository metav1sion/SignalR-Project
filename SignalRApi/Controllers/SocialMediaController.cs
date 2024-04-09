using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto p)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = p.Title,
                Url = p.Url,
                Icon = p.Icon,
            });
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto p)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = p.SocialMediaID,
                Title = p.Title,
                Url = p.Url,
                Icon = p.Icon,
            });
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
