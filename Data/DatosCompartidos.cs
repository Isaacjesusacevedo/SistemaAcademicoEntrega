using SistemaAcademicoEntrega.Models;

namespace SistemaAcademicoEntrega.Data
{
    public static class DatosCompartidos
    {
        public static List<Carrera> ListCarreras = new List<Carrera>();
        private static int _ultimoCarreaId = 0;
        public static int ObtenerNuevoCarreraId()
        {
            _ultimoCarreaId++;
            return _ultimoCarreaId;
        }
    }
}