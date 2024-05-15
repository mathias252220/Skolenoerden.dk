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
            for (int i = 0; i < numberOfOutposts; i++)
            {
                outposts.Add(string.Empty);
            }
		}

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
        public IActionResult AddOutpost()
        {
            numberOfOutposts++;
            return RedirectToPage(numberOfOutposts);
        }
        public IActionResult SubtractOutpost()
        {
            numberOfOutposts--;
            return RedirectToPage(numberOfOutposts);
        }
    }
}
