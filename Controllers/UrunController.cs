using Microsoft.AspNetCore.Mvc;
using enoca.Data.Interfaces;
namespace enoca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrunController : ControllerBase
{
    public IUrunRepository _urunRepository;
    public UrunController(IUrunRepository urunRepository)
    {
        _urunRepository = urunRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _urunRepository.Get();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Urun urun)
    {
        var result = await _urunRepository.Post(urun);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Urun urun)
    {
        var result = await _urunRepository.Put(urun);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _urunRepository.Delete(id);
        return Ok(result);
    }
}