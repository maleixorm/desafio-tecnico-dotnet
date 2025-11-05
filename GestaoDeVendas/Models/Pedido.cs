using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeVendas.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<string> Itens { get; set; }
        public int Quantidade { get; set; }
        public Enum Status { get; set; }
    }
}