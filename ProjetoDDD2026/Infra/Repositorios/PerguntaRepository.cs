using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorios.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public class PerguntaRepository : Repository<Pergunta>, IPerguntaRepository
    {

        public PerguntaRepository(PesquisaContext context) : base(context) { }

    }
}
