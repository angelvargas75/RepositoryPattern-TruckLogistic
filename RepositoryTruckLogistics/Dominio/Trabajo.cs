using MongoDB.Bson;

namespace Dominio
{
    public class Trabajo
    {
        public ObjectId Id { get; set; }
        public string Carga { get; set; }
        public int Peso { get; set; }
        public string Destino { get; set; }
        public int Distancia { get; set; }
        public decimal? IngresosDeTrabajo { get; set; }
        public string Tiempo { get; set; }
        public string Imagen { get; set; }
    }
}
