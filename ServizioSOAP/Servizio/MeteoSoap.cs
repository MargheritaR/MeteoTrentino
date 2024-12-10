using MeteoServizi;
using System.Globalization;
using System.ServiceModel;
using static MeteoTrentino.MeteoModelli;


namespace ServizioSOAP.Servizio
{
    [ServiceContract]
    public interface IMeteoSoap
    {
        [OperationContract]
        RootObject visualizza();
        
        [OperationContract]
        Previsione[] Cerca(DateTime tempo);
    }

    public class MeteoSoap : IMeteoSoap
    {
        public RootObject visualizza()
        {
            return RequestBollettino.Richiesta().Result;
        }
        public Previsione[] Cerca(DateTime tempo)
        {
            var bollettino = RequestBollettino.Richiesta().Result;
            if (bollettino != null && bollettino.previsione != null)
            {
                tempo = DateParseHandling(tempo);

                bollettino.previsione = bollettino.previsione
                    .Select(p => {
                        p.giorni = p.giorni
                        .Where(g => DateTime.TryParse(g.giorno, out DateTime giorno) && giorno == tempo)
                        .ToArray();

                        return p;
                    })
                    .Where(p => p.giorni.Any())
                    .ToArray();

                return bollettino.previsione;
            }
            return null;
        }


        private DateTime DateParseHandling(DateTime tempo) {
            string stringData = tempo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            if (DateTime.TryParseExact(stringData, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            } else {
                throw new ArgumentException("Utilizzare il formato corretto della data." +
                    "Il formato corretto è: yyyy-MM-dd");
            }
        }


    }
}
