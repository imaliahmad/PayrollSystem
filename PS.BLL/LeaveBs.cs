using PS.BOL;
using PS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BLL
{
    public interface ILeaveBs
    {
        IEnumerable<Leave> GetAll();
        Leave GetById(int id);
        bool Insert(Leave obj);
        bool Update(Leave obj);
        bool Delete(int id);
    }
    public class LeaveBs : ILeaveBs
    {
        private readonly ILeaveDb objDb;
        public LeaveBs(ILeaveDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Leave> GetAll()
        {
            return objDb.GetAll();
        }
        public Leave GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Leave obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Leave obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}

