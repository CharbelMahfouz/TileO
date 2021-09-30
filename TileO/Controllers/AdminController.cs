using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TileO.Data;
using TileO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TileO.Controllers
{
    public class AdminController : Controller
    {
        private static Random random = new Random();
        public static InHealthContext _context;
        public static ApplicationDbContext _context2;
        public AdminController(InHealthContext context, ApplicationDbContext context2)
        {
            _context = context;
            _context2 = context2;
        }


        [Authorize]
        public IActionResult Index()
        {
            ViewBag.HeadTitle = "Admin Dashboard";
            return View();
        }




        #region Banners
        public ActionResult Banners()
        {          
            var Banners = _context.HomeBanner.Where(x=>x.IsDeleted == false).OrderByDescending(x=>x.OrderId).ToList();
            return View(Banners);
        }

        public ActionResult CreateBanner()
        {
            return View();
        }


        public ActionResult Banner(int id)
        {         
            HomeBanner Banner = _context.HomeBanner.Where(x=>x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if (Banner == null)
            {
                return RedirectToAction("Banners");
            }
            return View(Banner);

        }
      
        public static string RandomStringNoCharacters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<string> SaveBanner()
        {          
            var newSubcat = new HomeBanner();
            newSubcat.CreatedDate = DateTime.UtcNow;
            newSubcat.IsDeleted = false;
            newSubcat.OrderId = Convert.ToInt32(Request.Form["OrderID"]);
            newSubcat.Title = Request.Form["Title"].ToString();         
            var file = Request.Form.Files["Image"];         
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.Image = NewFileName;
            }
            if (Request.Form["Id"].ToString() == "0")
            {
                _context.HomeBanner.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.HomeBanner.Where(x => x.Id == currID).FirstOrDefault();
                if (newSubcat.Image != null)
                {
                    currBanner.Image = newSubcat.Image;
                }
                
                currBanner.OrderId = newSubcat.OrderId;
                currBanner.Title = newSubcat.Title;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }

        public string DeleteBanner()
        {
            
            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.HomeBanner.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }


        #endregion

        #region Welcome
       
        public ActionResult Welcome()
        {
            Home Banner = _context.Home.FirstOrDefault();           
            return View(Banner);

        }

        public async Task<string> SaveWelcome()
        {
            var newSubcat = new Home();
            newSubcat.Section1Description = Request.Form["Section1Description"].ToString();
            newSubcat.Section1Title = Request.Form["Section1Title"].ToString();        
            var file = Request.Form.Files["Image"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.Section1Image = NewFileName;
                }
                        
                var currBanner = _context.Home.FirstOrDefault();
                if (newSubcat.Section1Image != null)
                {
                    currBanner.Section1Image = newSubcat.Section1Image;
                }
                currBanner.Section1Description = newSubcat.Section1Description;
                currBanner.Section1Title = newSubcat.Section1Title;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            
        }




        #endregion


        #region Glance

        public ActionResult glance()
        {
            Home Banner = _context.Home.FirstOrDefault();
            return View(Banner);

        }

        public async Task<string> SaveGlance()
        {
            var newSubcat = new Home();
            newSubcat.Section2Description = Request.Form["Section2Description"].ToString();
            newSubcat.Section2Subtitle = Request.Form["Section2Subtitle"].ToString();
            newSubcat.Section2Title = Request.Form["Section2Title"].ToString();
            var file = Request.Form.Files["Image"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.Section2Image = NewFileName;
            }

            var currBanner = _context.Home.FirstOrDefault();
            if (newSubcat.Section2Image != null)
            {
                currBanner.Section2Image = newSubcat.Section2Image;
            }
            currBanner.Section2Description = newSubcat.Section2Description;
            currBanner.Section2Title = newSubcat.Section2Title;
            currBanner.Section2Subtitle = newSubcat.Section2Subtitle;

            _context.SaveChanges();
            return currBanner.Id.ToString();

        }




        #endregion


        #region Why

        public ActionResult why()
        {
            Home Banner = _context.Home.FirstOrDefault();
            ViewBag.HomeWhy = _context.HomeWhy.Where(x => x.IsDeleted == false).ToList();
            return View(Banner);

        }

        public ActionResult edithomewhy(int id)
        {
            HomeWhy Banner = _context.HomeWhy.Where(x=>x.Id == id).FirstOrDefault();
            return View(Banner);

        }


        public async Task<string> SaveHomeWhy()
        {
            var newSubcat = new HomeWhy();          
            newSubcat.IsDeleted = false;

            newSubcat.Title = Request.Form["Title"].ToString();
            newSubcat.Description = Request.Form["Description"].ToString();
            var file = Request.Form.Files["Image"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.Icon = NewFileName;
            }
            if (Request.Form["Id"].ToString() == "0")
            {
                _context.HomeWhy.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.HomeWhy.Where(x => x.Id == currID).FirstOrDefault();
                if (newSubcat.Icon != null)
                {
                    currBanner.Icon = newSubcat.Icon;
                }

                currBanner.Description = newSubcat.Description;
                currBanner.Title = newSubcat.Title;
                _context.SaveChanges();
                return currBanner.Id.ToString();
            }
        }


        public ActionResult createhomewhy()
        {
          
            return View();

        }
        public string DeleteHomeWhy()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.HomeWhy.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }

        public string SaveWhy()
        {
            var newSubcat = new Home();
            newSubcat.WhyDescription = Request.Form["WhyDescription"].ToString();
            newSubcat.WhyTitle = Request.Form["WhyTitle"].ToString();          
            var currBanner = _context.Home.FirstOrDefault();           
            currBanner.WhyDescription = newSubcat.WhyDescription;          
            currBanner.WhyTitle = newSubcat.WhyTitle;
            _context.SaveChanges();
            return currBanner.Id.ToString();

        }




        #endregion

        #region About

        public ActionResult aboutCompany()
        {
            AboutCompany Banner = _context.AboutCompany.FirstOrDefault();
            return View(Banner);

        }

        public async Task<string> SaveAboutCompany()
        {
            var newSubcat = new AboutCompany();
            newSubcat.Title1 = Request.Form["Title1"].ToString();
            newSubcat.Title2 = Request.Form["Title2"].ToString();
            newSubcat.Description = Request.Form["Description"].ToString();
            var file = Request.Form.Files["Image"];
            if (file != null)
            {
                var NewFileName = RandomStringNoCharacters(20) + file.FileName.ToString();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", NewFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                newSubcat.Image = NewFileName;
            }

            var currBanner = _context.AboutCompany.FirstOrDefault();
            if (newSubcat.Image != null)
            {
                currBanner.Image = newSubcat.Image;
            }
            currBanner.Title1 = newSubcat.Title1;
            currBanner.Title2 = newSubcat.Title2;
            currBanner.Description = newSubcat.Description;

            _context.SaveChanges();
            return currBanner.Id.ToString();

        }




        #endregion


        #region Careers

        public ActionResult careers()
        {
            Career Banner = _context.Career.FirstOrDefault();
            ViewBag.AllCareers = _context.CareerVacancies.Where(x=>x.IsDeleted == false).ToList();
            return View(Banner);

        }

        public string SaveCareers()
        {
            var newSubcat = new Career();
            newSubcat.Title = Request.Form["Title"].ToString();
        
            var currBanner = _context.Career.FirstOrDefault();
           
            currBanner.Title = newSubcat.Title;
     

            _context.SaveChanges();
            return currBanner.Id.ToString();

        }


        public ActionResult createvacancy()
        {
            
            return View();

        }

        public ActionResult vacancy(int id)
        {
            CareerVacancies Banner = _context.CareerVacancies.Where(x=>x.Id==id).FirstOrDefault();
           
            return View(Banner);

        }


        public string SaveVacancy()
        {
            var newSubcat = new CareerVacancies();
            newSubcat.CreatedDate = DateTime.UtcNow;
            newSubcat.IsDeleted = false;
  
            newSubcat.About = Request.Form["About"].ToString();
            newSubcat.Qualifications = Request.Form["Qualifications"].ToString();
            newSubcat.Responsabilities = Request.Form["Responsabilities"].ToString();
            newSubcat.Status = Request.Form["Status"].ToString();
            newSubcat.Summary = Request.Form["Summary"].ToString();
            newSubcat.Title = Request.Form["Title"].ToString();
            newSubcat.Experience = Request.Form["Experience"].ToString();


            if (Request.Form["Id"].ToString() == "0")
            {
                _context.CareerVacancies.Add(newSubcat);
                _context.SaveChanges();
                return newSubcat.Id.ToString();
            }
            else
            {
                int currID = Convert.ToInt32(Request.Form["Id"]);
                var currBanner = _context.CareerVacancies.Where(x => x.Id == currID).FirstOrDefault();
               
                
                currBanner.Title = newSubcat.Title;
                currBanner.Qualifications = newSubcat.Qualifications;
                currBanner.Responsabilities = newSubcat.Responsabilities;
                currBanner.Summary = newSubcat.Summary;
                currBanner.Experience = newSubcat.Experience;
                currBanner.About = newSubcat.About;

                _context.SaveChanges();
                return currBanner.Id.ToString();
            }


           

        }

        public string DeleteVacancy()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.CareerVacancies.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = true;
            _context.SaveChanges();
            return "Deleted";
        }
        #endregion



        #region Contact

        public ActionResult ContactInfo()
        {
            ContactInfo Banner = _context.ContactInfo.FirstOrDefault();
            return View(Banner);

        }

        public  string SaveContactInfo()
        {
            var newSubcat = new ContactInfo();
            newSubcat.Address = Request.Form["Address"].ToString();
            newSubcat.Phone = Request.Form["Phone"].ToString();
            newSubcat.Email = Request.Form["Email"].ToString();
           

            var currBanner = _context.ContactInfo.FirstOrDefault();
           
            currBanner.Address = newSubcat.Address;
            currBanner.Phone = newSubcat.Phone;
            currBanner.Email = newSubcat.Email;

            _context.SaveChanges();
            return currBanner.Id.ToString();

        }

        public ActionResult Messages()
        {
            var Banners = _context.ContactMessages.Where(x => x.IsDeleted == "false").OrderByDescending(x => x.Id).ToList();
            return View(Banners);
        }

        public ActionResult Message(int id)
        {
            ContactMessages Banner = _context.ContactMessages.Where(x => x.Id == id && x.IsDeleted == "false").FirstOrDefault();
            if (Banner == null)
            {
                return RedirectToAction("Messages");
            }
            return View(Banner);
        }

        public string DeleteMessage()
        {

            var ItemID = Convert.ToInt32(Request.Form["ID"]);
            var currBanner = _context.ContactMessages.Where(x => x.Id == ItemID).FirstOrDefault();
            currBanner.IsDeleted = "true";
            _context.SaveChanges();
            return "Deleted";
        }

        #endregion
    }
}
