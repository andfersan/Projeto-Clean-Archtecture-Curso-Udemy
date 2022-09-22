using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        //Usando as APIs do Identy para gerenciar usuarios e login dos usuarios.
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singnInManager;

        public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _singnInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            //verifica se email e password conferem e retorna true.
            var result = await _singnInManager.PasswordSignInAsync(email,
                password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                // Esta atribuindo o nome de usuario ao email.
                UserName = email,
                Email = email
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _singnInManager.SignInAsync(applicationUser, isPersistent: false);

            }
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _singnInManager.SignOutAsync();
        }
    }
}
