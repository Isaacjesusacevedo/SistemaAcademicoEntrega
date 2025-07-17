using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Alumnos
{
    public class CreateAlumnoModel : PageModel
    {
        [BindProperty]
        public Alumno Alumnos { get; set; }
        private readonly ServicioAlumno Servicio;
        public CreateAlumnoModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicio = new ServicioAlumno(repo);
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Servicio.Agregar(Alumnos);

            return RedirectToPage("/Alumnos/Alumno");
        }
    }
}