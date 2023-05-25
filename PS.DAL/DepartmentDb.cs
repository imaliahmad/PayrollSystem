using PS.BOL;
using PS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DAL
{
    public interface IDepartmentDb
    {
        // 100% Abstractions
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        bool Insert(Department obj);
        bool Update(Department obj);
        bool Delete(int id);
    }
    public class DepartmentDb : IDepartmentDb
    {
        private AppDbContext context;
        public DepartmentDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Department> GetAll()
        {
            return context.Department;
        }
        public Department GetById(int id)
        {
            var obj = context.Department.Find(id);
            return obj;
        }
        public bool Insert(Department obj)
        {
            context.Department.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Department obj)
        {
            context.Department.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Department.Find(id);
            context.Department.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
