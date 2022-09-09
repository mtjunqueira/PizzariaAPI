using System;
using System.Collections.Generic;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItemPedidos = new HashSet<ItemPedido>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public decimal? ValorTotal { get; set; }
        public bool? Finalizado { get; set; }
        public bool? Entregue { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
