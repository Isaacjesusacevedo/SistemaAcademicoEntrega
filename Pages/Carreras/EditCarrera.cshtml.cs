using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Models;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class EditCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public void OnGet(int id)
        {
            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == id)
                {
                    CarreraCur = carrera;
                    break;
                }
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == CarreraCur.Id)
                {
                    carrera.Nombre = CarreraCur.Nombre;
                    carrera.Modalidad = CarreraCur.Modalidad;
                    carrera.DuracionAnios = CarreraCur.DuracionAnios;
                    carrera.TituloOtorgado = CarreraCur.TituloOtorgado;
                    break;
                }
            }
            return RedirectToPage("/Carreras/Carrera");
        }

    }
}