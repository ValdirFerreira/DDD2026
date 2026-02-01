using Domain.Interfaces;
using Domain.InterfacesServicos;
using Entities.Entidades;
using Entities.EntidadesNoMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class RespostaServico : IRespostaServico
    {

        private readonly IRespostaRepository _iRespostaRepository;

        private readonly IOpcaoRespostaRepository _IOpcaoRespostaRepository;
        public RespostaServico(IRespostaRepository iRespostaRepository, IOpcaoRespostaRepository IOpcaoRespostaRepository)
        {
            _iRespostaRepository = iRespostaRepository;
            _IOpcaoRespostaRepository = IOpcaoRespostaRepository;
        }


        public async Task AdicionarRespostasOpcoes(RespostasEntrevista Resposta)
        {
            foreach (var item in Resposta.ListaRespostaPergunta)
            {
                var resposta = new Resposta
                {
                    CpfEntrevistado = item.CpfEntrevistado,
                    NomeEntrevistado = item.NomeEntrevistado,
                    IdEmpresa = item.IdEmpresa
                };

                await _iRespostaRepository.AddAsync(resposta);

                var opcaoResposta = new OpcaoResposta
                {
                    IdOpcao = item.OpcaoResposta.Id,
                    IdResposta = resposta.Id
                };

                await _IOpcaoRespostaRepository.AddAsync(opcaoResposta);


            }
        }
    }
}
