using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MVC02.Controllers
{
    public class Bai2Controller : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Receive(string username, string password, string email)
        {
            // Kiểm tra username không rỗng
            if (string.IsNullOrWhiteSpace(username))
            {
                ViewBag.ErrorMessage = "Username không được để trống.";
                return View("Register");
            }

            // Kiểm tra password có ít nhất 8 ký tự và chứa ít nhất một số
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || !password.Any(char.IsDigit))
            {
                ViewBag.ErrorMessage = "Password phải có ít nhất 8 ký tự và chứa ít nhất một số.";
                return View("Register");
            }

            // Kiểm tra email đúng định dạng
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailPattern))
            {
                ViewBag.ErrorMessage = "Email không đúng định dạng.";
                return View("Register");
            }

            // Nếu tất cả điều kiện đều hợp lệ
            ViewBag.SuccessMessage = $"Xin chào {username}, Bạn đã đăng ký thành công";
            return View();
        }

        // GET: Hiển thị form nhập liệu cho GetRandomNumbers
        public IActionResult GetRandomNumbers()
        {
            return View();
        }

        // POST: Xử lý sinh số ngẫu nhiên
        [HttpPost]
        public IActionResult GetRandomNumbers(byte lb, byte ub, byte n)
        {
            // Kiểm tra điều kiện: lb < ub và n > 0
            if (lb >= ub)
            {
                ViewBag.ErrorMessage = "Lower bound phải nhỏ hơn Upper bound.";
                return View();
            }

            if (n <= 0)
            {
                ViewBag.ErrorMessage = "Số lượng n phải lớn hơn 0.";
                return View();
            }

            // Sinh ra n số ngẫu nhiên trong khoảng [lb, ub]
            Random random = new Random();
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                randomNumbers.Add(random.Next(lb, ub + 1)); // +1 vì Next() không bao gồm giá trị cuối
            }

            // Truyền dữ liệu cho view ShowRandomNumber
            ViewBag.LowerBound = lb;
            ViewBag.UpperBound = ub;
            ViewBag.Count = n;

            return View("ShowRandomNumber", randomNumbers);
        }
    }
}
