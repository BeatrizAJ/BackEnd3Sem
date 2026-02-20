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
            try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString())!;
                return generoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Genero novoGenero)
        {

            try
            {
                novoGenero.IdGenero = Guid.NewGuid().ToString();

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
            try
            {
                List<Genero> listaGenero = _context.Generos.ToList();

                return listaGenero; 
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
