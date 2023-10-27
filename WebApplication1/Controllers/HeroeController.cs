using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOS;
using WebApplication1.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        private readonly HeroeService _heroeService;
        public HeroeController(HeroeService heroeService)
        {
            _heroeService = heroeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<PersonajeHeroeDTO>> ListarHeroes()=> await _heroeService.ListarHeroes();





        // GET api/<ValuesController>/5
        [HttpGet("{nombre}")]
        public async Task<PersonajeHeroeDTO> BuscarHeroe(string nombre) => await _heroeService.BuscarHeroe(nombre);
    

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
