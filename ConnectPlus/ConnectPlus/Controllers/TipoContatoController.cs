using ConnectPlus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        //Dependencia
        private readonly ITipoContatoRepository _contatoRepository;
        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _contatoRepository = tipoContatoRepository;
        }

    }
}
