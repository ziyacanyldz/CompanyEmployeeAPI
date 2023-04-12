using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Salary
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Amount { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
