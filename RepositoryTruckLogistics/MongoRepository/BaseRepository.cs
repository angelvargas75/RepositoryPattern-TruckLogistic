using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MongoRepository
{
    public class BaseRepository<T>
        where T : class
    {
        private readonly string _nombreColeccion;
        private IMongoDatabase database;

        public BaseRepository(string nombreColeccion)
        {
            _nombreColeccion = nombreColeccion;
        }

        public void ConectarDb()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            database = client.GetDatabase("TruckWorks");
        }

        public void Insertar(T entidad)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            coleccion.InsertOne(entidad);
        }

        public void Eliminar(ObjectId id)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            var filtro = Builders<T>.Filter.Eq("_id", id);

            coleccion.DeleteOne(filtro);
        }

        public IQueryable<T> ObtenerTodos()
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            var cursor = coleccion.Find(new BsonDocument()).ToEnumerable();
            return cursor.AsQueryable();
        }

        public T ObtenerPorId(ObjectId id)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            var filtro = Builders<T>.Filter.Eq("_id", id);

            return coleccion.Find(filtro).FirstOrDefault();
        }


        public void Actualizar(T entidad)
        {
            var coleccion = database.GetCollection<T>(_nombreColeccion);
            var filtro = Builders<T>.Filter.Eq("_id", ObtenerIdEntidad(entidad));
            var actualizaciones = new List<UpdateDefinition<T>>();

            // aplicando la Reflexion en C# - System.Reflection
            // la reflexión es una capacidad de los lenguajes de programación que permite examinar y manipular
            // los tipos de datos en tiempo de ejecución, proporcionando acceso a la estructura y metadatos de
            // los tipos y permitiendo realizar operaciones dinámicas en ellos. incluso si no tienes conocimiento
            // estático de ellos en tiempo de compilación.
            var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.Name != "Id");

            foreach (var propiedad in propiedades)
            {
                var valor = propiedad.GetValue(entidad);
                var actualizacion = Builders<T>.Update.Set(propiedad.Name, valor);
                actualizaciones.Add(actualizacion);
            }

            var update = Builders<T>.Update.Combine(actualizaciones);
            coleccion.UpdateOne(filtro, update);
        }
        private ObjectId ObtenerIdEntidad(T entidad)
        {
            var propiedadId = typeof(T).GetProperty("Id");
            return (ObjectId)propiedadId.GetValue(entidad);
        }
    }
}
