using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkattejagtGeneratorWeb.Pages.SkattejagtGenerator
{
    public class SkattejagtGeneratorModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int numberOfOutposts { get; set; } = 1;
        [BindProperty]
        public List<string> outposts { get; set; } = new List<string>();
        public void OnGet()
        {
		}
        public IActionResult OnPost()
        {
        }
    }
}
