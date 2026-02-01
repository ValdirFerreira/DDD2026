using Entities.EntidadesNoMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.InterfacesServicos
{
    public interface IRespostaServico
    {
        Task AdicionarRespostasOpcoes(RespostasEntrevista Resposta);
    }
}
