using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Remedies.DataAccess.Repository.IRepository;
using Remedies.Models;
using Remedies.Models.ViewModels;
using Remedies.Utility;

namespace HomeRemedies.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,RemedyType");

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitOfWork.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count();
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
            }
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var ProductFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,RemedyType");
            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = ProductFromDb,
                ProductId = ProductFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart Cartobject)
        {
            Cartobject.Id = 0;
            if (ModelState.IsValid)
            {
                //then we add add to cart
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                Cartobject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == Cartobject.ApplicationUserId && u.ProductId == Cartobject.ProductId
                    , includeProperties: "Product"
                    );

                if (cartFromDb == null)
                {
                    //No records exists in database for that prduct for that user 
                    _unitOfWork.ShoppingCart.Add(Cartobject);
                }
                else
                {
                    cartFromDb.Count += Cartobject.Count;
                    _unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == Cartobject.ApplicationUserId)
                    .ToList().Count();
                //HttpContext.Session.SetObject(SD.ssShoppingCart, Cartobject); for cartlist
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
                //var obj = HttpContext.Session.GetObject<ShoppingCart>(SD.ssShoppingCart);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var ProductFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == Cartobject.ProductId, includeProperties: "Category,RemedyType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = ProductFromDb,
                    ProductId = ProductFromDb.Id
                };
                return View(cartObj);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
