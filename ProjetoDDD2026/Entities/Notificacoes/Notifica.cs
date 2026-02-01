using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Notificacoes
{
    public class Notifica
    {
        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }


        [JsonIgnore] // NÃO aparece no Swagger
        [NotMapped]
        public string? NomePropriedade { get; set; }


        [JsonIgnore] // NÃO aparece no Swagger
        [NotMapped]
        public string? mensagem { get; set; }


        [JsonIgnore] // NÃO aparece no Swagger
        [NotMapped]
        public List<Notifica>? notificacoes;

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }


        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = "nomePropriedade"
                });

                return false;
            }

            return true;

        }
    }
}
