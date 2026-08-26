using ApiProjeKampi.Context;
using ApiProjeKampi.Dtos.MessageDtos;
using ApiProjeKampi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly ApiContext _context;

        public MessageController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var entity = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetMessages")]
        public IActionResult GetMessages(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));

        }

        [HttpPut]
       public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _context.Messages.Update(_mapper.Map<Message>(updateMessageDto));
            _context.SaveChanges();
            return Ok("güncelleme başarılı");

        }
        



    }
}
