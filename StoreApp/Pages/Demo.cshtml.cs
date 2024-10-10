using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Infrastructre.Extensions;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? " No Name";

        public void OnGet()
        {
        }
        public void OnPost([FromForm] string name) 
        {
            HttpContext.Session.SetJson("name", name); 
        }
    }
}
