using FilmesMoura.webAPI.Interfaces;
using FilmesMoura.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesMoura.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository
            _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_generoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            { 
            return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);
                return StatusCode(201);
             }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        
        }

    }
}
