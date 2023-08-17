using Contrato;
using ServicioRepository.Camion;
using SqlRepository.Conductor;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ClienteWeb.Mantenimiento
{
    public partial class Conductor : System.Web.UI.Page
    {
        private IConductorRepository conductorRepository;
        private ICamionRepository camionRepository;

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

        public ICamionRepository CamionRepository
        {
            get
            {
                if (camionRepository == null)
                    camionRepository = new CamionRepository();

                return camionRepository;
            }
            set
            {
                camionRepository = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InitData();
        }
        private void InitData()
        {
            var datos = ObtenerConductores();
            dgvConductor.DataSource = datos;
            dgvConductor.DataBind();
        }
        public List<Dominio.Conductor> ObtenerConductores()
        {
            var res = ConductorRepository.ObtenerConductores();
            return res;
        }


        protected void dgvConductor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ConfirmarEliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Dominio.Conductor objConductor = new Dominio.Conductor { Id = id };

                ConductorRepository.EliminarConductor(objConductor);
                CamionRepository.EliminarCamion(id);

                InitData();
            }
        }
    }
}