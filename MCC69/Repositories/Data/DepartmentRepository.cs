using MCC69.Context;
using MCC69.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MCC69.Repositories.Data
{
    public class DepartmentRepository
    {
        SqlConnection sqlConnection;
        readonly string connectionString;
        SqlTransaction sqlTransaction;
        SqlCommand sqlCommand;

        public DepartmentRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public List<Department> GetAll()
        {
            List<Department> Departments = new List<Department>();
            string query = "SELECT * FROM Department";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    Department department = new Department(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString());
                    Departments.Add(department);
                }
            }

            sqlConnection.Close();
            return Departments;
        }

        public Department GetById(int id)
        {
            string query = $"SELECT * FROM Department Where Id = @param";

            if (id == 0)
            {
                return null;
            }
            else
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@param", id));

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        var department = new Department(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString());
                        return department;
                    }
                }
                sqlConnection.Close();
                return null;
            }
        }

        public int Insert(Department department)
        {
            string query1 = $"INSERT INTO Department (Name) VALUES (@name)";
            string query2 = $"INSERT INTO Division (Name) VALUES (@namediv)";

            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand = new SqlCommand(query2, sqlConnection, sqlTransaction);
                sqlCommand.Parameters.Add(new SqlParameter("@namediv", "try"));
                int result2 = sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand(query1, sqlConnection, sqlTransaction);
                sqlCommand.Parameters.Add(new SqlParameter("@name", department.Name));
                int result = sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();
                if (result > 0)
                    return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                sqlTransaction.Rollback();
            }
            return 0;
        }

        public int Update(Department department)
        {
            string query = $"UPDATE Department SET Name = @name WHERE Id = @id";

            if (!department.Check(department))
            {
                return 0;
            }
            else
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.Add(new SqlParameter("@id", department.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@name", department.Name));
                int result = sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();
                if (result > 0)
                    return result;
                sqlTransaction.Rollback();
                return 0;
            }
        }

        public int Delete(int id)
        {
            string query = $"DELETE Department WHERE Id = @id";
            Department department = new Department();
            if (!department.Check(id))
            {
                return 0;
            }
            else
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                int result = sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();
                if (result > 0)
                    return result;
                sqlTransaction.Rollback();
                return 0;
            }
        }
    }
}
