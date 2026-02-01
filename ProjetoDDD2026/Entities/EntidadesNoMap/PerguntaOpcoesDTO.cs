using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.EntidadesNoMap
{
    public class PerguntaOpcoesDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public int IdPesquisa { get; set; }


        public List<OpcaoDTO> Opcoes { get; set; }
    }


    public class OpcaoDTO
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Peso { get; set; }
        public bool Ativo { get; set; }

        public int IdPergunta { get; set; }

    }
}
