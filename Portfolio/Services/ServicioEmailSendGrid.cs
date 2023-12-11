﻿using SendGrid.Helpers.Mail;
using SendGrid;
using Portfolio.Models;

namespace Portfolio.Services
{

    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailSendGrid : IServicioEmail
    {

        private readonly IConfiguration _configuration;
        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var apiKey = _configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = _configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = _configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Nombre} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje;
            var contenidoHtml = $@"De: {contacto.Nombre} - 
Email: {contacto.Email}
Mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
