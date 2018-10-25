using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inspectral.Pages.Tests
{
    public class DoublePostModel : PageModel
    {
        public void OnGet()
        {
            Message = "OnGet";
        }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostTratata()
        {
            Message = "OnPostAsync";

            return Page();
        }
        [HttpPost]
        [ActionName("Post2")]
        public IActionResult OnPost2()
        {
            Message = "OnPostAsync2";

            return Page();
        }
    }
}