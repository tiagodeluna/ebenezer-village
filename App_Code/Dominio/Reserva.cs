using System;
using System.Collections.Generic;
using System.Web;


namespace Br.Com.EbenezerVillage.Dominio
{
    /// <summary>
    /// Classe que engloba as informações de uma Reserva
    /// </summary>
    public class Reserva
    {
        public Reserva() { }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }
        public string TipoApto { get; set; }
        public string Comentario { get; set; }
    }
}
