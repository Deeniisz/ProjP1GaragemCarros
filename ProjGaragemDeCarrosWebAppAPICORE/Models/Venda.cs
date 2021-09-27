using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGaragemDeCarrosWebAppAPICORE.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Carro Carro { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Carros { get; set; }
        public Vendedor Vendedor { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Vendedores { get; set; }
        public Cliente Cliente { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }
        public string Descricao { get; set; }


    }
}
