using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using Remedies.Utility;

namespace HomeRemedies.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class RemedyTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemedyTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            RemedyType RemedyType = new RemedyType();
            if (id == null)
            {
                //this is for create
                return View(RemedyType);
            }
            //this is for edit
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            RemedyType = _unitOfWork.SP_Call.oneRecord<RemedyType>(SD.Proc_RemedyType_Get, parameter);
            if (RemedyType == null)
            {
                return NotFound();
            }
            return View(RemedyType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RemedyType RemedyType)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Name", RemedyType.Name);
                if (RemedyType.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_RemedyType_Create, parameter);
                }
                else
                {
                    parameter.Add("@Id", RemedyType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_RemedyType_Update, parameter);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(RemedyType);
        }
        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<RemedyType>(SD.Proc_RemedyType_GetAll, null);
            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var ObjFromDb = _unitOfWork.SP_Call.oneRecord<RemedyType>(SD.Proc_RemedyType_Get, parameter);
            if (ObjFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_RemedyType_Delete, parameter);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}