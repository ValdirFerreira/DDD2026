using Domain.Interfaces;
using Domain.InterfacesServicos;
using Entities.Entidades;
using Entities.EntidadesNoMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class PerguntaServico : IPerguntaServico
    {

        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IOpcaoRepository _opcaoRepository;

        public PerguntaServico(IOpcaoRepository opcaoRepository,
            IPerguntaRepository perguntaRepository)
        {
            _opcaoRepository = opcaoRepository;
            _perguntaRepository = perguntaRepository;
        }

        public async Task AdicionarPesquisaOpcoes(PerguntaOpcoesDTO Resposta)
        {
            // 1 Criar pergunta

            var pergunta = new Pergunta
            {
                Ativo = Resposta.Ativo,
                IdPesquisa = Resposta.IdPesquisa,
                Nome = Resposta.Nome
            };

            await _perguntaRepository.AddAsync(pergunta);

            // 2 Criaço opçoes vinculadas a perguinta criada 

            foreach (var item in Resposta.Opcoes)
            {
                var opcao = new Opcao
                {
                    Peso = item.Peso,
                    Ativo = item.Ativo,
                    IdPergunta = item.IdPergunta,
                    Nome = item.Nome
                };

                await _opcaoRepository.AddAsync(opcao);
            }


        }

        public async Task AtualizarPesquisaOpcoes(PerguntaOpcoesDTO dto)
        {
            // 1 buscar a pergunta 

            var pergunta = await _perguntaRepository.GetByIdAsync(dto.Id);
            if (pergunta == null)
                throw new Exception();

            // 2 atualiza pergunta
            pergunta.Ativo = dto.Ativo;
            await _perguntaRepository.UpdateAsync(pergunta);

            // 3 Buscar as opçoes da pergunta 
            var opcoesAtuais = (await _opcaoRepository.GetAllAsync())
                .Where(o => o.IdPergunta == pergunta.Id)
                .ToList();


            foreach (var opcaoDto in dto.Opcoes)
            {
                if (opcaoDto.Id > 0)
                {
                    // Atualiza opcao Existente

                    var opcaoExistente = opcoesAtuais
                        .FirstOrDefault(o => o.Id == opcaoDto.Id);

                    if (opcaoExistente != null)
                    {
                        opcaoExistente.Peso = opcaoDto.Peso;
                        opcaoExistente.Ativo = opcaoDto.Ativo;
                        opcaoExistente.Nome = opcaoDto.Nome;

                        await _opcaoRepository.UpdateAsync(opcaoExistente);
                        continue;
                    }
                }


                var opcao = new Opcao
                {
                    Peso = opcaoDto.Peso,
                    Ativo = opcaoDto.Ativo,
                    IdPergunta = opcaoDto.IdPergunta,
                    Nome = opcaoDto.Nome
                };

                await _opcaoRepository.AddAsync(opcao);
            }

            // Inativar Opcoes removidas

            var idsRecebidos = dto.Opcoes
                .Where(o => o.Id > 0)
                .Select(o => o.Id)
                .ToList();


            var opcoesRemovidas = opcoesAtuais
                .Where(o => !idsRecebidos.Contains(o.Id)
                ).ToList();


            foreach (var opcao in opcoesRemovidas)
            {
                opcao.Ativo = false;
                await _opcaoRepository.UpdateAsync(opcao);
            }


        }

        public async Task<PerguntaOpcoesDTO> ObterPerguntaComOpcoes(int idPergunta)
        {
            // Buscar a ppergunta 

            var pergunta = await _perguntaRepository.GetByIdAsync(idPergunta);

            if (pergunta == null)
                throw new Exception();

            // buscar as opçoes da pergunta 

            var opcoes = (await _opcaoRepository.GetAllAsync())
                .Where(o => o.IdPergunta == pergunta.Id && o.Ativo)
                .ToList();

            // Montar o DTO de retorno 

            var dto = new PerguntaOpcoesDTO
            {
                Id = pergunta.Id,
                Nome = pergunta.Nome,
                Ativo = pergunta.Ativo,
                IdPesquisa = pergunta.IdPesquisa,
                Opcoes = opcoes.Select(o => new OpcaoDTO
                {
                    Id = o.Id,
                    Nome = o.Nome,
                    Ativo = o.Ativo,
                    Peso = o.Peso
                }).ToList()
            };

            return dto;

        }
    }
}
