using Microsoft.EntityFrameworkCore;
using PS.BOL;
using PS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DAL
{
    public interface ILeaveDb
    {
        IEnumerable<Leave> GetAll();
        Leave GetById(int id);
        bool Insert(Leave obj);
        bool Update(Leave obj);
        bool Delete(int id);
    }
    public class LeaveDb : ILeaveDb
    {
        private AppDbContext context;
        public LeaveDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Leave> GetAll()
        {
            var list = context.Leave
                        .Include(e => e.Employee)
                        .Select(x => new Leave()
                        {
                            LeaveId = x.LeaveId,
                            EmpId = x.EmpId,
                            Employee = x.Employee,
                            LeaveDate = x.LeaveDate,
                            Status = x.Status,

                        }).ToList();
            return list;
        }
        public Leave GetById(int id)
        {
            var obj = context.Leave.Find(id);
            return obj;
        }
        public bool Insert(Leave obj)
        {
            context.Leave.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Leave obj)
        {
            context.Leave.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Leave.Find(id);
            context.Leave.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}

