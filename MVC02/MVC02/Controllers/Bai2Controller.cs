using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    public class Bai2Controller : Controller
    {
        /// <summary>
        /// Action trả về chuỗi ngược của input
        /// </summary>
        /// <param name="input">Chuỗi cần đảo ngược</param>
        /// <returns>Chuỗi đã được đảo ngược</returns>
        public IActionResult Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Content("Vui lòng nhập chuỗi cần đảo ngược!");
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);

            return Content($"Chuỗi gốc: {input}\nChuỗi đảo ngược: {reversedString}");
        }

        /// <summary>
        /// Action trả về độ dài của input
        /// </summary>
        /// <param name="input">Chuỗi cần đếm độ dài</param>
        /// <returns>Độ dài của chuỗi</returns>
        public IActionResult Length(string input)
        {
            if (input == null)
            {
                return Content("Chuỗi null có độ dài: 0");
            }

            int length = input.Length;
            return Content($"Chuỗi: '{input}'\nĐộ dài: {length}");
        }
    }
}
