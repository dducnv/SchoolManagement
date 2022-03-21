using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolManagement.Models;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class AccountController : Controller
    {
        private MyDBContext db;
        private UserManager<Account> userManager;
        private RoleManager<Role> roleManager;
        private SignInManager<Account, string> signInManager;

        // GET: Account
        public AccountController()
        {
            db = new MyDBContext();
            UserStore<Account> userStore = new UserStore<Account>(db);
            userManager = new UserManager<Account>(userStore);
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            roleManager = new RoleManager<Role>(roleStore);
        }


        public async Task<ActionResult> Login()
        {
            // thông tin người dùng lấy từ form.
            string username = "ducnv";
            string password = "admin@123";
            // sử dụng userManager để check thông tin đăng nhập.
            var account = await userManager.FindAsync(username, password);
            if (account != null)
            {
                // đăng nhập  thành công thì dùng SignInManager để lưu lại thông tin vừa đăng nhập.
                signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }
        }

        public async Task<ActionResult> AddAccount()
        {
            string password = "admin@123";
            Account account = new Account()
            {
                UserName = "ducnv"
            };
            var result = await userManager.CreateAsync(account, password);
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }
        }
        public async Task<ActionResult> AddRole()
        {
            Role role = new Role()
            {
                Name = "Admin"
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }
        }
    }
}