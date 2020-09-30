using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            var viewModel = new DtoA
                            {
                                Id = 3,
                                DtoBs = new[]
                                        {
                                            new DtoB { Id = 4, },
                                            new DtoB
                                            {
                                                Id = 5,
                                                DtoCs = new[]
                                                        {
                                                            new DtoC { Id = 5 },
                                                            new DtoC { Id = 6 },
                                                        }
                                            },
                                        }
                            };

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Test")]
        public IActionResult PostTest(DtoA dtoA)
        {
            return View(dtoA);
        }
    }

    public class DtoA
    {
        [Range(1, 2, ErrorMessage = "{0} 要介於 {1} 及 {2} 之間")]
        public int Id { get; set; }

        public DtoB[] DtoBs { get; set; }
    }


    public class DtoB
    {
        [Range(1, 2, ErrorMessage = "{0} 要介於 {1} 及 {2} 之間")]
        public int Id { get; set; }

        public DtoC[] DtoCs { get; set; }
    }

    public class DtoC
    {
        [Range(1, 2, ErrorMessage = "{0} 要介於 {1} 及 {2} 之間")]
        public int Id { get; set; }
    }
}
