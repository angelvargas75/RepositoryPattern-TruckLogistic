using Dominio;

namespace Contrato
{
    public interface ICamionRepository
    {
        Camion ObtenerCamion(int id);

        bool GuardarCamion(Camion camion);

        bool EliminarCamion(int id);

        bool EditarCamion(Camion camion);
    }
}
