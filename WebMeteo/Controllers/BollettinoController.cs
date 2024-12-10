using MeteoServizi;
using Microsoft.AspNetCore.Mvc;
using WebMeteo.ViewModels;

namespace WebMeteo.Controllers;

public class BollettinoController : Controller
{
    public async Task<IActionResult> Visualizza()
    {
        try
        {
            var bollettino = await RequestBollettino.Richiesta();

            if (bollettino != null)
            {
                BollettinoVisualizzaViewModels vm = new BollettinoVisualizzaViewModels(bollettino);
                return View(vm);
            }
            else
            {
                return View("errore");
            }
            
        }
        catch (Exception e)
        {
            return View("errore");
        }
    }
}