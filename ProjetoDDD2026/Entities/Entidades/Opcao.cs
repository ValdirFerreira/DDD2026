using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Entidades
{
    [Table("Opcao")]
    public class Opcao :Base
    {
        public int Peso { get; set; }
        public bool Ativo { get; set; }
        [ForeignKey("Pergunta")]
        [Column(Order = 1)]
        public int IdPergunta { get; set; }

        [JsonIgnore]
        public virtual Pergunta? Pergunta { get; set; }
    }
}
