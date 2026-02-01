using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Entidades
{
    [Table("Resposta")]
    public class Resposta:Notifica
    {
        public int Id { get; set; }
        public string CpfEntrevistado { get; set; }
        public string NomeEntrevistado { get; set; }

        public DateTime DataResposta { get; set; }

        [ForeignKey("Empresa")]
        [Column(Order = 1)]
        public int IdEmpresa { get; set; }

        [JsonIgnore]
        public virtual Empresa? Empresa { get; set; }
    }
}
