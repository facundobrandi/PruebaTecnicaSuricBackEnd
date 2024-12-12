using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaConfig.Utils;

[ApiController]
[Route("api/[controller]")]
public class ArticuloController : ControllerBase
{
    private readonly PruebaTecnicaConfig.Models.PruebaTecnicaSurisContext _context;
    private PruebaTecnicaArticulos.Managers.ArticuloManager articuloManager;

    public ArticuloController(PruebaTecnicaConfig.Models.PruebaTecnicaSurisContext context)
    {
        _context = context;
        articuloManager = new PruebaTecnicaArticulos.Managers.ArticuloManager(_context);
    }

    [HttpGet]
    public async Task<IActionResult> GetArticulos()
    {
        var response = await articuloManager.GetArticulos();
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> PostPedidos(int[] pedidosIds , string name)
    {
        var response = await articuloManager.PostPedidos(pedidosIds,name);
        if (response.code.Equals(SystemEnums.CodesResponce.Error))
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}