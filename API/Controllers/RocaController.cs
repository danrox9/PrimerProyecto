using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RocasController : ControllerBase
{
    private readonly ILogger<RocasController> _logger;
    private readonly IRocaService _rocaService;

    public RocasController(ILogger<RocasController> logger, IRocaService rocaService)
    {
        _logger = logger;
        _rocaService = rocaService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RocaDTO))]
    public ActionResult<RocaDTO> Get()
    {
        return Ok(_rocaService.GetAll());
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RocaDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RocaDTO> Get(int Id)
    {
        RocaDTO result = _rocaService.GetByID(Id);

        if (result == null)
            return NotFound();

        return Ok(result);

    }


    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RocaDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<RocaDTO> Delete(int Id)
    {
        RocaDTO result = _rocaService.GetByID(Id);

        if (result == null)
            return NotFound();

        _rocaService.Delete(Id);

        return Ok(result);

    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RocaDTO))]
    public ActionResult<RocaDTO> Post([FromBody] BaseRocaDTO baseRoca)
    {

        return Ok(_rocaService.Add(baseRoca));
    }

    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RocaDTO))]
    public ActionResult<RocaDTO> Put([FromBody] BaseRocaDTO baseRoca, int Id)
    {

        return Ok(_rocaService.Modify(baseRoca, Id));
    }

}
