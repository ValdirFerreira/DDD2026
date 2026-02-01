using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.EntidadesNoMap
{
    public class RespostasEntrevista
    {

        public RespostasEntrevista()
        {
            ListaRespostaPergunta = new List<RespostaPerguntaDTO>();
        }

        public List<RespostaPerguntaDTO> ListaRespostaPergunta { get; set; }
    }


    public class RespostaPerguntaDTO
    {

        public int Id { get; set; }
        public string CpfEntrevistado { get; set; }
        public string NomeEntrevistado { get; set; }
        public DateTime DataResposta { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPergunta { get; set; }

        public OpcaoRespostaDTO OpcaoResposta { get; set; }

    }


    public class OpcaoRespostaDTO
    {
        public int Id { get; set; }
        public int Peso { get; set; }

    }

}
