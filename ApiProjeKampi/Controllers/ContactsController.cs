using ApiProjeKampi.Context;
using ApiProjeKampi.Dtos.ContactDtos;
using ApiProjeKampi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            try
            {
                Contact contact = new Contact();
                contact.Email = createContactDto.Email;
                contact.Address = createContactDto.Address;
                contact.PhoneNumber = createContactDto.PhoneNumber;
                contact.OpeningHours = createContactDto.OpeningHours;
                contact.MapLocation = createContactDto.MapLocation;
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return Ok("Ekleme işlemi başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
          

        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");

        }
        
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.PhoneNumber = updateContactDto.PhoneNumber;
            contact.OpeningHours = updateContactDto.OpeningHours;
            contact.ContactId = updateContactDto.ContactId;
            contact.MapLocation = updateContactDto.MapLocation;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");


        }


    }
}
