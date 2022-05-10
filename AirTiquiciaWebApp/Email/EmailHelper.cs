using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using AirTiquicia.Core.Entities;
using System.Runtime.InteropServices;

namespace AirTiquiciaWebApp.Email
{
    public class EmailHelper
    {
        public bool SendEmail(Passenger passenger, Airport airport, Flight OBFlight, Aeroline aeroline, string Flightclass, Price price)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("airtiquicia@gmail.com");
            mailMessage.To.Add(new MailAddress(passenger.Email));

            mailMessage.Subject = "Airtiquicia - Comprobante de compra de tiquetes de vuelo";
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Número de identificación: " + passenger.Id + Environment.NewLine +
                                "Nombre: " + passenger.FirstName + " " + passenger.LastName + Environment.NewLine +
                                "Nacionalidad: " + passenger.Nationality + Environment.NewLine +
                                "Teléfono: " + passenger.Phone + Environment.NewLine +
                                "Email: " + passenger.Email + Environment.NewLine + Environment.NewLine +
                                "Salida: " + airport.City + "(" + OBFlight.DepartureAirport + ") Fecha: " + OBFlight.DepartureDate + Environment.NewLine +
                                "Llegada: " + OBFlight.DestinationAirport + " Fecha: " + OBFlight.ArrivalDate + Environment.NewLine +
                                "Vuelo: " + OBFlight.Code + " Aeronave: " + OBFlight.IdAirplane + " Aerolinea: " + aeroline.Name + Environment.NewLine +
                                "Clase: " + Flightclass + " Precio: $" + price.Cost;


            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("airtiquicia@gmail.com", "imah1525");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                var excep = ex;
            }
            return false;
        }
    }
}
