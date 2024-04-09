using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto p)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDescription = p.FooterDescription,
                Location = p.Location,
                Mail = p.Mail,
                PhoneNumber = p.PhoneNumber
            });
            return Ok("İletişim Bilgisi Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateContactDto p)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = p.ContactID,
                FooterDescription = p.FooterDescription,
                Location = p.Location,
                Mail = p.Mail,
                PhoneNumber = p.PhoneNumber
            });
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
