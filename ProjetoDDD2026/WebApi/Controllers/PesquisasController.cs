using Domain.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisasController : ControllerBase
    {

        private readonly IPesquisaRepository _IPesquisaRepository;

        public PesquisasController(IPesquisaRepository IPesquisaRepository)
        {
            _IPesquisaRepository = IPesquisaRepository;

        }


        [HttpGet("/api/GetAllPesquisa")]
        [Produces("application/json")]
        public async Task<object> GetAllPesquisa()
        {
            return await _IPesquisaRepository.GetAllAsync();
        }


        [HttpPost("/api/AddPesquisa")]
        [Produces("application/json")]
        public async Task<object> AddPesquisa(Pesquisa pesquisa)
        {
            await _IPesquisaRepository.AddAsync(pesquisa);

            return pesquisa;
        }

        [HttpPost("/api/UpdatePesquisa")]
        [Produces("application/json")]
        public async Task<object> UpdatePesquisa(Pesquisa pesquisa)
        {
            await _IPesquisaRepository.UpdateAsync(pesquisa);

            return pesquisa;
        }

        [HttpGet("/api/GetPesquisaById")]
        [Produces("application/json")]
        public async Task<object> GetPesquisaById(int id)
        {
            return await _IPesquisaRepository.GetByIdAsync(id);
        }

        [HttpDelete("/api/DeletePesquisa")]
        [Produces("application/json")]
        public async Task<object> DeletePesquisa(int id)
        {
            try
            {
                var categoria = await _IPesquisaRepository.GetByIdAsync(id);
                await _IPesquisaRepository.DeleteAsync(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
