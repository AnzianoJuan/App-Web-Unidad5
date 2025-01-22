using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Presentacion_Web
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Disco> ListaDisco { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoData discoData = new DiscoData();
            ListaDisco = discoData.listarSP();

            if (!IsPostBack)
            {
                RepRepetidor.DataSource = ListaDisco;
                RepRepetidor.DataBind();
                if (!IsPostBack)
                {
                    if (Session["ListaDiscos"] == null)
                    {
                        DiscoData negocio = new DiscoData();
                        Session.Add("ListaDiscos", negocio.listarSP());
                    }
                }
            }
        }

        protected void BtnRepeater_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}