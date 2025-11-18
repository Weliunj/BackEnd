using BackEnd.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]     //Route: duong dan(link)
    [ApiController]
    public class gam106Controller : Controller
    {
        Gam106Context _gam106Context; //Ket noi csdl
        public gam106Controller(Gam106Context gam106Context)    //Constructor
        {
            _gam106Context = gam106Context;
        }
        [HttpGet] //Phuong thuc doc du lieu
        public async Task<IActionResult> GetAllAccount()        //async: Tao 1 thread moi , chay duoc lap
        {
            try //Chua code
            {
                var data = await _gam106Context.Accounts.ToListAsync();    //await: tam dung viec thuc thi khi truy van hoan tat
                return Ok(data);    //Code 400
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);      //Code 400
            }
        }
    }
}
