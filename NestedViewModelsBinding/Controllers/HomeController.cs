using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using NestedViewModelsBinding.Models;
namespace NestedViewModelsBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Test()
        {
            Dto viewModel = new Dto
            {
                Id = "A",
                Value = 1,
                Children = {
                    new Dto {
                        Id = "B",
                        Value = 4,
                    },
                    new Dto {
                        Id="C",
                        Value= 2,
                        Children = {
                            new Dto {
                                Id = "D",
                                Value = 5 },
                            new Dto {
                                Id = "E",
                                Value = 6
                            }
                        }
                    }
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Test")]
        public IActionResult PostTest([FromForm] Dto dto)
        {
            _logger.LogInformation("get dto" + System.Text.Json.JsonSerializer.Serialize(dto));
            return View(dto);
        }
    }

    
}
