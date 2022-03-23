using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "username,password")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var account = await userManager.FindAsync(login.username, login.password);
                if (account != null)
                {
                    signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                    await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(login);
                }

            }
            return View(login);
            
        }
        [Authorize]
        public ActionResult AddAccount()
        {
            ViewBag.Name = new SelectList(db.Roles.Where(u => !u.Name.Contains("Admin"))
                                   .ToList(), "Name", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAccount([Bind(Include = "firstname,lastname,username,roll_number,password,email,phoneNumber,address,birthday,gender,Roles")] AddAcountViewModel accountView)
        {

            if (ModelState.IsValid)
            {

                Account account = new Account()
                {
                    Firstname = accountView.firstname,
                    Lastname = accountView.lastname,
                    UserName = accountView.username,
                    Email = accountView.email,
                    PhoneNumber = accountView.phoneNumber,
                    gender = accountView.gender,
                    roll_number = accountView.roll_number,
                    address = accountView.address,
                    birthday = accountView.birthday,

                };

                var result = await userManager.CreateAsync(account, accountView.password);
                Debug.WriteLine(result.ToString());
                Debug.WriteLine(account.Id);
                var role = await userManager.AddToRoleAsync(account.Id, accountView.Roles);
                /*                var result = await userManager.AddToRolesAsync(userId, roleName1, roleName2);
                */
                if (role.Succeeded && result.Succeeded)
                {
                    return View("CreateAccountSuccess");
                }
                else
                {
                    return View("CreateAccountSuccess");
                }
            }
            return View(accountView);


        }

        public async Task<ActionResult> AddRole()
        {
            Role role = new Role()
            {
                Name = "TEACHER"
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