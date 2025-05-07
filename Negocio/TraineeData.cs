using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TraineeData
    {

        public int insertarNuevo(Trainee nuevo)
        {


            AccesoDatos accesoDatos = new AccesoDatos();


            try
            {
                accesoDatos.setearProcedimiento("insertarNuevo");
                accesoDatos.setearParametro("@email", nuevo.Email);
                accesoDatos.setearParametro("@pass", nuevo.Pass);
                return accesoDatos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

        }

    }
}
