using System;
using System.Collections.Generic;
using System.Web;

namespace Br.Com.EbenezerVillage.Dominio
{
    /// <summary>
    /// Classe que engloba as informações de uma mensagem do cliente
    /// </summary>
    public class MensagemDoCliente
    {
        public MensagemDoCliente() { }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Conteudo { get; set; }
        public string Conhecimento { get; set; }
    }
}
