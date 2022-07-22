using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        public ActionResult Index()
        {
            List<Employee> emps = new List<Employee>();
            emps = (from e in
                        dbContext.Employees.Include(x=>x.Department).OrderBy(x=>x.EmplyeeName) 
                    select e).ToList();
            return View(emps);
        }

        public ActionResult Create()
        {
            ViewBag.Departments = dbContext.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            //user image handling
            var image = HttpContext.Request.Files;
            if (image.Count > 0)
            {
                //in case of user uploaded image
                //step 1 : set a unique name for the image and put extention
                string imageName = Guid.NewGuid() + Path.GetExtension(image[0].FileName);

                //step 2 : create the path where we save the image
                var fileStraem = new FileStream(Path.Combine(@"Images/","",imageName),FileMode.Create);

                //step 3 : copy the file to the path
               // image[0].CopyTo(fileStraem);
                model.ImageUser = imageName;
                
            } else if (model.ImageUser == null && model.EmployeeID == null)
            {
                //in case of user didn't upload image
                model.ImageUser = "Default.jpg";
            }
            else
            {
                //in case of edit function
                model.ImageUser = model.ImageUser;
            }
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = dbContext.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Departments = dbContext.Departments.OrderBy(x => x.DepartmentName).ToList();
            var result=  dbContext.Employees.Find(id);
            return View("Create", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Employees.Find(id);
            if (result != null)
            {
                dbContext.Employees.Remove(result);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = dbContext.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View(model);
        }
    }
}