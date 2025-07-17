using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Alumnos
{
    public class DeleteAlumnoModel : PageModel
    {
        [BindProperty]
        public Alumno Alumnos { get; set; }
        private readonly ServicioAlumno Servicio;
        public DeleteAlumnoModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicio = new ServicioAlumno(repo);
        }

        public IActionResult OnGet(int id)
        {
            var alumno = Servicio.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("/Alumnos/Alumno");
            }

            Alumnos = alumno;
            return Page();
        }

        public IActionResult OnPost()
        {
            Servicio.EliminarPorId(Alumnos.Id);

            return RedirectToPage("/Alumnos/Alumno");
        }
    }
}