using MongoDB.Bson;

namespace MongoRepository.Trabajo
{
    public class Trabajo
    {
        public ObjectId Id { get; set; }
        public string Carga { get; set; }
        public int Peso { get; set; }
        public string Destino { get; set; }
        public int Distancia { get; set; }
        public double IngresosDeTrabajo { get; set; }
        public string Tiempo { get; set; }
        public string Imagen { get; set; }
    }
}
