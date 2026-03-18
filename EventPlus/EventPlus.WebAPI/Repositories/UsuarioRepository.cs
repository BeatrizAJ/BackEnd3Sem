using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuario pelo email e falida o hash da senha
    /// </summary>
    /// <param name="Email">email do usuario</param>
    /// <param name="Senha">senha do usuario</param>
    /// <returns>Usuario Buscado e validado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primeiro, buscamos o usuario pelo email
      var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.Email == Email);

        //Verifica se o usuario realmente existe
        if (usuarioBuscado != null)
        {
            //Comparamos o hash da senha digitada com oq esta no banco
           bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }
        return null!;
    }

    /// <summary>
    /// Busca um usuario pelo ID incluindo os dados do seu tipo usuario
    /// </summary>
    /// <param name="IdUsuario">Id do usuario a ser buscado</param>
    /// <returns>Usuario buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuari com a senha criptografada
    /// </summary>
    /// <param name="usuario">usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha); 

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
