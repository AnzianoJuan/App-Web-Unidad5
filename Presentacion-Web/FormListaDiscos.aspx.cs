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

        }
    }
}