using PS.BOL;
using PS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DAL
{
    public interface IEmployeeDb
    {
        // 100% Abstractions
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Insert(Employee obj);
        bool Update(Employee obj);
        bool Delete(int id);
    }
    public class EmployeeDb : IEmployeeDb
    {
        private AppDbContext context;
        public EmployeeDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return context.Employee;
        }
        public Employee GetById(int id)
        {
            var obj = context.Employee.Find(id);
            return obj;
        }
        public bool Insert(Employee obj)
        {
            context.Employee.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Employee obj)
        {
            context.Employee.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Employee.Find(id);
            context.Employee.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}


