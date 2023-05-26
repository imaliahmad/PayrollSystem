using Microsoft.AspNetCore.Mvc;
using PS.BLL;
using PS.BOL;

namespace PS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentBs objDepartmentBs;

        public DepartmentController(IDepartmentBs _objDepartmentBs)
        {
            objDepartmentBs = _objDepartmentBs;
        }

        /** 
         * This function is used to get department list
         **/
        public IActionResult Index()
        {
            try
            {
                var list = objDepartmentBs.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }

        }

        /** 
         * This function is used to get department records
         **/

        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Department obj = new Department();
                if (id > 0)
                {
                    obj = objDepartmentBs.GetById(id);
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }

        }

        /** 
         * This function is used to create and edit department records
         **/

        [HttpPost]
        public IActionResult CreateorEdit(Department model)
        {
            try
            {
                ModelState.Remove("Employee");
                if (ModelState.IsValid)
                {
                    if (model.DeptId > 0)
                    {
                        objDepartmentBs.Update(model);
                    }
                    else
                    {
                        objDepartmentBs.Insert(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Department is not Update/Insert";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }

        }

        /** 
        * This function is used to get department details
        **/
        public IActionResult Details(int id)
        {
            try
            {
                Department obj = new Department();
                if (id > 0)
                {
                    obj = objDepartmentBs.GetById(id);
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }

        }

    }
}
