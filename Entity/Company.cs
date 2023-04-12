using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<Employee>? Employees { get; set; } 
    }
}
