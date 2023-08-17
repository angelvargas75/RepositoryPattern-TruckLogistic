namespace ServicioRepository
{
    public class BaseRepository<T> 
        where T : class
    {
        ServiceReference1.ServicioWCFCamionClient servicio = new ServiceReference1.ServicioWCFCamionClient();


        public T ObtenerPorId(int id)
        {
            Dominio.Camion retorno = servicio.Get(id);
            Dominio.Camion camion = new Dominio.Camion();
            if (retorno != null)
            {
                camion.Id = id;
                camion.TipoDeCarga = retorno.TipoDeCarga;
                camion.Chasis = retorno.Chasis;
                camion.RecuentoDeEngranajes = retorno.RecuentoDeEngranajes;
                camion.Retardero = retorno.Retardero;
                camion.EjesAlimentados = retorno.EjesAlimentados;
                camion.PotenciaDelMotor = retorno.PotenciaDelMotor;
                camion.EsfuerzoDeTorsion = retorno.EsfuerzoDeTorsion;
            }
            return camion as T;
        }

        public bool Insertar(T datos)
        {
            return servicio.Insert(datos as Dominio.Camion);
        }

        public bool Actualizar(T datos)
        {
            return servicio.Update(datos as Dominio.Camion);
        }

        public bool Eliminar(int id)
        {
            return servicio.Delete(id);
        }
    }
}
