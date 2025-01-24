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

        protected void Page_Load(object sender, EventArgs e)
        {

            // pantalla inicial del formulario

            TextBoxId.Enabled = true;

            try
            {
                if (!IsPostBack)
                {
                    listarDropDownListDB();
                }
                //configuracion si estamos modificando
                if (Request.QueryString["id"] != null) { 
                
                    DiscoData discoData = new DiscoData();

                    List<Disco> lista = discoData.listar(Request.QueryString["id"].ToString());
                    Disco seleccionado = lista[0];


                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }

        }
        public void listarDropDownListDB()
        {

            EstiloData estiloData = new EstiloData();
            List<Estilo> listaEstilos = estiloData.listar();

            DropDownListEstilo.DataSource = listaEstilos;
            DropDownListEstilo.DataValueField = "id";
            DropDownListEstilo.DataTextField = "Descripcion";
            DropDownListEstilo.DataBind();

            EdicionData edicionData = new EdicionData();
            List<Edicion> listaEdicion = edicionData.listar();

            DropDownListEdicion.DataSource = listaEdicion;
            DropDownListEdicion.DataValueField = "id";
            DropDownListEdicion.DataTextField = "Descripcion";
            DropDownListEdicion.DataBind();
        }

        protected void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            UrlImagenTapa = TextBoxUrlImagenTapa.Text;
        }

        protected void TextBoxUrlImagenTapa_TextChanged(object sender, EventArgs e)
        {   
            UrlImagenTapa = TextBoxUrlImagenTapa.Text;
        }

        protected void ButtonAgregarDisco_Click(object sender, EventArgs e)
        {
            try
            {

                DiscoData discoData = new DiscoData();
                Disco discoNuevo = new Disco();

                discoNuevo.Id = int.Parse(TextBoxId.Text);
                discoNuevo.Titulo = TextBoxTitulo.Text;
                discoNuevo.CantidadCanciones = int.Parse(TextBoxCantidadCanciones.Text);
                discoNuevo.UrlImagenTapa = TextBoxUrlImagenTapa.Text;

                discoNuevo.Edicion = new Edicion();
                discoNuevo.Edicion.Id = int.Parse(DropDownListEdicion.SelectedValue);

                discoNuevo.Estilo = new Estilo();
                discoNuevo.Estilo.Id = int.Parse(DropDownListEstilo.SelectedValue);

                discoData.agregarDisco(discoNuevo);
                Response.Redirect("FormListaDiscos.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }
        }
    }
}