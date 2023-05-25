using PS.BOL;
using PS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DAL
{
    public interface IAttendenceDb
    {  
        IEnumerable<Attendence> GetAll();
        Attendence GetById(int id);
        bool Insert(Attendence obj);
        bool Update(Attendence obj);
        bool Delete(int id);
    }
    public class AttendenceDb : IAttendenceDb
    {
        private AppDbContext context;
        public AttendenceDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Attendence> GetAll()
        {
            return context.Attendence;
        }
        public Attendence GetById(int id)
        {
            var obj = context.Attendence.Find(id);
            return obj;
        }
        public bool Insert(Attendence obj)
        {
            context.Attendence.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Attendence obj)
        {
            context.Attendence.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Attendence.Find(id);
            context.Attendence.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
