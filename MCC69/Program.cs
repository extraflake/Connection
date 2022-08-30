using MCC69.Models;
using MCC69.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MCC69
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection();
            DepartmentRepository departmentRepository = new DepartmentRepository(sqlConnection);

            //foreach (var item in departmentRepository.GetAll())
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //}

            //var data = departmentRepository.GetById(1);
            //if (data != null)
            //{
            //    Console.WriteLine(data.Id);
            //    Console.WriteLine(data.Name);
            //}
            //else
            //{
            //    Console.WriteLine("No Data Found");
            //}

            //Department department = new Department("ADD 5");
            //var result = departmentRepository.Insert(department);
            //if (result > 0)
            //{
            //    Console.WriteLine("Data has been successfully inserted");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to insert data");
            //}

            //Department department = new Department(1, "ADD 5");
            //var result = departmentRepository.Update(department);
            //if (result > 0)
            //{
            //    Console.WriteLine("Data has been successfully updated");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to update data");
            //}

            //var result = departmentRepository.Delete(1);
            //if (result > 0)
            //{
            //    Console.WriteLine("Data has been successfully deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to delete data");
            //}
        }
    }
}
