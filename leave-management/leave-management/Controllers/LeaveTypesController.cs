using AutoMapper;
using leave_management.Data;
using leave_management.Models;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace leave_management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypesRepository _repo;
        private readonly IMapper _mapper ;

        public LeaveTypesController(ILeaveTypesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #region Index
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _repo.GetAll();
            var model = _mapper.Map<IEnumerable<LeaveType>, IEnumerable<LeaveTypeViewModel>>(leaveTypes);

            return View(model);
        }
        #endregion

        #region Details
        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(!await _repo.IsExists(id))
            {
                return NotFound();
            }

            var leaveType = await _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }
        #endregion

        #region Create
        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                var isSuccess = await _repo.Create(leaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View(model);
            }
        }
        #endregion

        #region Edit
        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (!await _repo.IsExists(id))
            {
                return NotFound();
            }

            var leaveType = await _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var leaveType = _mapper.Map<LeaveType>(model);
                var isSuccess = await _repo.Update(leaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong!");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            } 
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View(model);
            }
        }
        #endregion

        #region Delete
        // GET: LeaveTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var leaveType = await _repo.FindById(id);

                if (leaveType is null)
                {
                    return NotFound();
                }

                var isSuccess = await _repo.Delete(leaveType);

                if (!isSuccess)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LeaveTypeViewModel model)
        {
            try
            {
                var leaveType = await _repo.FindById(id);

                if (leaveType is null)
                {
                    return NotFound();
                }

                var isSuccess = await _repo.Delete(leaveType);

                if (!isSuccess)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
        #endregion
    }
}
