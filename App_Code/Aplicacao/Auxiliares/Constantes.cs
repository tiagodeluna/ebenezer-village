using System;
using System.Collections.Generic;
using System.Web;

namespace Br.Com.EbenezerVillage.Aplicacao.Auxiliares
{
    /// <summary>
    /// Constantes gerais da aplicação
    /// </summary>
    public class Constantes
    {
        /* IDS DAS PÁGINAS */
        public const string id_home = "ebnzrhm";
        public const string id_apartamentos = "ebnzrap";
        public const string id_contato = "ebnzrcn";
        public const string id_localizacao = "ebnzrlc";
        public const string id_pousada = "ebnzrps";
        public const string id_reservas = "ebnzrrv";
        public const string id_restaurantes = "ebnzrrt";
        public const string id_resposta = "ebnzrrp";

        /* VARIÁVEIS */
        public const string variavel_configuracao = "ebnzrconf";
        public const string variavel_unidade = "ebnzrunid";
        public const string variavel_formulario_obj = "ebnzrform";
        public const string variavel_layout = "ebnzrlayo";

        /* MENSAGENS */
        public const string mensagem_cliente_assunto = "Nova Mensagem de {0}";
        public const string mensagem_cliente_corpo =
            "<h3>INFORMAÇÕES DO CLIENTE</h3>"+
            "   <p><strong>Nome:</strong> {0}<br />"+
            "   <strong>Telefone:</strong> {1}<br />"+
            "   <strong>E-mail:</strong> {2}<br />"+
            "   <strong>Como conheceu a pousada:</strong> {3}<p/>"+
            "<h3>MENSAGEM</h3>"+
            "   <p>{4}</p>";
        public const string mensagem_reserva_assunto = "Nova Solicitação de Reserva: {0} (de {1} a {2})";
        public const string mensagem_reserva_corpo =
            "<h3>INFORMAÇÕES DO CLIENTE</h3>"+
            "   <p><strong>Nome:</strong> {0}<br />"+
            "   <strong>Cidade:</strong> {1}<br />"+
            "   <strong>Telefone:</strong> {2}<br />"+
            "   <strong>E-mail:</strong> {3}<p/>"+
            "<h3>DETALHES DA RESERVA</h3>"+
            "   <p><strong>Data de Entrada:</strong> {4}<br />"+
            "   <strong>Data de Saída:</strong> {5}<br />"+
            "   <strong>Tipo de apto:</strong> {6}<p/>"+
            "<h3>COMENTÁRIO</h3>"+
            "   <p>{7}</p>";
        public const string mensagem_resposta_automatica_assunto = "Ebenezer Village - Resposta Automática";
        public const string mensagem_resposta_automatica_corpo =
            "<p>Prezado(a) {0},<br /><br />"+
            "Agradecemos pelo contato e informamos que seu e-mail foi recebido, está em processamento e será<br />"+
            "respondido em breve.<br /><br />"+
            "As mensagens recebidas após as 19h00 serão processadas no dia seguinte a partir das 08h30.<br /><br />"+
            "Para sua comodidade, dispomos de Atendimento Emergencial para qualquer dúvida<br />após nosso horário de expediente.<br /><br />"+
            "Atendimento Emergencial: {1} / {2}<br /><br />"+
            "Desde já, agradecemos muito e ficamos sempre à disposição.<br /><br />"+
            "Atenciosamente,<br />"+
            "Setor de Reservas</p>";
    }
}