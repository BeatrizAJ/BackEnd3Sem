using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface ITipoEventoRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    void Deletar(Guid id);
    List<TipoUsuario> Listar();
    TipoUsuario BuscarporId(Guid id);
    void Atualizar(Guid id, TipoUsuario tipoUsuario);
    void Cadastrar(TipoEvento tipoEvento);
    void Atualizar(Guid id, TipoEvento tipoEvento);
}
