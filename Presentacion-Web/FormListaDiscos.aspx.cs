using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace Presentacion_Web
{
    public partial class FormListaDiscos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DiscoData discoData = new DiscoData();

            DGVListaDiscos.DataSource = discoData.listarSP();
            DGVListaDiscos.DataBind();

            if (!IsPostBack)
            {
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
    }
}