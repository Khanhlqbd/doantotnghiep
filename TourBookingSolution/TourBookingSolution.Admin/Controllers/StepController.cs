using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Admin.Controllers;
using TourBookingSolution.Business.Core;
using TourBookingSolution.Data.ViewModels;

namespace TourBookingSolution.Admin.Controllers
{
    [CheckLogin]
    public class StepController : Controller
    {
        // GET: Step
        IStepBusiness _stepBusiness;
        public StepController(IStepBusiness stepBusiness)
        {
            this._stepBusiness = stepBusiness;
        }
        public ActionResult List(long id)
        {
            try
            {
                ViewBag.TourID = id;
                var result = _stepBusiness.GetAll(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add(long id)
        {
            StepView step = new StepView();
            step.Tour = id;
            return View(step);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(StepView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_stepBusiness.Add(model))
                    {
                        _stepBusiness.Save();
                        return Redirect($"/Step/List/{model.Tour}");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult Edit(long id)
        {
            try
            {
                var result = _stepBusiness.GetDetail(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(StepView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_stepBusiness.Edit(model))
                    {
                        _stepBusiness.Save();
                        return Redirect($"/Step/List/{model.Tour}");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_stepBusiness.Delete(id))
                {
                    _stepBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
    }
}