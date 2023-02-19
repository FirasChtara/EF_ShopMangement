﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopManagement.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // TODO : Get best promotion 
        [HttpGet("/GetBestPromotion")]
        public async Task<Promotion> GetCustomerMaxBuying()
        {
            using (var context = new ShopEFContext())
            {

                var BigProduit = context.Promotions.OrderByDescending(p => p.PromotionProducts
                                        .Max(pp => pp.Product.OrderProducts.Sum(o => o.Quantity))).Take(1);
                //.Any(op=>op.Order.CreationDate >= pp.FromDate && op.CreationDate <= pp.ToDate))).ToListAsync();

                return BigProduit.FirstOrDefault();
            }
        }


        // Todo : Get Categories Ordred by Nbr of Product related
        [HttpGet("/GetCategoryOrdred")]
        public async Task<IEnumerable<Caregory>> GetCategoryOrdred()
        {
            using (var context = new ShopEFContext())
            {

                var result = await context.Caregories.OrderByDescending(c => c.Products.Count()).ToListAsync();

                return result;
            }
        }



        // Todo : Get Max Price Product Bought
        [HttpGet("/GetMaxPriceProductBought")]
        public Product GetMaxPriceProductBought()
        {
            using (var context = new ShopEFContext())
            {

                var result = context.Products.Where(p => p.OrderProducts.Count > 0).MaxBy(pp => pp.Price);

                return result;
            }
        }


        // Todo : Get Custmer without payment
        [HttpGet("/GetCustmerWithoutPayment")]
        public async Task<IEnumerable<Customer>> GetCustmerWithoutPayment()
        {
            using (var context = new ShopEFContext())
            {

                var result = await context.Customers.Where(c => c.Orders
                                    .Any(x => x.PaymentCustomers == null || x.PaymentCustomers.Count <= 0 )).ToListAsync();

                return result;
            }
        }

    }
}
