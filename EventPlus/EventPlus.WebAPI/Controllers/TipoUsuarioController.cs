using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ITipoUsuarioRepository
{
   
    public void Atualizar(Guid id, Models.TipoUsuario tipoUsuario)
    {
        throw new NotImplementedException();
    }

    public Models.TipoUsuario BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Models.TipoUsuario tipoUsuario)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Models.TipoUsuario> List(Guid IdTipoUsuario)
    {
        throw new NotImplementedException();
    }
}
