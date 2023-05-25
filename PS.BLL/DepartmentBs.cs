using PS.BOL;
using PS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BLL
{
    public interface IDepartmentBs
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        bool Insert(Department obj);
        bool Update(Department obj);
        bool Delete(int id);
    }
    public class DepartmentBs : IDepartmentBs
    {
        private readonly IDepartmentDb objDb;
        public DepartmentBs(IDepartmentDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Department> GetAll()
        {
            return objDb.GetAll();
        }
        public Department GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Department obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Department obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}


