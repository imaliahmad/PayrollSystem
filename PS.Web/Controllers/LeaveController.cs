using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.BLL;
using PS.BOL;
using PS.BOL.DataTypes;
using PS.DAL;

namespace PS.Web.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveBs objleaveBs;
        private readonly IEmployeeBs employeeBs;
        public LeaveController(ILeaveBs _objleaveBs, IEmployeeBs _employeeBs)
        {
            objleaveBs = _objleaveBs;
            employeeBs = _employeeBs;
        }
        /** 
         * This function is used to get attendence list.
        **/
        public IActionResult Index()
        {
            try
            {
                var list = objleaveBs.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
              var msg = ex.InnerException != null? ex.InnerException.Message : ex.Message;
              TempData["ErrorMessage"] = msg;
              return View(msg);
            }
           
        }
        /** 
         * This function is used to get attendence record.
        **/
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Leave obj = new Leave();
                obj.Status = LeaveStatusTypes.Pending;
                if (id > 0)
                {
                    obj = objleaveBs.GetById(id);
                }
                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.LeaveStatusList = new SelectList(Enum.GetValues(typeof(LeaveStatusTypes)));
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View(msg);
            }
            
        }
        /** 
         * This function is used to update or insert attendence.
        **/
        [HttpPost]
        public IActionResult CreateorEdit(Leave Model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(Model.LeaveId > 0)
                    {
                        objleaveBs.Update(Model);
                    }
                    else
                    {
                        objleaveBs.Insert(Model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Leave is not update / insert";
                    return View(Model);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View(msg);
            }
        }
       /** 
        * This function is used to get attendence detail.
       **/
        public IActionResult Details(int id)
        {
            try
            {
                Leave obj = new Leave();
                if (id > 0)
                {
                    obj = objleaveBs.GetById(id);
                }
                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.LeaveStatusList = new SelectList(Enum.GetValues(typeof(LeaveStatusTypes)));
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View(msg);
            }
        }
     /** 
      * This function is used to get leave.
     **/
        public JsonResult GetLeave()
        {
            var leave = objleaveBs.GetAll();
            return Json(leave);
        }
    }
}
