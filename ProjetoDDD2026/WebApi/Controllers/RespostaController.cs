using Domain.InterfacesServicos;
using Entities.EntidadesNoMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {

        private readonly IRespostaServico _IRespostaServico;

        public RespostaController(IRespostaServico IRespostaServico)
        {
            _IRespostaServico = IRespostaServico;

        }


        [HttpPost("/api/AddRespostaPesquisa")]
        [Produces("application/json")]
        public async Task<object> AddRespostaPesquisa(RespostasEntrevista respostasEntrevista)
        {
            await _IRespostaServico.AdicionarRespostasOpcoes(respostasEntrevista);

            return respostasEntrevista;
        }

    }
}
