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
    public interface ISalaryDb
    {
        IEnumerable<Salary> GetAll();
        Salary GetById(int id);
        bool Insert(Salary obj);
        bool Update(Salary obj);
        bool Delete(int id);
        decimal GetCalculatedSalary(int id);
        List<Employee> GetEmployee();
    }
    public class SalaryDb : ISalaryDb
    {
        private AppDbContext context;
        public SalaryDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Salary> GetAll()
        {
            var list = context.Salary
                         .Include(e => e.Employee)
                         .Select(x => new Salary()
                         {
                             SId = x.SId,
                             EmpId = x.EmpId,
                             Employee = x.Employee,
                             Date = x.Date,
                             Status = x.Status,

                         }).ToList();
            return list;
        }
        public Salary GetById(int id)
        {
            var obj = context.Salary.Find(id);
            return obj;
        }
        public bool Insert(Salary obj)
        {
            context.Salary.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Salary obj)
        {
            context.Salary.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Salary.Find(id);
            context.Salary.Remove(obj);
            context.SaveChanges();
            return true;
        }
        public decimal GetCalculatedSalary(int id)
        {
            decimal netSalary = 0;
            decimal grossSalary = 0;
            decimal perlecturesalary = 0;
            decimal taxAmt = 0;
            decimal ticketFee = 0;

            int totalPresentAttendances = context.Attendence.Where(x => x.EmpId == id &&
                                                            x.Status == BOL.DataTypes.StatusTypes.Present)
                                                            .ToList().Count();

            var employee = context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
            if (employee != null)
            {
                perlecturesalary = employee.PerLectureSalary;
                taxAmt = employee.Tax;
                ticketFee = employee.TicketFee;
            }
            int totalLeaves = context.Leave.Where(x => x.EmpId == id && x.Status == 0).ToList().Count();

            grossSalary = (totalPresentAttendances + totalLeaves) * perlecturesalary ;

            netSalary = grossSalary - taxAmt - ticketFee;

            return netSalary;
           
        }
        public List<Employee> GetEmployee()
        {
           var employees = context.Employee.ToList();
            return employees;
        }
       
    }
}

