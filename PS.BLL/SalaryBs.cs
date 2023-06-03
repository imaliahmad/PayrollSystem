using PS.BOL;
using PS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BLL
{
    public interface ISalaryBs
    {
        IEnumerable<Salary> GetAll();
        Salary GetById(int id);
        bool Insert(Salary obj);
        bool Update(Salary obj);
        bool Delete(int id);
        decimal GetCalculatedSalary(int id);
        List<Employee> GetEmployee();
    }
    public class SalaryBs : ISalaryBs
    {
        private readonly ISalaryDb objDb;
        public SalaryBs(ISalaryDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Salary> GetAll()
        {
            return objDb.GetAll();
        }
        public Salary GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Salary obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Salary obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }

        public decimal GetCalculatedSalary(int id)
        {
            return objDb.GetCalculatedSalary(id);
        }

        public List<Employee> GetEmployee()
        {
            return objDb.GetEmployee();
        }
    }
}

