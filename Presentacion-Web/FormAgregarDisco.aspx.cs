using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Presentacion_Web
{
    public partial class FormAgregarDisco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                List<Disco> temporal = (List<Disco>)Session["ListaDiscos"];
                Disco seleccionado = temporal.Find(x => x.Id == id);

                TextBoxTitulo.Text = seleccionado.Titulo;
                TextBoxId.Text = seleccionado.Id.ToString();
                TextBoxCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                TextBoxUrlImagenTapa.Text = seleccionado.UrlImagenTapa;


                TextBoxId.ReadOnly = true;
                ButtonAgregarDireccion.Enabled = false;
            }
            else if (Request.QueryString["id"] == null)
            {
                ButtonModificarDireccion.Enabled = false;
            }
        }
    }
}