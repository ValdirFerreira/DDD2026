using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Entidades
{
    [Table("Pergunta")]
    public class Pergunta :Base
    {
        public bool Ativo { get; set; }

        [ForeignKey("Pesquisa")]
        [Column(Order = 1)]
        public int IdPesquisa { get; set; }

        [JsonIgnore]
        public virtual Pesquisa? Pesquisa { get; set; }
    }
}
