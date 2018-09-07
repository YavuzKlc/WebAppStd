using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Service;
using WebAppStd.Models;

namespace WebAppStd.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var user = _userService.ValidateUser(model.UserName, model.Password);
            if (ModelState.IsValid && user != null)
            {
                //if (!user.IsConfirmed)
                //{
                //    TempData["EpostaOnayMesaj"] = "E-posta adresiniz onaylı değildir. Lütfen e-posta adresinizdeki linki kullanarak e-posta adresinizi onaylayınız.";

                //    return View();
                //}
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı ve ya şifre geçersiz!");
            }

            return View(model);
        }

        // RegisterModel içerisindeki Email alanını
        // RemoteAttribute ile kontrol eder
        public JsonResult ValidateEmail(string email)
        {
            var result = _userService.ValidateEmail(email);

            if (result)
            {
                return Json("Girdiğiniz e-posta adresi sistemde zaten mevcut!", JsonRequestBehavior.AllowGet);
            }

            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        // RegisterModel içerisindeki UserName alanını
        // RemoteAttribute ile kontrol eder
        public JsonResult ValidateUserName(string UserName)
        {
            var result = _userService.ValidateUserName(UserName);

            if (result)
            {
                return Json("Girdiğiniz kullanıcı adı sistemde zaten mevcut!", JsonRequestBehavior.AllowGet);
            }

            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult ConfirmUser(Guid confirmationId)
        //{
            //if (string.IsNullOrEmpty(confirmationId.ToString()) || (!Regex.IsMatch(confirmationId.ToString(),
            //       @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}")))
            //{
            //    TempData["EpostaOnayMesaj"] = "Hesap geçerli değil. Lütfen e-posta adresinizdeki linke tekrar tıklayınız.";

            //    return View();
            //}
            //else
            //{
            //    var user = _userService.Find(confirmationId);

            //    if (!user.IsConfirmed)
            //    {
            //        user.IsConfirmed = true;
            //        _userService.Update(user);
            //        _uow.SaveChanges();

            //        FormsAuthentication.SetAuthCookie(user.UserName, true);
            //        TempData["EpostaOnayMesaj"] = "E-posta adresinizi onayladığınız için teşekkürler. Artık sitemize üyesiniz.";

            //        return RedirectToAction("Wellcome");
            //    }
            //    else
            //    {
            //        TempData["EpostaOnayMesaj"] = "E-posta adresiniz zaten onaylı. Giriş yapabilirsiniz.";

            //        return RedirectToAction("Login");
            //    }
            //}
        //}

        //public ActionResult Wellcome()
        //{
        //    return View();
        //}

        #region private methods
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        //protected override void Dispose(bool disposing)
        //{
        //    _uow.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}