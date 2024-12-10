using static MeteoTrentino.MeteoModelli;

namespace WebMeteo.ViewModels
{
    public class BollettinoVisualizzaViewModels
    {
        public List<string> Localita {  get; set; }

        public List<int> Quota { get; set; }

        public List<string> Giorno { get; set; }

        public List<int> TemperaturaMinima { get; set; }

        public List<int> TemperaturaMassima { get; set; }

        public List<string> DescrizioneCondizioni { get; set; }

        public List<string> Icona { get; set; }

        public BollettinoVisualizzaViewModels(RootObject rootObject)
        {
            if (rootObject != null && rootObject.previsione != null)
            {
                Localita = rootObject.previsione.SelectMany(c => c.giorni.Select(g => c.localita)).ToList();
                Quota = rootObject.previsione.SelectMany(c => c.giorni.Select(g => c.quota)).ToList();
                Giorno = rootObject.previsione.SelectMany(c => c.giorni.Select(g => g.giorno)).ToList();
                TemperaturaMinima = rootObject.previsione.SelectMany(c => c.giorni.Select(g => g.tMinGiorno)).ToList();
                TemperaturaMassima = rootObject.previsione.SelectMany(c => c.giorni.Select(g => g.tMaxGiorno)).ToList();
                DescrizioneCondizioni = rootObject.previsione.SelectMany(c => c.giorni.Select(g => g.testoGiorno)).ToList();
                Icona = rootObject.previsione.SelectMany(c => c.giorni.Select(g => g.icona)).ToList();
            }
        }

    }
}
