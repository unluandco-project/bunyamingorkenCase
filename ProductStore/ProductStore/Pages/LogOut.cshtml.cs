using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ProductStore.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }
        public  IActionResult OnPostDontLogOut()
        {
            return RedirectToPage("Index");
        }

    }
}
