using AutoMapper;
using leave_management.Data;
using leave_management.Models;
using leave_management.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationRepository _allocationRepo;
        private readonly ILeaveTypesRepository _typeRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManger;

        public LeaveAllocationController(
            ILeaveTypesRepository typeRepo,
            ILeaveAllocationRepository allocationRepo,
            IMapper mapper,
            UserManager<Employee> userManager)
        {
            _typeRepo = typeRepo;
            _allocationRepo = allocationRepo;
            _mapper = mapper;
            _userManger = userManager;
        }

        #region Index
        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _typeRepo.GetAll();
            var mappedLeaveTypes = _mapper.Map<IEnumerable<LeaveType>, IEnumerable<LeaveTypeViewModel>>(leaveTypes);
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };

            return View(model);
        }
        #endregion

        #region Set Leave
        public async Task<ActionResult> SetLeave(int id)
        {
            var leaveType = await _typeRepo.FindById(id);
            var employees = _userManger.GetUsersInRoleAsync("Employee").Result;

            foreach (var employee in employees)
            {
                if (_allocationRepo.CheckAllocation(id, employee.Id))
                {
                    continue;
                }

                var allocation = new LeaveAllocationViewModel()
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = employee.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
                await _allocationRepo.Create(leaveAllocation);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        public async Task<ActionResult> ListEmployees()
        {
            var employees = await _userManger.GetUsersInRoleAsync("Employee");
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);

            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
