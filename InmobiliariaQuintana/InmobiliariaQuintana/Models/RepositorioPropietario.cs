using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class RepositorioPropietario
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=InmobiliariaQBD;Trusted_Connection=True;MultipleActiveResultSets=true";
        public RepositorioPropietario()
        {

        }
        public int Alta(Propietario p)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Propietarios (Nombre, Apellido, Telefono, Dni, Email, Clave)
                                VALUES  (@nombre, @apellido, @telefono, @dni, @email, @clave);
                                SELECT SCOPE_IDENTITY();";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", p.Nombre);
                    comm.Parameters.AddWithValue("@apellido", p.Apellido);
                    comm.Parameters.AddWithValue("@telefono", p.Telefono);
                    comm.Parameters.AddWithValue("@dni", p.Dni);
                    comm.Parameters.AddWithValue("@email", p.Email);
                    comm.Parameters.AddWithValue("@clave", p.Clave);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    p.IdPropietario = res;
                }

            }
            return res;
        }
        public IList<Propietario> ObtenerTodos()
        {
            
            IList<Propietario> res = new List<Propietario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT IdPropietario, Nombre, Apellido, Telefono, Dni , Email , Clave 
                                FROM Propietarios;";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    ;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var i = new Propietario
                        {
                            IdPropietario = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Propietario.Nombre)],
                            Apellido = (string)reader[nameof(Propietario.Apellido)],
                            Telefono = (string)reader[nameof(Propietario.Telefono)],
                            Dni = (string)reader[nameof(Propietario.Dni)],
                            Email = (string)reader[nameof(Propietario.Email)],
                            Clave = (string)reader[nameof(Propietario.Clave)],


                        };
                        res.Add(i);

                    }
                    conn.Close();

                }

            }
            return res;
        }
        public int Modificacion(Propietario e)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Propietarios SET " +
                    $"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Email=@email, Clave=@clave " +
                    $"WHERE IdPropietario = @idPropietario";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", e.Nombre);
                    command.Parameters.AddWithValue("@apellido", e.Apellido);
                    command.Parameters.AddWithValue("@dni", e.Dni);
                    command.Parameters.AddWithValue("@telefono", e.Telefono);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@idPropietario", e.IdPropietario);
                    command.Parameters.AddWithValue("@clave", e.Clave);
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
                string sql = $"DELETE FROM Propietarios WHERE IdPropietario = {id}";
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

        public Propietario ObtenerPorId(int id)
        {
            Propietario p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPropietario, Nombre, Apellido, Dni, Telefono, Email, Clave FROM Propietarios" +
                    $" WHERE IdPropietario=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Propietario
                        {
                            IdPropietario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                            Clave = reader.GetString(6),
                        };
                        return p;
                    }
                    connection.Close();
                }
            }
            return p;
        }
    }
}
