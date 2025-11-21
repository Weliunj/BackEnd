using BackEnd.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinecraftController : Controller
    {
        MinecraftContext _minecraftContext;
        public MinecraftController(MinecraftContext context)
        {
            _minecraftContext = context;
        }
        [HttpGet]       //Phương thức đọc dữ liệu
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var data = await _minecraftContext.Accounts.ToListAsync();    //await: tam dung viec thuc thi khi truy van hoan tat
                return Ok(data);    //Code 400
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
