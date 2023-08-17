using System.ServiceModel;

namespace ServicioWcfCamion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicioWCFCamion
    {
        [OperationContract]
        Dominio.Camion Get(int id);

        [OperationContract]
        bool Insert(Dominio.Camion datos);

        [OperationContract]
        bool Update(Dominio.Camion datos);

        [OperationContract]
        bool Delete(int id);
    }
}
