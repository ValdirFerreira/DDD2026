using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{
    [Table("OpcaoResposta")]
    public class OpcaoResposta : Notifica
    {
        public int Id { get; set; }

        [ForeignKey("Resposta")]
        [Column(Order = 1)]
        public int IdResposta { get; set; }

        [ForeignKey("Opcao")]
        [Column(Order = 1)]
        public int IdOpcao { get; set; }
    }
}
