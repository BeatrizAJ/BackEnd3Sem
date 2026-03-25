using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;

    //Injecao de dependencia
    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// Endpoint da API q faz a chamada p medoto de lista tipos de evento
    /// </summary>
    /// <returns>status code 200 e alista de tipos de evento</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API q faz a chamada para o metodo de buscar um tipo de evento especifico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>Status code 200 e o tipo de evento buscadoS</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarporId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de evento a ser cadastrado</returns>
    [Authorize]
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento
            {
             Titulo = tipoEvento.Titulo!,
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);

            return StatusCode(201, tipoEvento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoit API q faz a chamada para o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados</param>
    /// <returns>Staus code 204 e o tipo de evento atualizados</returns>
    [HttpPut("{id}")]

    public IActionResult Atualizar(Guid id, TipoEventoDTO tipoEvento)
    {
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            { 
             Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);

            return StatusCode(204, tipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    
    /// <summary>
    /// Endpoint da API q faz a chamada p metodo deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo do evento a ser excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}