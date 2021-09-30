using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class RepositorioInmueble : RepositorioBase
    {

        public RepositorioInmueble(IConfiguration configuration) : base(configuration)
        {

        }
		public int Alta(Inmueble entidad)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Inmuebles (Direccion, Ambientes, Superficie, Latitud, Longitud, PropietarioId, Estado) " +
					"VALUES (@direccion, @ambientes, @superficie, @latitud, @longitud, @propietarioId, @estado);" +
					"SELECT SCOPE_IDENTITY();";//devuelve el id insertado (LAST_INSERT_ID para mysql)
				using (var command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@direccion", entidad.Direccion);
					command.Parameters.AddWithValue("@ambientes", entidad.Ambientes);
					command.Parameters.AddWithValue("@superficie", entidad.Superficie);
					command.Parameters.AddWithValue("@latitud", entidad.Latitud);
					command.Parameters.AddWithValue("@longitud", entidad.Longitud);
					command.Parameters.AddWithValue("@propietarioId", entidad.PropietarioId);
					command.Parameters.AddWithValue("@estado", entidad.Estado);
					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					entidad.IdInmueble = res;
					connection.Close();
				}
			}
			return res;
		}
		public IList<Inmueble> obtenerInmuebles(string desde, string hasta, int id)
        {
			IList<Inmueble> lista = new List<Inmueble>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sql = @" SELECT i.IdInmueble,i.Direccion,i.Ambientes,i.Superficie,i.Latitud,i.Longitud,i.PropietarioId,P.nombre ,P.apellido,i.Estado 
                From(SELECT * FROM Inmueble i left join 
                (SELECT  InmuebleId FROM Contrato c WHERE ((c.fechaDesde between @desde  and @hasta) 
                or (c.fechaHasta between @desde and @hasta)) and c.idInmueble != @id) x on (i.IdInmueble = x.InmuebleId)
                where x.idInmueble is null and i.estado = 0) i  INNER JOIN Propietario P ON i.PropietarioId = P.idPropietario;";
				using (SqlCommand com = new SqlCommand(sql, con))
				{
					com.CommandType = CommandType.Text;
					com.Parameters.AddWithValue("@desde", desde);
					com.Parameters.AddWithValue("@hasta", hasta);
					com.Parameters.AddWithValue("@id", id);
					con.Open();
					var reader = com.ExecuteReader();
					if (reader != null)
                    {
						while (reader.Read())
						{
							Inmueble entidad = new Inmueble
							{
								IdInmueble = reader.GetInt32(0),
								Direccion = reader.GetString(1),
								Ambientes = reader.GetInt32(2),
								Superficie = reader.GetInt32(3),
								Latitud = reader.GetDecimal(4),
								Longitud = reader.GetDecimal(5),
								PropietarioId = reader.GetInt32(6),
								Estado = reader.GetString(7),
								Duenio = new Propietario
								{
									IdPropietario = reader.GetInt32(6),
									Nombre = reader.GetString(8),
									Apellido = reader.GetString(9),
								}
							};
							lista.Add(entidad);
						}
					}
					con.Close();
				}
			}
			return lista;
		}


	
	public IList<Inmueble> ObtenerTodos()
		{
			IList<Inmueble> res = new List<Inmueble>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "SELECT IdInmueble, Direccion, Ambientes, Superficie, Latitud, Longitud, PropietarioId, Estado, " +
					" p.Nombre, p.Apellido" +
					" FROM Inmuebles i INNER JOIN Propietarios p ON i.PropietarioId = p.IdPropietario";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inmueble entidad = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							Ambientes = reader.GetInt32(2),
							Superficie = reader.GetInt32(3),
							Latitud = reader.GetDecimal(4),
							Longitud = reader.GetDecimal(5),
							PropietarioId = reader.GetInt32(6),
							Estado = reader.GetString(7),
							Duenio = new Propietario
							{
								IdPropietario = reader.GetInt32(6),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							}
						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}
		public IList<Inmueble> BuscarPorPropietario(int idPropietario)
		{
			List<Inmueble> res = new List<Inmueble>();
			Inmueble entidad = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPropietario, Direccion, Ambientes, Superficie, Latitud, Longitud, PropietarioId, Estado, p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.PropietarioId = p.IdPropietario" +
					$" WHERE PropietarioId=@idPropietario";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idPropietario", SqlDbType.Int).Value = idPropietario;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						entidad = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							Ambientes = reader.GetInt32(2),
							Superficie = reader.GetInt32(3),
							Latitud = reader.GetDecimal(4),
							Longitud = reader.GetDecimal(5),
							PropietarioId = reader.GetInt32(6),
							Estado = reader.GetString(7),
							Duenio = new Propietario
							{
								IdPropietario = reader.GetInt32(6),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							}
						};
						res.Add(entidad);
					}
					connection.Close();
				}
			}
			return res;
		}
		public Inmueble ObtenerPorId(int id)
		{
			Inmueble entidad = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInmueble, Direccion, Ambientes, Superficie, Latitud, Longitud, PropietarioId, Estado, p.Nombre, p.Apellido" +
					$" FROM Inmuebles i INNER JOIN Propietarios p ON i.PropietarioId = p.IdPropietario" +
					$" WHERE IdInmueble=@idInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idInmueble", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						entidad = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							Direccion = reader.GetString(1),
							Ambientes = reader.GetInt32(2),
							Superficie = reader.GetInt32(3),
							Latitud = reader.GetDecimal(4),
							Longitud = reader.GetDecimal(5),
							PropietarioId = reader.GetInt32(6),
							Estado = reader.GetString(7),
							Duenio = new Propietario
							{
								IdPropietario = reader.GetInt32(6),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
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
				string sql = $"DELETE FROM Inmuebles WHERE IdInmueble = {id}";
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
		public int Modificacion(Inmueble entidad)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "UPDATE Inmuebles SET " +
					"Direccion=@direccion, Ambientes=@ambientes, Superficie=@superficie, Latitud=@latitud, Longitud=@longitud, PropietarioId=@propietarioId, Estado = @estado " +
					"WHERE IdInmueble = @idInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@direccion", entidad.Direccion);
					command.Parameters.AddWithValue("@ambientes", entidad.Ambientes);
					command.Parameters.AddWithValue("@superficie", entidad.Superficie);
					command.Parameters.AddWithValue("@latitud", entidad.Latitud);
					command.Parameters.AddWithValue("@longitud", entidad.Longitud);
					command.Parameters.AddWithValue("@propietarioId", entidad.PropietarioId);
					command.Parameters.AddWithValue("@estado", entidad.Estado);

					command.Parameters.AddWithValue("@idInmueble", entidad.IdInmueble);
					command.CommandType = CommandType.Text;
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

	}
}
