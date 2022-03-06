using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PujasController : ControllerBase
{
    private readonly ILogger<PujasController> _logger;
    private readonly IPujaService _pujaService;

    public PujasController(ILogger<PujasController> logger, IPujaService pujaService)
    {
        _logger = logger;
        _pujaService = pujaService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    public ActionResult<PujaDTO> Get()
    {
        return Ok(_pujaService.GetAll());
    }

    [HttpGet("roca{IdPiedra}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    public ActionResult<PujaDTO> GetOfRoca(int IdPiedra)
    {
        return Ok(_pujaService.GetAllOf(IdPiedra));
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PujaDTO> Get(int Id)
    {
        PujaDTO result = _pujaService.GetByID(Id);

        if (result == null)
            return NotFound();

        return Ok(result);

    }


    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<PujaDTO> Delete(int Id)
    {
        PujaDTO result = _pujaService.GetByID(Id);

        if (result == null)
            return NotFound();

        _pujaService.Delete(Id);

        return Ok(result);

    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    public ActionResult<PujaDTO> Post([FromBody] BasePujaDTO basePuja)
    {

        return Ok(_pujaService.Add(basePuja));
    }

    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PujaDTO))]
    public ActionResult<PujaDTO> Put([FromBody] BasePujaDTO basePuja, int Id)
    {

        return Ok(_pujaService.Modify(basePuja, Id));
    }

}
