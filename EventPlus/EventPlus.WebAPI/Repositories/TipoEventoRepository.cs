using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _context;

    //Injecao d dependencia: Recebe o contexto pelo construtor
    public TipoEventoRepository(EventContext context)
    {
      _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">id do tipo evento p atualiz</param>
    /// <param name="tipoEvento">novo dado do tip evento</param>

    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            _context.SaveChanges();
        }
    }

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca um tipo de evento p id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado</param>
    /// <returns>Objeto do tipo evento com as informacoes do tipo buscado</returns>
    public TipoEvento BuscarporId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }

    /// <summary>
    ///     Cadastra um nvo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deleta um tipo de evento 
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// Buscar a lista de eventos cadastrados 
    /// </summary>
    /// <returns>Uma lista do tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }

    TipoUsuario ITipoEventoRepository.BuscarporId(Guid id)
    {
        throw new NotImplementedException();
    }

    List<TipoUsuario> ITipoEventoRepository.Listar()
    {
        throw new NotImplementedException();
    }
}