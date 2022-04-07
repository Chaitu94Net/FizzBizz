using FizzBizz.Controllers;
using FizzBizz.Models;
using FizzBizz.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FizzBuzzTest
{
    public class FizzBussServiceFacts
    {
        [Fact]
        public void DivisibleByThree()
        {
            var service = new FizzBuzzService();
            var controller = new HomeController();

            string[] category = new string[] { "1", "3" };
            var result= controller.CheckFizzBizz(category,service);

            Assert.NotNull(result);
            var response = (result.Value) as List<ReturnResponseModel>;
            var checkWith=response?.FirstOrDefault(item=>item.Input=="3");
            Assert.Equal("fizz",checkWith?.Result);        
        }

        [Fact]
        public void DivisibleByFive()
        {
            var service = new FizzBuzzService();
            var controller = new HomeController();

            string[] category = new string[] { "1", "5", };
            var result = controller.CheckFizzBizz(category, service);

            Assert.NotNull(result);
            var response = (result.Value) as List<ReturnResponseModel>;
            var checkWith = response?.FirstOrDefault(item => item.Input == "5");
            Assert.Equal("buzz", checkWith?.Result);
        }

        [Fact]
        public void DivisibleByThreeFive()
        {
            var service = new FizzBuzzService();
            var controller = new HomeController();

            string[] category = new string[] { "15"};
            var result = controller.CheckFizzBizz(category, service);

            Assert.NotNull(result);
            var response = (result.Value) as List<ReturnResponseModel>;       
            Assert.Equal("fizzbuzz", response?.First().Result);
        }

        [Fact]
        public void InvalidEmpty()
        {
            var service = new FizzBuzzService();
            var controller = new HomeController();

            string[] category = new string[] { "" };
            var result = controller.CheckFizzBizz(category, service);

            Assert.NotNull(result);
            var response = (result.Value) as List<ReturnResponseModel>;
            Assert.Equal("Invalid Item", response?.First().Result);
        }
    }
}