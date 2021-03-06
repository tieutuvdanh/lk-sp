﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Facebook;
using LikeSport.Model;
using LikeSport.Web.App_Start;
using LikeSport.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace LikeSport.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginRegisterViewModel model)
        {
           
                if (!ModelState.IsValid)
                {
                    //return RedirectToAction("Index","Home",model);
                    return Json("Lỗi dữ liệu", JsonRequestBehavior.AllowGet);
                }
                var user = UserManager.FindByEmail(model.LoginViewModel.Email);
                if (user == null)
                {
                    //return RedirectToAction("Index", "Home", model);
                    return Json("Tài khoản không tồn tại", JsonRequestBehavior.AllowGet);
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(user.UserName, model.LoginViewModel.Password, false, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Index","Home");
                    //case SignInStatus.LockedOut:
                    //    return View("Lockout");
                    //case SignInStatus.RequiresVerification:
                    //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                    //return RedirectToAction("Index", "Home", model);
                        return Json("Tài khoản hoặc mật khẩu không đúng", JsonRequestBehavior.AllowGet);
                }
            
     
        }

        //
        // GET: /Account/VerifyCode
        //[AllowAnonymous]
        //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        //{
        //    // Require that the user has already logged in via username/password or external login
        //    if (!await SignInManager.HasBeenVerifiedAsync())
        //    {
        //        return View("Error");
        //    }
        //    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        //
        // POST: /Account/VerifyCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // The following code protects for brute force attacks against the two factor codes. 
        //    // If a user enters incorrect codes for a specified amount of time then the user account 
        //    // will be locked out for a specified amount of time. 
        //    // You can configure the account lockout settings in IdentityConfig
        //    var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(model.ReturnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid code.");
        //            return View(model);
        //    }
        //}

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //            return RedirectToAction("Index", "Home");
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        //[AllowAnonymous]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //
        // POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByNameAsync(model.Email);
        //        if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
        //        {
        //            // Don't reveal that the user does not exist or is not confirmed
        //            return View("ForgotPasswordConfirmation");
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        // Send an email with this link
        //        // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        //        // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
        //        // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //        // return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //
        // GET: /Account/ForgotPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ForgotPasswordConfirmation()
        //{
        //    return View();
        //}

        //
        // GET: /Account/ResetPassword
        //[AllowAnonymous]
        //public ActionResult ResetPassword(string code)
        //{
        //    return code == null ? View("Error") : View();
        //}

        //
        // POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var user = await UserManager.FindByNameAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("ResetPasswordConfirmation", "Account");
        //    }
        //    AddErrors(result);
        //    return View();
        //}

        //
        // GET: /Account/ResetPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ResetPasswordConfirmation()
        //{
        //    return View();
        //}

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        //[AllowAnonymous]
        //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        //{
        //    var userId = await SignInManager.GetVerifiedUserIdAsync();
        //    if (userId == null)
        //    {
        //        return View("Error");
        //    }
        //    var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
        //    var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //    return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        //
        // POST: /Account/SendCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SendCode(SendCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Generate the token and send it
        //    if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        //}

        //

        private string GetFacebookProfilePicture(ClaimsIdentity externalInfoSoruce)
        {
            var facebookUserID = externalInfoSoruce.Claims.First(c => c.Type == "urn:facebook:id").Value;
            string profilePicturePath = string.Format("http://graph.facebook.com/{0}/picture?type=large", facebookUserID);
            return profilePicturePath;
        }

        //[ChildActionOnly]
        //public  ActionResult FacebookFriends()
        //public async Task<ActionResult> FacebookFriends()
        //{
        //    var userFriends = new List<FacebookFriendsViewModel>();
        //    var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (info != null)
        //    {
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
        //            var accessToken = identity.FindFirstValue("FacebookAccessToken");
        //            //    var access_token = Session["AccessToken"].ToString();
        //            var fb = new FacebookClient(accessToken);
        //            dynamic fbFriends = fb.Get("/me/friends");

        //            foreach (var friendItem in fbFriends.data)
        //            {
        //                userFriends.Add(new FacebookFriendsViewModel()
        //                {
        //                    Name = friendItem.name,
        //                    Id = friendItem.id,
        //                    ImageUrl = String.Format("https://graph.facebook.com/{0}/picture?type=small", friendItem.id)

        //                });
        //            }
        //            //}
        //        }
        //    }
        //    return View(userFriends);
        //}
        //[FacebookAuthorize("friends_birthday")]
        //public async Task<ActionResult> Search(string friendName, FacebookContext context)
        //{
        //    var userFriends = await context.Client.GetCurrentUserFriendsAsync<MyAppUserFriendSimple>();
        //    var friendsFound = String.IsNullOrEmpty(friendName) ?
        //        userFriends.ToList() :
        //        userFriends.Where(f => f.Name.ToLowerInvariant().Contains(friendName.ToLowerInvariant())).ToList();
        //    friendsFound.ForEach(f => f.Birthday = !String.IsNullOrEmpty(f.Birthday) ? DateTime.Parse(f.Birthday).ToString("MMMM d") : "");
        //    return View(friendsFound);
        //}

        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                //case SignInStatus.LockedOut:
                //    return View("Lockout");
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

                    //return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
                    if (ModelState.IsValid)
                    {
                        // Get the information about the user from the external login provider
                        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                        if (info == null)
                        {
                            //return View("ExternalLoginFailure");
                            return RedirectToAction("Index", "Home");
                        }
                        var name = "";
                        var gender = "";
                        var firstName = "";
                        var lastName = "";
                        var birthday = "";
                        var location = "";
                        if (loginInfo.Login.LoginProvider == "Facebook")
                        {
                            var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                            var accessToken = identity.FindFirstValue("FacebookAccessToken");
                            var fb = new Facebook.FacebookClient(accessToken);
                            dynamic myInfo = fb.Get("/me?fields=email,first_name,last_name,gender,birthday,hometown");
                            loginInfo.Email = myInfo.email;
                            gender = myInfo.gender;
                            firstName = myInfo.first_name;
                            lastName = myInfo.last_name;
                            birthday = myInfo.birthday;
                            location = myInfo.hometown.name;


                        }
                        //var user = new ApplicationUser {  UserName = loginInfo.Email, Email = loginInfo.Email};
                        var user = new ApplicationUser { Location = location, BirthDay = DateTime.Parse(birthday), FisrtName = firstName, LastName = lastName, Gender = gender, UserName = loginInfo.Email, Email = loginInfo.Email, Image = GetFacebookProfilePicture(loginInfo.ExternalIdentity) };
                        var result2 = await UserManager.CreateAsync(user);
                        if (result2.Succeeded)
                        {
                            result2 = await UserManager.AddLoginAsync(user.Id, info.Login);
                            if (result2.Succeeded)
                            {
                                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                                return RedirectToLocal(returnUrl);
                            }
                        }
                        AddErrors(result2);
                    }

                    ViewBag.ReturnUrl = returnUrl;
                    return RedirectToAction("Index", "Home");

                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
                    //if (ModelState.IsValid)
                    //{
                    //    // Get the information about the user from the external login provider
                    //    var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                    //    if (info == null)
                    //    {
                    //        //return View("ExternalLoginFailure");
                    //        return RedirectToAction("Index", "Home");
                    //    }
                    //    var name = "";
                    //    var gender = "";
                    //    var firstName = "";
                    //    var lastName = "";
                    //    var birthday = "";
                    //    var location = "";
                    //    if (loginInfo.Login.LoginProvider == "Facebook")
                    //    {
                    //        var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    //        var accessToken = identity.FindFirstValue("FacebookAccessToken");
                    //        var fb = new Facebook.FacebookClient(accessToken);
                    //        dynamic myInfo = fb.Get("/me?fields=email,first_name,last_name,gender,birthday,hometown");
                    //        loginInfo.Email = myInfo.email;
                    //        gender = myInfo.gender;
                    //        firstName = myInfo.first_name;
                    //        lastName = myInfo.last_name;
                    //        birthday = myInfo.birthday;
                    //        location = myInfo.hometown.name;


                    //    }
                    //    //var name = loginInfo.ExternalIdentity.Claims.First(c => c.Type == "urn:facebook:name").Value;
                    //    //var gender = loginInfo.ExternalIdentity.Claims.First(c => c.Type == ClaimTypes.Gender).Value;
                    //    //var firstName= loginInfo.ExternalIdentity.Claims.First(c => c.Type == ClaimTypes.GivenName).Value;
                    //    //var lastName = loginInfo.ExternalIdentity.Claims.First(c => c.Type == ClaimTypes.Surname).Value;
                    //    var user = new ApplicationUser {Location = location, BirthDay = DateTime.Parse(birthday),FisrtName = firstName,LastName = lastName, Gender = gender, UserName = loginInfo.Email, Email = loginInfo.Email,Image  = GetFacebookProfilePicture (loginInfo.ExternalIdentity) };
                    //    var result2 = await UserManager.CreateAsync(user);
                    //    if (result2.Succeeded)
                    //    {
                    //        result2 = await UserManager.AddLoginAsync(user.Id, info.Login);
                    //        if (result2.Succeeded)
                    //        {
                    //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    //            return RedirectToLocal(returnUrl);
                    //        }
                    //    }
                    //    AddErrors(result2);
                    //}

                    //ViewBag.ReturnUrl = returnUrl;
                    //return RedirectToAction("Index", "Home");

            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    //return View("ExternalLoginFailure");
                    return RedirectToAction("Index", "Home");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}