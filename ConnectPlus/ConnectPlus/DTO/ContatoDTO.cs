using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO
{
    public class ContatoDTO
    {

        [Required(ErrorMessage = "O nome eh obrigatório!")]
        public string Nome { get; set; } = null!;

       
        
        [Required(ErrorMessage = "A forma de contato eh obrigatória!")]  
        public string FormaDeContato { get; set; } = null!;
      
        
        public IFormFile?  Imagem { get; set; }

       
        
        [Required(ErrorMessage = "O tipo de contato deve ser selecionado!")]
        public Guid IdTipoContato { get; set; }
    }
}
