using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace Presentacion_Web
{
    public partial class FormListaDiscos : System.Web.UI.Page
    {

        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            DiscoData discoData = new DiscoData();

            Session.Add("ListaDiscos",discoData.listarSP());

            DGVListaDiscos.DataSource = Session["ListaDiscos"];
            DGVListaDiscos.DataBind();

            if (!IsPostBack)
            {
                FiltroAvanzado = CheckBoxFiltroAvanzado.Checked;

                if (Session["ListaDiscos"] == null)
                {
                    DiscoData negocio = new DiscoData();
                    
                    Session.Add("ListaDiscos", negocio.listarSP());
                }
            }

        }

        protected void DGVListaDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = DGVListaDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormAgregarDisco.aspx?id=" + id);
        }

        protected void DGVListaDiscos_PageIndexChanged(object sender, EventArgs e)
        {
        }

        protected void FiltroTextbox_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaDiscos = (List<Disco>)Session["ListaDiscos"];
            List<Disco> listaFiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(FiltroTextbox.Text.ToUpper()));
            DGVListaDiscos.DataSource = listaFiltrada;
            DGVListaDiscos.DataBind();
        }

        protected void CheckBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {

            FiltroAvanzado = CheckBoxFiltroAvanzado.Checked;
            txtBoxFiltroAvanzado.Enabled = !FiltroAvanzado;



        }

        protected void DDLCAMPOasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLCAMPOasp.Items.Clear();

            if (DDLCAMPOasp.SelectedItem.ToString() == "Cantidad de canciones ")
            {

                ddlCriterio.Items.Add("Igual a ");
                ddlCriterio.Items.Add("Mayor a ");
                ddlCriterio.Items.Add("Menor a ");
            }
            else if (DDLCAMPOasp.SelectedItem.ToString() == "Titulo ")
            {
                ddlCriterio.Items.Add("Contiene ");
                ddlCriterio.Items.Add("Comienza con ");
                ddlCriterio.Items.Add("Termina con ");
            }
        }
    }
}