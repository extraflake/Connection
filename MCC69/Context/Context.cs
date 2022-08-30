using System;
using System.Collections.Generic;
using System.Text;

namespace MCC69.Context
{
    public class MyContext
    {
        public static string GetConnection()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MCC69;User ID=mcc69;Password=123456;";
        }
    }
}
