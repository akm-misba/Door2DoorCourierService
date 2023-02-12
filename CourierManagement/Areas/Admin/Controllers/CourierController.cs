using CourierManagement.Areas.Admin.Models;
using CourierManagement.Areas.Admin.Models.Account;
using CourierManagement.Common.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using QuickMailer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MailMessage = CourierManagement.Areas.Admin.Models.MailMessage;


namespace CourierManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourierController : Controller
    {
        //private readonly IHostingEnvironment Environment;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CourierController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<IdentityUser> _userSignIn;
        //public CourierController(IHostingEnvironment _environment)
        //{
        //    Environment = _environment;
        //}

        public CourierController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<CourierController> logger,
            IEmailSender emailSender,
            
            SignInManager<IdentityUser> userSignIn)
        
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _userSignIn = userSignIn;
            
        }

        public async Task<IActionResult> Register(string returnUrl = null)
        {
            var model = new RegisterModel();
            model.ReturnUrl = returnUrl;
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();



            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.ActionLink(
                        "/Account/ConfirmEmail",
                        values: new { userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToAction("Index", "Courier", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [TempData]
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            var model = new LoginModel();
            model.ReturnUrl = returnUrl;

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("DashBoard");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Courier");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult CashVoucher()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Discount()
        {
            return View();
        }
      
      
       
        [HttpPost]
        public IActionResult Discount(PriceCalculationModel model, string command)
        {

            if (command == "Bkash")
            
              model.Cost = model.Total* 0.1;
               
            if (command == "Nagad")
                model.Cost = model.Total* 0.05;
            if (command == "Distance")
                model.Cost = model.Total * 0.02;
            return View(model);

        }
        public IActionResult FlashSale()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Price()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Price(PriceCalculationModel model, string command)
        {

            if (command == "By_Air")
                model.Cost = model.Quantity * model.Distance * 49;
            if (command == "By_Ocean")
                model.Cost = model.Quantity * model.Distance * 39;
            if (command == "Land_Transport")
                model.Cost = model.Quantity * model.Distance * 0.59;
            return View(model);

        }

        public IActionResult AddCustomer()
        {
            var model = new AddCustomerModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCustomer(AddCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddCustomer();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Account");
                    _logger.LogError(ex, "Add Account Failed");
                }

            }
            return View(model);
        }
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlCommand com1 = new SqlCommand();
        SqlDataReader dr1;
        SqlCommand com3 = new SqlCommand();
        SqlDataReader dr3;

        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        void connetionString()
        {
            con.ConnectionString = "Server=DESKTOP-234E1GE\\misba;Database=CourierManagement; User Id=CouruerManagement; Password =Misbah38;";
        }
        const string SetUserDetails = "emailid";
        [HttpPost]
        public ActionResult CustomerLogin(CustomerLoginModel acc)
        {
            connetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customers where Email='" + acc.Email + "' and Password= '" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                HttpContext.Session.SetString(SetUserDetails, acc.Email.ToString());
                con.Close();
                return RedirectToAction("UserProfile", "Courier");
            }
            else
            {
                con.Close();
                return View("Index");
            }

        }



        [HttpGet]
        public ActionResult CourierLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourierLogin(CourierLoginModel acc)
        {
            connetionString();
            con.Open();
            com3.Connection = con;
            com3.CommandText = "select * from Couriers where Email='" + acc.Email + "' and Password= '" + acc.Password + "'";
            dr3 = com3.ExecuteReader();
            if (dr3.Read())
            {

                HttpContext.Session.SetString(SetUserDetails, acc.Email.ToString());
                con.Close();
                return RedirectToAction("CourierProfile", "Courier");
            }
            else
            {
                con.Close();
                return View("Index");
            }

        }


        /*------------------------------------------Admin---------------------*/
        SqlCommand com4 = new SqlCommand();
        SqlDataReader dr4;
        SqlCommand com5 = new SqlCommand();
        SqlDataReader dr5;
        SqlCommand com6 = new SqlCommand();
        SqlDataReader dr6;
        public IActionResult DashBoard()
        {
            connetionString();
            con.Open();
            com4.Connection = con;

            com4.CommandText = " select COUNT(*) from Customers  ";
            dr4 = com4.ExecuteReader();
           
            if (dr4.Read())
            {
                ViewData["TOTALCUSTOMER"] = dr4.GetInt32(0);
                con.Close();
                
            }
            else
            {

                con.Close();
               
            }
            connetionString();
            con.Open();
            com5.Connection = con;
           
            com5.CommandText = " select COUNT(*) from Couriers  ";
            dr5 = com5.ExecuteReader();
            if (dr5.Read())
            {
                ViewData["TOTALCOURIER"] = dr5.GetInt32(0);
                con.Close();
                
            }
            else
            {

                con.Close();
               
            }
            connetionString();
            con.Open();
            com6.Connection = con;

            com6.CommandText = " select COUNT(*) from Orders  ";
            dr6 = com6.ExecuteReader();
            if (dr6.Read())
            {
                ViewData["TOTALORDER"] = dr6.GetInt32(0);
                con.Close();

            }
            else
            {

                con.Close();

            }
           
            return View();
        }

        [HttpPost ]
        public ActionResult DashBoard(MailMessage mailMessage)
        {

            connetionString();
            con.Open();
            com4.Connection = con;

            com4.CommandText = " select COUNT(*) from Customers  ";
            dr4 = com4.ExecuteReader();

            if (dr4.Read())
            {
                ViewData["TOTALCUSTOMER"] = dr4.GetInt32(0);
                con.Close();

            }
            else
            {

                con.Close();

            }
            connetionString();
            con.Open();
            com5.Connection = con;

            com5.CommandText = " select COUNT(*) from Couriers  ";
            dr5 = com5.ExecuteReader();
            if (dr5.Read())
            {
                ViewData["TOTALCOURIER"] = dr5.GetInt32(0);
                con.Close();

            }
            else
            {

                con.Close();

            }
            connetionString();
            con.Open();
            com6.Connection = con;

            com6.CommandText = " select COUNT(*) from Orders  ";
            dr6 = com6.ExecuteReader();
            if (dr6.Read())
            {
                ViewData["TOTALORDER"] = dr6.GetInt32(0);
                con.Close();

            }
            else
            {

                con.Close();

            }
           
            
            try
            {
                List<string> toMailAddress = new List<string>();
                List<string> ccMailAddress = new List<string>();
                List<string> bccMailAddress = new List<string>();
                Email email = new Email();
                toMailAddress = GetValidMail(mailMessage.To);
                ccMailAddress = GetValidMail(mailMessage.Cc);
                bccMailAddress = GetValidMail(mailMessage.Bcc);
                string mgs = "Email send failed.";

                List<Attachment> attachments = new List<Attachment>();
                if (mailMessage.Files != null)
                {
                    foreach (var file in mailMessage.Files)
                    {
                        Attachment attachment = new Attachment(file.OpenReadStream(), file.FileName);
                        attachments.Add(attachment);
                    }

                }

                bool isSend = email.SendEmail(toMailAddress, Credential.Email, Credential.Password, mailMessage.Subject,
                     mailMessage.Body, ccMailAddress, bccMailAddress, attachments);
                if (isSend)
                {
                    mgs = "Email has been send.";
                    ModelState.Clear();
                }

                ViewBag.Mgs = mgs;
                return View();
            }
             
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            return View();
        }

        public List<string> GetValidMail(List<string> mails)
        {
            List<string> validMails = new List<string>();
            Email email = new Email();
            if (mails == null)
            {
                return validMails;
            }
            if (mails.Any())
            {

                foreach (var mail in mails)
                {
                    bool isValid = email.IsValidEmail(mail);
                    if (isValid)
                    {
                        validMails.Add(mail);
                    }
                }
            }

            return validMails;
        }
        public IActionResult ManageCustomer()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new CustomerListModel();
            return View(model);
        }
        public JsonResult GetCustomerData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerListModel();
            var data = model.GetCustomers(dataTablesModel);
            return Json(data);
        }

        public IActionResult EditCustomer(int id)
        {
            var model = new EditCustomerModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditCustomer(EditCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteCustomer(int id)
        {
            var model = new CustomerListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageCustomer));

        }


        public IActionResult ManageCourier()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new CourierListModel();
            return View(model);
        }
        public JsonResult GetCourierData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new CourierListModel();
            var data = model.GetCouriers(dataTablesModel);
            return Json(data);
        }

        public IActionResult EditCourier(int id)
        {
            var model = new EditCourierModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditCourier(EditCourierModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteCourier(int id)
        {
            var model = new CourierListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageCourier));

        }
        public IActionResult AddCourier()
        {
            var model = new AddCourierModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCourier(AddCourierModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddCourier();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Account");
                    _logger.LogError(ex, "Add Account Failed");
                }

            }
           // return View(model);
            return RedirectToAction(nameof(AddCourier));
        }


        public IActionResult ManageHelp()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new HelpListModel();
            return View(model);
        }
        public JsonResult GetHelpData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new HelpListModel();
            var data = model.GetHelps(dataTablesModel);
            return Json(data);
        }

        public IActionResult EditHelp(int id)
        {
            var model = new EditHelpModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHelp(EditHelpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteHelp(int id)
        {
            var model = new HelpListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageHelp));

        }


        public IActionResult ManageOrder()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new OrderListModel();
            return View(model);
        }
        public JsonResult GetOrderData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new OrderListModel();
            var data = model.GetOrders(dataTablesModel);
            return Json(data);
        }

        public IActionResult EditOrder(int id)
        {
            var model = new EditOrderModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditOrder(EditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteOrder(int id)
        {
            var model = new OrderListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageOrder));

        }


        public IActionResult ManageTrack()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new TrackListModel();
            return View(model);
        }
        public JsonResult GetTrackData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new TrackListModel();
            var data = model.GetTracks(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddTrack()
        {
            var model = new AddTrackModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddTrack(AddTrackModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddTrack();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Track");
                    _logger.LogError(ex, "Add Track Failed");
                }

            }
            return RedirectToAction(nameof(AddTrack));
            //return View(model);
        }
        public IActionResult EditTrack(int id)
        {
            var model = new EditTrackModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditTrack(EditTrackModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

             return View(model);
           
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeleteTrack(int id)
        {
            var model = new TrackListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageTrack));

        }



        public IActionResult ManagePickup()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new PickupListModel();
            return View(model);
        }
        public JsonResult GetPickupData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new PickupListModel();
            var data = model.GetPickups(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddPickup()
        {
            var model = new AddPickupModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddPickup(AddPickupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddPickup();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Pickup");
                    _logger.LogError(ex, "Add Pickup Failed");
                }

            }
            return RedirectToAction(nameof(AddPickup));
            //return View(model);
        }
        public IActionResult EditPickup(int id)
        {
            var model = new EditPickupModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPickup(EditPickupModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult DeletePickup(int id)
        {
            var model = new PickupListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManagePickup));

        }

        public IActionResult Authorize()
        {
            return View();
        }
        /* -----------------------------------------------Customer------------------------------*/
        public IActionResult UserProfile(TrackingModel tm)
        {
            var display = HttpContext.Session.GetString(SetUserDetails);
            connetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customers where Email='" + display + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                string id = dr["Id"].ToString();
                string name = dr["Name"].ToString();
                ViewData["username"] = name;
                ViewData["id"] = id;

            }
            con.Close();
            connetionString();
            con.Open();
            com1.Connection = con;
            com1.CommandText = "select * from Tracks where Id='" + tm.Id + "' ";
            dr1 = com1.ExecuteReader();
            if (dr1.Read())
            {
                string status = dr1["Status"].ToString();
                ViewData["status"] = status;
            }
            con.Close();
            return View();
        }

        public IActionResult AddOrder()
        {
            var model = new AddOrderModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddOrder(AddOrderModel model)
        {
            var display = HttpContext.Session.GetString(SetUserDetails);
            connetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customers where Email='" + display + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                string name = dr["Name"].ToString();
                ViewData["username"] = name;

            }
            con.Close();
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddOrder();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Order");
                    _logger.LogError(ex, "Add Order Failed");
                }

            }
             return View(model);

            //return RedirectToAction(nameof(AddOrder));
        }

        public JsonResult CustomerData()
        {
            var data = "";
            var display = HttpContext.Session.GetString(SetUserDetails);
            connetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customers where Email='" + display + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                data = dr["Id"].ToString();

            }
            con.Close();
            return Json(data);
        }

        public IActionResult CustomerUpdate(int id)
        {
            var model = new EditCustomerModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CustomerUpdate(EditCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult AddHelp()
        {
            var model = new AddHelpModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddHelp(AddHelpModel model)
        {
            var display = HttpContext.Session.GetString(SetUserDetails);
            connetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Customers where Email='" + display + "' ";
            dr = com.ExecuteReader();
            con.Close();
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddHelp();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to send message");
                    _logger.LogError(ex, "Send Message Failed");
                }

            }
            // return View(model);
            return RedirectToAction(nameof(AddHelp));
        }


        /*______________________________________________________________________Courier____________________________________________________*/

        public IActionResult CourierProfile()
        {
            var display = HttpContext.Session.GetString(SetUserDetails);
            connetionString();
            con.Open();
            com3.Connection = con;
            com3.CommandText = "select * from Couriers where Email='" + display + "' ";
            dr3 = com3.ExecuteReader();
            if (dr3.Read())
            {
                string id = dr3["Id"].ToString();
                string name = dr3["Name"].ToString();
                ViewData["username"] = name;
                ViewData["id"] = id;

            }
            con.Close();
            var model = new OrderListForCourier();
            return View(model);
        }
        public JsonResult GetOrderDataByCourier()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new OrderListForCourier();
            var data = model.GetOrders(dataTablesModel);
            return Json(data);
        }

        public IActionResult EditOrderByCourier(int id)
        {
            var model = new EditOrderForCourier();
            model.LoadModelDataForCourier(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditOrderByCourier(EditOrderForCourier model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult CourierUpdate(int id)
        {
            var model = new EditCourierModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CourierUpdate(EditCourierModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

    }
}
