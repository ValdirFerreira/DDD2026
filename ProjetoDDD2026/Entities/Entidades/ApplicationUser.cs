using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entidades
{
    public class ApplicationUser :IdentityUser
    {
        [Column("USER_CPF")]
        public string CPF { get; set; }
    }
}
