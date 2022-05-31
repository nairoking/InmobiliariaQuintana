using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class RepositorioContrato : RepositorioBase
    {
        public RepositorioContrato(IConfiguration configuration): base (configuration)
        {

        }
		public IList<Contrato> ObtenerTodos()
		{
			IList<Contrato> res = new List<Contrato>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "SELECT C.IdContrato, C.InquilinoID, C.InmuebleID, C.FechaDesde, C.FechaHasta, C.NombreGarante, C.DNIGarante, C.TelefonoGarante, C.Precio, " +
					"I.Nombre, I.Apellido, I.Dni, I.Telefono, INM.Direccion, INM.Latitud, INM.Longitud" +
					" FROM Contratos AS C " +
					"INNER JOIN Inquilinos AS I ON I.IdInquilino = C.InquilinoID " +
					"INNER JOIN Inmuebles AS INM ON INM.IdInmueble = C.InmuebleID ";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Contrato entidad = new Contrato
						{
							IdContrato = reader.GetInt32(0),
							InquilinoId = reader.GetInt32(1),
							InmuebleId = reader.GetInt32(2),
							FechaDesde = reader.GetDateTime(3),
							FechaHasta = reader.GetDateTime(4),
							NombreGarante = reader.GetString(5),
							DNIGarante = reader.GetString(6),
							TelefonoGarante = reader.GetString(7),
							Precio = reader.GetDecimal(8),

							inquilino = new Inquilinos
							{
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
								Dni = reader.GetString(11),
								Telefono = reader.GetString(12),
							},

							inmueble = new Inmueble
                            {
								Direccion = reader.GetString(13),
								Latitud = reader.GetDecimal(14),
								Longitud = reader.GetDecimal(15),
                            }

						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}
		public int Alta(Contrato entidad)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Contratos (InquilinoID, InmuebleID, FechaDesde, FechaHasta, NombreGarante, DNIGarante, TelefonoGarante, Precio) " +
					"VALUES (@inquilinoId, @inmuebleId, @fechaDesde, @fechaHasta, @nombreGarante, @dniGarante, @telefonoGarante, @precio);" +
					"SELECT SCOPE_IDENTITY();";//devuelve el id insertado (LAST_INSERT_ID para mysql)
				using (var command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@inquilinoId", entidad.InquilinoId);
					command.Parameters.AddWithValue("@inmuebleId", entidad.InmuebleId);
					command.Parameters.AddWithValue("@fechaDesde", entidad.FechaDesde);
					command.Parameters.AddWithValue("@fechaHasta", entidad.FechaHasta);
					command.Parameters.AddWithValue("@nombreGarante", entidad.NombreGarante);
					command.Parameters.AddWithValue("@dniGarante", entidad.DNIGarante);
					command.Parameters.AddWithValue("@telefonoGarante", entidad.TelefonoGarante);
					command.Parameters.AddWithValue("@precio", entidad.Precio);
					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					entidad.IdContrato = res;
					connection.Close();
				}
			}
			return res;
		}
		public int Mofificar( Contrato entidad)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "UPDATE Contratos SET " +
					"InquilinoId=@inquilinoId, InmuebleId=@inmuebleId, FechaDesde=@fechaDesde, FechaHasta=@fechaHasta, NombreGarante=@nombreGarante, DNIGarante=@dniGarante, TelefonoGarante=@telefonoGarante , Precio=@precio " +
					"WHERE IdContrato =@idContrato ";//devuelve el id insertado (LAST_INSERT_ID para mysql)
				using (var command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@inquilinoId", entidad.InquilinoId);
					command.Parameters.AddWithValue("@inmuebleId", entidad.InmuebleId);
					command.Parameters.AddWithValue("@fechaDesde", entidad.FechaDesde);
					command.Parameters.AddWithValue("@fechaHasta", entidad.FechaHasta);
					command.Parameters.AddWithValue("@nombreGarante", entidad.NombreGarante);
					command.Parameters.AddWithValue("@dniGarante", entidad.DNIGarante);
					command.Parameters.AddWithValue("@telefonoGarante", entidad.TelefonoGarante);
					command.Parameters.AddWithValue("@idContrato", entidad.IdContrato);
					command.Parameters.AddWithValue("@precio", entidad.Precio);
					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					entidad.IdContrato = res;
					connection.Close();
				}
			}
			return res;
		}
		public Contrato ObtenerPorId(int id)
		{
			Contrato entidad = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				
				string sql = "SELECT C.IdContrato, C.InquilinoID, C.InmuebleID, C.FechaDesde, C.FechaHasta, C.NombreGarante, C.DNIGarante, C.TelefonoGarante, C.Precio, " +
					"I.Nombre, I.Apellido, I.Dni, I.Telefono, INM.Direccion, INM.Latitud, INM.Longitud" +
					" FROM Contratos AS C " +
					"INNER JOIN Inquilinos AS I ON I.IdInquilino = C.InquilinoID " +
					"INNER JOIN Inmuebles AS INM ON INM.IdInmueble = C.InmuebleID " +
					"WHERE IdContrato=@idContrato";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idContrato", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						entidad = new Contrato
						{
							IdContrato = reader.GetInt32(0),
							InquilinoId = reader.GetInt32(1),
							InmuebleId = reader.GetInt32(2),
							FechaDesde = reader.GetDateTime(3),
							FechaHasta = reader.GetDateTime(4),
							NombreGarante = reader.GetString(5),
							DNIGarante = reader.GetString(6),
							TelefonoGarante = reader.GetString(7),
							Precio = reader.GetDecimal(8),

							inquilino = new Inquilinos
							{
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
								Dni = reader.GetString(11),
								Telefono = reader.GetString(12),
							},

							inmueble = new Inmueble
							{
								Direccion = reader.GetString(13),
								Latitud = reader.GetDecimal(14),
								Longitud = reader.GetDecimal(15),
							}

						};
					}
					connection.Close();
				}
			}
			return entidad;
		}
		public int Baja(int id)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"DELETE FROM Contratos WHERE IdContrato = {id}";
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
		public IList<Contrato> ObtenerPorInmueble(int id)
		{
			IList<Contrato> res = new List<Contrato>();
			
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				string sql = "SELECT C.IdContrato, C.InquilinoID, C.InmuebleID, C.FechaDesde, C.FechaHasta, C.NombreGarante, C.DNIGarante, C.TelefonoGarante, C.Precio, " +
					"I.Nombre, I.Apellido, I.Dni, I.Telefono, INM.Direccion, INM.Latitud, INM.Longitud" +
					" FROM Contratos AS C " +
					"INNER JOIN Inquilinos AS I ON I.IdInquilino = C.InquilinoID " +
					"INNER JOIN Inmuebles AS INM ON INM.IdInmueble = C.InmuebleID " +
					"WHERE C.InmuebleID=@idInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idInmueble", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Contrato entidad = new Contrato
						{
							IdContrato = reader.GetInt32(0),
							InquilinoId = reader.GetInt32(1),
							InmuebleId = reader.GetInt32(2),
							FechaDesde = reader.GetDateTime(3),
							FechaHasta = reader.GetDateTime(4),
							NombreGarante = reader.GetString(5),
							DNIGarante = reader.GetString(6),
							TelefonoGarante = reader.GetString(7),
							Precio = reader.GetDecimal(8),

							inquilino = new Inquilinos
							{
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
								Dni = reader.GetString(11),
								Telefono = reader.GetString(12),
							},

							inmueble = new Inmueble
							{
								Direccion = reader.GetString(13),
								Latitud = reader.GetDecimal(14),
								Longitud = reader.GetDecimal(15),
							}

						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}
	}
}
