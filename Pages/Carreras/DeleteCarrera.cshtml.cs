using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Models;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class DeleteCarreraModel : PageModel
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
            Carrera eliminarCarrera = null;

            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == CarreraCur.Id)
                {
                    eliminarCarrera = carrera;
                    break;
                }
            }

            if (eliminarCarrera != null)
            {
                DatosCompartidos.ListCarreras.Remove(eliminarCarrera);
            }

            return RedirectToPage("/Carreras/Carrera");
        }
    }
}