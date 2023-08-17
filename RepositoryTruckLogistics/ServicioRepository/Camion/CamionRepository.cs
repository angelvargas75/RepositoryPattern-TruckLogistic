using Contrato;

namespace ServicioRepository.Camion
{
    public class CamionRepository : BaseRepository<Dominio.Camion>, ICamionRepository
    {
        public Dominio.Camion ObtenerCamion(int id)
        {
            var retorno = ObtenerPorId(id);
            return retorno;
        }

        public bool GuardarCamion(Dominio.Camion camion)
        {
            var retorno = Insertar(camion);
            return retorno;
        }

        public bool EditarCamion(Dominio.Camion camion)
        {
            var retorno = Actualizar(camion);
            return retorno;
        }

        public bool EliminarCamion(int id)
        {
            var retorno = Eliminar(id);
            return retorno;
        }
    }
}
