using System;
using System.Collections.Generic;
using System.Web;

namespace Br.Com.EbenezerVillage.Dominio
{
    /// <summary>
    /// Modelo de Apartamento
    /// </summary>
    public class TipoDeApartamento
    {
        public TipoDeApartamento() { }

        public string Descricao { get; set; }
        public double Tarifa { get; set; }
    }
}