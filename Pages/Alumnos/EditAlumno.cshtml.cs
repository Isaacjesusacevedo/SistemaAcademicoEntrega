using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.AccesoDatos;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Repositorio;
using SistemaAcademicoEntrega.Servicio;

namespace SistemaAcademicoEntrega.Pages.Alumnos
{
    public class EditAlumnoModel : PageModel
    {
        [BindProperty]
        public Alumno Alumnos { get; set; }
        private readonly ServicioAlumno Servicio;
        public EditAlumnoModel()
        {
            IAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            IRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicio = new ServicioAlumno(repo);
        }
        public void OnGet(int id)
        {
            Alumno? alumno = Servicio.BuscarPorId(id);

            if (alumno != null)
            {
                Alumnos = alumno;
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Servicio.Editar(Alumnos);

            return RedirectToPage("/Alumnos/Alumno");
        }
    }
}