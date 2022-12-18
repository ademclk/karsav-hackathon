using Microsoft.AspNetCore.Mvc;
using enoca.Data.Interfaces;
namespace enoca.Controllers;
[ApiController]
[Route("api/[controller]")]

public class SiparisController : ControllerBase
{
    public ISiparisRepository _siparisRepository;
    public SiparisController(ISiparisRepository siparisRepository)
    {
        _siparisRepository = siparisRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _siparisRepository.Get();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Siparis siparis)
    {
        try
        {
            var result = await _siparisRepository.Post(siparis);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(Siparis siparis)
    {
        var result = await _siparisRepository.Put(siparis);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _siparisRepository.Delete(id);
        return Ok(result);
    }
}