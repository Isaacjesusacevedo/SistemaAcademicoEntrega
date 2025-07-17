using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Models;
using SistemaAcademicoEntrega.Data;

namespace SistemaAcademicoEntrega.Pages.Alumnos
{
    public class AlumnoModel : PageModel
    {
            public List<Alumno> listaAlumnosMotrar = new List<Alumno>();
            public void OnGet()
            {
                listaAlumnosMotrar = DatosCompartidos.ListaAlumnos;
            }
    }
}