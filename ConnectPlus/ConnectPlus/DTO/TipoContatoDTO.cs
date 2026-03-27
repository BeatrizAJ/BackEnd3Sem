using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ConnectPlus.DTO
{
    public class TipoContatoDTO
    {
        public Guid IdTipoContato { get; set; }
       
        public string Titulo { get; set; } = null!;

    }
}
