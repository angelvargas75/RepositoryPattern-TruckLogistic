using Dominio;
using System;
using System.Data.SqlClient;

namespace ServicioWcfCamion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioWCFCamion : IServicioWCFCamion
    {
        public Camion Get(int id)
        {
            Dominio.Camion objeto = null;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=ANGEL-PC\SQLEXPRESS; DataBase=Truck; User id=sa; Password=angel123"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Get"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        int index = 0;
                        try
                        {
                            while (reader.Read())
                            {
                                objeto = new Dominio.Camion();
                                index = reader.GetOrdinal("Id");
                                objeto.Id = reader.GetInt32(index);
                                index = reader.GetOrdinal("TipoDeCarga");
                                objeto.TipoDeCarga = reader.GetString(index);
                                index = reader.GetOrdinal("Chasis");
                                objeto.Chasis = reader.GetString(index);
                                index = reader.GetOrdinal("RecuentoDeEngranajes");
                                objeto.RecuentoDeEngranajes = reader.GetInt32(index);
                                index = reader.GetOrdinal("Retardero");
                                objeto.Retardero = reader.GetString(index);
                                index = reader.GetOrdinal("EjesAlimentados");
                                objeto.EjesAlimentados = reader.GetInt32(index);
                                index = reader.GetOrdinal("PotenciaDelMotor");
                                objeto.PotenciaDelMotor = reader.GetInt32(index);
                                index = reader.GetOrdinal("EsfuerzoDeTorsion");
                                objeto.EsfuerzoDeTorsion = reader.GetInt32(index);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Id no encontrado: " + ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos: " + ex);
            }
            return objeto;
        }


        public bool Insert(Dominio.Camion datos)
        {
            var retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=ANGEL-PC\SQLEXPRESS; DataBase=Truck; User id=sa; Password=angel123"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Insert"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", datos.Id));
                        cmd.Parameters.Add(new SqlParameter("@tipoDeCarga", datos.TipoDeCarga));
                        cmd.Parameters.Add(new SqlParameter("@chasis", datos.Chasis));
                        cmd.Parameters.Add(new SqlParameter("@recuentoDeEngranajes", datos.RecuentoDeEngranajes));
                        cmd.Parameters.Add(new SqlParameter("@retardero", datos.Retardero));
                        cmd.Parameters.Add(new SqlParameter("@ejesAlimentados", datos.EjesAlimentados));
                        cmd.Parameters.Add(new SqlParameter("@potenciaDelMotor", datos.PotenciaDelMotor));
                        cmd.Parameters.Add(new SqlParameter("@esfuerzoDeTorsion", datos.EsfuerzoDeTorsion));
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        retorno = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar datos: " + ex);
            }
            return retorno;
        }


        public bool Update(Dominio.Camion datos)
        {
            var retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=ANGEL-PC\SQLEXPRESS; DataBase=Truck; User id=sa; Password=angel123"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Update"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", datos.Id));
                        cmd.Parameters.Add(new SqlParameter("@tipoDeCarga", datos.TipoDeCarga));
                        cmd.Parameters.Add(new SqlParameter("@chasis", datos.Chasis));
                        cmd.Parameters.Add(new SqlParameter("@recuentoDeEngranajes", datos.RecuentoDeEngranajes));
                        cmd.Parameters.Add(new SqlParameter("@retardero", datos.Retardero));
                        cmd.Parameters.Add(new SqlParameter("@ejesAlimentados", datos.EjesAlimentados));
                        cmd.Parameters.Add(new SqlParameter("@potenciaDelMotor", datos.PotenciaDelMotor));
                        cmd.Parameters.Add(new SqlParameter("@esfuerzoDeTorsion", datos.EsfuerzoDeTorsion));
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        retorno = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar registro: " + ex);
            }
            return retorno;
        }


        public bool Delete(int id)
        {
            var retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server=ANGEL-PC\SQLEXPRESS; DataBase=Truck; User id=sa; Password=angel123"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Delete"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        retorno = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar registro: " + ex);
            }
            return retorno;
        }
    }
}
