using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using Br.Com.EbenezerVillage.Dominio;
using Br.Com.EbenezerVillage.Dominio.Enumeradores;

namespace Br.Com.EbenezerVillage.Dominio
{
    /// <summary>
    /// Informações gerais do site e da empresa
    /// </summary>
    public class Configuracoes
    {
        private UnidadeEnum unidade;
        private string contatoEmail;
        private string contatoTelefone;
        private string contatoCelular;
        private string endereco;
        private List<TipoDeApartamento> tiposDeApartamento;

        public Configuracoes(UnidadeEnum unidade)
        {
            this.unidade = unidade;
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            var prefixo = (unidade.Equals(UnidadeEnum.Matriz) ? "matriz." : "filial.");

            contatoEmail                = ConfigurationManager.AppSettings[prefixo+"contato_email"];
            contatoTelefone             = ConfigurationManager.AppSettings[prefixo+"contato_telefone"];
            contatoCelular              = ConfigurationManager.AppSettings[prefixo+"contato_celular"];
            endereco                    = ConfigurationManager.AppSettings[prefixo+"endereco"];
            PreencherTiposDeApartamento(ConfigurationManager.AppSettings[prefixo+"tipos_apto"]);
        }

        public UnidadeEnum Unidade
        {
            get { return unidade; }
        }

        public string ContatoEmail
        {
            get { return contatoEmail; }
            set { value = contatoEmail; }
        }

        public string ContatoTelefone
        {
            get { return contatoTelefone; }
            set { value = contatoTelefone; }
        }

        public string ContatoCelular
        {
            get { return contatoCelular; }
            set { value = contatoCelular; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { value = endereco; }
        }

        public List<TipoDeApartamento> TiposDeApartamento
        {
            get { return tiposDeApartamento; }
        }
 
        private void PreencherTiposDeApartamento(string cfg)
        {
            tiposDeApartamento = new List<TipoDeApartamento>();
            int i = 0, j = 0;

            while(i < cfg.Length)
            {
                TipoDeApartamento apto = new TipoDeApartamento();

                try
                {
                    j = cfg.IndexOf("|", i);
                    apto.Descricao = cfg.Substring(i, j-i);
                    i = j+1;
                    j = cfg.IndexOf("||", i);
                    apto.Tarifa = Double.Parse(cfg.Substring(i, j-i));
                    i = j+2;
                }
                catch(Exception ex)
                {
                    throw new Exception("Falha ao ler a configuração [tipos_apto]", ex);
                }

                tiposDeApartamento.Add(apto);
            }
        }
   }
}