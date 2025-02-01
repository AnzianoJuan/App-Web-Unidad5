using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion_Web
{
    public partial class FormListaDiscos : System.Web.UI.Page
    {
        public bool FiltroAvanzado
        {
            get
            {
                return ViewState["FiltroAvanzado"] != null && (bool)ViewState["FiltroAvanzado"];
            }
            set
            {
                ViewState["FiltroAvanzado"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DiscoData discoData = new DiscoData();
                Session["ListaDiscos"] = discoData.listarSP();

                DGVListaDiscos.DataSource = Session["ListaDiscos"];
                DGVListaDiscos.DataBind();

                FiltroAvanzado = CheckBoxFiltroAvanzado.Checked;

                // Inicializar ddlCriterio si está disponible
                ddlCriterio = FindControl("ddlCriterio") as DropDownList;
            }
        }

        protected void DGVListaDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = DGVListaDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormAgregarDisco.aspx?id=" + id);
        }

        protected void FiltroTextbox_TextChanged(object sender, EventArgs e)
        {
            if (Session["ListaDiscos"] == null)
                return;

            List<Disco> listaDiscos = (List<Disco>)Session["ListaDiscos"];
            List<Disco> listaFiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(FiltroTextbox.Text.ToUpper()));

            DGVListaDiscos.DataSource = listaFiltrada;
            DGVListaDiscos.DataBind();
        }

        protected void CheckBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = CheckBoxFiltroAvanzado.Checked;
            txtBoxFiltroAvanzado.Enabled = FiltroAvanzado;
        }

        protected void DDLCAMPOasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Intentar encontrar el control en caso de que sea nulo
            if (ddlCriterio == null)
            {
                ddlCriterio = FindControl("ddlCriterio") as DropDownList;
            }

            // Verificar nuevamente después de la asignación
            if (ddlCriterio == null)
            {
                Debug.WriteLine("ddlCriterio sigue siendo NULL. No se puede modificar.");
                return;
            }

            // Limpiar los elementos existentes de ddlCriterio
            ddlCriterio.Items.Clear();

            if (DDLCAMPOasp.SelectedItem != null)
            {
                string seleccion = DDLCAMPOasp.SelectedItem.ToString().Trim();

                if (seleccion == "Estilo")
                {
                    ddlCriterio.Items.Add("Comienza Con");
                    ddlCriterio.Items.Add("Termina Con");
                    ddlCriterio.Items.Add("Contiene");
                }
                else if (seleccion == "Titulo")
                {
                    ddlCriterio.Items.Add("Comienza Con");
                    ddlCriterio.Items.Add("Termina Con");
                    ddlCriterio.Items.Add("Contiene");
                }
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                DiscoData discoData = new DiscoData();
                DGVListaDiscos.DataSource = discoData.filtrar(DDLCAMPOasp.SelectedItem.ToString(),ddlCriterio.SelectedItem.ToString(), txtBoxFiltroAvanzado.Text);
                DGVListaDiscos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}
