using Dominio;
using System.Collections.Generic;

namespace Contrato
{
    public interface IConductorRepository
    {
        List<Conductor> ObtenerConductores();

        Conductor ObtenerConductorPorId(int id);

        IEnumerable<Conductor> ObtenerConductorPorNombre(string nombre);

        Conductor GuardarConductor(Conductor conductor);

        void EditarConductor(Conductor conductor);

        void EliminarConductor(Conductor conductor);
    }
}
