using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.BLL;
using PS.BOL;
using PS.BOL.DataTypes;
using PS.DAL;

namespace PS.Web.Controllers
{
   
    public class AttendenceController : Controller
    {
        private readonly IAttendenceBs objattendenceBs;
        private readonly IEmployeeBs employeeBs;

        public AttendenceController(IAttendenceBs _objattendenceBs, IEmployeeBs _employeeBs)
        {
            objattendenceBs = _objattendenceBs;
            employeeBs = _employeeBs;
        }
        /** 
         * This function is used to get attendence list.
        **/
        public IActionResult Index()
        {
            try
            {
                var list = objattendenceBs.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
               var msg =ex.InnerException != null? ex.InnerException.Message : ex.Message;
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
                Attendence obj = new Attendence();
                if(id > 0)
                {
                    obj = objattendenceBs.GetById(id);
                }
                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.BatchList = new SelectList(Enum.GetValues(typeof(BatchTypes)));
                ViewBag.SectionList = new SelectList(Enum.GetValues(typeof(SectionTypes)));
                ViewBag.LectureList = new SelectList(Enum.GetValues(typeof(LectureTypes)));
                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusTypes)));
                
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
        * This function is used to insert and update attendence.
       **/
        [HttpPost]
        public IActionResult CreateorEdit(Attendence Model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(Model.AttId > 0)
                    {
                        objattendenceBs.Update(Model);
                    }
                    else
                    {
                        objattendenceBs.Insert(Model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Attendence is not update / insert";
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
        * This function is used to attendence details.
       **/
        public IActionResult Details(int id)
        {
            try
            {
                Attendence obj = new Attendence();
                if (id > 0)
                {
                    obj = objattendenceBs.GetById(id);
                }

                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.BatchList = new SelectList(Enum.GetValues(typeof(BatchTypes)));
                ViewBag.SectionList = new SelectList(Enum.GetValues(typeof(SectionTypes)));
                ViewBag.LectureList = new SelectList(Enum.GetValues(typeof(LectureTypes)));
                ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(StatusTypes)));
                
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View(msg);
            }
        }
    }
}
