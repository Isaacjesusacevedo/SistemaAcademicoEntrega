using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Helpers;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class CreateCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public List<string> Modalidades { get; set; } = new List<string>();
        private readonly ServicioCarrera ServicioCarreras;

        public CreateCarreraModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            ServicioCarreras = new ServicioCarrera(repo);
        }
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

            ServicioCarreras.Agregar(CarreraCur);

            return RedirectToPage("/Carreras/Carrera");
        }
    }
}