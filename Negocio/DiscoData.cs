using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class DiscoData
    {
        public List<Disco> listar()
        {

            List<Disco> listaDiscos = new List<Disco>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT D.Id AS Id, Titulo, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion AS Estilo, TE.Descripcion AS Edicion, D.IdEstilo,D.IdTipoEdicion  FROM dbo.DISCOS D JOIN dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion\r\n");

                // consulta para no mostar los inactivos     datos.setearConsulta("SELECT D.Id AS Id, D.Titulo, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion AS Estilo, TE.Descripcion AS Edicion, D.IdEstilo,D.IdTipoEdicion  FROM dbo.DISCOS D JOIN dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion and D.Activo = 1\r\n");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Disco aux = new Disco();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagenTapa"))))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];


                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Lector["Edicion"];

                    listaDiscos.Add(aux);

                }

                return listaDiscos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                datos.cerrarConexion();

            }

        }

        public void agregarDisco(Disco nuevo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into DISCOS (Titulo,CantidadCanciones,IdEstilo,IdTipoEdicion,UrlImagenTapa) values('" + nuevo.Titulo + "'," + nuevo.CantidadCanciones + " , @IdEstilo,@IdTipoEdicion,@UrlImagenTapa )");
                datos.setearParametro("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.setearParametro("@UrlImagenTapa", nuevo.UrlImagenTapa);


                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void modificar(Disco disc)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("update DISCOS set Titulo = @Titulo,CantidadCanciones = @CantidadCanciones,UrlImagenTapa = @UrlImagenTapa,IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion where Id = @Id\r\n");
                datos.setearParametro("@Titulo", disc.Titulo);
                datos.setearParametro("@CantidadCanciones", disc.CantidadCanciones);
                datos.setearParametro("@UrlImagenTapa", disc.UrlImagenTapa);
                datos.setearParametro("@IdEstilo", disc.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", disc.Edicion.Id);
                datos.setearParametro("@Id", disc.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {

            try
            {

                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("delete from DISCOS where Id = @Id \r\n");
                datos.setearParametro("@Id", id);

                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void eliminarLogico(int id)
        {
            try
            {

                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("update DISCOS set Activo = 0 where Id = @Id\r\n");
                datos.setearParametro("@Id", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {

            List<Disco> listaDiscos = new List<Disco>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                string consulta = "SELECT D.Id AS Id,Titulo, D.CantidadCanciones,  D.UrlImagenTapa, E.Descripcion AS Estilo, TE.Descripcion   AS Edicion, D.IdEstilo,D.IdTipoEdicion  FROM dbo.DISCOS D JOIN\r\n  dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN  dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion where ";

                if (campo == "Estilo") {
                    switch (criterio)
                    {
                        case "Comienza Con":
                            consulta += "E.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina Con":
                            consulta += " E.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                    accesoDatos.setearConsulta(consulta);
                    accesoDatos.ejecutarLectura();

                    while (accesoDatos.Lector.Read())
                    {

                        Disco aux = new Disco();

                        aux.Id = (int)accesoDatos.Lector["Id"];
                        aux.Titulo = (string)accesoDatos.Lector["Titulo"];
                        aux.CantidadCanciones = (int)accesoDatos.Lector["CantidadCanciones"];

                        if (!(accesoDatos.Lector.IsDBNull(accesoDatos.Lector.GetOrdinal("UrlImagenTapa"))))
                            aux.UrlImagenTapa = (string)accesoDatos.Lector["UrlImagenTapa"];


                        aux.Estilo = new Estilo();
                        aux.Estilo.Id = (int)accesoDatos.Lector["IdEstilo"];
                        aux.Estilo.Descripcion = (string)accesoDatos.Lector["Estilo"];
                        aux.Edicion = new Edicion();
                        aux.Edicion.Id = (int)accesoDatos.Lector["IdTipoEdicion"];
                        aux.Edicion.Descripcion = (string)accesoDatos.Lector["Edicion"];

                        listaDiscos.Add(aux);

                    }

                return listaDiscos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
