using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana.Models
{
    public class RepositorioInquilinos
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=InmobiliariaQBD;Trusted_Connection=True;MultipleActiveResultSets=true";
        public RepositorioInquilinos()
        {

        }

        public int Alta (Inquilinos I)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Inquilinos (Nombre, Apellido, Telefono, Dni, Email)
                                VALUES  (@nombre, @apellido, @telefono, @dni, @email);
                                SELECT SCOPE_IDENTITY();";
                using(SqlCommand comm = new SqlCommand(sql,conn))
                {
                    comm.Parameters.AddWithValue("@nombre", I.Nombre);
                    comm.Parameters.AddWithValue("@apellido", I.Apellido);
                    comm.Parameters.AddWithValue("@telefono", I.Telefono);
                    comm.Parameters.AddWithValue("@dni", I.Dni);
                    comm.Parameters.AddWithValue("@email", I.Email);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    I.IdInquilino = res;
                }

            }
            return res;
        }

        public IList<Inquilinos>  ObtenerTodos()
        {
            IList<Inquilinos> res = new List<Inquilinos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT IdInquilino, Nombre, Apellido, Telefono, Dni , Email
                                FROM Inquilinos;";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    ;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while(reader.Read())
                    {
                        var i = new Inquilinos
                        {
                            IdInquilino = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Inquilinos.Nombre)],
                            Apellido = (string)reader[nameof(Inquilinos.Apellido)],
                            Telefono = (string)reader[nameof(Inquilinos.Telefono)],
                            Dni = (string)reader[nameof(Inquilinos.Dni)],
                            Email = (string)reader[nameof(Inquilinos.Email)],


                        };
                        res.Add(i);

                    }
                    conn.Close();
                    
                }

            }
            return res;
        }
        public int Modificacion(Inquilinos e)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Inquilinos SET " +
                    $"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Email=@email " +
                    $"WHERE IdInquilino = @idInquilino";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", e.Nombre);
                    command.Parameters.AddWithValue("@apellido", e.Apellido);
                    command.Parameters.AddWithValue("@dni", e.Dni);
                    command.Parameters.AddWithValue("@telefono", e.Telefono);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@idInquilino", e.IdInquilino);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public Inquilinos ObtenerPorId(int id)
        {
            Inquilinos p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInquilino, Nombre, Apellido, Dni, Telefono, Email FROM Inquilinos" +
                    $" WHERE IdInquilino=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Inquilinos
                        {
                            IdInquilino = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                        };
                        return p;
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Inquilinos WHERE IdInquilino = {id}";
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
    }
}
