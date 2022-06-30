using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.ViewModel;
using System.Threading.Tasks;

namespace ProductStore.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        private readonly SignInManager<IdentityUser> signInManager;
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string returnurl = null)
        {
            if (ModelState.IsValid)
            {
                var loginresult = await signInManager.PasswordSignInAsync(Model.EmailAddress, Model.Password, Model.RememberMe, false);
                if (loginresult.Succeeded)
                {
                    if (returnurl == null || returnurl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnurl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email Address or Password is Wrong!");
                }             
            }
            return Page();
        }
    }
}
