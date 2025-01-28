using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            // pantalla inicial del formulario

            ConfirmaEliminacion = false;

            try
            {
                if (!IsPostBack)
                {
                    DivConfirmaEliminacion.Visible = ConfirmaEliminacion;
                    listarDropDownListDB();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                //configuracion si estamos modificando
                if (id != "" && !(IsPostBack))
                {
                    DiscoData discoData = new DiscoData();

                    Disco seleccionado = ((discoData.listar(id)[0]));

                    //Precargar los campos 
                    DivTextBoxId.Visible = false;

                    TextBoxId.Text = id;
                    TextBoxTitulo.Text = seleccionado.Titulo;
                    TextBoxUrlImagenTapa.Text = seleccionado.UrlImagenTapa;
                    TextBoxCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();

                    DropDownListEdicion.SelectedValue = seleccionado.Edicion.Id.ToString();
                    DropDownListEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                    TextBoxUrlImagenTapa_TextChanged(sender, e);

                }
                else
                {
                    DivTextBoxId.Visible = true;
                    TextBoxId.Enabled = true;
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


                if (Request.QueryString["id"] != null)
                {
                    discoNuevo.Id = int.Parse(TextBoxId.Text);
                    discoData.modificar(discoNuevo);
                }
                else
                {
                    discoData.agregarDisco(discoNuevo);
                }

                Response.Redirect("FormListaDiscos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }
        }

        protected void ButtonModificarDisco_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
            DivConfirmaEliminacion.Visible = true;
        }

        protected void ButtonConfiEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxConfiEliminacion.Checked)
                {
                    // Validar el ID antes de proceder
                    int id;
                    if (!int.TryParse(TextBoxId.Text, out id))
                    {
                        Debug.WriteLine("El valor de TextBoxId.Text no es un número válido: " + TextBoxId.Text);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('ID no válido o vacío. No se puede eliminar.');", true);
                        return; // Termina la ejecución si el ID no es válido
                    }

                    Debug.WriteLine("ID válido recibido: " + id);

                    // Proceder con la eliminación
                    DiscoData discoData = new DiscoData();
                    discoData.eliminar(id);

                    Debug.WriteLine("Registro eliminado correctamente.");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Registro eliminado correctamente.');", true);

                    // Redirigir a la lista después de la eliminación
                    Response.Redirect("FormListaDiscos.aspx", false);
                }
                else
                {
                    // Mostrar alerta si el checkbox no está marcado
                    Debug.WriteLine("Checkbox no marcado. Confirmación requerida.");
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Debe confirmar la eliminación.');", true);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void BtnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscoData data = new DiscoData();
                data.eliminarLogico(int.Parse(TextBoxId.Text));
                Response.Redirect("FormListaDiscos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                
            }
        }
    }
}
