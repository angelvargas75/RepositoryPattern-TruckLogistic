using Contrato;
using System.Collections.Generic;
using System.Linq;

namespace SqlRepository.Conductor
{
    public class ConductorRepository : BaseRepository<Conductor>, IConductorRepository
    {
        public void EliminarConductor(Dominio.Conductor conductor)
        {
            /* Aquí se realiza una conversión de tipo indirecta utilizando object como intermediario.Sin embargo,
               tener en cuenta que esta solución solo funcionará si las estructuras y propiedades de ambos tipos son 
               idénticas. */
            //var emp = (SqlRepository.Conductor.Conductor)(object) conductor; 

            Conductor cond = new Conductor { Id = conductor.Id };
            Eliminar(cond);
        }

        public Dominio.Conductor GuardarConductor(Dominio.Conductor conductor)
        {
            var config = new AutoMapper.MapperConfiguration(
                 cf => cf.CreateMap<Dominio.Conductor, SqlRepository.Conductor.Conductor>());
            var mapper = new AutoMapper.Mapper(config);
            Conductor cond = mapper.Map<Conductor>(conductor);
            var conductorGuardado = Insertar(cond);
            Dominio.Conductor conductorId = new Dominio.Conductor();
            conductorId.Id = conductorGuardado.Id;
            return conductorId;
        }

        public void EditarConductor(Dominio.Conductor conductor)
        {
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<Dominio.Conductor, SqlRepository.Conductor.Conductor>());
            var mapper = new AutoMapper.Mapper(config);
            Conductor cond = mapper.Map<Conductor>(conductor);
            Actualizar(cond);
        }

        public Dominio.Conductor ObtenerConductorPorId(int id)
        {
            var conductor = ObtenerPorId(id);
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<SqlRepository.Conductor.Conductor, Dominio.Conductor>());
            var mapper = new AutoMapper.Mapper(config);
            Dominio.Conductor cond = mapper.Map<Dominio.Conductor>(conductor);
            return cond;
        }

        public IEnumerable<Dominio.Conductor> ObtenerConductorPorNombre(string nombre)
        {
            var conductor = ObtenerPorNombre(c => c.Nombre.Contains(nombre));
            if (conductor == null || !conductor.Any())
            {
                return null;
            }
            return conductor.Select(c => new Dominio.Conductor
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Pais = c.Pais
            });
        }

        public List<Dominio.Conductor> ObtenerConductores()
        {
            var config = new AutoMapper.MapperConfiguration(
                cf => cf.CreateMap<SqlRepository.Conductor.Conductor, Dominio.Conductor>());
            var mapper = new AutoMapper.Mapper(config);
            return new List<Dominio.Conductor>(
                ObtenerTodos()
                .AsEnumerable()
                .Select(mapper.Map<Dominio.Conductor>)).ToList();
        }
    }
}
