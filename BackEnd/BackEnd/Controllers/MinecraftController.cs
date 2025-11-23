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
        ResponseAPI re;
        public MinecraftController(MinecraftContext context)        //Khoi tao contructor
        {
            _minecraftContext = context;
            re = new ResponseAPI();
        }

        //Phương thức đọc dữ liệu
        [HttpGet("GetAcc")]       
        public async Task<IActionResult> GetAllAccounts()       //async: Hàm chạy bất đồng bộ
        {
            try
            {
                var data = await _minecraftContext.Items.ToListAsync();    //await: tam dung viec thuc thi khi truy van hoan tat

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

        //Phương thức ghi dữ liệu
        [HttpPost("CreateAccount")] 
        public async Task<IActionResult> CreateAccount(string email, string password, string charname)
        {
            try
            {
                //Add doi tuong
                Account account = new Account();
                account.Email = email;
                account.Password = password;
                account.CharName = charname;

                _minecraftContext.Accounts.Add(account);     
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

        //Phương thức cập nhật dữ liệu
        [HttpPut("UpdateAcc")] 
        public async Task<IActionResult> UpdateAccount(Account acc)
        {
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

        //Phương thức cập nhật dữ liệu, cập nhật 1 phần
        [HttpPatch("UpdateEmail")] 
        public async Task<IActionResult> UpdateEmail(int uid, string email)
        {
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

        //Phương thức xóa dữ liệu
        [HttpDelete("DeleteAcc")] 
        public async Task<IActionResult> DeleteAcc(int uid)
        {
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


        [HttpGet("All resources")]        //1. Lấy thông tin tất cả các loại tài nguyên trong game 
        public async Task<IActionResult> GetAllResources()
        {
            try
            {
                var data = await _minecraftContext.Resources.ToListAsync();

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

            [HttpGet("All player.mode")]        //2. Lấy thông tin tất cả người chơi theo từng chế độ chơi (thông tin chế độ chơi sẽ do người dùng truyền lên API, ví dụ: 'Sinh tồn') 
            public async Task<IActionResult> GetPlayers(string ModeName)
            {
                var re = new ResponseAPI();
                try
                {
                    var modename = await _minecraftContext.Modes.FirstOrDefaultAsync(m => m.MName.Contains(ModeName));
                    if (modename == null)
                    {
                    re.message = "Loi";
                    re.success = false;
                    re.data = null;

                    return NotFound(re);
                }
                var data = await _minecraftContext.Plays.Where(n => n.MId == modename.MId).Select(n => new {n.PId, n.UId, n.MId, n.WorldName, n.Time, n.Exp, n.Health, n.Hunger}).ToListAsync();
                if(data == null) { return NotFound(re); }
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

        [HttpGet("Item.exp")]        //3. Lấy tất cả các vũ khí có giá trị trên 100 điểm kinh nghiệm
        public async Task<IActionResult> GetWeapsons()
        {
            try
            {
                var wp = await _minecraftContext.Items.Where(k => k.IKind == 1 && k.IPrice > 100).ToListAsync();

                re.message = "Lấy dữ liệu thành công";
                re.success = true;
                re.data = wp;
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

        [HttpGet("Item.Player")]        //4. Lấy thông tin các item mà người chơi có thể mua với số điểm kinh nghiệm tích lũy hiện tại của họ. 
        public async Task<IActionResult> GetItem(int Playerid)
        {
            try
            {
                var player = await _minecraftContext.Plays.FirstOrDefaultAsync(p => p.PId == Playerid);
                if (player == null)
                {
                    return BadRequest("khong tim thay id:" + Playerid);    //Code 400
                }
                var items = await _minecraftContext.Items.Where(i => player.Exp >= i.IPrice).ToListAsync();
                if (items.Count() == 0)
                {
                    return Ok("khong co du lieu");    //Code 400
                }
                re.message = "Lấy dữ liệu thành công";
                re.success = true;
                re.data = items;
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

        [HttpGet("Item.name")]        //5. Lấy thông tin các item có tên chứa từ 'kim cương' và có giá trị dưới 500 điểm kinh nghiệm 
        public async Task<IActionResult> GetItemKc()
        {
            try
            {
                var items = await _minecraftContext.Items.Where(i => i.IName.Contains("Kimcuong") && i.IPrice < 500).ToListAsync();
                re.message = "Lấy dữ liệu thành công";
                re.success = true;
                re.data = items;
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

        [HttpGet("Trans.Play")]        //6. Lấy thông tin tất cả các giao dịch mua item và phương tiện của một người chơi cụ thể,
                                        //  sắp xếp theo thứ tự thời gian (thông tin người chơi cần lấy giao dịch sẽ cho người dùng truyền lên API) 
        public async Task<IActionResult> GetTransa(int Playerid)
        {
            try
            {
                var data = await _minecraftContext.Ptransactions.Where(t => t.PId == Playerid).ToListAsync();
                if(data == null) { return NotFound(re); }
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

        [HttpPost("Add item")]        //7. Thêm thông tin của một item mới
        public async Task<IActionResult> AddItem(string Name ,string? Img, int? Price, int? Kind)
        {
            try
            {
                Item item = new Item();
                item.IName = Name;
                item.IImg = Img;
                item.IPrice = Price;
                item.IKind = Kind;

                _minecraftContext.Add(item);
                await _minecraftContext.SaveChangesAsync();

                re.message = "Them du liệu thành công";
                re.success = true;
                re.data = item;
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

        [HttpPatch("Update pass")]        //8. Cập nhật mật khẩu của người chơi 
        public async Task<IActionResult> updatePass(int UId, string NewPassword)
        {
            try
            {
                var data = await _minecraftContext.Accounts.FirstOrDefaultAsync(a => a.UId == UId);
                if(data == null)
                {
                    re.message = "Khong thay Player id " + UId;
                    re.success = false;
                    return NotFound(re);
                }
                data.Password = NewPassword;
                await _minecraftContext.SaveChangesAsync();     //Save DB

                re.message = "Them du liệu thành công";
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

        [HttpGet("Item.Trans")]        //9. Lấy danh sách các item được mua nhiều nhất 
        public async Task<IActionResult> GetItemtMost()
        {
            try
            {
                var key = await _minecraftContext.Ptransactions.Where(s => s.Status == true).GroupBy(t => t.IId).Select(t=> new { iid=t.Key , quan = t.Count()}).OrderByDescending(i => i.quan).FirstOrDefaultAsync();
                if (key == null)
                {
                    re.message = "No data";
                    re.success = false;
                    return NotFound(re);
                }
                var data = await _minecraftContext.Items.Where(i => i.IId == key.iid).Select(i => new { i.IId, i.IName, i.IImg, i.IPrice, i.IKind, Soluong = key.quan }).FirstOrDefaultAsync();
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

        [HttpGet("Play.Trans")]        //10. Lấy danh sách tất cả người chơi và số lần họ đã mua hàng
        public async Task<IActionResult> GetPlayer()
        {
            try
            {
                var data = await _minecraftContext.Ptransactions.Where(s => s.Status == true).GroupBy(p => p.PId).Select(n => new { pid = n.Key, solanmuahang = n.Count() }).
                    Join(_minecraftContext.Plays, s => s.pid, p => p.PId, (s, p) => new { p, s.solanmuahang}).ToListAsync();
                if(data == null)
                {
                    re.message = "Lấy dữ liệu không thành công";
                    re.success = false;
                    re.data = null;
                    return NotFound(re);
                }
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
    }
}