using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LikeSport.Data;
using LikeSport.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(LikeSport.Web.App_Start.Startup))]
namespace LikeSport.Web.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ActivitySportDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            //Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");
            var options = new FacebookAuthenticationOptions
            {
                AppId = "229495737575345",
                AppSecret = "6ceb700194d0f2c64d64d69bb75fa2bf",

                //AuthenticationType = "Facebook",
                //SignInAsAuthenticationType = "ExternalCookie",
                //Provider = new FacebookAuthenticationProvider
                //{


                //    OnAuthenticated = async ctx =>
                //    {

                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.Country, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.Gender, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.MobilePhone, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.OtherPhone, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.HomePhone, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.StateOrProvince, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.Email, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.Country, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.Actor, ctx.User["birthday"].ToString()));
                //        ctx.Identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, ctx.User["birthday"].ToString()));
                //    }
                //}
            };
            options.UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name";
            options.Provider = new FacebookAuthenticationProvider
            {
                OnAuthenticated = async context =>
                {
                    context.Identity.AddClaim(new Claim("FacebookAccessToken", context.AccessToken));
                    foreach (var claim in context.User)
                    {
                        var claimType = string.Format("urn:facebook:{0}", claim.Key);
                        string claimValue = claim.Value.ToString();
                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
                    }
                }

            };

            //options.Scope.Add("public_profile");
            //options.Scope.Add("email");

            ////add this for facebook to actually return the email and name
            //options.Fields.Add("email");
            //options.Fields.Add("name");


            //options.Fields.Add("user_photos");
            options.Scope.Add("public_profile");
            options.Scope.Add("user_birthday");
            options.Scope.Add("user_about_me");
            options.Scope.Add("user_friends");
            //options.Scope.Add("read_stream");
            options.Scope.Add("user_location");
            options.Scope.Add("user_photos");
            options.Scope.Add("user_hometown");
            options.Scope.Add("user_website");
            options.Scope.Add("email");

            ////add this for facebook to actually return the email and name
            options.Fields.Add("email");
            options.Fields.Add("name");


            options.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(options
                //appId: "229495737575345",
                //appSecret: "6ceb700194d0f2c64d64d69bb75fa2bf"
               
                //new FacebookAuthenticationOptions
                //{
                //    AppId = "229495737575345",
                //    AppSecret = "6ceb700194d0f2c64d64d69bb75fa2bf",
                //    Scope = { "email" },
                //    Provider = new FacebookAuthenticationProvider
                //    {
                //        OnAuthenticated = context =>
                //        {
                //            context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
                //            return Task.FromResult(true);
                //        }
                //    }
                //}
                );


            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "229495737575345",
                ClientSecret = "6ceb700194d0f2c64d64d69bb75fa2bf"
            });
        }
    }
}
