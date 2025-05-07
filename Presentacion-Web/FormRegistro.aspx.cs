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
    public partial class FormRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                Trainee user = new Trainee();
                TraineeData traineeNegocio = new TraineeData();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                int id = traineeNegocio.insertarNuevo(user);

                emailService.armarCorreo(user.Email, "Bienvenida trainer", "Registración completada");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}