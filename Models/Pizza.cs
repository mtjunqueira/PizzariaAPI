using System;
using System.Collections.Generic;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            ItemPedidoIdPizza1Navigations = new HashSet<ItemPedido>();
            ItemPedidoIdPizza2Navigations = new HashSet<ItemPedido>();
        }

        public int Id { get; set; }
        public string Pizza1 { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidoIdPizza1Navigations { get; set; }
        public virtual ICollection<ItemPedido> ItemPedidoIdPizza2Navigations { get; set; }
    }
}
