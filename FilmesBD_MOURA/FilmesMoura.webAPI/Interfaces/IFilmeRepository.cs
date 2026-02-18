using FilmesMoura.webAPI.Models;

namespace FilmesMoura.webAPI.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filme novoFilme);
        List<Filme> Listar();
        void AtualizarIdCorpo(Filme FIlmeAtualizado);
        void AtualizarIdUrl(Guid id, Filme FIlmeAtualizado);
        void Deletar(Guid id);
        Filme BuscarPorId(Guid id);
    }
}
