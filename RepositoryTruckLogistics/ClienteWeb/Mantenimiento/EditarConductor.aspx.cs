using Contrato;
using ServicioRepository.Camion;
using SqlRepository.Conductor;
using System;

namespace ClienteWeb.Mantenimiento
{
    public partial class EditarConductor : System.Web.UI.Page
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
            ConductorRepository = new ConductorRepository();
            if (!IsPostBack)
                InitData();
        }

        private void InitData()
        {
            var ID = Request.QueryString["Id"];
            Dominio.Conductor empleado = new Dominio.Conductor();

            if (!string.IsNullOrWhiteSpace(ID))
            {
                var empleadoId = Convert.ToInt32(ID);
                var objetoConductor = ConductorRepository.ObtenerConductorPorId(empleadoId);
                var objetoCamion = CamionRepository.ObtenerCamion(empleadoId);
                if (objetoConductor != null)
                {
                    hidCodigoConductor.Value = objetoConductor.Id.ToString();
                    txtNombre.Text = objetoConductor.Nombre;
                    txtPais.Text = objetoConductor.Pais;
                    txtCiudad.Text = objetoConductor.Ciudad;
                    txtTelefono.Text = objetoConductor.Telefono;

                    ddlTipoCarga.SelectedValue = objetoCamion.TipoDeCarga;
                    txtChasis.Text = objetoCamion.Chasis;
                    txtRecuentoEngranajes.Text = objetoCamion.RecuentoDeEngranajes.ToString();
                    if (objetoCamion.Retardero == "Si")
                        rbRetarderoSi.Checked = true;
                    else
                        rbRetarderoNo.Checked = true;
                    txtEjesAlimentados.Text = objetoCamion.EjesAlimentados.ToString();
                    txtPotencia.Text = objetoCamion.PotenciaDelMotor.ToString();
                    txtTorque.Text = objetoCamion.EsfuerzoDeTorsion.ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int codigo = !string.IsNullOrEmpty(hidCodigoConductor.Value) ? Convert.ToInt32(hidCodigoConductor.Value) : 0;

            Dominio.Conductor conductor = new Dominio.Conductor();
            conductor.Id = codigo;
            conductor.Nombre = txtNombre.Text.Trim();
            conductor.Pais = txtPais.Text.Trim();
            conductor.Ciudad = txtCiudad.Text.Trim();
            conductor.Telefono = txtTelefono.Text.Trim();

            Dominio.Camion camion = new Dominio.Camion();
            camion.Id = codigo;
            camion.TipoDeCarga = ddlTipoCarga.SelectedValue;
            camion.Chasis = txtChasis.Text.Trim();
            camion.RecuentoDeEngranajes = Convert.ToInt32(txtRecuentoEngranajes.Text.Trim());
            camion.Retardero = rbRetarderoSi.Checked ? rbRetarderoSi.Text : rbRetarderoNo.Text;
            camion.EjesAlimentados = Convert.ToInt32(txtEjesAlimentados.Text.Trim());
            camion.PotenciaDelMotor = Convert.ToInt32(txtPotencia.Text.Trim());
            camion.EsfuerzoDeTorsion = Convert.ToInt32(txtTorque.Text.Trim());

            if (codigo > 0) //Edicion
            {
                ConductorRepository.EditarConductor(conductor);
                CamionRepository.EditarCamion(camion);
            }
            else //Nuevo
            {
                var retorno = ConductorRepository.GuardarConductor(conductor);
                conductor.Id = retorno.Id;
                camion.Id = retorno.Id;

                var datosCamnion = CamionRepository.GuardarCamion(camion);
            }

            Response.Redirect("~/Mantenimiento/Conductor");
        }
    }
}