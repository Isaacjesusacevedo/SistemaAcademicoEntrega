using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class DeleteCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        private readonly ServicioCarrera ServicioCarreras;

        public DeleteCarreraModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            ServicioCarreras = new ServicioCarrera(repo);
        }
        public IActionResult OnGet(int id)
        {
            var carrera = ServicioCarreras.BuscarPorId(id);

            if (carrera == null)
            {
                return RedirectToPage("/Carreras/Carrera");
            }

            CarreraCur = carrera;
            return Page();
        }

        public IActionResult OnPost()
        {
            ServicioCarreras.EliminarPorId(CarreraCur.Id);

            return RedirectToPage("/Carreras/Carrera");
        }
    }
}