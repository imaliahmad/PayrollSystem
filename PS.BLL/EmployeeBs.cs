using PS.BOL;
using PS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BLL
{
    public interface IEmployeeBs
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Insert(Employee obj);
        bool Update(Employee obj);
        bool Delete(int id);
    }
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeDb objDb;
        public EmployeeBs(IEmployeeDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Employee> GetAll()
        {
            return objDb.GetAll();
        }
        public Employee GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Employee obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Employee obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}

