using Domain.Interfaces;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;

        }


        [HttpGet("/api/GetEmpresaById")]
        [Produces("application/json")]
        public async Task<object> GetEmpresaById( int id)
        {
            var empresas = await  _empresaRepository.GetByIdAsync(id);
            return Ok(empresas);
        }


        [HttpGet("/api/GetAllEmpresas")]
        [Produces("application/json")]
        public async Task<object> GetAllEmpresas()
        {
            var empresas = await _empresaRepository.GetAllAsync();
            return Ok(empresas);
        }

        [HttpPost("/api/CreateEmpresa")]
        [Produces("application/json")]
        public async Task<object> CreateEmpresa([FromBody] Empresa empresa)
        {
            await _empresaRepository.AddAsync(empresa);
            return Ok(empresa);
        }


        [HttpPost("/api/UpdateEmpresa")]
        [Produces("application/json")]
        public async Task<object> UpdateEmpresa([FromBody] Empresa empresa)
        {
            await _empresaRepository.UpdateAsync(empresa);
            return Ok(empresa);
        }

    }
}
