using Domain.Interfaces;
using Domain.InterfacesServicos;
using Entities.Entidades;
using Entities.EntidadesNoMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : ControllerBase
    {

        private readonly IPerguntaRepository _IPerguntaRepository;

        private readonly IPerguntaServico _IPerguntaServico;
        public PerguntaController(IPerguntaRepository IPerguntaRepository, IPerguntaServico IPerguntaServico)
        {
            _IPerguntaRepository = IPerguntaRepository;
            _IPerguntaServico = IPerguntaServico;
        }

        [HttpGet("/api/GetPerguntaById")]
        [Produces("application/json")]
        public async Task<object> GetPerguntaById(int id)
        {
            var perguntas = await _IPerguntaRepository.GetByIdAsync(id);
            return Ok(perguntas);
        }

        [HttpGet("/api/GetAllPerguntas")]
        [Produces("application/json")]
        public async Task<object> GetAllPerguntas()
        {
            var perguntas = await _IPerguntaRepository.GetAllAsync();
            return Ok(perguntas);
        }

        [HttpGet("/api/ObterPerguntaComOpcoes/{idPergunta}")]
        [Produces("application/json")]
        public async Task<object> ObterPerguntaComOpcoes(int idPergunta)
        {
            var resultado = await _IPerguntaServico.ObterPerguntaComOpcoes(idPergunta);
            return Ok(resultado);
        }

        [HttpPost("/api/AdicionarPesquisaOpcoes")]
        [Produces("application/json")]
        public async Task<object> AdicionarPesquisaOpcoes(PerguntaOpcoesDTO perguntaOpcoesDTO)
        {
            await _IPerguntaServico.AdicionarPesquisaOpcoes(perguntaOpcoesDTO);
            return Ok(perguntaOpcoesDTO);
        }



        [HttpPost("/api/AtualizarPesquisaOpcoes")]
        [Produces("application/json")]
        public async Task<object> AtualizarPesquisaOpcoes(PerguntaOpcoesDTO perguntaOpcoesDTO)
        {
            await _IPerguntaServico.AtualizarPesquisaOpcoes(perguntaOpcoesDTO);
            return Ok(perguntaOpcoesDTO);
        }



        [HttpPost("/api/UpdatePergunta")]
        [Produces("application/json")]
        public async Task<object> UpdatePergunta(Pergunta Pergunta)
        {
            await _IPerguntaRepository.UpdateAsync(Pergunta);

            return Pergunta;
        }

       
        [HttpDelete("/api/DeletePergunta")]
        [Produces("application/json")]
        public async Task<object> DeletePergunta(int id)
        {
            try
            {
                var categoria = await _IPerguntaRepository.GetByIdAsync(id);
                await _IPerguntaRepository.DeleteAsync(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



    }
}
