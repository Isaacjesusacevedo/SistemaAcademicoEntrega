using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Helpers;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class CreateCarreraModel : PageModel
    {
        public List<string> Modalidades { get; set; } = new List<string>();

        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public void OnGet()
        {
            Modalidades = OpcionesModalidad.lista;
        }

        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }


            ServicioCarrera.AgregarCarrera(CarreraCur);

            return RedirectToPage("/Carreras/Carrera");
        }
    }
}