using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;
namespace SistemaAcademicoEntrega.Pages.Alumnos
{
    public class AlumnoModel : PageModel
    {
        public List<Alumno> listaAlumnosMotrar;
        private readonly ServicioAlumno Servicio;
        public AlumnoModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicio = new ServicioAlumno(repo);
        }
        public void OnGet()
        {
            listaAlumnosMotrar = Servicio.ObtenerTodos();
        }
    }
}