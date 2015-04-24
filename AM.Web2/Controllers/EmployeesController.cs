﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AM.Data;
using AM.Data.Entities;
using AM.Web2.Models;

namespace AM.Web2.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult List()
        {
            using (var context = new AMDbContext("AMConnectionString"))
            {
                var models = context.Employees.Select(e => new EmployeeModel
                {
                    Age = e.Age,
                    Id = e.EmployeeId,
                    Name = e.Name,
                });

                return View(models.ToList());
            }
        }

        public ActionResult Edit(int id)
        {
            using (var context = new AMDbContext("AMConnectionString"))
            {
                var employee = context.Employees.SingleOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    return HttpNotFound();
                }

                var model = new EmployeeModel
                {
                    Age = employee.Age,
                    Id = employee.EmployeeId,
                    Name = employee.Name,
                };
                
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AMDbContext("AMConnectionString"))
                {
                    var entity = context.Employees.SingleOrDefault(e => e.EmployeeId == model.Id);

                    if (entity == null)
                    {
                        return HttpNotFound();
                    }

                    entity.Age = model.Age;
                    entity.Name = model.Name;

                    context.SaveChanges();
                }

                return RedirectToAction("Edit", new { id = model.Id });
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new EmployeeModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AMDbContext("AMConnectionString"))
                {
                    var entity = new Employee()
                    {
                        Name = model.Name,
                        Age = model.Age,
                    };

                    context.Employees.Add(entity);

                    context.SaveChanges();

                    return RedirectToAction("Edit", new { id = entity.EmployeeId });
                }
            }

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            using (var context = new AMDbContext())
            {
                var employee = context.Employees.SingleOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    return HttpNotFound();
                }

                var model = new EmployeeDetailModel()
                {
                    Employee = new EmployeeModel()
                    {
                        Age = employee.Age,
                        Name = employee.Name,
                        Id = employee.EmployeeId,
                    },
                    TotalTimeAtWork = ComputeTotalTimeAtWork(employee.EmployeeId),
                };

                return View(model);
            }
        }

        private TimeSpan ComputeTotalTimeAtWork(int id)
        {
            using (var context = new AMDbContext())
            {
                var passes = context.Passes.Where(p => p.EmployeeId == id).OrderBy(p => p.Time).ToList();
                
                var pairs = new List<ArriveLeavePair>();

                for (int i = 0; i < passes.Count; i += 2)
                {
                    pairs.Add(new ArriveLeavePair()
                    {
                        Arrival = passes[i].Time,
                        Leave = passes[i + 1].Time,
                    });
                }

                return pairs.Aggregate(TimeSpan.Zero, (total, pair) => total + (pair.Leave - pair.Arrival));
            }
        }

        private class ArriveLeavePair
        {
            public DateTime Arrival { get; set; }

            public DateTime Leave { get; set; }
        }
    }
}