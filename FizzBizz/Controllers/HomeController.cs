using FizzBizz.Models;
using FizzBizz.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FizzBizz.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckFizzBizz(string[] category, [FromServices] IFizzBuzzService fizzBuzzService)
        {
            var returnResponse= new List<ReturnResponseModel>();
            try
            {
                foreach (var item in category)
                {
                    if (string.IsNullOrEmpty(item))
                        returnResponse.Add(new ReturnResponseModel { Input = item, Result = "Invalid Item" });
                    else
                    {
                        var isConverted=Int32.TryParse(item, out int j);
                        if (isConverted)
                        {
                            var responseFromService = fizzBuzzService.CheckFizzBuzz(j);
                            returnResponse.Add(new ReturnResponseModel { Input = item, Result = responseFromService });
                        }
                        else
                        {
                            returnResponse.Add(new ReturnResponseModel { Input = item, Result = "Invalid Item" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnResponse.Add(new ReturnResponseModel { Input = String.Empty, Result = ex.Message });
            }
            return new JsonResult(returnResponse, new JsonSerializerOptions { PropertyNamingPolicy=null});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }    
}