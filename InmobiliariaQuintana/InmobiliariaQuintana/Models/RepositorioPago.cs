using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class RepositorioPago : RepositorioBase
    {
        public RepositorioPago(IConfiguration configuration) : base(configuration)
        {

        }
        public int Alta(Pago i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Pago (NumeroPago, FechaPago, Monto, ContratoId) VALUES(@numeroPago,@fechaPago,@monto,@contratoId);SELECT SCOPE_IDENTITY();";
                using (SqlCommand com = new SqlCommand(sql, connection))
                {
                    com.Parameters.AddWithValue("@numeroPago", i.NumeroPago);
                    com.Parameters.AddWithValue("@fechaPago", DateTime.Now);
                    com.Parameters.AddWithValue("@monto", i.Monto);
                    com.Parameters.AddWithValue("@contratoId", i.ContratoId);

                    connection.Open();
                    res = com.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public int Modificacion(Pago e)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"UPDATE Pago SET " +
                    "numeroPago=@numeroPago, fechaUpdate=@fechaUpdate, monto=@monto " +
                    $"WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    var fecha = DateTime.Now;
                    command.Parameters.AddWithValue("@numeroPago", e.NumeroPago);
                    command.Parameters.AddWithValue("@fechaUpdate", fecha);
                    command.Parameters.AddWithValue("@monto", e.Monto);



                    command.Parameters.AddWithValue("@id", e.Id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Pago WHERE id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public IList<Pago> ObtenerTodos()
        {
            IList<Pago> lista = new List<Pago>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT p.id,p.NumeroPago,p.fechaPago,p.monto,p.contratoId,c.idInquilino,c.idInmueble,inm.direccion,c.precio,p.fechaUpdate
                FROM Pago p inner join Contrato c on p.contratoId = c.id
                inner join Inquilino i on c.idInquilino= i.idInquilino 
                inner join Inmueble inm on inm.id=c.idInmueble";
                using (SqlCommand com = new SqlCommand(sql, connection))
                {
                    com.CommandType = CommandType.Text;

                    connection.Open();
                    var reader = com.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {

                            Pago i = new Pago
                            {
                                Id = reader.GetInt32(0),
                                NumeroPago = reader.GetInt32(1),
                                FechaPago = reader.GetDateTime(2),
                                Monto = reader.GetDecimal(3),
                                ContratoId = reader.GetInt32(4),
                                Contrato = new Contrato
                                {
                                    IdContrato = reader.GetInt32(4),
                                    InquilinoId = reader.GetInt32(5),
                                    InmuebleId = reader.GetInt32(7),
                                    FechaDesde = reader.GetDateTime(8),
                                    FechaHasta = reader.GetDateTime(9),
                                    NombreGarante = reader.GetString(10),
                                    DNIGarante = reader.GetString(11),
                                    TelefonoGarante = reader.GetString(12),

                                },
                                FechaUpdate = reader["fechaUpdate"] != DBNull.Value ? reader.GetDateTime(10) : null


                            };
                            lista.Add(i);




                        }
                    }
                    connection.Close();
                }
            }
            return lista;
        }
        public IList<Pago> ObtenerTodosPorId(int Id)
        {
            IList<Pago> lista = new List<Pago>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT p.id,p.NumeroPago,p.FechaPago,p.Monto,p.ContratoId, p.FechaUpdate,
                c.InquilinoId,c.InmuebleId,c.FechaDesde, c.FechaHasta, c.NombreGarante, c.DNIGarante, c.TelefonoGarante
                FROM Pago p inner join Contratos c on p.contratoId = c.idContrato
                inner join Inquilinos i on c.InquilinoId= i.idInquilino 
                inner join Inmuebles inm on inm.idInmueble=c.InmuebleId where p.contratoId = @id;";
                using (SqlCommand com = new SqlCommand(sql, connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("@id", Id);
                    connection.Open();
                    var reader = com.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {

                            Pago i = new Pago
                            {
                                Id = reader.GetInt32(0),
                                NumeroPago = reader.GetInt32(1),
                                FechaPago = reader.GetDateTime(2),
                                Monto = reader.GetDecimal(3),
                                ContratoId = reader.GetInt32(4),
                                FechaUpdate = reader["fechaUpdate"] != DBNull.Value ? reader.GetDateTime(5) : null,
                                Contrato = new Contrato
                                {
                                    IdContrato = reader.GetInt32(4),
                                    InquilinoId = reader.GetInt32(6),
                                    InmuebleId = reader.GetInt32(7),
                                    FechaDesde = reader.GetDateTime(8),
                                    FechaHasta = reader.GetDateTime(9),
                                    NombreGarante = reader.GetString(10),
                                    DNIGarante = reader.GetString(11),
                                    TelefonoGarante = reader.GetString(12),

                                },



                            };
                            lista.Add(i);




                        }
                    }
                    connection.Close();
                }
            }
            return lista;
        } 

        public Pago ObtenerPorId(int id)
        {
            Pago p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT p.id,p.NumeroPago,p.FechaPago,p.Monto,p.ContratoId, p.FechaUpdate,
                c.InquilinoId,c.InmuebleId,c.FechaDesde, c.FechaHasta, c.NombreGarante, c.DNIGarante, c.TelefonoGarante
                FROM Pago p inner join Contratos c on p.contratoId = c.idContrato
                inner join Inquilinos i on c.InquilinoId= i.idInquilino 
                inner join Inmuebles inm on inm.idInmueble=c.InmuebleId where p.id = @id;";
                using (SqlCommand com = new SqlCommand(sql, connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = com.ExecuteReader();

                        while (reader.Read())
                        {

                            Pago i = new Pago
                            {
                                Id = reader.GetInt32(0),
                                NumeroPago = reader.GetInt32(1),
                                FechaPago = reader.GetDateTime(2),
                                Monto = reader.GetDecimal(3),
                                ContratoId = reader.GetInt32(4),
                                FechaUpdate = reader["fechaUpdate"] != DBNull.Value ? reader.GetDateTime(5) : null,
                                Contrato = new Contrato
                                {
                                    IdContrato = reader.GetInt32(4),
                                    InquilinoId = reader.GetInt32(6),
                                    InmuebleId = reader.GetInt32(7),
                                    FechaDesde = reader.GetDateTime(8),
                                    FechaHasta = reader.GetDateTime(9),
                                    NombreGarante = reader.GetString(10),
                                    DNIGarante = reader.GetString(11),
                                    TelefonoGarante = reader.GetString(12),

                                },



                            };
                        p = i;
                            




                        
                    }
                    connection.Close();
                }
            }
            return p;
        }
    }

    }

