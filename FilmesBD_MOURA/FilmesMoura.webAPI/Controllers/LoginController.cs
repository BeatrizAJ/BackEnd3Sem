using FilmesMoura.webAPI.DTO;
using FilmesMoura.webAPI.Interfaces;
using FilmesMoura.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FilmesMoura.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public LoginController(IUsuarioRepository usarioRepository)
    {
      _usuarioRepository = usarioRepository;    
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDto)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDto.Email!, loginDto.Senha!);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha invalidos");
            }

            //caso encontre o usua. prossegue para a criacao do token

            // 1- defirnir as inform q seram fornecidas no token
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario),

        new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!)
        };
            //2 Definir a chave de acessoa ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3 definir credenc do token
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            //4 gerar token
            var token = new JwtSecurityToken
                (
                //qm gerou ele
                issuer: "api_filmes",

                //destinatario
                audience: "api_filmes",

                //dados definidos nas claims(INFO)
                claims: claims,

                //tempo de expiracao do token
                expires: DateTime.Now.AddMinutes(5),

                //credenc do token
                signingCredentials: creds
                );
            //5 

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)       
            });
                
                

        }

        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
}
