using MeteoServizi;
using Microsoft.AspNetCore.Mvc;

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
                return View(bollettino);
            }
            else
            {
                return NotFound();
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}