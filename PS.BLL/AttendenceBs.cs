using PS.BOL;
using PS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BLL
{
    public interface IAttendenceBs
    {
        IEnumerable<Attendence> GetAll();
        Attendence GetById(int id);
        bool Insert(Attendence obj);
        bool Update(Attendence obj);
        bool Delete(int id);
    }
    public class AttendenceBs : IAttendenceBs
    {
        private readonly IAttendenceDb objDb;
        public AttendenceBs(IAttendenceDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Attendence> GetAll()
        {
            return objDb.GetAll();
        }
        public Attendence GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Attendence obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Attendence obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}

