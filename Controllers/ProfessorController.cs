using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscola_API.Data;
using ProjetoEscola_API.Models;

namespace ProjetoEscola_API.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class ProfessorController : Controller {
    public IRepository _repo { get; }
    public ProfessorController (IRepository repo) {
      _repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> Get () {
      try
      {
        var result = await _repo.GetAllProfessoresAsync(true);
        return Ok (result);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }

    [HttpGet ("{ProfessorId}")]
    public async Task<IActionResult> GetByProfessorId(int ProfessorId) {
      try
      {
        var result = await _repo.GetProfessorAsyncById(ProfessorId, true);
        return Ok (result);
      }
      catch (System.Exception)
      {
        return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Professor model) {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangesAsync ())
        {
          return Created($"/api/Professor/{model.Id}", model);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }

    [HttpPut ("{ProfessorId}")]
    public async Task<IActionResult> Put(int ProfessorId, Professor model) {
      try
      {
        var Professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
        if(Professor == null) return NotFound();

        _repo.Update(model);

        if(await _repo.SaveChangesAsync())
        {
          Professor = await _repo.GetProfessorAsyncById(ProfessorId, true);
          return Created($"/api/Professor/{model.Id}", Professor);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }

    [HttpDelete ("{ProfessorId}")]
    public async Task<IActionResult> delete (int ProfessorId) {
      try
      {
        var Professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
        if(Professor == null) return NotFound();

        _repo.Delete(Professor);

        if(await _repo.SaveChangesAsync())
        {
          return Ok();
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode (StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
      }
      return BadRequest();
    }
  }
}