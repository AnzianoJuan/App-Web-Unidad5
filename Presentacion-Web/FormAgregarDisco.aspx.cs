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
    public partial class FormAgregarDisco : System.Web.UI.Page
    {
        public string UrlImagenTapa { get; set; }

        public string ImageAltas { get; set; } = "https://static.vecteezy.com/system/resources/previews/005/720/408/non_2x/crossed-image-icon-picture-not-available-delete-picture-symbol-free-vector.jpg";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listarDropDownListDB();

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());

                        List<Disco> temporal = (List<Disco>)Session["ListaDiscos"];
                        Disco seleccionado = temporal.Find(x => x.Id == id);

                        if (seleccionado != null)
                        {
                            TextBoxTitulo.Text = seleccionado.Titulo;
                            TextBoxId.Text = seleccionado.Id.ToString();
                            TextBoxCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                            TextBoxUrlImagenTapa.Text = seleccionado.UrlImagenTapa;

                            // Preselecciona el valor correspondiente en los dropdowns

                            Estilo estiloVar = seleccionado.Estilo;  
                            DropDownListEstilo.SelectedValue = estiloVar.Id.ToString();

                            Edicion edicionVar = seleccionado.Edicion;
                            DropDownListEdicion.SelectedValue = edicionVar.Id.ToString();

                            TextBoxId.ReadOnly = true;
                            ButtonAgregarDisco.Enabled = false;
                        }
                    }
                    else
                    {
                        ButtonModificarDisco.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
        public void listarDropDownListDB()
        {
            DiscoData data = new DiscoData();

            // Carga los estilos
            DropDownListEstilo.DataSource = data.listarEstilos(); 
            DropDownListEstilo.DataTextField = "Descripcion"; 
            DropDownListEstilo.DataValueField = "Id"; 
            DropDownListEstilo.DataBind();

            // Agregar un elemento inicial
            DropDownListEstilo.Items.Insert(0, new ListItem("Seleccione un estilo", "0"));

            // Carga las ediciones
            DropDownListEdicion.DataSource = data.listarEdiciones(); 
            DropDownListEdicion.DataTextField = "Descripcion"; 
            DropDownListEdicion.DataValueField = "Id"; 
            DropDownListEdicion.DataBind();

            // Agregar un elemento inicial
            DropDownListEdicion.Items.Insert(0, new ListItem("Seleccione una edición", "0"));
        }

        protected void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            UrlImagenTapa = TextBoxUrlImagenTapa.Text;
        }

        protected void TextBoxUrlImagenTapa_TextChanged(object sender, EventArgs e)
        {
            UrlImagenTapa = TextBoxUrlImagenTapa.Text;
        }
    }
}