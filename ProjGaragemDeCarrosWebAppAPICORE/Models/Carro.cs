using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGaragemDeCarrosWebAppAPICORE.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Renavam { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public int Preco { get; set; }
    }
}
