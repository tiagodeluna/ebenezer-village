using System;
using System.Web;
using Br.Com.EbenezerVillage.Aplicacao.Auxiliares;
using Br.Com.EbenezerVillage.Dominio;
using Br.Com.EbenezerVillage.Dominio.Enumeradores;

namespace Br.Com.EbenezerVillage.Aplicacao
{
    /// <summary>
    /// Controla o acesso às configurações do sistema
    /// </summary>
    public class GerenciadorDeConfiguracao
    {

        public static Configuracoes GetConfiguracoesDaMatriz(HttpSessionStateBase sessao)
        {
            return GetConfiguracoes(sessao, UnidadeEnum.Matriz);
        }

        public static Configuracoes GetConfiguracoesDaFilial(HttpSessionStateBase sessao)
        {
            return GetConfiguracoes(sessao, UnidadeEnum.Filial);
        }

        public static string GetLayout(HttpSessionStateBase sessao)
        {
            string layout = (string)sessao[Constantes.variavel_layout];

            if (string.IsNullOrEmpty(layout))
            {
                layout = "~/Matriz/_SiteLayout.cshtml";
            }

            return layout;
        }

        public static void SetLayout(HttpSessionStateBase sessao, string layout)
        {
            sessao.Add(Constantes.variavel_layout, layout);
        }

        private static Configuracoes GetConfiguracoes(HttpSessionStateBase sessao, UnidadeEnum unidade)
        {
            var und = (UnidadeEnum?)sessao[Constantes.variavel_unidade];
            var cfg = (Configuracoes)sessao[Constantes.variavel_configuracao];
        
            if ((cfg == null) || (!unidade.Equals(und)))
            {
                cfg = new Configuracoes(unidade);
                sessao.Add(Constantes.variavel_unidade, unidade);
                sessao.Add(Constantes.variavel_configuracao, cfg);
            }

            return cfg;
        }
    }
}