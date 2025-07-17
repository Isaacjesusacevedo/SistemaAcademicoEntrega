using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class DeleteCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public IActionResult OnGet(int id)
        {
            var carrera = ServicioCarrera.BuscarPorId(id);
            if (carrera == null)
            {
                return RedirectToPage("/Carreras/Carrera");
            }

            CarreraCur = carrera;
            return Page();
        }

        public IActionResult OnPost()
        {
            ServicioCarrera.EliminarPorId(CarreraCur.Id);
            return RedirectToPage("/Carreras/Carrera");
        }
    }
}