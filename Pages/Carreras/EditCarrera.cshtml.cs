using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Helpers;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class EditCarreraModel : PageModel
    {
        public List<string> Modalidades = new List<string>();
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public void OnGet(int id)
        {
            Modalidades = OpcionesModalidad.lista;

            Carrera? carrera = ServicioCarrera.BuscarPorId(id);
            if (carrera != null)
            {
                CarreraCur = carrera;
            }
        }
        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ServicioCarrera.EditarCarrera(CarreraCur);

            return RedirectToPage("/Carreras/Carrera");
        }

    }
}