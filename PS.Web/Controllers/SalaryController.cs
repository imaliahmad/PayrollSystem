using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.BLL;
using PS.BOL;
using PS.BOL.DataTypes;

namespace PS.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryBs objsalaryBs;
        private readonly IEmployeeBs employeeBs;
        public SalaryController(ISalaryBs _objsalaryBs, IEmployeeBs _employeeBs)
        {
            objsalaryBs = _objsalaryBs;
            employeeBs = _employeeBs;
        }
       /** 
        * This function is used to get salary list.
       **/
        public IActionResult Index()
        {
            try
            {
               var list = objsalaryBs.GetAll();
               return View(list);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null? ex.InnerException.Message :ex.Message;
                TempData["ErrorMessage"] = msg;
                return View(msg);
               
            }
            
        }
       /** 
        * This function is used to get salary record.
       **/
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Salary obj = new Salary();
                obj.Status = SalaryTypes.Pending;
                if(id > 0)
                {
                    obj = objsalaryBs.GetById(id);
                }
                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.SalaryStatusList = new SelectList(Enum.GetValues(typeof(SalaryTypes)));
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
         * This function is used to insert or update salary.
        **/
        [HttpPost]
        public IActionResult CreateorEdit(Salary Model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(Model.SId > 0)
                    {
                        objsalaryBs.Update(Model);
                    }
                    else
                    {
                        objsalaryBs.Insert(Model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Salary is not update or insert";
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
        * This function is used to get salary detail.
       **/
       public IActionResult Details(int id)
        {
            try
            {
                Salary obj = new Salary();
                if (id > 0)
                {
                    obj = objsalaryBs.GetById(id);
                }
                ViewBag.EmployeeList = new SelectList(employeeBs.GetAll(), "EmpId", "Name");
                ViewBag.SalaryStatusList = new SelectList(Enum.GetValues(typeof(SalaryTypes)));
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
