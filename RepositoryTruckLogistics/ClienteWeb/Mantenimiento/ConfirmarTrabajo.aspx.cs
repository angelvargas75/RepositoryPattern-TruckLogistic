using Contrato;
using MongoDB.Bson;
using MongoRepository.Trabajo;
using SqlRepository.Conductor;
using System;

namespace ClienteWeb.Mantenimiento
{
    public partial class ConfirmarTrabajo : System.Web.UI.Page
    {
        private IConductorRepository conductorRepository;
        private ITrabajoRepository trabajoRepository;

        public IConductorRepository ConductorRepository
        {
            get
            {
                if (conductorRepository == null)
                    conductorRepository = new ConductorRepository();

                return conductorRepository;
            }
            set
            {
                conductorRepository = value;
            }
        }

        public ITrabajoRepository TrabajoRepository
        {
            get
            {
                if (trabajoRepository == null)
                    trabajoRepository = new TrabajoRepository();

                return trabajoRepository;
            }
            set
            {
                trabajoRepository = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idConductor = Convert.ToInt32(Session["IDConductor"]);
                var resCond = ConductorRepository.ObtenerConductorPorId(idConductor);
                lblConductorNombre.Text = resCond.Nombre;
                lblConductorPais.Text = resCond.Pais;

                var idTrabajo = Session["IDTrabajo"].ToString();
                ObjectId id = new ObjectId(idTrabajo);
                var resTrab = TrabajoRepository.ObtenerTrabajoPorId(id);
                lblCarga.Text = resTrab.Carga;
                lblIngresosTrabajo.Text = "€ " + resTrab.IngresosDeTrabajo.ToString();
                lblDestino.Text = resTrab.Destino;
                lblDistancia.Text = resTrab.Distancia.ToString() + " Km";
                lblPeso.Text = resTrab.Peso.ToString() + " t";
                lblTiempo.Text = resTrab.Tiempo;
            }
        }
    }
}