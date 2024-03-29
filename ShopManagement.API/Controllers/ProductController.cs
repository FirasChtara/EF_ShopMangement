﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopManagement.API.Models;


namespace ShopManagement.API.Controllers;

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
                                .Any(x => x.PaymentCustomers == null || x.PaymentCustomers.Count <= 0)).ToListAsync();

            return result;
        }
    }



    // Todo : Get Order who is payed in many times
    [HttpGet("/GetOrderPayedInManyTimes")]
    public async Task<IEnumerable<Order>> GetOrderPayedInManyTimes()
    {
        using (var context = new ShopEFContext())
        {
            var result = await context.Orders.Where(p => p.PaymentCustomers.Count >=2).ToListAsync();

            return result;
        }
    }

    // Todo : Get Max Order who is payed in many times
    [HttpGet("/GetMaxOrderPayedInManyTimes")]
    public Order GetMaxOrderPayedInManyTimes()
    {
        using (var context = new ShopEFContext())
        {
            var result = context.Orders.OrderByDescending(p => p.PaymentCustomers.Count).FirstOrDefault();

            return result;
        }
    }

    // Todo : Get Order Ordred by Acending Max Payed Amout 
    [HttpGet("/GetOrderOrdredbyMaxPayedAmout")]
    public async Task<IEnumerable<Order>> GetOrderOrdredbyMaxPayedAmout()
    {
        using (var context = new ShopEFContext())
        {
            var result = await context.Orders.OrderBy(p => p.PaymentCustomers
                                        .Sum(pc=>pc.SettlementAmount)).ToListAsync();

            return result;
        }
    }

    // Todo : Get Order with rimining seltement Amount
    [HttpGet("/GetOrderWithRiminingSeltementAmount")]
    public async Task<IEnumerable<Order>> GetOrderWithRiminingSeltementAmount()
    {
        using (var context = new ShopEFContext())
        {
            var result = await context.Orders.Where(o=>o.OrderProducts.
                                Sum(op=>op.Price*op.Quantity)>o.PaymentCustomers.Sum(pc=>pc.SettlementAmount)).ToListAsync();

            return result;
        }
        // TDOO : Update this Method
    }

    [HttpGet("/GetOrderWithRiminingSeltementAmount2")]
    public async Task<IEnumerable<Order>> GetOrderWithRiminingSeltementAmount2()
    {
        using (var context = new ShopEFContext())
        {
            var result = await context.Orders.Where(o => o.OrderProducts.
                                Sum(op => op.Price * op.Quantity) > o.PaymentCustomers.Sum(pc => pc.SettlementAmount)).ToListAsync();

            return result;
        }

        // Todo : Get Order with rimining seltement Amount
        [HttpGet("/GetOrderWithRiminingSeltementAmount")]
        public async Task<IEnumerable<Order>> GetOrderWithRiminingSeltement()
        {
            using (var context = new ShopEFContext())
            {
                IEnumerable<Order> order;
                order = await context.Orders.Where(o => o.OrderProducts.
                                    Sum(op => op.Price * op.Quantity) > o.PaymentCustomers.Sum(pc => pc.SettlementAmount)).ToListAsync();

                return order;
            }
        }
    }
}
