using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCDemoApp.Controllers
{
    public class TestController1 : Controller
    {
        TestDataAccessLayer objtest = new TestDataAccessLayer();
        // GET: /<controller>/

        public IActionResult Index()
        {
            List<Test> lst = new List<Test>();

            lst = objtest.GetAll().ToList();

            return View(lst);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Test test)

        {

            if (ModelState.IsValid)

            {

                objtest.AddTest(test);

                return RedirectToAction("Index");

            }

            return View(test);

        }

        [HttpGet]

        public IActionResult Edit(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            Test test = objtest.GetData(id);

            if (test == null)

            {

                return NotFound();

            }

            return View(test);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind]Test test)

        {

            if (id != test.AccountId)

            {

                return NotFound();

            }

            if (ModelState.IsValid)

            {

                objtest.UpdateTest(test);

                return RedirectToAction("Index");

            }

            return View(test);

        }

        [HttpGet]

        public IActionResult Details(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            Test test = objtest.GetData(id);

            if (test == null)

            {

                return NotFound();

            }

            return View(test);

        }

        [HttpGet]

        public IActionResult Delete(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            Test test = objtest.GetData(id);

            if (test == null)

            {

                return NotFound();

            }

            return View(test);

        }

        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int? id)

        {

            objtest.DeleteTest(id);

            return RedirectToAction("Index");

        }
    }

}
