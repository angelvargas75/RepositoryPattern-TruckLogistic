using Contrato;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace MongoRepository.Trabajo
{
    public class TrabajoRepository : BaseRepository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(string nombreColeccion = "Trabajo") : base(nombreColeccion)
        {
        }


        public List<Dominio.Trabajo> ObtenerTrabajos()
        {
            var config = new AutoMapper.MapperConfiguration(
               cf => cf.CreateMap<Trabajo, Dominio.Trabajo>());
            var mapper = new AutoMapper.Mapper(config);

            ConectarDb();
            return ObtenerTodos().Select(c => mapper.Map<Dominio.Trabajo>(c)).ToList();
        }

        public Dominio.Trabajo ObtenerTrabajoPorId(ObjectId id)
        {
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<Trabajo, Dominio.Trabajo>());
            var mapper = new AutoMapper.Mapper(config);

            ConectarDb();
            var art = ObtenerPorId(id);
            return mapper.Map<Dominio.Trabajo>(art);
        }

        public void GuardarTrabajo(Dominio.Trabajo trabajo)
        {
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<Dominio.Trabajo, Trabajo>());
            var mapper = new AutoMapper.Mapper(config);
            Trabajo trab = mapper.Map<Trabajo>(trabajo);

            ConectarDb();
            Insertar(trab);
        }

        public void EditarTrabajo(Dominio.Trabajo trabajo)
        {
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<Dominio.Trabajo, Trabajo>());
            var mapper = new AutoMapper.Mapper(config);
            Trabajo trab = mapper.Map<Trabajo>(trabajo);

            ConectarDb();
            Actualizar(trab);
        }

        public void EliminarTrabajo(ObjectId id)
        {
            ConectarDb();
            Eliminar(id);
        }
    }
}
