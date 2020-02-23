using System.Web.Mvc;
using Business;
using Shared.DTOs;
using BookReadingEventManagement2.Models;
using BookReadingEventManagement2.Helper;
using Business.Exceptions;
using AutoMapper;

namespace BookReadingEventManagement2.Controllers
{
    public class UserController : Controller
    {
        private UserService UserService = new UserService();
        private UserMapper UserMapper = new UserMapper();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel)
        {
            UserDTO UserDTO = UserMapper.UserViewModel2userDTO(userViewModel);
            UserDTO LoggedInUserDTO;
            try
            {
                LoggedInUserDTO = UserService.Login(UserDTO);
            }
            catch (InvalidUserException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(userViewModel);
            }

            UserViewModel LoggedInUser = UserMapper.UserDTO2UserViewModel(LoggedInUserDTO);
            Session["User"] = LoggedInUser;
            if (LoggedInUser.isAdmin)
            {
                Session["Admin"] = true;
            }
            return RedirectToAction("Home", "Event");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Home","Event");
        }

        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email,Password,FullName,ConfirmPassword")] RegisterViewModel registerViewModel)
        {
            UserDTO UserDTO = UserMapper.RegisterViewModel2UserDTO(registerViewModel);
            try
            {
                UserService.Register(UserDTO);
            }
            catch (UsernameAlreadyExists ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(registerViewModel);
            }

            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Home","Event");
            }

            return View(registerViewModel);
        }

        public ActionResult handback()
        {
            return Redirect("http://www.helpdesk.nagarro.com");
        }

        // GET: User/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,Email,Password,FullName")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        // GET: User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
    }
}
