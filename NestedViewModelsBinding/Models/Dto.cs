using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NestedViewModelsBinding.Models
{
    public class Dto
    {
        public string Id { get; set; }
        [Range(1, 2, ErrorMessage = "{0} 要介於 {1} 及 {2} 之間")]
        public int Value { get; set; }
        public List<Dto> Children { get; set; } = new List<Dto>();
    }
}
