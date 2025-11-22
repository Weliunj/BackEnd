using BackEnd.Entity;
using BackEnd.Models;           //Truy Cap folder
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]     //attribute định nghĩa URL      /api/Minecraft
    [ApiController]     //Code sạch, an toàn
    public class MinecraftController : Controller
    {
        MinecraftContext _minecraftContext;     //Ket noi DATABASE
        public MinecraftController(MinecraftContext context)        //Khoi tao contructor
        {
            _minecraftContext = context;
        }

    /*======================================================*/
        //Phương thức đọc dữ liệu
        [HttpGet("Get")]       
        public async Task<IActionResult> GetAllAccounts()       //async: Hàm chạy bất đồng bộ
        {
            var re = new ResponseAPI();
            try
            {
                var data = await _minecraftContext.Accounts.ToListAsync();    //await: tam dung viec thuc thi khi truy van hoan tat

                re.message = "Lấy dữ liệu thành công";
                re.success = true;
                re.data = data;

                return Ok(re);    //Code 400
            }
            catch (Exception ex)
            {
                re.message = "Lấy dữ liệu không thành công";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re);
            }
        }
    /*====================================================================*/
        //Phương thức ghi dữ liệu
        [HttpPost("CreateAccount")] 
        public async Task<IActionResult> CreateAccount(string email, string password, string charname)
        {
            var re = new ResponseAPI();     //Debug
            try
            {
                //Add doi tuong
                Account account = new Account();
                account.Email = email;
                account.Password = password;
                account.CharName = charname;

                _minecraftContext.Add(account);     
                await _minecraftContext.SaveChangesAsync();     //INSERT

                re.message = "Tạo tài khoản thành công";
                re.success = true;
                re.data = account;

                return Ok(re); //code 200
            }
            catch (Exception ex)
            {
                re.message = "Tạo tài khoản thất bại";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re); //code 400
            }
        }
        [HttpPost("CreateMode")]
        public async Task<IActionResult> CreateMode(string Mname)
        {
            var re = new ResponseAPI();     //Debug
            try
            {
                Mode mode = new Mode();
                mode.MName = Mname;

                _minecraftContext.Add(mode);
                await _minecraftContext.SaveChangesAsync();

                re.message = "Tạo tài khoản thành công";
                re.success = true;
                re.data = mode;

                return Ok(re); //code 200
            }
            catch (Exception ex)
            {
                re.message = "Tạo tài khoản thất bại";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re); //code 400
            }
        }
    /*====================================================================*/
        //Phương thức cập nhật dữ liệu
        [HttpPut("UpdateAcc")] 
        public async Task<IActionResult> UpdateAccount(Account acc)
        {
            var re = new ResponseAPI();     //Debug
            try
            {
                var getAcc = await _minecraftContext.Accounts.FirstOrDefaultAsync(x => x.UId == acc.UId);
                if (getAcc != null)
                {
                    getAcc.Email = acc.Email;
                    getAcc.Password = acc.Password;
                    getAcc.CharName = acc.CharName;

                    await _minecraftContext.SaveChangesAsync();     //DATABASE

                    re.message = "Cập nhật tài khoản thành công";
                    re.success = true;
                    re.data = getAcc;
                    return Ok(re); //code 200
                }
                else
                {
                    re.message = "Không tìm thấy tài khoản có UID tương ứng";
                    re.success = false;
                    re.data = "Lỗi";
                    return Ok(re); //code 200
                }
            }
            catch (Exception ex)
            {
                re.message = "Cập nhật tài khoản thất bại";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re); //code 400
            }
        }
    /*====================================================================*/
        //Phương thức cập nhật dữ liệu, cập nhật 1 phần
        [HttpPatch("UpdateEmail")] 
        public async Task<IActionResult> UpdateEmail(int uid, string email)
        {
            var re = new ResponseAPI();     //Debug
            try
            {
                var getAcc = await _minecraftContext.Accounts.FirstOrDefaultAsync(x => x.UId == uid);
                if (getAcc != null)
                {
                    getAcc.Email = email;
                    await _minecraftContext.SaveChangesAsync();
                    re.message = "Cập nhật email tài khoản thành công";
                    re.success = true;
                    re.data = getAcc;
                    return Ok(re); //code 200
                }
                else
                {
                    re.message = "Không tìm thấy tài khoản";
                    re.success = false;
                    re.data = "Lỗi";
                    return Ok(re); //code 200
                }
            }
            catch (Exception ex)
            {
                re.message = "Cập nhật email tài khoản thất bại";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re); //code 400
            }
        }
    /*====================================================================*/
        //Phương thức xóa dữ liệu
        [HttpDelete("DeleteAcc")] 
        public async Task<IActionResult> DeleteAcc(int uid)
        {
            var re = new ResponseAPI();     //Debug
            try
            {
                var getAcc = await _minecraftContext.Accounts.FirstOrDefaultAsync(x => x.UId == uid);
                if (getAcc != null)
                {
                    _minecraftContext.Accounts.Remove(getAcc);
                    await _minecraftContext.SaveChangesAsync();
                    re.message = "Xóa tài khoản thành công";
                    re.success = true;
                    re.data = getAcc;
                    return Ok(re); //code 200
                }
                else
                {
                    re.message = "Không tìm thấy tài khoản cần xóa";
                    re.success = false;
                    re.data = "Lỗi";
                    return Ok(re); //code 200
                }
            }
            catch (Exception ex)
            {
                re.message = "Xóa tài khoản thất bại";
                re.success = false;
                re.data = ex.Message;

                return BadRequest(re); //code 400
            }
        }
    }
}
