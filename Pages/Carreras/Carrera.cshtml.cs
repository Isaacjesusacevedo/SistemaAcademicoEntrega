using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class CarreraModel : PageModel
    {
        public List<Carrera> ListaMostrarCarrera;
        private readonly ServicioCarrera ServicioCarreras;
        public CarreraModel()
        {
            IAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            IRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            ServicioCarreras = new ServicioCarrera(repo);
        }
        public void OnGet()
        {
            ListaMostrarCarrera = ServicioCarreras.ObtenerTodos();
        }

    }
}