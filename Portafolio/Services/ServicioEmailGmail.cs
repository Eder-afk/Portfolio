using System.Net;
using System.Net.Mail;
using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;
        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage
                (
                emailEmisor, //De
                emailEmisor, //Para
                $"El cliente {contacto.Nombre} ({contacto.Email}) ha enviado un mensaje", //Asunto
                contacto.Mensaje //Mensaje
                );

            await smtpCliente.SendMailAsync(mensaje);
        }
    }
}
