using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.ViewModel;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProductStore.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        [BindProperty]
        public Register Model { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            string password = Model.Password;
            password =  CreateHashPassword(password).ToString();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.UserName,
                    Email = Model.EmailAddress,
                    PasswordHash = CreateHashPassword(password).ToString()
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
        public string CreateHashPassword(string Password)
        {

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;

        }

    }
}

