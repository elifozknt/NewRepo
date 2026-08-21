using ApiProjeKampi.Context;
using ApiProjeKampi.Dtos.FeatureDtos;
using ApiProjeKampi.Entities; 
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            
            var value = _mapper.Map <Feature>(createFeatureDto);
            _context.Features.Add(value);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id) 
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return ("Silme işlemi başarılı");
        }


    }
}
