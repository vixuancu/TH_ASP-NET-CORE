using Microsoft.AspNetCore.Mvc;

namespace MVC03.Controllers
{
    public class Bai3Controller : Controller
    {
        // GET: /Bai3/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Bai3/Add
        [HttpPost]
        public IActionResult Add(int a, int b)
        {
            int result = a + b;
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Result = result;
            return View("AddResult");
        }

        // GET: /Bai3/Multiply?a=5&b=3
        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            return Json(new
            {
                a = a,
                b = b,
                result = result,
                operation = "multiply"
            });
        }
    }
}
