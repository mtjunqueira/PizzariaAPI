using System;
using System.Collections.Generic;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class ItemPedido
    {
        public int Id { get; set; }
        public int? IdPizza1 { get; set; }
        public int? IdPizza2 { get; set; }
        public decimal? Valor { get; set; }
        public int IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Pizza IdPizza1Navigation { get; set; }
        public virtual Pizza IdPizza2Navigation { get; set; }
    }
}
