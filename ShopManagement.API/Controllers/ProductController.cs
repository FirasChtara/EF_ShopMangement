using Microsoft.AspNetCore.Mvc;
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
                //var BigProduit = await context.PromotionProducts.Where(p=>p.Product.OrderProducts
                //                .Any(op=>op.Order.CreationDate>=p.FromDate && op.CreationDate<=p.ToDate))
                //                    .Select(x=> new {x.Promotion,x.}).ToListAsync();

                var BigProduit = await  context.Promotions.OrderByDescending(p=>p.PromotionProducts
                                        .Count(pp=>pp.Product.OrderProducts.
                                        Any(op=>op.Order.CreationDate >= pp.FromDate && op.CreationDate <= pp.ToDate))).ToListAsync();
                return BigProduit.FirstOrDefault();
            }
        }
    }
}
