using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Entidades
{
    [Table("Pesquisa")]
    public class Pesquisa : Base
    {
        public bool Ativo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }

        [ForeignKey("Empresa")]
        [Column(Order = 1)]
        public int IdEmpresa { get; set; }


        [JsonIgnore]
        public virtual Empresa? Empresa { get; set; }   
    }
}
