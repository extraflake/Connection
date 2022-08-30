using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCC69.Models
{
    public class Department
    {
        public Department()
        {

        }

        public Department(string Name)
        {
            this.Name = Name;
        }

        public Department(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public bool Check(Department department)
        {
            if (string.IsNullOrWhiteSpace(department.Id.ToString()) && string.IsNullOrWhiteSpace(department.Name))
            {
                return true;
            }
            return false;
        }

        public bool Check(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
