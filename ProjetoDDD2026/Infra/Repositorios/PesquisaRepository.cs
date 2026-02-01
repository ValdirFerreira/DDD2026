using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorios.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public class PesquisaRepository : Repository<Pesquisa>, IPesquisaRepository
    {

        public PesquisaRepository(PesquisaContext context) : base(context) { }

    }
}
