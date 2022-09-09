using System;
using System.Collections.Generic;

#nullable disable

namespace PizzariaAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            EnderecoClientes = new HashSet<EnderecoCliente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<EnderecoCliente> EnderecoClientes { get; set; }
    }
}
