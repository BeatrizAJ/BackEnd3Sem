using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    /// <summary>
    /// Endpoint da api, que faz a chamada p o metodo de buscar um usuario por id
    /// </summary>
    /// <param name="id">Id usuario a ser buscado</param>
    /// <returns>status code 200 e o usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_usuarioRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }



    /// <summary>
    /// Endpoint da api, q faz a chamada para o metodo cadastrar um usuario
    /// </summary>
    /// <param name="usuario">usuario a ser cadastrado</param>
    /// <returns>status code 200 aeo usuario cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {
        try
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome!,
                Senha = usuario.Senha!,
                Email = usuario.Email!,
                IdTipoUsuario = usuario.IdTipoUsuario
            };

            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201, novoUsuario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}
