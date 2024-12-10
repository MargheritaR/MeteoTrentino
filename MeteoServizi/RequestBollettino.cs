using MeteoTrentino;
using Newtonsoft.Json;
namespace MeteoServizi;

public class RequestBollettino
{
    public static async Task<MeteoModelli.RootObject> Richiesta()
    {
        string uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita";
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    MeteoModelli.RootObject rootObject = JsonConvert.DeserializeObject<MeteoModelli.RootObject>(result);
                    return rootObject;
                }
                else
                {
                    throw new HttpRequestException($"Errore nella richiesta HTTP. Codice: {response.StatusCode}");
                }
            }
        }
        {
            
        }
    }
}