using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _context;

        public ComentarioEventoRepository(EventContext context)
        {
            _context = context;
        }



        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            _context.ComentarioEventos.Add(comentarioEvento);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var comentarioBuscado = _context.ComentarioEventos.Find(id);
            if (comentarioBuscado != null)
            {
                _context.ComentarioEventos.Remove(comentarioBuscado);
                _context.SaveChanges();
            }
        }

        public List<ComentarioEvento> Listar()
        {
            return _context.ComentarioEventos.Include(c => c.IdUsuarioNavigation).ToList();
        }

        public List<ComentarioEvento> List(Guid idEvento)
        {
            return _context.ComentarioEventos.Where(c => c.IdEvento == idEvento).Include(c => c.IdUsuarioNavigation).ToList();
        }

        public List<ComentarioEvento> ListarSomenteExibe(Guid idEvento)
        {
            return _context.ComentarioEventos.Where(c => c.IdEvento == idEvento && c.ExibeComentario == true).Include(c => c.IdUsuarioNavigation).ToList();
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            return _context.ComentarioEventos.FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == idEvento)!;
        }
    }
}
