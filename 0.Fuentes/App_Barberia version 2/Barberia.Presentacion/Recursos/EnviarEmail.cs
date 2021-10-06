using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Barberia.Presentacion.Recursos
{
    public class EnviarEmail:IDisposable
    {
        /// <summary>
        /// Autor: Alejandro Yauyo Barrientos
        /// Permite enviar un correo electronico
        /// </summary>
        /// <param name="asDe"></param>
        /// <param name="asPara"></param>
        /// <param name="asAsunto"></param>
        /// <param name="asCuerpo"></param>
        /// <param name="asesHtml"></param>
        /// <param name="asCC"></param>
        /// <param name="listaAdjunto"></param>
        /// <param name="RutaImagen"></param>
        /// 
        public bool exito;
        
        public void SetEnviarEmailCompleto(string asDe, List<string> asPara, string asAsunto, string asCuerpo, bool asesHtml, List<string> asCC = null, List<string> asCO = null, List<Attachment> listaAdjunto = null, string RutaImagen = "")
        {
            MailMessage correo = new MailMessage();
            SmtpClient smpt = new SmtpClient();
            correo.From = new MailAddress(asDe);
            //Correo de Destino
            foreach (var item in asPara)
            {
                correo.To.Add(item);
            }
            //Correo de Copia
            if (asCC != null)
            {
                if (asCC.Count > 0)
                {
                    foreach (var item in asCC)
                    {
                        correo.CC.Add(item);
                    }
                }
            }
            //Correo de Copia Oculta
            if (asCO != null)
            {
                if (asCO.Count > 0)
                {
                    foreach (var item in asCO)
                    {
                        correo.Bcc.Add(item);
                    }
                }
            }

            ServicePointManager.ServerCertificateValidationCallback = delegate(object s
                   , X509Certificate certificate
                   , X509Chain chain
                   , SslPolicyErrors sslPolicyErrors)

            { return true; };
            correo.Subject = asAsunto;
            //correo.Body = asCuerpo;

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(asCuerpo, Encoding.UTF8, MediaTypeNames.Text.Html);
            //try
            //{
            //    LinkedResource imgLogo = new LinkedResource(@ConfigurationManager.AppSettings.Get("ImagenLogoMEMcorreo") + "logo_login.png", MediaTypeNames.Image.Jpeg);
            //    imgLogo.ContentId = "imagenLogoMEM";
            //    htmlView.LinkedResources.Add(imgLogo);

            //    correo.AlternateViews.Add(htmlView);

            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine("ERROR: Al exportar el archivo escaneado... " + err.ToString());
            //}

            correo.IsBodyHtml = asesHtml;
            correo.Priority = MailPriority.Normal;
            smpt.Host = ConfigurationManager.AppSettings.Get("IpMail");
            string UserMail, ClaveMail;
            UserMail = ConfigurationManager.AppSettings.Get("UserMail");
            ClaveMail = ConfigurationManager.AppSettings.Get("ClaveMail");
            smpt.Credentials = new NetworkCredential(UserMail, ClaveMail);
            smpt.EnableSsl = true;
            if (listaAdjunto != null)
            {
                if (listaAdjunto.Count > 0)
                {
                    foreach (var item in listaAdjunto)
                    {
                        correo.Attachments.Add(item);
                    }
                }
            }
            try
            {
                // ENCARGO DE ENVIAR EL CORREO 
                smpt.Send(correo);
            }
            catch (Exception ex)
            {
                //agregar el log.
                throw ex;
            }
        }

        public void SetEnviarEmail(string asDe,string asDeClave, List<string> asPara, string asAsunto, string asCuerpo,int asport, string ashost, bool asesHtml, List<string> asCC = null, List<string> listaAdjuntos = null, string RutaImagen = "")
        {
            //Envio();
            //return;
           // bool enviado;
            MailMessage correo = new MailMessage();
            SmtpClient smpt = new SmtpClient();
            correo.From = new MailAddress(asDe);
            foreach (var item in asPara)
            {
                correo.To.Add(item);
            }
            if (asCC != null)
            {
                if (asCC.Count > 0)
                {
                    foreach (var item in asCC)
                    {
                        correo.CC.Add(item);
                    }
                }
            }
             
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s
                   , X509Certificate certificate
                   , X509Chain chain
                   , SslPolicyErrors sslPolicyErrors)

            { return true; };
            correo.Subject = asAsunto;
            correo.Body = asCuerpo;
            correo.IsBodyHtml = asesHtml;
            correo.Priority = MailPriority.Normal;
            smpt.Port = 587;
            smpt.Host = ashost;
            string UserMail, ClaveMail;
            UserMail = asDe;
            ClaveMail = asDeClave; 
            smpt.Credentials = new NetworkCredential(UserMail, "enonime123"); 
            smpt.EnableSsl = true; 
            if (listaAdjuntos != null)
            {
                if (listaAdjuntos.Count > 0)
                {
                    foreach (var item in listaAdjuntos)
                    {
                       // using (Attachment doc_ = new Attachment(item))
                        //{
                        Attachment doc_ = new Attachment(item);
                        correo.Attachments.Add(doc_);
                        //}
                          
                    }
                }
            }
            try
            {
                // ENCARGO DE ENVIAR EL CORREO 
                smpt.Send(correo);
                correo.Dispose();
                exito = true;
            }
            catch (Exception ex)
            {
                //agregar el log.
                //throw ex;
                exito = false;
            }
        }

        private void Envio()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("vongolaenoshiro@gmail.com");
            msg.From = new MailAddress("vongolaenoshiro@gmail.com", "richi", System.Text.Encoding.UTF8);
            msg.Subject = "Prueba de correo a GMail";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Cuerpo del mensaje";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("vongolaenoshiro@gmail.com", "Alucardenonime2");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
