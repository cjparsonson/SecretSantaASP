using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecretSanta.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string? DayName { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Secret Santa";
            DayName = System.DateTime.Now.ToString("dddd");
        }
    }
}
