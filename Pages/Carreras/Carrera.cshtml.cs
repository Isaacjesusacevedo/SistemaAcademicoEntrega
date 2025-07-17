using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademicoEntrega.Data;
using SistemaAcademicoEntrega.Models;

namespace SistemaAcademicoEntrega.Pages.Carreras
{
    public class CarreraModel : PageModel
    {
        public List<Carrera> ListaMostrarCarrera;
        public void OnGet()
        {
            ListaMostrarCarrera = DatosCompartidos.ListCarreras;
        }
    }
}