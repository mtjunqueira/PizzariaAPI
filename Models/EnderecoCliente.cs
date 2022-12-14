using System;
using System.Collections.Generic;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class EnderecoCliente
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
