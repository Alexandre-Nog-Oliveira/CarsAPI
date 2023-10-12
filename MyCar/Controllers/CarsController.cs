using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System.Threading.Tasks;

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CarsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            return Ok( await _appDbContext.Cars.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreatedCar(Car car)
        {
            await _appDbContext.AddAsync(car);
            await _appDbContext.SaveChangesAsync();
            return Ok(car);
            
        }
    }
}
