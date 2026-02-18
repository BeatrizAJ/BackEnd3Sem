using FilmesMoura.webAPI.BdContextFilme;
using FilmesMoura.webAPI.Interfaces;
using FilmesMoura.webAPI.Models;

namespace FilmesMoura.webAPI.repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly FilmeContext _context;
        public GeneroRepository(FilmeContext context) 
        { 
        _context = context;
        }

        public void AtualizarIdCorpo(Genero generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(Guid id, Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Genero novoGenero)
        {

            try
            {
                _context.Generos.Add(novoGenero);

                _context.SaveChanges();

            }

            catch (Exception ex)
            {
                throw;
            }
           
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Genero> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
