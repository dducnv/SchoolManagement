using ExcelDataReader;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using StudentManage.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public ActionResult AddAccount()
        {
            ViewBag.Name = new SelectList(db.Roles.Where(u => !u.Name.Contains("Admin"))
                                   .ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAccount([Bind(Include = "firstname,lastname,username,roll_number,password,email,phoneNumber,address,birthday,gender,Roles")] AddAcountViewModel accountView)
        {
            var password = "admin@123";
            Account account = new Account()
            {
                UserName = "admin123",
              
            };
            var result = await userManager.CreateAsync(account, password);
            var role = await userManager.AddToRoleAsync(account.Id, "ADMIN");
            /*                var result = await userManager.AddToRolesAsync(userId, roleName1, roleName2);
            */
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountSuccess");
            }

         /*   if (ModelState.IsValid)
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
                var role = await userManager.AddToRoleAsync(account.Id, accountView.Roles);
                *//*                var result = await userManager.AddToRolesAsync(userId, roleName1, roleName2);
                *//*
                if ( result.Succeeded)
                {
                    return View("CreateAccountSuccess");
                }
                else
                {
                    return View("CreateAccountSuccess");
                }
            }*/
            return View(accountView);


        }
        [HttpPost]
        public async Task<ActionResult> ImportAccountExcel(HttpPostedFileBase accountFile)
        {
            if (accountFile != null)
            {
                if (accountFile.ContentType == "application/vnd.ms-excel" || accountFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = accountFile.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    accountFile.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
                    {
                        using (var stream = System.IO.File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
                        {

                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                do
                                {
                                    while (reader.Read())
                                    {
                                        if (reader.GetValue(0).ToString() != "First Name")
                                        {
                                            Account account = new Account()
                                            {
                                                Firstname = reader.GetValue(0).ToString(),
                                                Lastname = reader.GetValue(1).ToString(),
                                                UserName = reader.GetValue(2).ToString(),
                                                Email = reader.GetValue(3).ToString(),
                                                PhoneNumber = reader.GetValue(4).ToString(),
                                                Gender = reader.GetValue(5).ToString(),
                                                roll_number = reader.GetValue(6).ToString(),
                                                Address = reader.GetValue(9).ToString(),
                                                Birthday = reader.GetValue(7).ToString(),

                                            };
                                            var result = await userManager.CreateAsync(account, reader.GetValue(6).ToString());
                                            var role = await userManager.AddToRoleAsync(account.Id, reader.GetValue(8).ToString());
                                         

                                        }
                                    }

                                } while (reader.NextResult());
                            }

                        }
                    }
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return RedirectToAction("AddAccount", "Account");
                }
            }
            return RedirectToAction("AddAccount", "Account");

        }
        public async Task<ActionResult> AddRole()
        {
            Role role = new Role()
            {
                Name = "STUDENT"
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