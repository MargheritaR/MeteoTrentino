using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServizioSOAP.Servizio;
using SoapCore;

namespace ServizioSOAP
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<IMeteoSoap,MeteoSoap>();

            var app = builder.Build();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<IMeteoSoap>("/SOAPMeteo.wsdl", 
                    new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run();
        }
    }
}
