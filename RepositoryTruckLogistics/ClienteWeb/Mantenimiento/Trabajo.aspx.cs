using Contrato;
using MongoRepository.Trabajo;
using SqlRepository.Conductor;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWeb.Mantenimiento
{
    public partial class Trabajo : System.Web.UI.Page
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
                BindCarouselData();
            }
        }

        protected void BindCarouselData()
        {
            List<Dominio.Trabajo> trabajos = TrabajoRepository.ObtenerTrabajos();
            carouselListView.DataSource = trabajos;
            carouselListView.DataBind();
        }
        public string GetActiveClass(int itemIndex)
        {
            if (itemIndex == 0)
            {
                return "carousel-item active";
            }
            else
            {
                return "carousel-item";
            }
        }


        public IEnumerable<Dominio.Conductor> ObtenerConductor()
        {
            var filtroPorNombre = txtFiltroNombre.Value;
            var conductor = ConductorRepository.ObtenerConductorPorNombre(filtroPorNombre);

            return conductor;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var conductor = ObtenerConductor();
            int id = 0;
            if (conductor != null)
            {
                foreach (var item in conductor)
                {
                    id = item.Id;
                    lblNombre.Text = item.Nombre;
                    lblOrigen.Text = item.Pais;
                }
            }

            Session["IDConductor"] = id.ToString();
        }


        protected void carouselListView_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Control btnNext = carouselListView.FindControl("btnNext");
                Control btnPrev = carouselListView.FindControl("btnPrev");

                if (btnNext != null && btnPrev != null)
                {
                    string nextButtonId = btnNext.ClientID;
                    string prevButtonId = btnPrev.ClientID;

                    ScriptManager.RegisterStartupScript(this, GetType(), "InitSwiper", $"initSwiper('{nextButtonId}', '{prevButtonId}');", true);
                }
            }
        }

        protected void carouselListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            // Evita que el evento SelectedIndexChanging realice el cambio de índice
            e.Cancel = true;
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            LinkButton btnSeleccionar = (LinkButton)sender;
            string idSeleccionado = btnSeleccionar.CommandArgument;
            Session["IDTrabajo"] = idSeleccionado;
            var idConductor = Convert.ToInt32(Session["IDConductor"]);

            if (!string.IsNullOrEmpty(idSeleccionado) && idConductor > 0)
            {
                Response.Redirect($"ConfirmarTrabajo.aspx");
            }
        }
    }
}