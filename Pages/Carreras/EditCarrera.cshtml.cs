using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Helpers;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class EditCarreraModel : PageModel
    {
        [BindProperty]
        public Carrera CarreraCur { get; set; }
        public List<string> Modalidades = new List<string>();
        private readonly ServicioCarrera ServicioCarreras;

        public EditCarreraModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            ServicioCarreras = new ServicioCarrera(repo);
        }
        public void OnGet(int id)
        {
            Modalidades = OpcionesModalidad.lista;

            Carrera? carrera = ServicioCarreras.BuscarPorId(id);

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

            ServicioCarreras.Editar(CarreraCur);

            return RedirectToPage("/Carreras/Carrera");
        }

    }
}