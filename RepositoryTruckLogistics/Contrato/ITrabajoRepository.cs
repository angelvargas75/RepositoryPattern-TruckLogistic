using Dominio;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Contrato
{
    public interface ITrabajoRepository
    {
        List<Trabajo> ObtenerTrabajos();

        Trabajo ObtenerTrabajoPorId(ObjectId id);

        void GuardarTrabajo(Trabajo trabajo);

        void EditarTrabajo(Trabajo trabajo);

        void EliminarTrabajo(ObjectId id);
    }
}
