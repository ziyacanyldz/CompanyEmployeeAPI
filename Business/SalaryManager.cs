using Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SalaryManager : ISalaryService
    {
        public  int TotalSalary(int companyId)
        {
            EfDbContext dbContext = new EfDbContext();
            List<int> asd = dbContext.Employees.Where(e => e.CompanyId == companyId).Select(e => e.SalaryId).ToList();
            int sum = 0;
            foreach (var item in asd)
            {
                int a = dbContext.Salaries.Where(s => s.Id == item).Select(s => s.Amount).FirstOrDefault();
                sum += a;
            }
            return sum;
        }
    }
}
