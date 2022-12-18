using Microsoft.AspNetCore.Mvc;
using enoca.Data.Interfaces;
namespace enoca.Controllers;
[ApiController]
[Route("api/[controller]")]

public class FirmaController : ControllerBase
{
    public IFirmaRepository _firmaRepository;
    public FirmaController(IFirmaRepository firmaRepository)
    {
        _firmaRepository = firmaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _firmaRepository.Get();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Firma firma)
    {
        var result = await _firmaRepository.Post(firma);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Firma firma)
    {
        var result = await _firmaRepository.Put(firma);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _firmaRepository.Delete(id);
        return Ok(result);
    }
}
