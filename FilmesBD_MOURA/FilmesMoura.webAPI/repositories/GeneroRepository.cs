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
            try
            {
                Genero generoBuscado = _context.Generos.Find(generoAtualizado.IdGenero)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome = generoAtualizado.Nome;
                }

                _context.Generos.Update(generoBuscado!);
                _context.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarIdUrl(Guid id, Genero generoAtualizado)
        {
            try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString()!);


                if (generoBuscado != null)
                {
                    generoBuscado.Nome = generoAtualizado.Nome;
                }

                _context.Generos.Update(generoBuscado!);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            } 
            
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
            try
            {
                Genero generoBuscado = _context.Generos.Find(id.ToString())!;

                if (generoBuscado != null)
                {
                    _context.Generos.Remove(generoBuscado);
                }
               
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
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
