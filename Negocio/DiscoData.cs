﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Negocio
{
    public class DiscoData
    {
        public List<Disco> listar(string id = "")
        {

            List<Disco> listaDiscos = new List<Disco>();

            AccesoDatos datos = new AccesoDatos();


            try
            {
                string consulta = "SELECT D.Id AS Id, Titulo, D.CantidadCanciones, D.UrlImagenTapa,E.Descripcion AS Estilo, TE.Descripcion AS Edicion, D.IdEstilo,D.IdTipoEdicion  FROM dbo.DISCOS D JOIN dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion ";

                // consulta para no mostar los inactivos  string consulta = "SELECT D.Id AS Id, Titulo, D.CantidadCanciones, D.UrlImagenTapa,D.Activo as Activo ,E.Descripcion AS Estilo, TE.Descripcion AS Edicion, D.IdEstilo,D.IdTipoEdicion  FROM dbo.DISCOS D JOIN dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion ";


                if (id != "")
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        consulta += " AND D.Id = @Id"; // Usamos parámetro para evitar SQL Injection
                        datos.setearConsulta(consulta);
                        datos.setearParametro("@Id", id);
                    }
                    else
                    {
                        datos.setearConsulta(consulta);
                    }
                }

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

                    //aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

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

        public List<Disco> listarSP()
        {
            List<Disco> listaDiscos = new List<Disco>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                //string consulta = "SELECT D.Id AS Numero,D.Titulo AS Nombre,D.CantidadCanciones AS Cantidad,D.FechaLanzamiento AS Lanzamiento,D.UrlImagenTapa AS UrlImagen,E.Descripcion AS Estilo,TE.Descripcion AS Edicion,D.IdEstilo AS IdTipo,D.IdTipoEdicion AS IdDebilidad FROM dbo.DISCOS D JOIN dbo.ESTILOS E ON E.Id = D.IdEstilo JOIN dbo.TiposEdicion TE ON TE.Id = D.IdTipoEdicion;";
                //accesoDatos.setearConsulta(consulta);


                accesoDatos.setearProcedimiento("storedListar");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {

                    Disco aux = new Disco();

                    aux.Id = (int)accesoDatos.Lector["Numero"];
                    aux.Titulo = (string)accesoDatos.Lector["Nombre"];
                    aux.CantidadCanciones = (int)accesoDatos.Lector["Cantidad"];

                    if (!(accesoDatos.Lector.IsDBNull(accesoDatos.Lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagenTapa = (string)accesoDatos.Lector["UrlImagen"];


                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)accesoDatos.Lector["IdTipo"];
                    aux.Estilo.Descripcion = (string)accesoDatos.Lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)accesoDatos.Lector["IdDebilidad"];
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
                Debug.WriteLine("Iniciando eliminación del registro con ID: " + id);

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM DISCOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarAccion();

                Debug.WriteLine("Registro eliminado correctamente.");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {

                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("update DISCOS set Activo = @activo where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@activo",activo);

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

                if (campo == "Estilo")
                {
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
                }else if (campo == "Titulo"){
                    switch (criterio)
                    {
                        case "Comienza Con":
                            consulta += "Titulo like '" + filtro + "%'";
                            break;
                        case "Termina Con":
                            consulta += "Titulo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Titulo like '%" + filtro + "%'";
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

        public List<Estilo> listarEstilos()
        {
            return new List<Estilo>{
        new Estilo { Id = 1, Descripcion = "Pop Punk" },
        new Estilo { Id = 2, Descripcion = "Pop " },
        new Estilo { Id = 3, Descripcion = "Rock" },
        new Estilo { Id = 4, Descripcion = "Grunge" },
        new Estilo { Id = 5, Descripcion = "trap" },
        new Estilo { Id = 6, Descripcion = "Hip hop" }

            };
        }

        public List<Edicion> listarEdiciones()
        {
            return new List<Edicion>{
        new Edicion { Id = 1, Descripcion = "Vinilo" },
        new Edicion { Id = 2, Descripcion = "CD " },
        new Edicion { Id = 3, Descripcion = "Tape" },
        new Edicion { Id = 4, Descripcion = "mp3" },

            };
        }

    }
}
