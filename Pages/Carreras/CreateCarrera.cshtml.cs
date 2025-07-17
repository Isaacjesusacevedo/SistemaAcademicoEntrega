using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Models;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class CreateCarreraModel : PageModel

    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public void OnGet() { }

        public static int ultimoId = 0;

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            CarreraCur.Id = DatosCompartidos.ObtenerNuevoCarreraId();
            DatosCompartidos.ListCarreras.Add(CarreraCur);
            return RedirectToPage("/Carreras/Carrera");
        }
    }
}