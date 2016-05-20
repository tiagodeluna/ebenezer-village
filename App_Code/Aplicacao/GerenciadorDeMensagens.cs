using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using Br.Com.EbenezerVillage.Aplicacao.Auxiliares;
using Br.Com.EbenezerVillage.Dominio;
using Br.Com.EbenezerVillage.Dominio.Enumeradores;

namespace Br.Com.EbenezerVillage.Aplicacao
{
    enum TipoEmailEnum {
        Contato,
        Reservas
    }

    /// <summary>
    /// Controla mensagens que exibidas e enviadas pela aplicação
    /// </summary>
    public class GerenciadorDeMensagens
    {
        public static bool EnviarEmailDeReserva(Configuracoes config, Reserva reserva)
        {
            //Conteúdo do Email
            var assunto = string.Format(Constantes.mensagem_reserva_assunto, reserva.Nome, reserva.DataEntrada, reserva.DataSaida);
            var corpo = string.Format(Constantes.mensagem_reserva_corpo, reserva.Nome, reserva.Cidade, reserva.Telefone, reserva.Email, reserva.DataEntrada,
                reserva.DataSaida, reserva.TipoApto, reserva.Comentario);

            try {
                //Envia solicitação de Reserva
                EnviarEmail(config.Unidade, TipoEmailEnum.Reservas, reserva.Email, reserva.Nome, assunto, corpo);
            } catch (Exception ex) {
                throw new Exception("Erro ao enviar email: " + ex.Message, ex);
                //return false;
            }

            return true;
        }

        public static bool EnviarMensagemDoCliente(Configuracoes config, MensagemDoCliente mensagem)
        {
            //Conteúdo do Email
            var assunto = string.Format(Constantes.mensagem_cliente_assunto, mensagem.Nome);
            var corpo = string.Format(Constantes.mensagem_cliente_corpo, mensagem.Nome, mensagem.Telefone, mensagem.Email,
                mensagem.Conhecimento, mensagem.Conteudo);

            try {
                //Envia email de Contato
                EnviarEmail(config.Unidade, TipoEmailEnum.Contato, mensagem.Email, mensagem.Nome, assunto, corpo);
            } catch (Exception ex) {
                throw new Exception("Erro ao enviar email: " + ex.Message, ex);
                //return false;
            }

            return true;
        }

        private static void EnviarEmail(UnidadeEnum unidade, TipoEmailEnum tipoEmail, string emailDeOrigem, string nomeDeOrigem, 
            string assunto, string corpo)
        {
            //Seção SMTP do Web.config
            string u = (unidade.Equals(UnidadeEnum.Matriz) ? "matriz" : "filial");
            string t = (tipoEmail.Equals(TipoEmailEnum.Contato) ? "contato" : "reservas");
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection(string.Format("mailSettings/smtp_{0}_{1}", u, t));

            //Composição do E-mail
            MailMessage email = new MailMessage();
            email.From = new MailAddress(emailDeOrigem, nomeDeOrigem);
            email.To.Clear();
            email.To.Add(smtpSection.Network.UserName);
            email.Subject = assunto;            
            email.Body = corpo;
            email.IsBodyHtml = true;

            //Configuração de SMTP
            SmtpClient smtp = new SmtpClient(smtpSection.Network.Host);
            smtp.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);

            //Envio
            smtp.Send(email);
        }

        //private static bool EnviarEmail2(UnidadeEnum unidade, TipoEmailEnum tipoEmail, string emailDeOrigem, string nomeDeOrigem, 
        //    string assunto, string corpo)
        //{
        //    //Seção SMTP do Web.config
        //    string u = (unidade.Equals(UnidadeEnum.Matriz) ? "matriz" : "filial");
        //    string t = (tipoEmail.Equals(TipoEmailEnum.Contato) ? "contato" : "reservas");
        //    SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection(string.Format("mailSettings/smtp_{0}_{1}", u, t));

        //    //Configuração de SMTP
        //    WebMail.SmtpServer = smtpSection.Network.Host;

        //    //Credenciais para o Email
        //    WebMail.UserName = smtpSection.Network.UserName;
        //    WebMail.Password = smtpSection.Network.Password;
        //    WebMail.From = emailDeOrigem;

        //    WebMail.Send(to: smtpSection.Network.UserName, subject: assunto, body: corpo);

        //    return true;
        //}

        //public static bool EnviarMensagemDoCliente(Configuracoes config, MensagemDoCliente mensagem)
        //{
        //    //Configuração de SMTP
        //    WebMail.SmtpServer = config.SmtpServidor;
        //    WebMail.SmtpPort = config.SmtpPorta;
        //    WebMail.EnableSsl = config.SmtpSSL;

        //    //Credenciais para o Email
        //    WebMail.UserName = config.EmailUsuario;
        //    WebMail.Password = config.EmailSenha;
        //    WebMail.From = config.EmailEnderecoDeEnvio;

        //    //Conteúdo do Email
        //    var assunto = string.Format(Constantes.mensagem_cliente_assunto, mensagem.Nome);
        //    var corpo = string.Format(Constantes.mensagem_cliente_corpo, mensagem.Nome, mensagem.Telefone, mensagem.Email, mensagem.Conhecimento, mensagem.Conteudo);

        //    try {
        //        WebMail.Send(to: config.EmailEnderecoDeRecebimento, subject: assunto, body: corpo);
        //    } catch (Exception ex) {
        //        return false;
        //    }

        //    return true;
        //}
    }
}