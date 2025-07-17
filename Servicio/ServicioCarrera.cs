using SistemaAcademicoEntrega.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace SistemaAcademicoEntrega.Servicio
{
    public class ServicioCarrera
    {
        private static string path = "Data/Carreras.json";

        public static string LeerTextoDelArchivo()
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                return "[]";
            }
        }

        public static List<Carrera> ObtenerCarreras()
        {
            string json = LeerTextoDelArchivo();

            var lista = JsonSerializer.Deserialize<List<Carrera>>(json);

            return lista ?? new List<Carrera>();
        }

        public static void AgregarCarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarreras();

            nuevaCarrera.Id = ObtenerNuevoId(carreras);

            carreras.Add(nuevaCarrera);

            GuardarCarreras(carreras);
        }

        public static void GuardarCarreras(List<Carrera> carreras)
        {
            string json = JsonSerializer.Serialize(carreras);

            File.WriteAllText(path, json);
        }

        public static void EliminarPorId(int id)
        {
            var lista = ObtenerCarreras();
            Carrera? carreraAEliminar = BuscarCarreraPorId(lista, id);

            if (carreraAEliminar != null)
            {
                lista.Remove(carreraAEliminar);
                GuardarCarreras(lista);
            }
        }

        public static void EditarCarrera(Carrera carreraEditada)
        {
            var lista = ObtenerCarreras();
            var carrera = BuscarCarreraPorId(lista, carreraEditada.Id);

            if (carrera != null)
            {
                carrera.Nombre = carreraEditada.Nombre;
                carrera.Modalidad = carreraEditada.Modalidad;
                carrera.DuracionAnios = carreraEditada.DuracionAnios;
                carrera.TituloOtorgado = carreraEditada.TituloOtorgado;
                GuardarCarreras(lista);
            }

        }
        public static Carrera? BuscarPorId(int id)
        {
            var lista = ObtenerCarreras();

            return BuscarCarreraPorId(lista, id);
        }
        private static Carrera? BuscarCarreraPorId(List<Carrera> lista, int id)
        {
            foreach (var carrera in lista)
            {
                if (carrera.Id == id)
                {
                    return carrera;
                }
            }
            return null;
        }
        private static int ObtenerNuevoId(List<Carrera> listaCarreras)
        {
            int lastId = 0;

            foreach (var carrera in listaCarreras)
            {
                if (carrera.Id > lastId)
                {
                    lastId = carrera.Id;
                }
            }

            lastId++;

            return lastId;
        }
    }
}